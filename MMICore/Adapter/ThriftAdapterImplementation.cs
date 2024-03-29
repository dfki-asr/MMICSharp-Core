﻿// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Felix Gaisbauer

using System;
using System.Collections.Generic;
using MMIStandard;
using System.Linq;
using CSharpAdapter;
using MMICSharp.Common;
using System.Diagnostics;

namespace MMICSharp.Adapter
{
    /// <summary>
    /// Implementation of the thrift adapter functionality
    /// </summary>
    [Serializable]
    public class ThriftAdapterImplementation : MMIAdapter.Iface
    {

        /// <summary>
        /// The assigned mmuInstantiator
        /// </summary>
        private readonly IMMUInstantiation mmuInstantiator;


        /// <summary>
        /// The assigned session data
        /// </summary>
        protected readonly SessionData SessionData;


        /// <summary>
        /// Basic constructor
        /// </summary>
        public ThriftAdapterImplementation(SessionData sessionData, IMMUInstantiation mmuInstantiator)
        {
            this.SessionData = sessionData;
            this.mmuInstantiator = mmuInstantiator;
        }

        #region Adapter specific features

        /// <summary>
        /// Working
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> GetStatus()
        {
            Dictionary<string, string> status = new Dictionary<string, string>();

            try
            {
                status = new Dictionary<string, string>
                {
                    { "Running since", SessionData.StartTime.ToLongDateString() + " " + SessionData.StartTime.ToLongTimeString() },
                    { "Total Sessions", SessionData.SessionContents.Count.ToString() },
                    { "Loadable MMUs", SessionData.MMUDescriptions.Count.ToString() }
                };


                try
                {
                    status.Add("Version", System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString());

                }
                catch (Exception)
                {
                
                }
                if (SessionData.LastAccess == DateTime.MinValue)
                    status.Add("Last Access", "None");

                else
                    status.Add("Last Access", SessionData.LastAccess.ToLongDateString() + " " + SessionData.LastAccess.ToLongTimeString());
            }
            catch (Exception e)
            {
                status.Add("Exception", e.Message);
            }

            MMICSharp.Logger.LogDebug("Status request finished");

            return status;
        }


        /// <summary>
        /// Returns all available MMUs
        /// </summary>
        /// <returns></returns>
        public virtual List<MMUDescription> GetLoadableMMUs()
        {
            MMICSharp.Logger.LogDebug("Get Loadable MMUs requested");
            return SessionData.MMUDescriptions;
        }


        /// <summary>
        /// Returns the scene contained within the adapter
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public virtual List<MSceneObject> GetScene(string sessionID)
        {
            SessionContent sessionContent = null;

            MBoolResponse sessionResult = SessionData.GetSessionContent(sessionID, out sessionContent);

            if (sessionResult.Successful)
            {
                //Set the last access time
                sessionContent.UpdateLastAccessTime();

                Logger.Log(Log_level.L_INFO, "Transfer all scene objects");

                return sessionContent.SceneBuffer.GetSceneObjects();
            }

            else
            {
                Debug.Fail(sessionResult.LogData.ToString());
            }

            return new List<MSceneObject>();
        }


        /// <summary>
        /// Returns the deltas of the last frame
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public virtual MSceneUpdate GetSceneChanges(string sessionID)
        {
            SessionContent sessionContent = null;

            MBoolResponse sessionResult = SessionData.GetSessionContent(sessionID, out sessionContent);

            if (sessionResult.Successful)
            {
                //Set the last access time
                sessionContent.UpdateLastAccessTime();

                return sessionContent.SceneBuffer.GetSceneChanges();
            }

            else
            {
                Logger.Log(Log_level.L_ERROR, sessionResult.LogData.ToString());
            }

            return new MSceneUpdate();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mmus"></param>
        /// <param name="sessionID"></param>
        /// <returns>A mapping from MMUID to a specific instance id</returns>
        public virtual Dictionary<string,string> LoadMMUs(List<string> mmus, string sessionID)
        {
            SessionContent sessionContent = null;
            SessionID idContainer = new SessionID(sessionID);

            //Get the session content for the id
            MBoolResponse sessionResult = SessionData.GetSessionContent(sessionID, out sessionContent);

            //Skip if invalid session result
            if (!sessionResult.Successful)
            {
                Logger.Log(Log_level.L_ERROR, "Cannot generate session content");
                return new Dictionary<string, string>();
            }

            //Set the last access time
            sessionContent.UpdateLastAccessTime();

            Dictionary<string, string> mmuInstanceMapping = new Dictionary<string, string>();

            //Iterate over each desired MMU
            foreach (string mmuID in mmus)
            {
                MMULoadingProperty mmuLoadingProperty = null;

                //Skip MMU is not contained in adapter
                if (!SessionData.MMULoadingProperties.TryGetValue(mmuID, out mmuLoadingProperty))
                    continue;

                IMotionModelUnitDev mmu = null;

                //Instantiate MMU 
                try
                {
                    mmu = this.mmuInstantiator.InstantiateMMU(mmuLoadingProperty);
                }
                catch (Exception e)
                {
                    Logger.Log(Log_level.L_ERROR, $"Problem at loading MMU {mmuLoadingProperty.Description.Name}, Exception: {e.Message}, {e.StackTrace}");

                    return new Dictionary<string, string>();
                }


                //Create and assign the service access
                mmu.ServiceAccess = new ServiceAccess(SessionData.MMIRegisterAddress, sessionID);
                ((ServiceAccess)mmu.ServiceAccess).Initialize();

                //Assign the scene
                mmu.SceneAccess = sessionContent.SceneBuffer;

                //Set the instance as the adapter
                mmu.AdapterEndpoint = new AdapterEndpoint()
                {
                    Instance = SessionData.AdapterInstance,
                    Description = SessionData.AdapterDescription,
                    MMIRegisterAddress = SessionData.MMIRegisterAddress
                };


                Logger.Log(Log_level.L_INFO, $"Loaded MMU: {mmuLoadingProperty.Description.Name} for session: {sessionID}");

                //Add to the specific avatar content
                AvatarContent avatarContent = null;

                if (!sessionContent.AvatarContent.TryGetValue(idContainer.AvatarID, out avatarContent))
                {
                    avatarContent = new AvatarContent(idContainer.AvatarID);

                    sessionContent.AvatarContent.TryAdd(idContainer.AvatarID, avatarContent);
                }

                //Add the mmu
                avatarContent.MMUs.Add(mmuLoadingProperty.Description.ID, mmu);

                //To do -> create a unique instance ID
                mmuInstanceMapping.Add(mmuLoadingProperty.Description.ID, "tbd");
            }

            return mmuInstanceMapping;
        }


        /// <summary>
        /// Should work
        /// </summary>
        /// <param name="sceneManipulations"></param>
        /// <param name="sessionID"></param>
        public virtual MBoolResponse PushScene(MSceneUpdate sceneUpdates, string sessionID)
        {
            SessionContent sessionContent = null;

            //Get the session content for the id
            MBoolResponse sessionResult = SessionData.GetSessionContent(sessionID, out sessionContent);

            //Skip if invalid session result
            if (!sessionResult.Successful)
            {
                Debug.Fail(sessionResult.LogData.ToString());
                return sessionResult;
            }


            //Set the last access time
            sessionContent.UpdateLastAccessTime();

            //Synchronize the respective scene
            return sessionContent.SceneBuffer.Apply(sceneUpdates);

        }


        /// <summary>
        /// Creates a new session for the specified id
        /// </summary>
        /// <param name="sessionID"></param>
        public virtual MBoolResponse CreateSession(string sessionID)
        {
            // Todo: implement proper scene buffering
            //Skip if the sessionID is invalid
            if (sessionID == null || sessionID.Count() == 0)
                return new MBoolResponse(false)
                {
                    LogData = new List<string>() { "Session ID invalid" }
                };

            //Skip if sessionID already available
            if (SessionData.SessionIDAvailable(sessionID))
                return new MBoolResponse(false)
                {
                    LogData = new List<string>() { "Session ID already available" }
                };

            //Create a new session content using the specified id
            SessionContent sessionContent = SessionData.CreateSessionContent(sessionID);

            //Set the last access time
            sessionContent.UpdateLastAccessTime();

            return new MBoolResponse(true);
        }


        /// <summary>
        /// Clsoes the session
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public virtual MBoolResponse CloseSession(string sessionID)
        {
            Logger.Log(Log_level.L_INFO, $"Closing the session: {sessionID}");
            return SessionData.RemoveSessionContent(sessionID);
        }



        #endregion

        #region MMU functionality

        /// <summary>
        /// Basic initialization of a MMMU
        /// </summary>
        /// <param name="mmuID"></param>
        /// <param name="sessionID"></param>
        public virtual MBoolResponse Initialize(MAvatarDescription avatarDescription, Dictionary<string, string> properties, string mmuID, string sessionID)
        {
            //Get the session result
            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out SessionContent sessionContent, out AvatarContent avatarContent);

            //Skip if invalid session result
            if (!sessionResult.Successful)
                return sessionResult;

            try
            {
                //Get the corresponding MMU
                IMotionModelUnitDev mmu = avatarContent.MMUs[mmuID];

                //Setup the skeleton access
                mmu.SkeletonAccess = new IntermediateSkeleton();
                ((IntermediateSkeleton)mmu.SkeletonAccess).InitializeAnthropometry(avatarDescription);

                //Update the access time
                sessionContent.UpdateLastAccessTime();


                //Logger.Log(Log_level.L_INFO, "MMU initialized: " + mmu.Name + " " + sessionID);

                var cDesc = avatarDescription.Clone();
                //Call the respective MMU
                return mmu.Initialize(cDesc, properties);
            }
            catch (Exception e)
            {
                Logger.Log(Log_level.L_ERROR, $"Problem at initializing MMU: {mmuID}, message: {e.Message}");

                return new MBoolResponse(false)
                {
                    LogData = new List<string>()
                     {
                         e.Message,
                         e.StackTrace,
                         e.InnerException.ToString(),
                         e.StackTrace
                     }
                };

            }
        }


        /// <summary>
        /// Execute command of a MMU
        /// </summary>
        /// <param name="instruction"></param>
        /// <param name="simulationState"></param>
        /// <param name="hierarchy"></param>
        /// <param name="mmuID"></param>
        /// <param name="sessionID"></param>
        public virtual MBoolResponse AssignInstruction(MInstruction instruction, MSimulationState simulationState, string mmuID, string sessionID)
        {
            var watch = new System.Diagnostics.Stopwatch();
            float t_getContent; float t_UpdateAccess; float t_AssignInstr;
            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);
            t_getContent = watch.ElapsedMilliseconds;
            //Directly return if not successfull
            if (!sessionResult.Successful)
                return sessionResult;

            sessionContent.UpdateLastAccessTime();
            t_UpdateAccess = watch.ElapsedMilliseconds - (t_getContent);

            Logger.Log(Log_level.L_DEBUG, $"ThriftAdapterImplementation.AssignInstruction: Execute instruction {instruction.Name}:{instruction.ID} on {mmuID}");

            var ret = avatarContent.MMUs[mmuID].AssignInstruction(instruction.Clone(), simulationState.Clone());
            t_AssignInstr = watch.ElapsedMilliseconds - (t_getContent + t_UpdateAccess);
            //Logger.Log(Log_level.L_DEBUG, $"ThriftAdapterImplementation.AssignInstruction: t_getContent {t_getContent}ms, t_UpdateAccess {t_UpdateAccess}ms, t_AssignInstr {t_AssignInstr}ms");
            watch.Stop();
            //Directly assign the instruction
            return ret;
        }


        /// <summary>
        /// Basic do step routine which triggers the simulation update of the repsective MMU
        /// </summary>
        /// <param name="time"></param>
        /// <param name="simulationState"></param>
        /// <param name="mmuID"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public virtual MSimulationResult DoStep(double time, MSimulationState simulationState, string mmuID, string sessionID)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Restart();
            float t_getContent; float t_UpdateAccess; float t_AssignInstr;

            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);
            t_getContent = watch.ElapsedMilliseconds;

            //Skip if invalid session result
            if (!sessionResult.Successful)
                return null;

            sessionContent.UpdateLastAccessTime();
            t_UpdateAccess = watch.ElapsedMilliseconds - (t_getContent);
            var ret = avatarContent.MMUs[mmuID].DoStep(time, simulationState.Clone());
            t_AssignInstr = watch.ElapsedMilliseconds - (t_getContent + t_UpdateAccess);
            //Logger.Log(Log_level.L_DEBUG, $"ThriftAdapterImplementation.DoStep:  {mmuID} t_getContent {t_getContent}ms, t_UpdateAccess {t_UpdateAccess}ms, t_doStep {t_AssignInstr}ms");
            watch.Stop();
            //Execute the do step of the respective MMU
            return ret;
        }


        public virtual MBoolResponse CheckPrerequisites(MInstruction instruction, string mmuID, string sessionID)
        {
            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);

            if (!sessionResult.Successful)
                return sessionResult;


            sessionContent.UpdateLastAccessTime();

            //Execute the method of the MMU
            return avatarContent.MMUs[mmuID].CheckPrerequisites(instruction);
        }


        public virtual MBoolResponse Abort(string instructionId, string mmuID, string sessionID)
        {
            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);

            if (!sessionResult.Successful)
                return sessionResult;

            sessionContent.UpdateLastAccessTime();

            //Abort the respective MMU
            return avatarContent.MMUs[mmuID].Abort(instructionId);
        }


        public virtual MMUDescription GetDescription(string mmuID, string sessionID)
        {
            return SessionData.MMUDescriptions.Find(s => s.Name == mmuID);
        }


        public virtual List<MConstraint> GetBoundaryConstraints(MInstruction instruction, string mmuID, string sessionID)
        {
            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);

            if (!sessionResult.Successful)
                return new List<MConstraint>();

            sessionContent.UpdateLastAccessTime();

            return avatarContent.MMUs[mmuID].GetBoundaryConstraints(instruction);
        }

        public virtual MBoolResponse Dispose(string mmuID, string sessionID, string avatarID)
        {
            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);

            if (!sessionResult.Successful)
                return sessionResult;

            sessionContent.UpdateLastAccessTime();

            //Call the dispose method of the respective MMU
            return avatarContent.MMUs[mmuID].Dispose(avatarID, new Dictionary<string, string>());
        }

        public virtual List<MMUDescription> GetMMus(string sessionID)
        {
            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);

            if (!sessionResult.Successful)
                return new List<MMUDescription>();

            sessionContent.UpdateLastAccessTime();

            return SessionData.MMUDescriptions.Where(s => avatarContent.MMUs.Keys.Contains(s.ID)).ToList();
        }


        /// <summary>
        /// Creates a checkpoint for all specified MMUs.
        /// The checkpoint contains the internal state of each MMU whoch can be later used to restore the state.
        /// </summary>
        /// <param name="mmuIDs"></param>
        /// <param name="sessionID"></param>
        /// <param name="checkpointID"></param>
        public virtual byte[] CreateCheckpoint(string mmuID, string sessionID, string avatarID)
        {
            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);

            if (!sessionResult.Successful)
                return null;

            sessionContent.UpdateLastAccessTime();
            
            //Add method to interface
            byte[] checkpointData = avatarContent.MMUs[mmuID].CreateCheckpoint(avatarID);

            Logger.Log(Log_level.L_INFO, $"Checkpoint of {mmuID} sucessfully created ({checkpointData.Length} bytes)");

            return checkpointData;
        }

        public virtual MBoolResponse RestoreCheckpoint(string mmuID, string sessionID, byte[] checkpointData, string avatarID)
        {
            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);

            if (!sessionResult.Successful)
                return sessionResult;

            sessionContent.UpdateLastAccessTime();
            if(avatarID == "")
            {
                avatarID = avatarContent.AvatarId;
            }

            Logger.Log(Log_level.L_INFO, $"Restore checkpoint of {mmuID}");

            return avatarContent.MMUs[mmuID].RestoreCheckpoint(checkpointData, avatarID);
        }

        public Dictionary<string, string> ExecuteFunction(string name, Dictionary<string, string> parameters, string mmuID, string sessionID, string avatarID)
        {
            SessionContent sessionContent = null;
            AvatarContent avatarContent = null;

            MBoolResponse sessionResult = SessionData.GetContents(sessionID, out sessionContent, out avatarContent);

            if (!sessionResult.Successful)
                return null;

            sessionContent.UpdateLastAccessTime();


            Logger.Log(Log_level.L_DEBUG, $"Ecexute function {name} of {mmuID}");

            return avatarContent.MMUs[mmuID].ExecuteFunction(name, avatarID, parameters);

        }

        /// <summary>
        /// Returns the assigned adapter description
        /// </summary>
        /// <returns></returns>
        public virtual MAdapterDescription GetAdapterDescription()
        {
            return SessionData.AdapterDescription;
        }








        #endregion
    }
}

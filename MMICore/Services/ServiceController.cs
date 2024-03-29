﻿// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Felix Gaisbauer

using MMICSharp.Common;
using MMIStandard;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using System.Collections.Generic;

namespace MMICSharp.Services
{
    /// <summary>
    /// Basic class which provides a service controller that manages a server as well as the automatic registration at the register. 
    /// </summary>
    public class ServiceController
    {
        /// <summary>
        /// Flag which indicates whether the service controller has been started
        /// </summary>
        public bool Started
        {
            get;
            private set;
        } = false;


        #region private fields


        /// <summary>
        /// Instance of the utilized server to communicate with the MMI framework
        /// </summary>
        private ThriftServerBase thriftServer;


        /// <summary>
        /// The address of the thrift server
        /// </summary>
        private readonly MIPAddress address;


        /// <summary>
        /// The address of the register
        /// </summary>
        private readonly MIPAddress mmiRegisterAddress;


        /// <summary>
        /// The description of the service
        /// </summary>
        private readonly MServiceDescription serviceDescription;

        private MIPAddress internalAddress = null;

        /// <summary>
        /// The instance of the adapter implementation
        /// </summary>
        private readonly TProcessor processor;


        /// <summary>
        /// The utilized registration handler (manages the registration of the service at the central register)
        /// </summary>
        private ServiceRegistrationHandler registrationHandler;

        #endregion


        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="description">The service description</param>
        /// <param name="mmiRegisterAddress">The address of the mmi register</param>
        /// <param name="processor">The assigned processor of the service controller</param>
        public ServiceController(MServiceDescription description, MIPAddress mmiRegisterAddress, TProcessor processor, MIPAddress internalAddress = null)
        {
            //Assign the adapter description
            this.serviceDescription = description;
            //Assign the addresses
            this.address = description.Addresses[0];
            this.mmiRegisterAddress = mmiRegisterAddress;
            //Assign the processor
            this.processor = processor;
            this.internalAddress = internalAddress;
        }


        /// <summary>
        /// Starts the controller async
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StartAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                this.Start();
                return true;
            });

        }

        /// <summary>
        /// Starts the service controller
        /// </summary>
        /// <param name="adapterImplementation"></param>
        public virtual void Start()
        {
            //Create and start the registration handler
            this.registrationHandler = new ServiceRegistrationHandler(this.mmiRegisterAddress, this.serviceDescription);

            string address = this.address.Address;
            int port = this.address.Port;
            if(this.internalAddress != null)
            {
                address = this.internalAddress.Address;
                port = this.internalAddress.Port;
            } 
            this.thriftServer = new ThriftServerBase(address, port, this.processor);



            Logger.Log(Log_level.L_INFO, $"Starting service socket at {this.serviceDescription.Name} at {address}:{port}");
            Logger.Log(Log_level.L_INFO, $"Registering service at Launcher as {this.serviceDescription.Name} at {this.address.Address}:{this.address.Port}");

            //Start the adapter controller in separate thread
            ThreadPool.QueueUserWorkItem(delegate
            {
                this.thriftServer.Start();
                this.Started = true;
            });
        }



        /// <summary>
        /// Disposes the service controller
        /// </summary>
        public void Dispose()
        { 
            //Dispose the registration handler
            this.registrationHandler.Dispose();

            //Dispose the thrift server
            this.thriftServer.Dispose();
        }
    }
}

// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Felix Gaisbauer

using System.Collections.Generic;

namespace MMIStandard
{
    public static class Extensions
    {

        #region clone methods

        /// <summary>
        /// Returns a deep copy of a MJoint
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static MJoint Clone(this MJoint bone)
        {
            return new MJoint(bone.ID, bone.Type, bone.Position.Clone(), bone.Rotation.Clone())
            {
                Parent = bone.Parent,
                Channels = bone.Channels.Clone(),
            };
        }


        public static List<MChannel> Clone (this List<MChannel> c)
        {
            var nc = new List<MChannel>();
            foreach(MChannel mc in c)
            {
                nc.Add(mc);
            }
            return nc;
        }

        /// <summary>
        /// Returns a deep copy of a MTransform
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static MTransform Clone(this MTransform original)
        {
            return new MTransform(original.ID, original.Position.Clone(), original.Rotation.Clone(), original.Scale.Clone())
            {
                Parent = original.Parent
            };
        }

        public static MSceneObject Clone(this MSceneObject original)
        {
            MSceneObject clone = new MSceneObject()
            {
                ID = original.ID,
                Name = original.Name,
                Collider = original.Collider!=null? original.Collider.Clone(): null,
                Properties = original.Properties != null ? original.Properties.Clone():null,
                Transform = original.Transform!=null?original.Transform.Clone():null,
                Mesh = original.Mesh!=null?original.Mesh.Clone():null
            };

            return clone;
        }


        public static MCollider Clone(this MCollider original)
        {
            MCollider clone = new MCollider()
            {
                Type = original.Type,
                BoxColliderProperties = original.BoxColliderProperties,
                SphereColliderProperties = original.SphereColliderProperties,
                CapsuleColliderProperties = original.CapsuleColliderProperties,
                MeshColliderProperties = original.MeshColliderProperties,
                ConeColliderProperties = original.ConeColliderProperties,
                CylinderColliderProperties = original.CylinderColliderProperties,
                ID = original.ID,
                //To do
                Colliders = original.Colliders,
                PositionOffset = original.PositionOffset.Clone(),
                RotationOffset = original.RotationOffset.Clone(),
                Properties = original.Properties.Clone()
            };

            return clone;
        }

        /// <summary>
        /// To DO 
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static MMesh Clone(this MMesh original)
        {
            MMesh clone = new MMesh()
            {
                ID = original.ID,
                Properties = original.Properties,
                Triangles = new List<int>(original.Triangles),
                Vertices = new List<MVector3>(original.Vertices)
            };
            
            return clone;
        }

        public static Dictionary<string,string> Clone(this Dictionary<string,string> original)
        {
            Dictionary<string, string> clone = new Dictionary<string, string>();

            if(original != null)
            {
                foreach(KeyValuePair<string,string> pair in original)
                {
                    clone.Add(pair.Key, pair.Value);
                }
            }

            return clone;
        }

        #endregion


        public static Dictionary<MJointType, string> Invert(this Dictionary<string, MJointType> boneMapping)
        {
            Dictionary<MJointType, string> result = new Dictionary<MJointType, string>();


            foreach (var entry in boneMapping)
            {
                if (!result.ContainsKey(entry.Value))
                    result.Add(entry.Value, entry.Key);
            }

            return result;
        }


        /// <summary>
        /// Returns a hash of the scene manipulations
        /// Can be utilized to check if there have been any differences
        /// </summary>
        /// <param name="sceneUpdates"></param>
        /// <returns></returns>
        public static int GetSceneHash(this MSceneUpdate sceneUpdates)
        {
            int hash = sceneUpdates.GetHashCode();

            return hash;
        }

        public static MSimulationState Clone(this MSimulationState s)
        {
            var ns = new MSimulationState(s.Initial.Clone(), s.Current.Clone());
            if (s.Constraints != null)
                ns.Constraints = s.Constraints.Clone();
            if (s.Events != null)
                ns.Events = s.Events.Clone();
            if (s.SceneManipulations != null)
                ns.SceneManipulations = s.SceneManipulations.Clone();
            return ns;
        }

        public static List<MSceneManipulation> Clone(this List<MSceneManipulation> l)
        {
            var nl = new List<MSceneManipulation>();
            foreach (var c in l)
            {
                nl.Add(c.Clone());
            }
            return nl;
        }

        public static MSceneManipulation Clone(this MSceneManipulation s)
        {
            var ns = new MSceneManipulation();
            if (s.Properties != null)
                ns.Properties = s.Properties.Clone();
            if (s.PhysicsInteractions != null)
                ns.PhysicsInteractions = s.PhysicsInteractions.Clone();
            if (s.Transforms != null)
                ns.Transforms = s.Transforms.Clone();
            return ns;
        }

        public static List<MTransformManipulation> Clone(this List<MTransformManipulation> l)
        {
            var nl = new List<MTransformManipulation>();
            foreach (var c in l)
            {
                nl.Add(c.Clone());
            }
            return nl;
        }


        public static MTransformManipulation Clone(this MTransformManipulation m)
        {
            var nm = new MTransformManipulation(m.Target + "");
            if (m.Parent != null)
                nm.Parent = m.Parent + "";
            if (m.Position != null)
                nm.Position = m.Position.Clone();
            if (m.Rotation != null)
                nm.Rotation = m.Rotation.Clone();
            return nm;
        }

        public static List<MPhysicsInteraction> Clone(this List<MPhysicsInteraction> l)
        {
            var nl = new List<MPhysicsInteraction>();
            foreach (var c in l)
            {
                nl.Add(c.Clone());
            }
            return nl;
        }

        public static MPhysicsInteraction Clone(this MPhysicsInteraction i)
        {
            var ni = new MPhysicsInteraction(i.Target + "", i.Type, new List<double>(i.Values));
            if (i.Properties != null)
                ni.Properties = i.Properties.Clone();
            return ni;
        }

        public static List<MPropertyManipulation> Clone(this List<MPropertyManipulation> l)
        {
            var nl = new List<MPropertyManipulation>();
            foreach (var c in l)
            {
                nl.Add(c.Clone());
            }
            return nl;
        }

        public static MPropertyManipulation Clone(this MPropertyManipulation pm)
        {
            var newPM = new MPropertyManipulation(pm.Target + "", pm.Key + "", pm.AddRemove);
            if (pm.Value != null)
                newPM.Value = pm.Value + "";
            return newPM;
        }

        public static List<MSimulationEvent> Clone(this List<MSimulationEvent> l)
        {
            var nl = new List<MSimulationEvent>();
            foreach (var c in l)
            {
                nl.Add(c.Clone());
            }
            return nl;
        }


        public static MSimulationEvent Clone(this MSimulationEvent e)
        {
            var ne = new MSimulationEvent(e.Name + "", e.Type + "", e.Reference + "");
            if (e.Properties != null)
                ne.Properties = e.Properties.Clone();
            return ne;
        }
    }
}

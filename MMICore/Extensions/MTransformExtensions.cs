﻿// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Felix Gaisbauer

namespace MMIStandard
{
    /// <summary>
    /// This is a static class containing several useful extensions for the MTransform class contained in the MMI standard
    /// </summary>
    public static class MTransformExtensions
    {
        /// <summary>
        /// Transforms a point from the local space of the MTransform to the global space
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="localPosition"></param>
        /// <returns></returns>
        public static MVector3 TransformPoint(this MTransform transform, MVector3 localPosition)
        {
            return transform.Rotation.Multiply(localPosition).Add(transform.Position);
        }

        /// <summary>
        /// Transforms a point from the global space to the local space of the MTransform
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="globalPosition"></param>
        /// <returns></returns>
        public static MVector3 InverseTransformPoint(this MTransform transform, MVector3 globalPosition)
        {
            return MQuaternionExtensions.Inverse(transform.Rotation).Multiply(globalPosition.Subtract(transform.Position));
        }

        public static MTransform Inverse(this MTransform transform)
        {
            return new MTransform(transform.ID + "_inverse", transform.Position.Multiply(-1), MQuaternionExtensions.Inverse(transform.Rotation), transform.Scale);
        }

        /// <summary>
        /// Transforms a rotation form local space of the MTransform to the global space
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="localRotation"></param>
        /// <returns></returns>
        public static MQuaternion TransformRotation(this MTransform transform, MQuaternion localRotation)
        {
            return transform.Rotation.Multiply(localRotation);
        }

        /// <summary>
        /// Transforms a rotation from global space into the local space of the MTransform
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="globalRotation"></param>
        /// <returns></returns>
        public static MQuaternion InverseTransformRotation(this MTransform transform, MQuaternion globalRotation)
        {
            return MQuaternionExtensions.Inverse(transform.Rotation).Multiply(globalRotation);
        }


        /// <summary>
        /// Applies this transform to the other transform. 
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static MTransform Multiply(this MTransform transform, MTransform other)
        {
            MQuaternion q = transform.TransformRotation(other.Rotation);
            MVector3 pos = transform.TransformPoint(other.Position);
            MVector3 newScale = transform.Scale.Scale(other.Scale);
            MTransform t = new MTransform(transform.ID, pos, q, newScale);
            return t;
        }


        /// <summary>
        /// Changes this transform from local to global space by iteratively progressing to parent objects transforms. 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="sceneAccess"></param>
        /// <returns></returns>
        public static MTransform LocalToGlobal(this MTransform t, MSceneAccess.Iface sceneAccess)
        {
            MTransform newT = t;
            if(t.Parent != null)
            {
                MSceneObject o = sceneAccess.GetSceneObjectByID(t.Parent);
                if(o != null)
                {
                    newT = t.Multiply(o.Transform);
                    if(o.Transform.Parent != null)
                    {
                        newT.Parent = o.Transform.Parent;
                        newT = newT.LocalToGlobal(sceneAccess);
                    }
                }
            }
            return newT;
        }

        public static MTransform Identity()
        {
            return new MTransform("", MVector3Extensions.Zero(), MQuaternionExtensions.Identity(), MVector3Extensions.One());
        }
    }
}

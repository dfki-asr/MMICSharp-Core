// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Felix Gaisbauer

using System.Collections.Generic;

namespace MMIStandard
{
    /// <summary>
    /// Extensions for the MGeometryConstraint
    /// </summary>
    public static class MGeometryConstraintExtensions
    {
        /// <summary>
        /// Returns the global position of a given MGeometry constraint
        /// </summary>
        /// <param name="constraint"></param>
        /// <param name="sceneAccess"></param>
        /// <returns></returns>
        public static MVector3 GetGlobalPosition(this MGeometryConstraint constraint, MSceneAccess.Iface sceneAccess)
        {
            MTransform parentTransform = sceneAccess.GetTransformByID(constraint.ParentObjectID);

            if(parentTransform != null)
            {
                if (constraint.ParentToConstraint != null)
                    return parentTransform.TransformPoint(constraint.ParentToConstraint.Position);
                else
                    return parentTransform.Position;
            }
            //No parent defined
            else
            {
                if(constraint.ParentToConstraint != null)
                    return constraint.ParentToConstraint.Position;
            }

            return null;
        }


        /// <summary>
        /// Returns the global rotation of the specified constraint
        /// </summary>
        /// <param name="constraint"></param>
        /// <param name="sceneAccess"></param>
        /// <returns></returns>
        public static MQuaternion GetGlobalRotation(this MGeometryConstraint constraint, MSceneAccess.Iface sceneAccess)
        {
            MTransform parentTransform = sceneAccess.GetTransformByID(constraint.ParentObjectID);

            if (parentTransform != null)
            {
                if (constraint.ParentToConstraint != null)
                    return parentTransform.TransformRotation(constraint.ParentToConstraint.Rotation);
                else
                    return parentTransform.Rotation;
            }
            //No parent defined
            else
            {
                if (constraint.ParentToConstraint != null)
                    return constraint.ParentToConstraint.Rotation;
            }

            return null;
        }

        public static MGeometryConstraint MakeGlobalConstraint(this MGeometryConstraint constraint, MSceneAccess.Iface sceneAccess)
        {
            if(constraint.ParentObjectID != "")
            {
                MVector3 scale = constraint.ParentToConstraint.Scale.Clone();
                MTransform parentTransform = sceneAccess.GetTransformByID(constraint.ParentObjectID);
                scale.X *= parentTransform.Scale.X;
                scale.Y *= parentTransform.Scale.Y;
                scale.Z *= parentTransform.Scale.Z;
                MGeometryConstraint global = new MGeometryConstraint("")
                {
                    ParentToConstraint = new MTransform(constraint.ParentToConstraint.ID,
                    constraint.GetGlobalPosition(sceneAccess), constraint.GetGlobalRotation(sceneAccess), scale),
                    RotationConstraint = constraint.RotationConstraint.Clone(),
                    TranslationConstraint = constraint.TranslationConstraint.Clone(),
                    WeightingFactor = constraint.WeightingFactor
                };
                return global;
            }
            else
            {
                // nothing to globalize
                return constraint.Clone();
            }
        }

        public static MGeometryConstraint Identity(string parent)
        {
            MGeometryConstraint local = new MGeometryConstraint(parent)
            {
                ParentToConstraint = MTransformExtensions.Identity()
            };
            return local;
        }

        /// <summary>
        /// Clones the MGeometry Constraint
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        public static MGeometryConstraint Clone(this MGeometryConstraint constraint)
        {
            MGeometryConstraint nc = new MGeometryConstraint(constraint.ParentObjectID + "")
            {
                ParentToConstraint = constraint.ParentToConstraint.Clone(),
                RotationConstraint = constraint.RotationConstraint.Clone(),
                TranslationConstraint = constraint.TranslationConstraint.Clone(),
                WeightingFactor = constraint.WeightingFactor * 1.0
            };
            return nc;
        }

        public static List<MGeometryConstraint> Clone(this List<MGeometryConstraint> l)
        {
            var nl = new List<MGeometryConstraint>();
            foreach(MGeometryConstraint c in l)
            {
                nl.Add(c.Clone());
            }
            return nl;
        }

    }
}
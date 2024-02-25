// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Janis Sprenger
using System.Collections.Generic;
namespace MMIStandard
{
    /// <summary>
    /// Extensions for the MGeometryConstraint
    /// </summary>
    public static class MConstraintExtensions
    {
        public static bool Contains(this List<MConstraint> cList, string id) 
        { 
            foreach(MConstraint c in cList)
            {
                if(c.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool TryGetConstraint(this List<MConstraint> cList, string id, out MConstraint outC)
        {
            foreach (MConstraint c in cList)
            {
                if (c.ID == id)
                {
                    outC = c;
                    return true;
                }
            }
            outC = null;
            return false;
        }

        public static List<MConstraint> Clone(this List<MConstraint> l)
        {
            var nl = new List<MConstraint>();
            foreach (MConstraint c in l)
            {
                nl.Add(c.Clone());
            }
            return nl;
        }

        public static MConstraint Clone(this MConstraint c)
        {
            MConstraint nc = new MConstraint(c.ID + "");
            if(c.GeometryConstraint != null)
                nc.GeometryConstraint = c.GeometryConstraint.Clone();
            if(c.AccelerationConstraint != null)
                nc.AccelerationConstraint = c.AccelerationConstraint.Clone();
            if(c.JointConstraint != null)
                nc.JointConstraint = c.JointConstraint.Clone();
            if(c.JointConstraint != null)
                nc.JointPathConstraint = c.JointPathConstraint.Clone();
            if(c.PathConstraint != null)
                nc.PathConstraint = c.PathConstraint.Clone();
            if (c.PostureConstraint != null)
                nc.PostureConstraint = c.PostureConstraint.Clone();
            if (c.Properties != null)
                nc.Properties = c.Properties.Clone();
            if (c.VelocityConstraint != null)
                nc.VelocityConstraint = c.VelocityConstraint.Clone();
            return nc;
        }

        public static MVelocityConstraint Clone(this MVelocityConstraint c)
        {
            var nc = new MVelocityConstraint(c.ParentObjectID + "");
            if (c.ParentToConstraint != null)
                nc.ParentToConstraint = c.ParentToConstraint.Clone();
            if (c.RotationalVelocity != null)
                nc.RotationalVelocity = c.RotationalVelocity.Clone();
            if (c.TranslationalVelocity != null)
                nc.TranslationalVelocity = c.TranslationalVelocity.Clone();
            c.WeightingFactor = nc.WeightingFactor;
            return nc;
        }

        public static List<MJointConstraint> Clone(this List<MJointConstraint> l)
        {
            var nl = new List<MJointConstraint>();
            foreach(var c in l)
            {
                nl.Add(c.Clone());
            }
            return nl;
        }

        public static MPostureConstraint Clone(this MPostureConstraint c)
        {
            var nc = new MPostureConstraint(c.Posture.Clone());
            if (c.JointConstraints != null)
                nc.JointConstraints = c.JointConstraints.Clone();
            return nc;
        }

        public static MPathConstraint Clone(this MPathConstraint c)
        {
            var nc = new MPathConstraint(c.PolygonPoints.Clone());
            nc.WeightingFactor = c.WeightingFactor;
            return nc;
        }

        public static MJointPathConstraint Clone(this MJointPathConstraint c)
        {
            var nc = new MJointPathConstraint(c.JointType, c.PathConstraint.Clone());
            return nc;
        }

        public static MJointConstraint Clone(this MJointConstraint c)
        {
            var nc = new MJointConstraint(c.JointType);
            if (c.GeometryConstraint != null)
                nc.GeometryConstraint = c.GeometryConstraint.Clone();
            if (c.AccelerationConstraint != null)
                nc.AccelerationConstraint = c.AccelerationConstraint.Clone();
            if (c.VelocityConstraint != null)
                nc.VelocityConstraint = c.VelocityConstraint.Clone();
            return nc;
        }

        public static MAccelerationConstraint Clone(this MAccelerationConstraint c)
        {
            MAccelerationConstraint nc = new MAccelerationConstraint(c.ParentObjectID + "");
            if(c.ParentToConstraint != null)
                nc.ParentToConstraint = c.ParentToConstraint.Clone();
            if (c.RotationalAcceleration != null)
                nc.RotationalAcceleration = c.RotationalAcceleration.Clone();
            if (c.TranslationalAcceleration != null)
                nc.TranslationalAcceleration = c.TranslationalAcceleration.Clone();
            nc.WeightingFactor = c.WeightingFactor;
            return nc;
        }
    }
}
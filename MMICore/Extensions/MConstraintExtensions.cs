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

    }
}
﻿using MMIStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMICoSimulation.Solvers
{
    /// <summary>
    /// Apply Posture Constraints without IK. In case there is a (partial) posture provided as a constraint, this posture will be utilized. 
    /// </summary>
    public class LocalPostureSolver : ICoSimulationSolver
    {

        MSkeletonAccess.Iface skelAccess;

        public LocalPostureSolver(MSkeletonAccess.Iface skeletonAccess)
        {
            this.skelAccess = skeletonAccess;
        }

        public bool RequiresSolving(MSimulationResult result, float timeSpan)
        {
            if(result.Constraints != null && result.Constraints.Count > 0) {
                foreach (MConstraint c in result.Constraints)
                {
                    if (c.PostureConstraint != null) return true;
                }
            }
            
            return false;
        }

        public MSimulationResult Solve(MSimulationResult currentResult, List<MSimulationResult> mmuResults, float timeSpan)
        {
            MAvatarPostureValues values = currentResult.Posture;
            foreach(MConstraint c in currentResult.Constraints)
            {
                if(c.PostureConstraint != null)
                {
                    MPostureConstraint pc = c.PostureConstraint;

                    MAvatarPostureValues v_values = pc.Posture;
                    if(v_values.PartialJointList != null && v_values.PartialJointList.Count > 0)
                    {
                        currentResult.Posture = currentResult.Posture.OverwriteWithPartial(v_values);
                    }
                    else
                    {
                        currentResult.Posture = v_values;
                    }
                }
            }
            return currentResult;
        }
    }
}

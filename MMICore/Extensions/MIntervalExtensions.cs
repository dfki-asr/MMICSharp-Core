// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Felix Gaisbauer


namespace MMIStandard
{
    public static class MIntervalExtensions
    {
        public static double X(this MInterval3 interval)
        {
            return (interval.X.Min+ interval.X.Max)/2f;
        }

        public static double Y(this MInterval3 interval)
        {
            return (interval.Y.Min + interval.Y.Max) / 2f;
        }

        public static double Z(this MInterval3 interval)
        {
            return (interval.Z.Min + interval.Z.Max) / 2f;
        }

        public static MInterval3 Clone(this MInterval3 intv)
        {
            return new MInterval3(intv.X.Clone(), intv.Y.Clone(), intv.Z.Clone());
        }

        public static MInterval Clone(this MInterval intv)
        {
            return new MInterval(intv.Min * 1.0, intv.Max * 1.0);
        }

    }
}

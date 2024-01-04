// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Felix Gaisbauer

namespace MMIStandard
{
    public static class MAvatarExtensions
    {
        public static MAvatar Clone(this MAvatar avatar)
        {
            MAvatar clone = new MAvatar();
            clone.ID = avatar.ID;
            clone.Name = avatar.Name;

            //To do -> proper cloning
            clone.Description = avatar.Description;
            clone.PostureValues = avatar.PostureValues;
            clone.SceneObjects = avatar.SceneObjects;

            return clone;
        }

        public static MAvatarDescription Clone(this MAvatarDescription desc)
        {
            MAvatarDescription d = new MAvatarDescription(desc.AvatarID + "", desc.ZeroPosture.Clone());
            if(desc.Properties != null)
            {
                d.Properties = new System.Collections.Generic.Dictionary<string, string>();
                foreach(string key in desc.Properties.Keys)
                {
                    d.Properties.Add(key, desc.Properties[key]);
                }
            }
            return d;
        }

        public static MAvatarPosture Clone (this MAvatarPosture p)
        {
            MAvatarPosture np = new MAvatarPosture();
            np.AvatarID = p.AvatarID + "";
            np.Joints = new System.Collections.Generic.List<MJoint>();
            foreach(MJoint j in p.Joints)
            {
                np.Joints.Add(j.Clone());
            }
            return np;
        }
    }
}

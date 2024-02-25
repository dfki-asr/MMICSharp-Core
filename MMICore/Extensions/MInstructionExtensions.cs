// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Janis Sprenger
using System.Collections.Generic;

namespace MMIStandard
{
    /// <summary>
    /// Extensions for the MInstructions
    /// </summary>
    public static class MInstructionExtensions
    {
        public static void AddOrUpdate<T>(this Dictionary<string, T> dict, string key, T value)
        {
            if(dict.ContainsKey(key))
            {
                dict[key] = value;
            } else
            {
                dict.Add(key, value);
            }
        }

        public static bool ContainsInstruction(this List<MInstruction> instList, MInstruction key)
        {
            foreach(MInstruction i in instList)
            {
                if(i.ID == key.ID)
                {
                    return true;
                }
            }
            return false;
        }
        public static void TryRemove(this List<MInstruction> instList, MInstruction key)
        {
            int id = -1;
            for(int i = 0; i < instList.Count; i++)
            {
                if (instList[i].ID == key.ID)
                {
                    id = i;
                    break;
                }
            }
            if(id >= 0)
            {
                instList.RemoveAt(id);
            }
        }

        public static void AddOrUpdate(this List<MInstruction> instList, MInstruction key)
        {
            instList.TryRemove(key);
            instList.Add(key);
        }

        public static MInstruction Clone(this MInstruction instr)
        {
            MInstruction newInstr = new MInstruction(instr.ID + "", instr.Name + "", instr.MotionType + "", instr.AvatarID + "");
            if (instr.Constraints != null)
                newInstr.Constraints = instr.Constraints.Clone();
            if (instr.Action != null)
                newInstr.Action = instr.Action + "";
            if (instr.EndCondition != null)
                newInstr.EndCondition = instr.EndCondition + "";
            if (instr.Instructions != null)
                newInstr.Instructions = instr.Instructions.Clone();
            if (instr.Properties != null)
                newInstr.Properties = instr.Properties.Clone();
            if (instr.StartCondition != null)
                newInstr.StartCondition = instr.StartCondition + "";

            return newInstr;
        }

        public static List<MInstruction> Clone(this List<MInstruction> l)
        {
            var nl = new List<MInstruction>();
            foreach (var i in l)
                nl.Add(i.Clone());
            return nl;
        }
    }
}
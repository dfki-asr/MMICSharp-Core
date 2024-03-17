using MMIStandard;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using MMICSharp.Common;
using System.Linq;


namespace MMIStandard
{
    class MSceneObjectException : SystemException
    {
        public MSceneObjectException() : base() { }
        public MSceneObjectException(string message) : base(message) { }
        public MSceneObjectException(string message, Exception innerException) : base(message, innerException) { }
        protected MSceneObjectException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    class MSceneObjectNotFoundException : MSceneObjectException
    {
        public MSceneObjectNotFoundException() : base() { }
        public MSceneObjectNotFoundException(string message) : base(message) { }
        public MSceneObjectNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected MSceneObjectNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }


    public static class InstructionParseHelper
    {
        // if dic does not contain key value=defaultVal and return false
        public static bool TryGetValueWithDefault(this Dictionary<string, string> dic, string key, out string value, string defaultVal)
        {
            if (dic.TryGetValue(key, out value))
                return true;
            value = defaultVal;
            return false;
        }

        public static bool TryGetPropertyByKey(this MInstruction instruction, string propertyKey, out string property, out string msg)
        {
            var res = instruction.Properties.TryGetValue(propertyKey, out property);
            if (res)
                msg = $"Instruction ({instruction.Name}:{instruction.ID}) Property {propertyKey}: {property} is found";
            else
                msg = $"Instruction ({instruction.Name}:{instruction.ID}) Property with key {propertyKey} is not found";
            return res;
        }

        public static bool TryGetPropertyByKey(MSceneObject sceneObject, string propertyKey, out string property, out string msg)
        {
            var res = sceneObject.Properties.TryGetValue(propertyKey, out property);
            if (res)
                msg = $"Instruction ({sceneObject.Name}:{sceneObject.ID}) Property {propertyKey}: {property} is found";
            else
                msg = $"Instruction ({sceneObject.Name}:{sceneObject.ID}) Property with key {propertyKey} is not found";
            return res;
        }


        public static bool TryGetMSeneObjectByIDOrName(this IMotionModelUnitDev mmu, string objectID, out MSceneObject sceneObject, out string msg)
        {
            string key_type = "id";
            sceneObject = mmu.SceneAccess.GetSceneObjectByID(objectID);
            if (sceneObject == null)
            {
                key_type = "name";
                sceneObject = mmu.SceneAccess.GetSceneObjectByName(objectID);
            }
            var res = (sceneObject != null);

            if (res)
                msg = $"{mmu.Name}: SceneObject with {key_type} {objectID} is found";
            else
                msg = $"{mmu.Name}: SceneObject with id or name {objectID} is not found";
            return res;
        }


        // use instruction[propertyKey] as MSeneObject id or name
        public static bool TryGetMSeneObjectByPropertyKey(this IMotionModelUnitDev mmu, MInstruction instruction, string propertyKey, out MSceneObject sceneObject, out string msg)
        {
            sceneObject = null;
            if (!instruction.TryGetPropertyByKey(propertyKey, out string objectID, out string iMsg))
            {
                msg = $"{mmu.Name}: TryGetMSeneObjectByPropertyKey:" + iMsg;
                return false;
            }
            return mmu.TryGetMSeneObjectByIDOrName(objectID, out sceneObject, out msg);
        }

        public static bool TryGetConstraintByPropertyKeyAndType(MInstruction instruction, MSceneObject sceneObject, string propertyKey, MConstraintType cType, out MConstraint constraint, out string msg)
        {
            constraint = null;
            if (!instruction.TryGetPropertyByKey(propertyKey, out string cID, out msg))
                return false;
            var cList = instruction.Constraints;
            if (sceneObject != null)
                cList = instruction.Constraints.Concat(sceneObject.Constraints).ToList();
            var res = cList.TryGetConstraintByIDAndType(cID, cType, out constraint, out msg);
            return res;
        }

        public static string GetPropertyByKey(this MInstruction instruction, string propertyKey)
        {
            var properties = instruction.Properties;
            if (!properties.ContainsKey(propertyKey))
                throw new KeyNotFoundException($"Instruction ({instruction.Name}:{instruction.ID}) Properties does not contain key {propertyKey}");
            var property = properties[propertyKey];

            return property;
        }

        public static string GetPropertyByKey(this MSceneObject sceneObject, string propertyKey)
        {
            var properties = sceneObject.Properties;
            if (!properties.ContainsKey(propertyKey))
                throw new KeyNotFoundException($"SceneObject ({sceneObject.Name}:{sceneObject.ID}) Properties does not contain key {propertyKey}");
            var property = properties[propertyKey];

            return property;
        }

        public static MSceneObject GetMSeneObjectByIDOrName(this IMotionModelUnitDev mmu, string objectID)
        {
            MSceneObject sceneObject;
            sceneObject = mmu.SceneAccess.GetSceneObjectByID(objectID) ?? mmu.SceneAccess.GetSceneObjectByName(objectID);
            if (sceneObject == null)
                throw new MSceneObjectNotFoundException($"SceneObject with id or name {objectID} is not found");

            return sceneObject;
        }

        public static MSceneObject GetMSeneObjectByPropertyKey(this IMotionModelUnitDev mmu, MInstruction instruction, string propertyKey)
        {
            var objectID = instruction.GetPropertyByKey(propertyKey);
            return mmu.GetMSeneObjectByIDOrName(objectID);
        }

        public static MConstraint GetConstraintByPropertyKeyAndType(MInstruction instruction, MSceneObject sceneObject, string propertyKey, MConstraintType cType = MConstraintType.Any)
        {
            var cList = instruction.Constraints;
            if (sceneObject != null)
                cList = instruction.Constraints.Concat(sceneObject.Constraints).ToList();
            var cID = instruction.GetPropertyByKey(propertyKey);
            return cList.GetConstraintByIDAndType(cID, cType);
        }
    }
}
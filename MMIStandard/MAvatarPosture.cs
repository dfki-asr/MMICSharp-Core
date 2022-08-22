/**
 * Autogenerated by Thrift Compiler (0.13.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;


#if !SILVERLIGHT
[Serializable]
#endif
public partial class MAvatarPosture : TBase
{

  public string AvatarID { get; set; }

  public List<MJoint> Joints { get; set; }

  public MAvatarPosture() {
  }

  public MAvatarPosture(string AvatarID, List<MJoint> Joints) : this() {
    this.AvatarID = AvatarID;
    this.Joints = Joints;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_AvatarID = false;
      bool isset_Joints = false;
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              AvatarID = iprot.ReadString();
              isset_AvatarID = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.List) {
              {
                Joints = new List<MJoint>();
                TList _list12 = iprot.ReadListBegin();
                for( int _i13 = 0; _i13 < _list12.Count; ++_i13)
                {
                  MJoint _elem14;
                  _elem14 = new MJoint();
                  _elem14.Read(iprot);
                  Joints.Add(_elem14);
                }
                iprot.ReadListEnd();
              }
              isset_Joints = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
      if (!isset_AvatarID)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field AvatarID not set");
      if (!isset_Joints)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Joints not set");
    }
    finally
    {
      iprot.DecrementRecursionDepth();
    }
  }

  public void Write(TProtocol oprot) {
    oprot.IncrementRecursionDepth();
    try
    {
      TStruct struc = new TStruct("MAvatarPosture");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (AvatarID == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field AvatarID not set");
      field.Name = "AvatarID";
      field.Type = TType.String;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(AvatarID);
      oprot.WriteFieldEnd();
      if (Joints == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Joints not set");
      field.Name = "Joints";
      field.Type = TType.List;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      {
        oprot.WriteListBegin(new TList(TType.Struct, Joints.Count));
        foreach (MJoint _iter15 in Joints)
        {
          _iter15.Write(oprot);
        }
        oprot.WriteListEnd();
      }
      oprot.WriteFieldEnd();
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }
    finally
    {
      oprot.DecrementRecursionDepth();
    }
  }

  public override string ToString() {
    StringBuilder __sb = new StringBuilder("MAvatarPosture(");
    __sb.Append(", AvatarID: ");
    __sb.Append(AvatarID);
    __sb.Append(", Joints: ");
    __sb.Append(Joints);
    __sb.Append(")");
    return __sb.ToString();
  }

}


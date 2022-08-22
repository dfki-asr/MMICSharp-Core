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
public partial class MTransform : TBase
{
  private string _Parent;

  public string ID { get; set; }

  public MVector3 Position { get; set; }

  public MQuaternion Rotation { get; set; }

  public MVector3 Scale { get; set; }

  public string Parent
  {
    get
    {
      return _Parent;
    }
    set
    {
      __isset.Parent = true;
      this._Parent = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool Parent;
  }

  public MTransform() {
  }

  public MTransform(string ID, MVector3 Position, MQuaternion Rotation, MVector3 Scale) : this() {
    this.ID = ID;
    this.Position = Position;
    this.Rotation = Rotation;
    this.Scale = Scale;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_ID = false;
      bool isset_Position = false;
      bool isset_Rotation = false;
      bool isset_Scale = false;
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
              ID = iprot.ReadString();
              isset_ID = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Struct) {
              Position = new MVector3();
              Position.Read(iprot);
              isset_Position = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              Rotation = new MQuaternion();
              Rotation.Read(iprot);
              isset_Rotation = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              Scale = new MVector3();
              Scale.Read(iprot);
              isset_Scale = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              Parent = iprot.ReadString();
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
      if (!isset_ID)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field ID not set");
      if (!isset_Position)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Position not set");
      if (!isset_Rotation)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Rotation not set");
      if (!isset_Scale)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Scale not set");
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
      TStruct struc = new TStruct("MTransform");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (ID == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field ID not set");
      field.Name = "ID";
      field.Type = TType.String;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(ID);
      oprot.WriteFieldEnd();
      if (Position == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Position not set");
      field.Name = "Position";
      field.Type = TType.Struct;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      Position.Write(oprot);
      oprot.WriteFieldEnd();
      if (Rotation == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Rotation not set");
      field.Name = "Rotation";
      field.Type = TType.Struct;
      field.ID = 3;
      oprot.WriteFieldBegin(field);
      Rotation.Write(oprot);
      oprot.WriteFieldEnd();
      if (Scale == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Scale not set");
      field.Name = "Scale";
      field.Type = TType.Struct;
      field.ID = 4;
      oprot.WriteFieldBegin(field);
      Scale.Write(oprot);
      oprot.WriteFieldEnd();
      if (Parent != null && __isset.Parent) {
        field.Name = "Parent";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Parent);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }
    finally
    {
      oprot.DecrementRecursionDepth();
    }
  }

  public override string ToString() {
    StringBuilder __sb = new StringBuilder("MTransform(");
    __sb.Append(", ID: ");
    __sb.Append(ID);
    __sb.Append(", Position: ");
    __sb.Append(Position== null ? "<null>" : Position.ToString());
    __sb.Append(", Rotation: ");
    __sb.Append(Rotation== null ? "<null>" : Rotation.ToString());
    __sb.Append(", Scale: ");
    __sb.Append(Scale== null ? "<null>" : Scale.ToString());
    if (Parent != null && __isset.Parent) {
      __sb.Append(", Parent: ");
      __sb.Append(Parent);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


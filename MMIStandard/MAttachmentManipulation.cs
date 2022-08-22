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
public partial class MAttachmentManipulation : TBase
{
  private string _Type;

  public string Parent { get; set; }

  public string Child { get; set; }

  public bool AddRemove { get; set; }

  public string Type
  {
    get
    {
      return _Type;
    }
    set
    {
      __isset.Type = true;
      this._Type = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool Type;
  }

  public MAttachmentManipulation() {
  }

  public MAttachmentManipulation(string Parent, string Child, bool AddRemove) : this() {
    this.Parent = Parent;
    this.Child = Child;
    this.AddRemove = AddRemove;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_Parent = false;
      bool isset_Child = false;
      bool isset_AddRemove = false;
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
              Parent = iprot.ReadString();
              isset_Parent = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Child = iprot.ReadString();
              isset_Child = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Bool) {
              AddRemove = iprot.ReadBool();
              isset_AddRemove = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              Type = iprot.ReadString();
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
      if (!isset_Parent)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Parent not set");
      if (!isset_Child)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Child not set");
      if (!isset_AddRemove)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field AddRemove not set");
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
      TStruct struc = new TStruct("MAttachmentManipulation");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Parent == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Parent not set");
      field.Name = "Parent";
      field.Type = TType.String;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Parent);
      oprot.WriteFieldEnd();
      if (Child == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Child not set");
      field.Name = "Child";
      field.Type = TType.String;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Child);
      oprot.WriteFieldEnd();
      field.Name = "AddRemove";
      field.Type = TType.Bool;
      field.ID = 3;
      oprot.WriteFieldBegin(field);
      oprot.WriteBool(AddRemove);
      oprot.WriteFieldEnd();
      if (Type != null && __isset.Type) {
        field.Name = "Type";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Type);
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
    StringBuilder __sb = new StringBuilder("MAttachmentManipulation(");
    __sb.Append(", Parent: ");
    __sb.Append(Parent);
    __sb.Append(", Child: ");
    __sb.Append(Child);
    __sb.Append(", AddRemove: ");
    __sb.Append(AddRemove);
    if (Type != null && __isset.Type) {
      __sb.Append(", Type: ");
      __sb.Append(Type);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


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
public partial class MPropertyUpdate : TBase
{
  private string _Value;

  public string Key { get; set; }

  public string Value
  {
    get
    {
      return _Value;
    }
    set
    {
      __isset.@Value = true;
      this._Value = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool @Value;
  }

  public MPropertyUpdate() {
  }

  public MPropertyUpdate(string Key) : this() {
    this.Key = Key;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_Key = false;
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
              Key = iprot.ReadString();
              isset_Key = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Value = iprot.ReadString();
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
      if (!isset_Key)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Key not set");
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
      TStruct struc = new TStruct("MPropertyUpdate");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Key == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Key not set");
      field.Name = "Key";
      field.Type = TType.String;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Key);
      oprot.WriteFieldEnd();
      if (Value != null && __isset.@Value) {
        field.Name = "Value";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Value);
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
    StringBuilder __sb = new StringBuilder("MPropertyUpdate(");
    __sb.Append(", Key: ");
    __sb.Append(Key);
    if (Value != null && __isset.@Value) {
      __sb.Append(", Value: ");
      __sb.Append(Value);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


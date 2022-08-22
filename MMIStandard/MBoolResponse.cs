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
public partial class MBoolResponse : TBase
{
  private List<string> _LogData;

  public bool Successful { get; set; }

  public List<string> LogData
  {
    get
    {
      return _LogData;
    }
    set
    {
      __isset.LogData = true;
      this._LogData = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool LogData;
  }

  public MBoolResponse() {
  }

  public MBoolResponse(bool Successful) : this() {
    this.Successful = Successful;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_Successful = false;
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
            if (field.Type == TType.Bool) {
              Successful = iprot.ReadBool();
              isset_Successful = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.List) {
              {
                LogData = new List<string>();
                TList _list0 = iprot.ReadListBegin();
                for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                {
                  string _elem2;
                  _elem2 = iprot.ReadString();
                  LogData.Add(_elem2);
                }
                iprot.ReadListEnd();
              }
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
      if (!isset_Successful)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Successful not set");
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
      TStruct struc = new TStruct("MBoolResponse");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      field.Name = "Successful";
      field.Type = TType.Bool;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteBool(Successful);
      oprot.WriteFieldEnd();
      if (LogData != null && __isset.LogData) {
        field.Name = "LogData";
        field.Type = TType.List;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, LogData.Count));
          foreach (string _iter3 in LogData)
          {
            oprot.WriteString(_iter3);
          }
          oprot.WriteListEnd();
        }
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
    StringBuilder __sb = new StringBuilder("MBoolResponse(");
    __sb.Append(", Successful: ");
    __sb.Append(Successful);
    if (LogData != null && __isset.LogData) {
      __sb.Append(", LogData: ");
      __sb.Append(LogData);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


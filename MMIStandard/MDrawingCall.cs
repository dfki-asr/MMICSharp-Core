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
public partial class MDrawingCall : TBase
{
  private List<double> _Data;
  private Dictionary<string, string> _Properties;

  /// <summary>
  /// 
  /// <seealso cref="MDrawingCallType"/>
  /// </summary>
  public MDrawingCallType Type { get; set; }

  public List<double> Data
  {
    get
    {
      return _Data;
    }
    set
    {
      __isset.Data = true;
      this._Data = value;
    }
  }

  public Dictionary<string, string> Properties
  {
    get
    {
      return _Properties;
    }
    set
    {
      __isset.Properties = true;
      this._Properties = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool Data;
    public bool Properties;
  }

  public MDrawingCall() {
  }

  public MDrawingCall(MDrawingCallType Type) : this() {
    this.Type = Type;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_Type = false;
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
            if (field.Type == TType.I32) {
              Type = (MDrawingCallType)iprot.ReadI32();
              isset_Type = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.List) {
              {
                Data = new List<double>();
                TList _list70 = iprot.ReadListBegin();
                for( int _i71 = 0; _i71 < _list70.Count; ++_i71)
                {
                  double _elem72;
                  _elem72 = iprot.ReadDouble();
                  Data.Add(_elem72);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Map) {
              {
                Properties = new Dictionary<string, string>();
                TMap _map73 = iprot.ReadMapBegin();
                for( int _i74 = 0; _i74 < _map73.Count; ++_i74)
                {
                  string _key75;
                  string _val76;
                  _key75 = iprot.ReadString();
                  _val76 = iprot.ReadString();
                  Properties[_key75] = _val76;
                }
                iprot.ReadMapEnd();
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
      if (!isset_Type)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Type not set");
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
      TStruct struc = new TStruct("MDrawingCall");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      field.Name = "Type";
      field.Type = TType.I32;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32((int)Type);
      oprot.WriteFieldEnd();
      if (Data != null && __isset.Data) {
        field.Name = "Data";
        field.Type = TType.List;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Double, Data.Count));
          foreach (double _iter77 in Data)
          {
            oprot.WriteDouble(_iter77);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Properties != null && __isset.Properties) {
        field.Name = "Properties";
        field.Type = TType.Map;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
          foreach (string _iter78 in Properties.Keys)
          {
            oprot.WriteString(_iter78);
            oprot.WriteString(Properties[_iter78]);
          }
          oprot.WriteMapEnd();
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
    StringBuilder __sb = new StringBuilder("MDrawingCall(");
    __sb.Append(", Type: ");
    __sb.Append(Type);
    if (Data != null && __isset.Data) {
      __sb.Append(", Data: ");
      __sb.Append(Data);
    }
    if (Properties != null && __isset.Properties) {
      __sb.Append(", Properties: ");
      __sb.Append(Properties);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


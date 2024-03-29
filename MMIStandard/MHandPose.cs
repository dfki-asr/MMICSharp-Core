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
public partial class MHandPose : TBase
{
  private Dictionary<string, string> _Properties;

  public List<MJoint> Joints { get; set; }

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
    public bool Properties;
  }

  public MHandPose() {
  }

  public MHandPose(List<MJoint> Joints) : this() {
    this.Joints = Joints;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
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
            if (field.Type == TType.List) {
              {
                Joints = new List<MJoint>();
                TList _list16 = iprot.ReadListBegin();
                for( int _i17 = 0; _i17 < _list16.Count; ++_i17)
                {
                  MJoint _elem18;
                  _elem18 = new MJoint();
                  _elem18.Read(iprot);
                  Joints.Add(_elem18);
                }
                iprot.ReadListEnd();
              }
              isset_Joints = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Map) {
              {
                Properties = new Dictionary<string, string>();
                TMap _map19 = iprot.ReadMapBegin();
                for( int _i20 = 0; _i20 < _map19.Count; ++_i20)
                {
                  string _key21;
                  string _val22;
                  _key21 = iprot.ReadString();
                  _val22 = iprot.ReadString();
                  Properties[_key21] = _val22;
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
      TStruct struc = new TStruct("MHandPose");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Joints == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Joints not set");
      field.Name = "Joints";
      field.Type = TType.List;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      {
        oprot.WriteListBegin(new TList(TType.Struct, Joints.Count));
        foreach (MJoint _iter23 in Joints)
        {
          _iter23.Write(oprot);
        }
        oprot.WriteListEnd();
      }
      oprot.WriteFieldEnd();
      if (Properties != null && __isset.Properties) {
        field.Name = "Properties";
        field.Type = TType.Map;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
          foreach (string _iter24 in Properties.Keys)
          {
            oprot.WriteString(_iter24);
            oprot.WriteString(Properties[_iter24]);
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
    StringBuilder __sb = new StringBuilder("MHandPose(");
    __sb.Append(", Joints: ");
    __sb.Append(Joints);
    if (Properties != null && __isset.Properties) {
      __sb.Append(", Properties: ");
      __sb.Append(Properties);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


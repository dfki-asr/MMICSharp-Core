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
public partial class MCapsuleColliderProperties : TBase
{
  private MVector3 _MainAxis;

  public double Radius { get; set; }

  public double Height { get; set; }

  public MVector3 MainAxis
  {
    get
    {
      return _MainAxis;
    }
    set
    {
      __isset.MainAxis = true;
      this._MainAxis = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool MainAxis;
  }

  public MCapsuleColliderProperties() {
  }

  public MCapsuleColliderProperties(double Radius, double Height) : this() {
    this.Radius = Radius;
    this.Height = Height;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_Radius = false;
      bool isset_Height = false;
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
            if (field.Type == TType.Double) {
              Radius = iprot.ReadDouble();
              isset_Radius = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Double) {
              Height = iprot.ReadDouble();
              isset_Height = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              MainAxis = new MVector3();
              MainAxis.Read(iprot);
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
      if (!isset_Radius)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Radius not set");
      if (!isset_Height)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Height not set");
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
      TStruct struc = new TStruct("MCapsuleColliderProperties");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      field.Name = "Radius";
      field.Type = TType.Double;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteDouble(Radius);
      oprot.WriteFieldEnd();
      field.Name = "Height";
      field.Type = TType.Double;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteDouble(Height);
      oprot.WriteFieldEnd();
      if (MainAxis != null && __isset.MainAxis) {
        field.Name = "MainAxis";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        MainAxis.Write(oprot);
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
    StringBuilder __sb = new StringBuilder("MCapsuleColliderProperties(");
    __sb.Append(", Radius: ");
    __sb.Append(Radius);
    __sb.Append(", Height: ");
    __sb.Append(Height);
    if (MainAxis != null && __isset.MainAxis) {
      __sb.Append(", MainAxis: ");
      __sb.Append(MainAxis== null ? "<null>" : MainAxis.ToString());
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


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
public partial class MJointConstraint : TBase
{
  private MGeometryConstraint _GeometryConstraint;
  private MVelocityConstraint _VelocityConstraint;
  private MAccelerationConstraint _AccelerationConstraint;

  /// <summary>
  /// 
  /// <seealso cref=".MJointType"/>
  /// </summary>
  public MJointType JointType { get; set; }

  public MGeometryConstraint GeometryConstraint
  {
    get
    {
      return _GeometryConstraint;
    }
    set
    {
      __isset.GeometryConstraint = true;
      this._GeometryConstraint = value;
    }
  }

  public MVelocityConstraint VelocityConstraint
  {
    get
    {
      return _VelocityConstraint;
    }
    set
    {
      __isset.VelocityConstraint = true;
      this._VelocityConstraint = value;
    }
  }

  public MAccelerationConstraint AccelerationConstraint
  {
    get
    {
      return _AccelerationConstraint;
    }
    set
    {
      __isset.AccelerationConstraint = true;
      this._AccelerationConstraint = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool GeometryConstraint;
    public bool VelocityConstraint;
    public bool AccelerationConstraint;
  }

  public MJointConstraint() {
  }

  public MJointConstraint(MJointType JointType) : this() {
    this.JointType = JointType;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_JointType = false;
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
              JointType = (MJointType)iprot.ReadI32();
              isset_JointType = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Struct) {
              GeometryConstraint = new MGeometryConstraint();
              GeometryConstraint.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              VelocityConstraint = new MVelocityConstraint();
              VelocityConstraint.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              AccelerationConstraint = new MAccelerationConstraint();
              AccelerationConstraint.Read(iprot);
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
      if (!isset_JointType)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field JointType not set");
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
      TStruct struc = new TStruct("MJointConstraint");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      field.Name = "JointType";
      field.Type = TType.I32;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32((int)JointType);
      oprot.WriteFieldEnd();
      if (GeometryConstraint != null && __isset.GeometryConstraint) {
        field.Name = "GeometryConstraint";
        field.Type = TType.Struct;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        GeometryConstraint.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (VelocityConstraint != null && __isset.VelocityConstraint) {
        field.Name = "VelocityConstraint";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        VelocityConstraint.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (AccelerationConstraint != null && __isset.AccelerationConstraint) {
        field.Name = "AccelerationConstraint";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        AccelerationConstraint.Write(oprot);
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
    StringBuilder __sb = new StringBuilder("MJointConstraint(");
    __sb.Append(", JointType: ");
    __sb.Append(JointType);
    if (GeometryConstraint != null && __isset.GeometryConstraint) {
      __sb.Append(", GeometryConstraint: ");
      __sb.Append(GeometryConstraint== null ? "<null>" : GeometryConstraint.ToString());
    }
    if (VelocityConstraint != null && __isset.VelocityConstraint) {
      __sb.Append(", VelocityConstraint: ");
      __sb.Append(VelocityConstraint== null ? "<null>" : VelocityConstraint.ToString());
    }
    if (AccelerationConstraint != null && __isset.AccelerationConstraint) {
      __sb.Append(", AccelerationConstraint: ");
      __sb.Append(AccelerationConstraint== null ? "<null>" : AccelerationConstraint.ToString());
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


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
public partial class MVelocityConstraint : TBase
{
  private MTransform _ParentToConstraint;
  private MVector3 _TranslationalVelocity;
  private MVector3 _RotationalVelocity;
  private double _WeightingFactor;

  public string ParentObjectID { get; set; }

  public MTransform ParentToConstraint
  {
    get
    {
      return _ParentToConstraint;
    }
    set
    {
      __isset.ParentToConstraint = true;
      this._ParentToConstraint = value;
    }
  }

  public MVector3 TranslationalVelocity
  {
    get
    {
      return _TranslationalVelocity;
    }
    set
    {
      __isset.TranslationalVelocity = true;
      this._TranslationalVelocity = value;
    }
  }

  public MVector3 RotationalVelocity
  {
    get
    {
      return _RotationalVelocity;
    }
    set
    {
      __isset.RotationalVelocity = true;
      this._RotationalVelocity = value;
    }
  }

  public double WeightingFactor
  {
    get
    {
      return _WeightingFactor;
    }
    set
    {
      __isset.WeightingFactor = true;
      this._WeightingFactor = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool ParentToConstraint;
    public bool TranslationalVelocity;
    public bool RotationalVelocity;
    public bool WeightingFactor;
  }

  public MVelocityConstraint() {
  }

  public MVelocityConstraint(string ParentObjectID) : this() {
    this.ParentObjectID = ParentObjectID;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_ParentObjectID = false;
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
              ParentObjectID = iprot.ReadString();
              isset_ParentObjectID = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Struct) {
              ParentToConstraint = new MTransform();
              ParentToConstraint.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              TranslationalVelocity = new MVector3();
              TranslationalVelocity.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              RotationalVelocity = new MVector3();
              RotationalVelocity.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Double) {
              WeightingFactor = iprot.ReadDouble();
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
      if (!isset_ParentObjectID)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field ParentObjectID not set");
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
      TStruct struc = new TStruct("MVelocityConstraint");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (ParentObjectID == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field ParentObjectID not set");
      field.Name = "ParentObjectID";
      field.Type = TType.String;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(ParentObjectID);
      oprot.WriteFieldEnd();
      if (ParentToConstraint != null && __isset.ParentToConstraint) {
        field.Name = "ParentToConstraint";
        field.Type = TType.Struct;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        ParentToConstraint.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (TranslationalVelocity != null && __isset.TranslationalVelocity) {
        field.Name = "TranslationalVelocity";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        TranslationalVelocity.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (RotationalVelocity != null && __isset.RotationalVelocity) {
        field.Name = "RotationalVelocity";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        RotationalVelocity.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (__isset.WeightingFactor) {
        field.Name = "WeightingFactor";
        field.Type = TType.Double;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(WeightingFactor);
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
    StringBuilder __sb = new StringBuilder("MVelocityConstraint(");
    __sb.Append(", ParentObjectID: ");
    __sb.Append(ParentObjectID);
    if (ParentToConstraint != null && __isset.ParentToConstraint) {
      __sb.Append(", ParentToConstraint: ");
      __sb.Append(ParentToConstraint== null ? "<null>" : ParentToConstraint.ToString());
    }
    if (TranslationalVelocity != null && __isset.TranslationalVelocity) {
      __sb.Append(", TranslationalVelocity: ");
      __sb.Append(TranslationalVelocity== null ? "<null>" : TranslationalVelocity.ToString());
    }
    if (RotationalVelocity != null && __isset.RotationalVelocity) {
      __sb.Append(", RotationalVelocity: ");
      __sb.Append(RotationalVelocity== null ? "<null>" : RotationalVelocity.ToString());
    }
    if (__isset.WeightingFactor) {
      __sb.Append(", WeightingFactor: ");
      __sb.Append(WeightingFactor);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


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
public partial class MCollider : TBase
{
  private MBoxColliderProperties _BoxColliderProperties;
  private MSphereColliderProperties _SphereColliderProperties;
  private MCapsuleColliderProperties _CapsuleColliderProperties;
  private MConeColliderProperties _ConeColliderProperties;
  private MCylinderColliderProperties _CylinderColliderProperties;
  private MMeshColliderProperties _MeshColliderProperties;
  private MVector3 _PositionOffset;
  private MQuaternion _RotationOffset;
  private List<MCollider> _Colliders;
  private Dictionary<string, string> _Properties;

  public string ID { get; set; }

  /// <summary>
  /// 
  /// <seealso cref="MColliderType"/>
  /// </summary>
  public MColliderType Type { get; set; }

  public MBoxColliderProperties BoxColliderProperties
  {
    get
    {
      return _BoxColliderProperties;
    }
    set
    {
      __isset.BoxColliderProperties = true;
      this._BoxColliderProperties = value;
    }
  }

  public MSphereColliderProperties SphereColliderProperties
  {
    get
    {
      return _SphereColliderProperties;
    }
    set
    {
      __isset.SphereColliderProperties = true;
      this._SphereColliderProperties = value;
    }
  }

  public MCapsuleColliderProperties CapsuleColliderProperties
  {
    get
    {
      return _CapsuleColliderProperties;
    }
    set
    {
      __isset.CapsuleColliderProperties = true;
      this._CapsuleColliderProperties = value;
    }
  }

  public MConeColliderProperties ConeColliderProperties
  {
    get
    {
      return _ConeColliderProperties;
    }
    set
    {
      __isset.ConeColliderProperties = true;
      this._ConeColliderProperties = value;
    }
  }

  public MCylinderColliderProperties CylinderColliderProperties
  {
    get
    {
      return _CylinderColliderProperties;
    }
    set
    {
      __isset.CylinderColliderProperties = true;
      this._CylinderColliderProperties = value;
    }
  }

  public MMeshColliderProperties MeshColliderProperties
  {
    get
    {
      return _MeshColliderProperties;
    }
    set
    {
      __isset.MeshColliderProperties = true;
      this._MeshColliderProperties = value;
    }
  }

  public MVector3 PositionOffset
  {
    get
    {
      return _PositionOffset;
    }
    set
    {
      __isset.PositionOffset = true;
      this._PositionOffset = value;
    }
  }

  public MQuaternion RotationOffset
  {
    get
    {
      return _RotationOffset;
    }
    set
    {
      __isset.RotationOffset = true;
      this._RotationOffset = value;
    }
  }

  public List<MCollider> Colliders
  {
    get
    {
      return _Colliders;
    }
    set
    {
      __isset.Colliders = true;
      this._Colliders = value;
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
    public bool BoxColliderProperties;
    public bool SphereColliderProperties;
    public bool CapsuleColliderProperties;
    public bool ConeColliderProperties;
    public bool CylinderColliderProperties;
    public bool MeshColliderProperties;
    public bool PositionOffset;
    public bool RotationOffset;
    public bool Colliders;
    public bool Properties;
  }

  public MCollider() {
  }

  public MCollider(string ID, MColliderType Type) : this() {
    this.ID = ID;
    this.Type = Type;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_ID = false;
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
            if (field.Type == TType.String) {
              ID = iprot.ReadString();
              isset_ID = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              Type = (MColliderType)iprot.ReadI32();
              isset_Type = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              BoxColliderProperties = new MBoxColliderProperties();
              BoxColliderProperties.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              SphereColliderProperties = new MSphereColliderProperties();
              SphereColliderProperties.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Struct) {
              CapsuleColliderProperties = new MCapsuleColliderProperties();
              CapsuleColliderProperties.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.Struct) {
              ConeColliderProperties = new MConeColliderProperties();
              ConeColliderProperties.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.Struct) {
              CylinderColliderProperties = new MCylinderColliderProperties();
              CylinderColliderProperties.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.Struct) {
              MeshColliderProperties = new MMeshColliderProperties();
              MeshColliderProperties.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.Struct) {
              PositionOffset = new MVector3();
              PositionOffset.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.Struct) {
              RotationOffset = new MQuaternion();
              RotationOffset.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.List) {
              {
                Colliders = new List<MCollider>();
                TList _list104 = iprot.ReadListBegin();
                for( int _i105 = 0; _i105 < _list104.Count; ++_i105)
                {
                  MCollider _elem106;
                  _elem106 = new MCollider();
                  _elem106.Read(iprot);
                  Colliders.Add(_elem106);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.Map) {
              {
                Properties = new Dictionary<string, string>();
                TMap _map107 = iprot.ReadMapBegin();
                for( int _i108 = 0; _i108 < _map107.Count; ++_i108)
                {
                  string _key109;
                  string _val110;
                  _key109 = iprot.ReadString();
                  _val110 = iprot.ReadString();
                  Properties[_key109] = _val110;
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
      if (!isset_ID)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field ID not set");
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
      TStruct struc = new TStruct("MCollider");
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
      field.Name = "Type";
      field.Type = TType.I32;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32((int)Type);
      oprot.WriteFieldEnd();
      if (BoxColliderProperties != null && __isset.BoxColliderProperties) {
        field.Name = "BoxColliderProperties";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        BoxColliderProperties.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (SphereColliderProperties != null && __isset.SphereColliderProperties) {
        field.Name = "SphereColliderProperties";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        SphereColliderProperties.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (CapsuleColliderProperties != null && __isset.CapsuleColliderProperties) {
        field.Name = "CapsuleColliderProperties";
        field.Type = TType.Struct;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        CapsuleColliderProperties.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (ConeColliderProperties != null && __isset.ConeColliderProperties) {
        field.Name = "ConeColliderProperties";
        field.Type = TType.Struct;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        ConeColliderProperties.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (CylinderColliderProperties != null && __isset.CylinderColliderProperties) {
        field.Name = "CylinderColliderProperties";
        field.Type = TType.Struct;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        CylinderColliderProperties.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (MeshColliderProperties != null && __isset.MeshColliderProperties) {
        field.Name = "MeshColliderProperties";
        field.Type = TType.Struct;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        MeshColliderProperties.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (PositionOffset != null && __isset.PositionOffset) {
        field.Name = "PositionOffset";
        field.Type = TType.Struct;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        PositionOffset.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (RotationOffset != null && __isset.RotationOffset) {
        field.Name = "RotationOffset";
        field.Type = TType.Struct;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        RotationOffset.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Colliders != null && __isset.Colliders) {
        field.Name = "Colliders";
        field.Type = TType.List;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Colliders.Count));
          foreach (MCollider _iter111 in Colliders)
          {
            _iter111.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Properties != null && __isset.Properties) {
        field.Name = "Properties";
        field.Type = TType.Map;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
          foreach (string _iter112 in Properties.Keys)
          {
            oprot.WriteString(_iter112);
            oprot.WriteString(Properties[_iter112]);
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
    StringBuilder __sb = new StringBuilder("MCollider(");
    __sb.Append(", ID: ");
    __sb.Append(ID);
    __sb.Append(", Type: ");
    __sb.Append(Type);
    if (BoxColliderProperties != null && __isset.BoxColliderProperties) {
      __sb.Append(", BoxColliderProperties: ");
      __sb.Append(BoxColliderProperties== null ? "<null>" : BoxColliderProperties.ToString());
    }
    if (SphereColliderProperties != null && __isset.SphereColliderProperties) {
      __sb.Append(", SphereColliderProperties: ");
      __sb.Append(SphereColliderProperties== null ? "<null>" : SphereColliderProperties.ToString());
    }
    if (CapsuleColliderProperties != null && __isset.CapsuleColliderProperties) {
      __sb.Append(", CapsuleColliderProperties: ");
      __sb.Append(CapsuleColliderProperties== null ? "<null>" : CapsuleColliderProperties.ToString());
    }
    if (ConeColliderProperties != null && __isset.ConeColliderProperties) {
      __sb.Append(", ConeColliderProperties: ");
      __sb.Append(ConeColliderProperties== null ? "<null>" : ConeColliderProperties.ToString());
    }
    if (CylinderColliderProperties != null && __isset.CylinderColliderProperties) {
      __sb.Append(", CylinderColliderProperties: ");
      __sb.Append(CylinderColliderProperties== null ? "<null>" : CylinderColliderProperties.ToString());
    }
    if (MeshColliderProperties != null && __isset.MeshColliderProperties) {
      __sb.Append(", MeshColliderProperties: ");
      __sb.Append(MeshColliderProperties== null ? "<null>" : MeshColliderProperties.ToString());
    }
    if (PositionOffset != null && __isset.PositionOffset) {
      __sb.Append(", PositionOffset: ");
      __sb.Append(PositionOffset== null ? "<null>" : PositionOffset.ToString());
    }
    if (RotationOffset != null && __isset.RotationOffset) {
      __sb.Append(", RotationOffset: ");
      __sb.Append(RotationOffset== null ? "<null>" : RotationOffset.ToString());
    }
    if (Colliders != null && __isset.Colliders) {
      __sb.Append(", Colliders: ");
      __sb.Append(Colliders);
    }
    if (Properties != null && __isset.Properties) {
      __sb.Append(", Properties: ");
      __sb.Append(Properties);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


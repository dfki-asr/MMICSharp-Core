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
public partial class MSceneObject : TBase
{
  private MCollider _Collider;
  private MMesh _Mesh;
  private MPhysicsProperties _PhysicsProperties;
  private Dictionary<string, string> _Properties;
  private List<MAttachment> _Attachments;
  private List<MConstraint> _Constraints;

  public string ID { get; set; }

  public string Name { get; set; }

  public MTransform Transform { get; set; }

  public MCollider Collider
  {
    get
    {
      return _Collider;
    }
    set
    {
      __isset.Collider = true;
      this._Collider = value;
    }
  }

  public MMesh Mesh
  {
    get
    {
      return _Mesh;
    }
    set
    {
      __isset.Mesh = true;
      this._Mesh = value;
    }
  }

  public MPhysicsProperties PhysicsProperties
  {
    get
    {
      return _PhysicsProperties;
    }
    set
    {
      __isset.PhysicsProperties = true;
      this._PhysicsProperties = value;
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

  public List<MAttachment> Attachments
  {
    get
    {
      return _Attachments;
    }
    set
    {
      __isset.Attachments = true;
      this._Attachments = value;
    }
  }

  public List<MConstraint> Constraints
  {
    get
    {
      return _Constraints;
    }
    set
    {
      __isset.Constraints = true;
      this._Constraints = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool Collider;
    public bool Mesh;
    public bool PhysicsProperties;
    public bool Properties;
    public bool Attachments;
    public bool Constraints;
  }

  public MSceneObject() {
  }

  public MSceneObject(string ID, string Name, MTransform Transform) : this() {
    this.ID = ID;
    this.Name = Name;
    this.Transform = Transform;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_ID = false;
      bool isset_Name = false;
      bool isset_Transform = false;
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
            if (field.Type == TType.String) {
              Name = iprot.ReadString();
              isset_Name = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              Transform = new MTransform();
              Transform.Read(iprot);
              isset_Transform = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              Collider = new MCollider();
              Collider.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Struct) {
              Mesh = new MMesh();
              Mesh.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.Struct) {
              PhysicsProperties = new MPhysicsProperties();
              PhysicsProperties.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.Map) {
              {
                Properties = new Dictionary<string, string>();
                TMap _map117 = iprot.ReadMapBegin();
                for( int _i118 = 0; _i118 < _map117.Count; ++_i118)
                {
                  string _key119;
                  string _val120;
                  _key119 = iprot.ReadString();
                  _val120 = iprot.ReadString();
                  Properties[_key119] = _val120;
                }
                iprot.ReadMapEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.List) {
              {
                Attachments = new List<MAttachment>();
                TList _list121 = iprot.ReadListBegin();
                for( int _i122 = 0; _i122 < _list121.Count; ++_i122)
                {
                  MAttachment _elem123;
                  _elem123 = new MAttachment();
                  _elem123.Read(iprot);
                  Attachments.Add(_elem123);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.List) {
              {
                Constraints = new List<MConstraint>();
                TList _list124 = iprot.ReadListBegin();
                for( int _i125 = 0; _i125 < _list124.Count; ++_i125)
                {
                  MConstraint _elem126;
                  _elem126 = new MConstraint();
                  _elem126.Read(iprot);
                  Constraints.Add(_elem126);
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
      if (!isset_ID)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field ID not set");
      if (!isset_Name)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Name not set");
      if (!isset_Transform)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Transform not set");
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
      TStruct struc = new TStruct("MSceneObject");
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
      if (Name == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Name not set");
      field.Name = "Name";
      field.Type = TType.String;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Name);
      oprot.WriteFieldEnd();
      if (Transform == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Transform not set");
      field.Name = "Transform";
      field.Type = TType.Struct;
      field.ID = 3;
      oprot.WriteFieldBegin(field);
      Transform.Write(oprot);
      oprot.WriteFieldEnd();
      if (Collider != null && __isset.Collider) {
        field.Name = "Collider";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        Collider.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Mesh != null && __isset.Mesh) {
        field.Name = "Mesh";
        field.Type = TType.Struct;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        Mesh.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (PhysicsProperties != null && __isset.PhysicsProperties) {
        field.Name = "PhysicsProperties";
        field.Type = TType.Struct;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        PhysicsProperties.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Properties != null && __isset.Properties) {
        field.Name = "Properties";
        field.Type = TType.Map;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
          foreach (string _iter127 in Properties.Keys)
          {
            oprot.WriteString(_iter127);
            oprot.WriteString(Properties[_iter127]);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Attachments != null && __isset.Attachments) {
        field.Name = "Attachments";
        field.Type = TType.List;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Attachments.Count));
          foreach (MAttachment _iter128 in Attachments)
          {
            _iter128.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Constraints != null && __isset.Constraints) {
        field.Name = "Constraints";
        field.Type = TType.List;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Constraints.Count));
          foreach (MConstraint _iter129 in Constraints)
          {
            _iter129.Write(oprot);
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
    StringBuilder __sb = new StringBuilder("MSceneObject(");
    __sb.Append(", ID: ");
    __sb.Append(ID);
    __sb.Append(", Name: ");
    __sb.Append(Name);
    __sb.Append(", Transform: ");
    __sb.Append(Transform== null ? "<null>" : Transform.ToString());
    if (Collider != null && __isset.Collider) {
      __sb.Append(", Collider: ");
      __sb.Append(Collider== null ? "<null>" : Collider.ToString());
    }
    if (Mesh != null && __isset.Mesh) {
      __sb.Append(", Mesh: ");
      __sb.Append(Mesh== null ? "<null>" : Mesh.ToString());
    }
    if (PhysicsProperties != null && __isset.PhysicsProperties) {
      __sb.Append(", PhysicsProperties: ");
      __sb.Append(PhysicsProperties== null ? "<null>" : PhysicsProperties.ToString());
    }
    if (Properties != null && __isset.Properties) {
      __sb.Append(", Properties: ");
      __sb.Append(Properties);
    }
    if (Attachments != null && __isset.Attachments) {
      __sb.Append(", Attachments: ");
      __sb.Append(Attachments);
    }
    if (Constraints != null && __isset.Constraints) {
      __sb.Append(", Constraints: ");
      __sb.Append(Constraints);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


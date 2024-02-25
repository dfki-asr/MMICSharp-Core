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
public partial class MAvatarUpdate : TBase
{
  private MAvatarPostureValues _PostureValues;
  private List<string> _SceneObjects;
  private MAvatarDescription _Description;
  private List<MPropertyUpdate> _Properties;

  public string ID { get; set; }

  public MAvatarPostureValues PostureValues
  {
    get
    {
      return _PostureValues;
    }
    set
    {
      __isset.PostureValues = true;
      this._PostureValues = value;
    }
  }

  public List<string> SceneObjects
  {
    get
    {
      return _SceneObjects;
    }
    set
    {
      __isset.SceneObjects = true;
      this._SceneObjects = value;
    }
  }

  public MAvatarDescription Description
  {
    get
    {
      return _Description;
    }
    set
    {
      __isset.Description = true;
      this._Description = value;
    }
  }

  public List<MPropertyUpdate> Properties
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
    public bool PostureValues;
    public bool SceneObjects;
    public bool Description;
    public bool Properties;
  }

  public MAvatarUpdate() {
  }

  public MAvatarUpdate(string ID) : this() {
    this.ID = ID;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_ID = false;
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
            if (field.Type == TType.Struct) {
              PostureValues = new MAvatarPostureValues();
              PostureValues.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.List) {
              {
                SceneObjects = new List<string>();
                TList _list170 = iprot.ReadListBegin();
                for( int _i171 = 0; _i171 < _list170.Count; ++_i171)
                {
                  string _elem172;
                  _elem172 = iprot.ReadString();
                  SceneObjects.Add(_elem172);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              Description = new MAvatarDescription();
              Description.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.List) {
              {
                Properties = new List<MPropertyUpdate>();
                TList _list173 = iprot.ReadListBegin();
                for( int _i174 = 0; _i174 < _list173.Count; ++_i174)
                {
                  MPropertyUpdate _elem175;
                  _elem175 = new MPropertyUpdate();
                  _elem175.Read(iprot);
                  Properties.Add(_elem175);
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
      TStruct struc = new TStruct("MAvatarUpdate");
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
      if (PostureValues != null && __isset.PostureValues) {
        field.Name = "PostureValues";
        field.Type = TType.Struct;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        PostureValues.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (SceneObjects != null && __isset.SceneObjects) {
        field.Name = "SceneObjects";
        field.Type = TType.List;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, SceneObjects.Count));
          foreach (string _iter176 in SceneObjects)
          {
            oprot.WriteString(_iter176);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Description != null && __isset.Description) {
        field.Name = "Description";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        Description.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Properties != null && __isset.Properties) {
        field.Name = "Properties";
        field.Type = TType.List;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Properties.Count));
          foreach (MPropertyUpdate _iter177 in Properties)
          {
            _iter177.Write(oprot);
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
    StringBuilder __sb = new StringBuilder("MAvatarUpdate(");
    __sb.Append(", ID: ");
    __sb.Append(ID);
    if (PostureValues != null && __isset.PostureValues) {
      __sb.Append(", PostureValues: ");
      __sb.Append(PostureValues== null ? "<null>" : PostureValues.ToString());
    }
    if (SceneObjects != null && __isset.SceneObjects) {
      __sb.Append(", SceneObjects: ");
      __sb.Append(SceneObjects);
    }
    if (Description != null && __isset.Description) {
      __sb.Append(", Description: ");
      __sb.Append(Description== null ? "<null>" : Description.ToString());
    }
    if (Properties != null && __isset.Properties) {
      __sb.Append(", Properties: ");
      __sb.Append(Properties);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


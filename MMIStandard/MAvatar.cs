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
public partial class MAvatar : TBase
{
  private List<string> _SceneObjects;
  private Dictionary<string, string> _Properties;

  public string ID { get; set; }

  public string Name { get; set; }

  public MAvatarDescription Description { get; set; }

  public MAvatarPostureValues PostureValues { get; set; }

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
    public bool SceneObjects;
    public bool Properties;
  }

  public MAvatar() {
  }

  public MAvatar(string ID, string Name, MAvatarDescription Description, MAvatarPostureValues PostureValues) : this() {
    this.ID = ID;
    this.Name = Name;
    this.Description = Description;
    this.PostureValues = PostureValues;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_ID = false;
      bool isset_Name = false;
      bool isset_Description = false;
      bool isset_PostureValues = false;
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
              Description = new MAvatarDescription();
              Description.Read(iprot);
              isset_Description = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              PostureValues = new MAvatarPostureValues();
              PostureValues.Read(iprot);
              isset_PostureValues = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.List) {
              {
                SceneObjects = new List<string>();
                TList _list30 = iprot.ReadListBegin();
                for( int _i31 = 0; _i31 < _list30.Count; ++_i31)
                {
                  string _elem32;
                  _elem32 = iprot.ReadString();
                  SceneObjects.Add(_elem32);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.Map) {
              {
                Properties = new Dictionary<string, string>();
                TMap _map33 = iprot.ReadMapBegin();
                for( int _i34 = 0; _i34 < _map33.Count; ++_i34)
                {
                  string _key35;
                  string _val36;
                  _key35 = iprot.ReadString();
                  _val36 = iprot.ReadString();
                  Properties[_key35] = _val36;
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
      if (!isset_Name)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Name not set");
      if (!isset_Description)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Description not set");
      if (!isset_PostureValues)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field PostureValues not set");
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
      TStruct struc = new TStruct("MAvatar");
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
      if (Description == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Description not set");
      field.Name = "Description";
      field.Type = TType.Struct;
      field.ID = 3;
      oprot.WriteFieldBegin(field);
      Description.Write(oprot);
      oprot.WriteFieldEnd();
      if (PostureValues == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field PostureValues not set");
      field.Name = "PostureValues";
      field.Type = TType.Struct;
      field.ID = 4;
      oprot.WriteFieldBegin(field);
      PostureValues.Write(oprot);
      oprot.WriteFieldEnd();
      if (SceneObjects != null && __isset.SceneObjects) {
        field.Name = "SceneObjects";
        field.Type = TType.List;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, SceneObjects.Count));
          foreach (string _iter37 in SceneObjects)
          {
            oprot.WriteString(_iter37);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Properties != null && __isset.Properties) {
        field.Name = "Properties";
        field.Type = TType.Map;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
          foreach (string _iter38 in Properties.Keys)
          {
            oprot.WriteString(_iter38);
            oprot.WriteString(Properties[_iter38]);
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
    StringBuilder __sb = new StringBuilder("MAvatar(");
    __sb.Append(", ID: ");
    __sb.Append(ID);
    __sb.Append(", Name: ");
    __sb.Append(Name);
    __sb.Append(", Description: ");
    __sb.Append(Description== null ? "<null>" : Description.ToString());
    __sb.Append(", PostureValues: ");
    __sb.Append(PostureValues== null ? "<null>" : PostureValues.ToString());
    if (SceneObjects != null && __isset.SceneObjects) {
      __sb.Append(", SceneObjects: ");
      __sb.Append(SceneObjects);
    }
    if (Properties != null && __isset.Properties) {
      __sb.Append(", Properties: ");
      __sb.Append(Properties);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


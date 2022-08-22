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
public partial class MMesh : TBase
{
  private List<MVector2> _UVCoordinates;
  private Dictionary<string, string> _Properties;

  public string ID { get; set; }

  public List<MVector3> Vertices { get; set; }

  public List<int> Triangles { get; set; }

  public List<MVector2> UVCoordinates
  {
    get
    {
      return _UVCoordinates;
    }
    set
    {
      __isset.UVCoordinates = true;
      this._UVCoordinates = value;
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
    public bool UVCoordinates;
    public bool Properties;
  }

  public MMesh() {
  }

  public MMesh(string ID, List<MVector3> Vertices, List<int> Triangles) : this() {
    this.ID = ID;
    this.Vertices = Vertices;
    this.Triangles = Triangles;
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_ID = false;
      bool isset_Vertices = false;
      bool isset_Triangles = false;
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
            if (field.Type == TType.List) {
              {
                Vertices = new List<MVector3>();
                TList _list40 = iprot.ReadListBegin();
                for( int _i41 = 0; _i41 < _list40.Count; ++_i41)
                {
                  MVector3 _elem42;
                  _elem42 = new MVector3();
                  _elem42.Read(iprot);
                  Vertices.Add(_elem42);
                }
                iprot.ReadListEnd();
              }
              isset_Vertices = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.List) {
              {
                Triangles = new List<int>();
                TList _list43 = iprot.ReadListBegin();
                for( int _i44 = 0; _i44 < _list43.Count; ++_i44)
                {
                  int _elem45;
                  _elem45 = iprot.ReadI32();
                  Triangles.Add(_elem45);
                }
                iprot.ReadListEnd();
              }
              isset_Triangles = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.List) {
              {
                UVCoordinates = new List<MVector2>();
                TList _list46 = iprot.ReadListBegin();
                for( int _i47 = 0; _i47 < _list46.Count; ++_i47)
                {
                  MVector2 _elem48;
                  _elem48 = new MVector2();
                  _elem48.Read(iprot);
                  UVCoordinates.Add(_elem48);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Map) {
              {
                Properties = new Dictionary<string, string>();
                TMap _map49 = iprot.ReadMapBegin();
                for( int _i50 = 0; _i50 < _map49.Count; ++_i50)
                {
                  string _key51;
                  string _val52;
                  _key51 = iprot.ReadString();
                  _val52 = iprot.ReadString();
                  Properties[_key51] = _val52;
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
      if (!isset_Vertices)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Vertices not set");
      if (!isset_Triangles)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Triangles not set");
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
      TStruct struc = new TStruct("MMesh");
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
      if (Vertices == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Vertices not set");
      field.Name = "Vertices";
      field.Type = TType.List;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      {
        oprot.WriteListBegin(new TList(TType.Struct, Vertices.Count));
        foreach (MVector3 _iter53 in Vertices)
        {
          _iter53.Write(oprot);
        }
        oprot.WriteListEnd();
      }
      oprot.WriteFieldEnd();
      if (Triangles == null)
        throw new TProtocolException(TProtocolException.INVALID_DATA, "required field Triangles not set");
      field.Name = "Triangles";
      field.Type = TType.List;
      field.ID = 3;
      oprot.WriteFieldBegin(field);
      {
        oprot.WriteListBegin(new TList(TType.I32, Triangles.Count));
        foreach (int _iter54 in Triangles)
        {
          oprot.WriteI32(_iter54);
        }
        oprot.WriteListEnd();
      }
      oprot.WriteFieldEnd();
      if (UVCoordinates != null && __isset.UVCoordinates) {
        field.Name = "UVCoordinates";
        field.Type = TType.List;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, UVCoordinates.Count));
          foreach (MVector2 _iter55 in UVCoordinates)
          {
            _iter55.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Properties != null && __isset.Properties) {
        field.Name = "Properties";
        field.Type = TType.Map;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
          foreach (string _iter56 in Properties.Keys)
          {
            oprot.WriteString(_iter56);
            oprot.WriteString(Properties[_iter56]);
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
    StringBuilder __sb = new StringBuilder("MMesh(");
    __sb.Append(", ID: ");
    __sb.Append(ID);
    __sb.Append(", Vertices: ");
    __sb.Append(Vertices);
    __sb.Append(", Triangles: ");
    __sb.Append(Triangles);
    if (UVCoordinates != null && __isset.UVCoordinates) {
      __sb.Append(", UVCoordinates: ");
      __sb.Append(UVCoordinates);
    }
    if (Properties != null && __isset.Properties) {
      __sb.Append(", Properties: ");
      __sb.Append(Properties);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}


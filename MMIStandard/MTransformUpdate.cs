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

namespace MMIStandard
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class MTransformUpdate : TBase
  {
    private List<double> _Position;
    private List<double> _Rotation;
    private string _Parent;

    public List<double> Position
    {
      get
      {
        return _Position;
      }
      set
      {
        __isset.Position = true;
        this._Position = value;
      }
    }

    public List<double> Rotation
    {
      get
      {
        return _Rotation;
      }
      set
      {
        __isset.Rotation = true;
        this._Rotation = value;
      }
    }

    public string Parent
    {
      get
      {
        return _Parent;
      }
      set
      {
        __isset.Parent = true;
        this._Parent = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Position;
      public bool Rotation;
      public bool Parent;
    }

    public MTransformUpdate() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
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
                  Position = new List<double>();
                  TList _list0 = iprot.ReadListBegin();
                  for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                  {
                    double _elem2;
                    _elem2 = iprot.ReadDouble();
                    Position.Add(_elem2);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.List) {
                {
                  Rotation = new List<double>();
                  TList _list3 = iprot.ReadListBegin();
                  for( int _i4 = 0; _i4 < _list3.Count; ++_i4)
                  {
                    double _elem5;
                    _elem5 = iprot.ReadDouble();
                    Rotation.Add(_elem5);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Parent = iprot.ReadString();
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
        TStruct struc = new TStruct("MTransformUpdate");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Position != null && __isset.Position) {
          field.Name = "Position";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Double, Position.Count));
            foreach (double _iter6 in Position)
            {
              oprot.WriteDouble(_iter6);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Rotation != null && __isset.Rotation) {
          field.Name = "Rotation";
          field.Type = TType.List;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Double, Rotation.Count));
            foreach (double _iter7 in Rotation)
            {
              oprot.WriteDouble(_iter7);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Parent != null && __isset.Parent) {
          field.Name = "Parent";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Parent);
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
      StringBuilder __sb = new StringBuilder("MTransformUpdate(");
      bool __first = true;
      if (Position != null && __isset.Position) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Position: ");
        __sb.Append(Position);
      }
      if (Rotation != null && __isset.Rotation) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Rotation: ");
        __sb.Append(Rotation);
      }
      if (Parent != null && __isset.Parent) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Parent: ");
        __sb.Append(Parent);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}

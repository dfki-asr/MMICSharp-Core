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

public partial class MPathPlanningService {
  public interface ISync : MMIServiceBase.ISync {
    MPathConstraint ComputePath(MVector start, MVector goal, List<MSceneObject> sceneObjects, Dictionary<string, string> properties);
  }

  public interface Iface : ISync {
    #if SILVERLIGHT
    IAsyncResult Begin_ComputePath(AsyncCallback callback, object state, MVector start, MVector goal, List<MSceneObject> sceneObjects, Dictionary<string, string> properties);
    MPathConstraint End_ComputePath(IAsyncResult asyncResult);
    #endif
  }

  public class Client : MMIServiceBase.Client, Iface {
    public Client(TProtocol prot) : this(prot, prot)
    {
    }

    public Client(TProtocol iprot, TProtocol oprot) : base(iprot, oprot)
    {
    }

    
    #if SILVERLIGHT
    
    public IAsyncResult Begin_ComputePath(AsyncCallback callback, object state, MVector start, MVector goal, List<MSceneObject> sceneObjects, Dictionary<string, string> properties)
    {
      return send_ComputePath(callback, state, start, goal, sceneObjects, properties);
    }

    public MPathConstraint End_ComputePath(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_ComputePath();
    }

    #endif

    public MPathConstraint ComputePath(MVector start, MVector goal, List<MSceneObject> sceneObjects, Dictionary<string, string> properties)
    {
      #if SILVERLIGHT
      var asyncResult = Begin_ComputePath(null, null, start, goal, sceneObjects, properties);
      return End_ComputePath(asyncResult);

      #else
      send_ComputePath(start, goal, sceneObjects, properties);
      return recv_ComputePath();

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_ComputePath(AsyncCallback callback, object state, MVector start, MVector goal, List<MSceneObject> sceneObjects, Dictionary<string, string> properties)
    {
      oprot_.WriteMessageBegin(new TMessage("ComputePath", TMessageType.Call, seqid_));
      ComputePath_args args = new ComputePath_args();
      args.Start = start;
      args.Goal = goal;
      args.SceneObjects = sceneObjects;
      args.Properties = properties;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      return oprot_.Transport.BeginFlush(callback, state);
    }

    #else

    public void send_ComputePath(MVector start, MVector goal, List<MSceneObject> sceneObjects, Dictionary<string, string> properties)
    {
      oprot_.WriteMessageBegin(new TMessage("ComputePath", TMessageType.Call, seqid_));
      ComputePath_args args = new ComputePath_args();
      args.Start = start;
      args.Goal = goal;
      args.SceneObjects = sceneObjects;
      args.Properties = properties;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      oprot_.Transport.Flush();
    }
    #endif

    public MPathConstraint recv_ComputePath()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      ComputePath_result result = new ComputePath_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.success) {
        return result.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "ComputePath failed: unknown result");
    }

  }
  public class Processor : MMIServiceBase.Processor, TProcessor {
    public Processor(ISync iface) : base(iface)
    {
      iface_ = iface;
      processMap_["ComputePath"] = ComputePath_Process;
    }

    private ISync iface_;

    public new bool Process(TProtocol iprot, TProtocol oprot)
    {
      try
      {
        TMessage msg = iprot.ReadMessageBegin();
        ProcessFunction fn;
        processMap_.TryGetValue(msg.Name, out fn);
        if (fn == null) {
          TProtocolUtil.Skip(iprot, TType.Struct);
          iprot.ReadMessageEnd();
          TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
          oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
          x.Write(oprot);
          oprot.WriteMessageEnd();
          oprot.Transport.Flush();
          return true;
        }
        fn(msg.SeqID, iprot, oprot);
      }
      catch (IOException)
      {
        return false;
      }
      return true;
    }

    public void ComputePath_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      ComputePath_args args = new ComputePath_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      ComputePath_result result = new ComputePath_result();
      try
      {
        result.Success = iface_.ComputePath(args.Start, args.Goal, args.SceneObjects, args.Properties);
        oprot.WriteMessageBegin(new TMessage("ComputePath", TMessageType.Reply, seqid)); 
        result.Write(oprot);
      }
      catch (TTransportException)
      {
        throw;
      }
      catch (Exception ex)
      {
        Console.Error.WriteLine("Error occurred in processor:");
        Console.Error.WriteLine(ex.ToString());
        TApplicationException x = new TApplicationException      (TApplicationException.ExceptionType.InternalError," Internal error.");
        oprot.WriteMessageBegin(new TMessage("ComputePath", TMessageType.Exception, seqid));
        x.Write(oprot);
      }
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ComputePath_args : TBase
  {
    private MVector _start;
    private MVector _goal;
    private List<MSceneObject> _sceneObjects;
    private Dictionary<string, string> _properties;

    public MVector Start
    {
      get
      {
        return _start;
      }
      set
      {
        __isset.start = true;
        this._start = value;
      }
    }

    public MVector Goal
    {
      get
      {
        return _goal;
      }
      set
      {
        __isset.goal = true;
        this._goal = value;
      }
    }

    public List<MSceneObject> SceneObjects
    {
      get
      {
        return _sceneObjects;
      }
      set
      {
        __isset.sceneObjects = true;
        this._sceneObjects = value;
      }
    }

    public Dictionary<string, string> Properties
    {
      get
      {
        return _properties;
      }
      set
      {
        __isset.properties = true;
        this._properties = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool start;
      public bool goal;
      public bool sceneObjects;
      public bool properties;
    }

    public ComputePath_args() {
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
              if (field.Type == TType.Struct) {
                Start = new MVector();
                Start.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.Struct) {
                Goal = new MVector();
                Goal.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.List) {
                {
                  SceneObjects = new List<MSceneObject>();
                  TList _list140 = iprot.ReadListBegin();
                  for( int _i141 = 0; _i141 < _list140.Count; ++_i141)
                  {
                    MSceneObject _elem142;
                    _elem142 = new MSceneObject();
                    _elem142.Read(iprot);
                    SceneObjects.Add(_elem142);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Map) {
                {
                  Properties = new Dictionary<string, string>();
                  TMap _map143 = iprot.ReadMapBegin();
                  for( int _i144 = 0; _i144 < _map143.Count; ++_i144)
                  {
                    string _key145;
                    string _val146;
                    _key145 = iprot.ReadString();
                    _val146 = iprot.ReadString();
                    Properties[_key145] = _val146;
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
        TStruct struc = new TStruct("ComputePath_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Start != null && __isset.start) {
          field.Name = "start";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          Start.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (Goal != null && __isset.goal) {
          field.Name = "goal";
          field.Type = TType.Struct;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          Goal.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (SceneObjects != null && __isset.sceneObjects) {
          field.Name = "sceneObjects";
          field.Type = TType.List;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, SceneObjects.Count));
            foreach (MSceneObject _iter147 in SceneObjects)
            {
              _iter147.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Properties != null && __isset.properties) {
          field.Name = "properties";
          field.Type = TType.Map;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
            foreach (string _iter148 in Properties.Keys)
            {
              oprot.WriteString(_iter148);
              oprot.WriteString(Properties[_iter148]);
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
      StringBuilder __sb = new StringBuilder("ComputePath_args(");
      bool __first = true;
      if (Start != null && __isset.start) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Start: ");
        __sb.Append(Start== null ? "<null>" : Start.ToString());
      }
      if (Goal != null && __isset.goal) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Goal: ");
        __sb.Append(Goal== null ? "<null>" : Goal.ToString());
      }
      if (SceneObjects != null && __isset.sceneObjects) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SceneObjects: ");
        __sb.Append(SceneObjects);
      }
      if (Properties != null && __isset.properties) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Properties: ");
        __sb.Append(Properties);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ComputePath_result : TBase
  {
    private MPathConstraint _success;

    public MPathConstraint Success
    {
      get
      {
        return _success;
      }
      set
      {
        __isset.success = true;
        this._success = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool success;
    }

    public ComputePath_result() {
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
            case 0:
              if (field.Type == TType.Struct) {
                Success = new MPathConstraint();
                Success.Read(iprot);
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
        TStruct struc = new TStruct("ComputePath_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          if (Success != null) {
            field.Name = "Success";
            field.Type = TType.Struct;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            Success.Write(oprot);
            oprot.WriteFieldEnd();
          }
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
      StringBuilder __sb = new StringBuilder("ComputePath_result(");
      bool __first = true;
      if (Success != null && __isset.success) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Success: ");
        __sb.Append(Success== null ? "<null>" : Success.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}

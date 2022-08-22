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

public partial class MRetargetingService {
  public interface ISync : MMIServiceBase.ISync {
    MAvatarDescription SetupRetargeting(MAvatarPosture globalTarget);
    MAvatarPostureValues RetargetToIntermediate(MAvatarPosture globalTarget);
    MAvatarPosture RetargetToTarget(MAvatarPostureValues intermediatePostureValues);
  }

  public interface Iface : ISync {
    #if SILVERLIGHT
    IAsyncResult Begin_SetupRetargeting(AsyncCallback callback, object state, MAvatarPosture globalTarget);
    MAvatarDescription End_SetupRetargeting(IAsyncResult asyncResult);
    #endif
    #if SILVERLIGHT
    IAsyncResult Begin_RetargetToIntermediate(AsyncCallback callback, object state, MAvatarPosture globalTarget);
    MAvatarPostureValues End_RetargetToIntermediate(IAsyncResult asyncResult);
    #endif
    #if SILVERLIGHT
    IAsyncResult Begin_RetargetToTarget(AsyncCallback callback, object state, MAvatarPostureValues intermediatePostureValues);
    MAvatarPosture End_RetargetToTarget(IAsyncResult asyncResult);
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
    
    public IAsyncResult Begin_SetupRetargeting(AsyncCallback callback, object state, MAvatarPosture globalTarget)
    {
      return send_SetupRetargeting(callback, state, globalTarget);
    }

    public MAvatarDescription End_SetupRetargeting(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_SetupRetargeting();
    }

    #endif

    public MAvatarDescription SetupRetargeting(MAvatarPosture globalTarget)
    {
      #if SILVERLIGHT
      var asyncResult = Begin_SetupRetargeting(null, null, globalTarget);
      return End_SetupRetargeting(asyncResult);

      #else
      send_SetupRetargeting(globalTarget);
      return recv_SetupRetargeting();

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_SetupRetargeting(AsyncCallback callback, object state, MAvatarPosture globalTarget)
    {
      oprot_.WriteMessageBegin(new TMessage("SetupRetargeting", TMessageType.Call, seqid_));
      SetupRetargeting_args args = new SetupRetargeting_args();
      args.GlobalTarget = globalTarget;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      return oprot_.Transport.BeginFlush(callback, state);
    }

    #else

    public void send_SetupRetargeting(MAvatarPosture globalTarget)
    {
      oprot_.WriteMessageBegin(new TMessage("SetupRetargeting", TMessageType.Call, seqid_));
      SetupRetargeting_args args = new SetupRetargeting_args();
      args.GlobalTarget = globalTarget;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      oprot_.Transport.Flush();
    }
    #endif

    public MAvatarDescription recv_SetupRetargeting()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      SetupRetargeting_result result = new SetupRetargeting_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.success) {
        return result.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "SetupRetargeting failed: unknown result");
    }

    
    #if SILVERLIGHT
    
    public IAsyncResult Begin_RetargetToIntermediate(AsyncCallback callback, object state, MAvatarPosture globalTarget)
    {
      return send_RetargetToIntermediate(callback, state, globalTarget);
    }

    public MAvatarPostureValues End_RetargetToIntermediate(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_RetargetToIntermediate();
    }

    #endif

    public MAvatarPostureValues RetargetToIntermediate(MAvatarPosture globalTarget)
    {
      #if SILVERLIGHT
      var asyncResult = Begin_RetargetToIntermediate(null, null, globalTarget);
      return End_RetargetToIntermediate(asyncResult);

      #else
      send_RetargetToIntermediate(globalTarget);
      return recv_RetargetToIntermediate();

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_RetargetToIntermediate(AsyncCallback callback, object state, MAvatarPosture globalTarget)
    {
      oprot_.WriteMessageBegin(new TMessage("RetargetToIntermediate", TMessageType.Call, seqid_));
      RetargetToIntermediate_args args = new RetargetToIntermediate_args();
      args.GlobalTarget = globalTarget;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      return oprot_.Transport.BeginFlush(callback, state);
    }

    #else

    public void send_RetargetToIntermediate(MAvatarPosture globalTarget)
    {
      oprot_.WriteMessageBegin(new TMessage("RetargetToIntermediate", TMessageType.Call, seqid_));
      RetargetToIntermediate_args args = new RetargetToIntermediate_args();
      args.GlobalTarget = globalTarget;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      oprot_.Transport.Flush();
    }
    #endif

    public MAvatarPostureValues recv_RetargetToIntermediate()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      RetargetToIntermediate_result result = new RetargetToIntermediate_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.success) {
        return result.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "RetargetToIntermediate failed: unknown result");
    }

    
    #if SILVERLIGHT
    
    public IAsyncResult Begin_RetargetToTarget(AsyncCallback callback, object state, MAvatarPostureValues intermediatePostureValues)
    {
      return send_RetargetToTarget(callback, state, intermediatePostureValues);
    }

    public MAvatarPosture End_RetargetToTarget(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_RetargetToTarget();
    }

    #endif

    public MAvatarPosture RetargetToTarget(MAvatarPostureValues intermediatePostureValues)
    {
      #if SILVERLIGHT
      var asyncResult = Begin_RetargetToTarget(null, null, intermediatePostureValues);
      return End_RetargetToTarget(asyncResult);

      #else
      send_RetargetToTarget(intermediatePostureValues);
      return recv_RetargetToTarget();

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_RetargetToTarget(AsyncCallback callback, object state, MAvatarPostureValues intermediatePostureValues)
    {
      oprot_.WriteMessageBegin(new TMessage("RetargetToTarget", TMessageType.Call, seqid_));
      RetargetToTarget_args args = new RetargetToTarget_args();
      args.IntermediatePostureValues = intermediatePostureValues;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      return oprot_.Transport.BeginFlush(callback, state);
    }

    #else

    public void send_RetargetToTarget(MAvatarPostureValues intermediatePostureValues)
    {
      oprot_.WriteMessageBegin(new TMessage("RetargetToTarget", TMessageType.Call, seqid_));
      RetargetToTarget_args args = new RetargetToTarget_args();
      args.IntermediatePostureValues = intermediatePostureValues;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      oprot_.Transport.Flush();
    }
    #endif

    public MAvatarPosture recv_RetargetToTarget()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      RetargetToTarget_result result = new RetargetToTarget_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.success) {
        return result.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "RetargetToTarget failed: unknown result");
    }

  }
  public class Processor : MMIServiceBase.Processor, TProcessor {
    public Processor(ISync iface) : base(iface)
    {
      iface_ = iface;
      processMap_["SetupRetargeting"] = SetupRetargeting_Process;
      processMap_["RetargetToIntermediate"] = RetargetToIntermediate_Process;
      processMap_["RetargetToTarget"] = RetargetToTarget_Process;
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

    public void SetupRetargeting_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      SetupRetargeting_args args = new SetupRetargeting_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      SetupRetargeting_result result = new SetupRetargeting_result();
      try
      {
        result.Success = iface_.SetupRetargeting(args.GlobalTarget);
        oprot.WriteMessageBegin(new TMessage("SetupRetargeting", TMessageType.Reply, seqid)); 
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
        oprot.WriteMessageBegin(new TMessage("SetupRetargeting", TMessageType.Exception, seqid));
        x.Write(oprot);
      }
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

    public void RetargetToIntermediate_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      RetargetToIntermediate_args args = new RetargetToIntermediate_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      RetargetToIntermediate_result result = new RetargetToIntermediate_result();
      try
      {
        result.Success = iface_.RetargetToIntermediate(args.GlobalTarget);
        oprot.WriteMessageBegin(new TMessage("RetargetToIntermediate", TMessageType.Reply, seqid)); 
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
        oprot.WriteMessageBegin(new TMessage("RetargetToIntermediate", TMessageType.Exception, seqid));
        x.Write(oprot);
      }
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

    public void RetargetToTarget_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      RetargetToTarget_args args = new RetargetToTarget_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      RetargetToTarget_result result = new RetargetToTarget_result();
      try
      {
        result.Success = iface_.RetargetToTarget(args.IntermediatePostureValues);
        oprot.WriteMessageBegin(new TMessage("RetargetToTarget", TMessageType.Reply, seqid)); 
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
        oprot.WriteMessageBegin(new TMessage("RetargetToTarget", TMessageType.Exception, seqid));
        x.Write(oprot);
      }
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class SetupRetargeting_args : TBase
  {
    private MAvatarPosture _globalTarget;

    public MAvatarPosture GlobalTarget
    {
      get
      {
        return _globalTarget;
      }
      set
      {
        __isset.globalTarget = true;
        this._globalTarget = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool globalTarget;
    }

    public SetupRetargeting_args() {
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
                GlobalTarget = new MAvatarPosture();
                GlobalTarget.Read(iprot);
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
        TStruct struc = new TStruct("SetupRetargeting_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (GlobalTarget != null && __isset.globalTarget) {
          field.Name = "globalTarget";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          GlobalTarget.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("SetupRetargeting_args(");
      bool __first = true;
      if (GlobalTarget != null && __isset.globalTarget) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("GlobalTarget: ");
        __sb.Append(GlobalTarget== null ? "<null>" : GlobalTarget.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class SetupRetargeting_result : TBase
  {
    private MAvatarDescription _success;

    public MAvatarDescription Success
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

    public SetupRetargeting_result() {
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
                Success = new MAvatarDescription();
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
        TStruct struc = new TStruct("SetupRetargeting_result");
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
      StringBuilder __sb = new StringBuilder("SetupRetargeting_result(");
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


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class RetargetToIntermediate_args : TBase
  {
    private MAvatarPosture _globalTarget;

    public MAvatarPosture GlobalTarget
    {
      get
      {
        return _globalTarget;
      }
      set
      {
        __isset.globalTarget = true;
        this._globalTarget = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool globalTarget;
    }

    public RetargetToIntermediate_args() {
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
                GlobalTarget = new MAvatarPosture();
                GlobalTarget.Read(iprot);
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
        TStruct struc = new TStruct("RetargetToIntermediate_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (GlobalTarget != null && __isset.globalTarget) {
          field.Name = "globalTarget";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          GlobalTarget.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("RetargetToIntermediate_args(");
      bool __first = true;
      if (GlobalTarget != null && __isset.globalTarget) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("GlobalTarget: ");
        __sb.Append(GlobalTarget== null ? "<null>" : GlobalTarget.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class RetargetToIntermediate_result : TBase
  {
    private MAvatarPostureValues _success;

    public MAvatarPostureValues Success
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

    public RetargetToIntermediate_result() {
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
                Success = new MAvatarPostureValues();
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
        TStruct struc = new TStruct("RetargetToIntermediate_result");
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
      StringBuilder __sb = new StringBuilder("RetargetToIntermediate_result(");
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


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class RetargetToTarget_args : TBase
  {
    private MAvatarPostureValues _intermediatePostureValues;

    public MAvatarPostureValues IntermediatePostureValues
    {
      get
      {
        return _intermediatePostureValues;
      }
      set
      {
        __isset.intermediatePostureValues = true;
        this._intermediatePostureValues = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool intermediatePostureValues;
    }

    public RetargetToTarget_args() {
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
                IntermediatePostureValues = new MAvatarPostureValues();
                IntermediatePostureValues.Read(iprot);
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
        TStruct struc = new TStruct("RetargetToTarget_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (IntermediatePostureValues != null && __isset.intermediatePostureValues) {
          field.Name = "intermediatePostureValues";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          IntermediatePostureValues.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("RetargetToTarget_args(");
      bool __first = true;
      if (IntermediatePostureValues != null && __isset.intermediatePostureValues) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IntermediatePostureValues: ");
        __sb.Append(IntermediatePostureValues== null ? "<null>" : IntermediatePostureValues.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class RetargetToTarget_result : TBase
  {
    private MAvatarPosture _success;

    public MAvatarPosture Success
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

    public RetargetToTarget_result() {
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
                Success = new MAvatarPosture();
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
        TStruct struc = new TStruct("RetargetToTarget_result");
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
      StringBuilder __sb = new StringBuilder("RetargetToTarget_result(");
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

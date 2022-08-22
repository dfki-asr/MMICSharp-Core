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

public partial class MCoSimulationEventCallback {
  public interface ISync {
    void OnEvent(MCoSimulationEvents @event);
    void OnFrameEnd(MAvatarPostureValues newPosture);
  }

  public interface Iface : ISync {
    #if SILVERLIGHT
    IAsyncResult Begin_OnEvent(AsyncCallback callback, object state, MCoSimulationEvents @event);
    void End_OnEvent(IAsyncResult asyncResult);
    #endif
    #if SILVERLIGHT
    IAsyncResult Begin_OnFrameEnd(AsyncCallback callback, object state, MAvatarPostureValues newPosture);
    void End_OnFrameEnd(IAsyncResult asyncResult);
    #endif
  }

  public class Client : IDisposable, Iface {
    public Client(TProtocol prot) : this(prot, prot)
    {
    }

    public Client(TProtocol iprot, TProtocol oprot)
    {
      iprot_ = iprot;
      oprot_ = oprot;
    }

    protected TProtocol iprot_;
    protected TProtocol oprot_;
    protected int seqid_;

    public TProtocol InputProtocol
    {
      get { return iprot_; }
    }
    public TProtocol OutputProtocol
    {
      get { return oprot_; }
    }


    #region " IDisposable Support "
    private bool _IsDisposed;

    // IDisposable
    public void Dispose()
    {
      Dispose(true);
    }
    

    protected virtual void Dispose(bool disposing)
    {
      if (!_IsDisposed)
      {
        if (disposing)
        {
          if (iprot_ != null)
          {
            ((IDisposable)iprot_).Dispose();
          }
          if (oprot_ != null)
          {
            ((IDisposable)oprot_).Dispose();
          }
        }
      }
      _IsDisposed = true;
    }
    #endregion


    
    #if SILVERLIGHT
    
    public IAsyncResult Begin_OnEvent(AsyncCallback callback, object state, MCoSimulationEvents @event)
    {
      return send_OnEvent(callback, state, @event);
    }

    public void End_OnEvent(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      recv_OnEvent();
    }

    #endif

    public void OnEvent(MCoSimulationEvents @event)
    {
      #if SILVERLIGHT
      var asyncResult = Begin_OnEvent(null, null, @event);
      End_OnEvent(asyncResult);

      #else
      send_OnEvent(@event);
      recv_OnEvent();

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_OnEvent(AsyncCallback callback, object state, MCoSimulationEvents @event)
    {
      oprot_.WriteMessageBegin(new TMessage("OnEvent", TMessageType.Call, seqid_));
      OnEvent_args args = new OnEvent_args();
      args.Event = @event;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      return oprot_.Transport.BeginFlush(callback, state);
    }

    #else

    public void send_OnEvent(MCoSimulationEvents @event)
    {
      oprot_.WriteMessageBegin(new TMessage("OnEvent", TMessageType.Call, seqid_));
      OnEvent_args args = new OnEvent_args();
      args.Event = @event;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      oprot_.Transport.Flush();
    }
    #endif

    public void recv_OnEvent()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      OnEvent_result result = new OnEvent_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      return;
    }

    
    #if SILVERLIGHT
    
    public IAsyncResult Begin_OnFrameEnd(AsyncCallback callback, object state, MAvatarPostureValues newPosture)
    {
      return send_OnFrameEnd(callback, state, newPosture);
    }

    public void End_OnFrameEnd(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      recv_OnFrameEnd();
    }

    #endif

    public void OnFrameEnd(MAvatarPostureValues newPosture)
    {
      #if SILVERLIGHT
      var asyncResult = Begin_OnFrameEnd(null, null, newPosture);
      End_OnFrameEnd(asyncResult);

      #else
      send_OnFrameEnd(newPosture);
      recv_OnFrameEnd();

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_OnFrameEnd(AsyncCallback callback, object state, MAvatarPostureValues newPosture)
    {
      oprot_.WriteMessageBegin(new TMessage("OnFrameEnd", TMessageType.Call, seqid_));
      OnFrameEnd_args args = new OnFrameEnd_args();
      args.NewPosture = newPosture;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      return oprot_.Transport.BeginFlush(callback, state);
    }

    #else

    public void send_OnFrameEnd(MAvatarPostureValues newPosture)
    {
      oprot_.WriteMessageBegin(new TMessage("OnFrameEnd", TMessageType.Call, seqid_));
      OnFrameEnd_args args = new OnFrameEnd_args();
      args.NewPosture = newPosture;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      oprot_.Transport.Flush();
    }
    #endif

    public void recv_OnFrameEnd()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      OnFrameEnd_result result = new OnFrameEnd_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      return;
    }

  }
  public class Processor : TProcessor {
    public Processor(ISync iface)
    {
      iface_ = iface;
      processMap_["OnEvent"] = OnEvent_Process;
      processMap_["OnFrameEnd"] = OnFrameEnd_Process;
    }

    protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
    private ISync iface_;
    protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

    public bool Process(TProtocol iprot, TProtocol oprot)
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

    public void OnEvent_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      OnEvent_args args = new OnEvent_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      OnEvent_result result = new OnEvent_result();
      try
      {
        iface_.OnEvent(args.Event);
        oprot.WriteMessageBegin(new TMessage("OnEvent", TMessageType.Reply, seqid)); 
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
        oprot.WriteMessageBegin(new TMessage("OnEvent", TMessageType.Exception, seqid));
        x.Write(oprot);
      }
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

    public void OnFrameEnd_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      OnFrameEnd_args args = new OnFrameEnd_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      OnFrameEnd_result result = new OnFrameEnd_result();
      try
      {
        iface_.OnFrameEnd(args.NewPosture);
        oprot.WriteMessageBegin(new TMessage("OnFrameEnd", TMessageType.Reply, seqid)); 
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
        oprot.WriteMessageBegin(new TMessage("OnFrameEnd", TMessageType.Exception, seqid));
        x.Write(oprot);
      }
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class OnEvent_args : TBase
  {
    private MCoSimulationEvents _event;

    public MCoSimulationEvents Event
    {
      get
      {
        return _event;
      }
      set
      {
        __isset.@event = true;
        this._event = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool @event;
    }

    public OnEvent_args() {
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
                Event = new MCoSimulationEvents();
                Event.Read(iprot);
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
        TStruct struc = new TStruct("OnEvent_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Event != null && __isset.@event) {
          field.Name = "event";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          Event.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("OnEvent_args(");
      bool __first = true;
      if (Event != null && __isset.@event) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Event: ");
        __sb.Append(Event== null ? "<null>" : Event.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class OnEvent_result : TBase
  {

    public OnEvent_result() {
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
        TStruct struc = new TStruct("OnEvent_result");
        oprot.WriteStructBegin(struc);

        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("OnEvent_result(");
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class OnFrameEnd_args : TBase
  {
    private MAvatarPostureValues _newPosture;

    public MAvatarPostureValues NewPosture
    {
      get
      {
        return _newPosture;
      }
      set
      {
        __isset.newPosture = true;
        this._newPosture = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool newPosture;
    }

    public OnFrameEnd_args() {
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
                NewPosture = new MAvatarPostureValues();
                NewPosture.Read(iprot);
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
        TStruct struc = new TStruct("OnFrameEnd_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (NewPosture != null && __isset.newPosture) {
          field.Name = "newPosture";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          NewPosture.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("OnFrameEnd_args(");
      bool __first = true;
      if (NewPosture != null && __isset.newPosture) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("NewPosture: ");
        __sb.Append(NewPosture== null ? "<null>" : NewPosture.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class OnFrameEnd_result : TBase
  {

    public OnFrameEnd_result() {
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
        TStruct struc = new TStruct("OnFrameEnd_result");
        oprot.WriteStructBegin(struc);

        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("OnFrameEnd_result(");
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}

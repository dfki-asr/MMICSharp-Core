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
  public partial class MPostureBlendingService {
    public interface ISync : MMIServiceBase.ISync {
      MMIStandard.MAvatarPostureValues Blend(MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, double weight, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties);
      List<MMIStandard.MAvatarPostureValues> BlendMany(MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, List<double> weights, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties);
    }

    public interface Iface : ISync {
      #if SILVERLIGHT
      IAsyncResult Begin_Blend(AsyncCallback callback, object state, MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, double weight, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties);
      MMIStandard.MAvatarPostureValues End_Blend(IAsyncResult asyncResult);
      #endif
      #if SILVERLIGHT
      IAsyncResult Begin_BlendMany(AsyncCallback callback, object state, MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, List<double> weights, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties);
      List<MMIStandard.MAvatarPostureValues> End_BlendMany(IAsyncResult asyncResult);
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
      
      public IAsyncResult Begin_Blend(AsyncCallback callback, object state, MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, double weight, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties)
      {
        return send_Blend(callback, state, startPosture, targetPosture, weight, mask, properties);
      }

      public MMIStandard.MAvatarPostureValues End_Blend(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_Blend();
      }

      #endif

      public MMIStandard.MAvatarPostureValues Blend(MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, double weight, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties)
      {
        #if SILVERLIGHT
        var asyncResult = Begin_Blend(null, null, startPosture, targetPosture, weight, mask, properties);
        return End_Blend(asyncResult);

        #else
        send_Blend(startPosture, targetPosture, weight, mask, properties);
        return recv_Blend();

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_Blend(AsyncCallback callback, object state, MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, double weight, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties)
      {
        oprot_.WriteMessageBegin(new TMessage("Blend", TMessageType.Call, seqid_));
        Blend_args args = new Blend_args();
        args.StartPosture = startPosture;
        args.TargetPosture = targetPosture;
        args.Weight = weight;
        args.Mask = mask;
        args.Properties = properties;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        return oprot_.Transport.BeginFlush(callback, state);
      }

      #else

      public void send_Blend(MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, double weight, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties)
      {
        oprot_.WriteMessageBegin(new TMessage("Blend", TMessageType.Call, seqid_));
        Blend_args args = new Blend_args();
        args.StartPosture = startPosture;
        args.TargetPosture = targetPosture;
        args.Weight = weight;
        args.Mask = mask;
        args.Properties = properties;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }
      #endif

      public MMIStandard.MAvatarPostureValues recv_Blend()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        Blend_result result = new Blend_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "Blend failed: unknown result");
      }

      
      #if SILVERLIGHT
      
      public IAsyncResult Begin_BlendMany(AsyncCallback callback, object state, MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, List<double> weights, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties)
      {
        return send_BlendMany(callback, state, startPosture, targetPosture, weights, mask, properties);
      }

      public List<MMIStandard.MAvatarPostureValues> End_BlendMany(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_BlendMany();
      }

      #endif

      public List<MMIStandard.MAvatarPostureValues> BlendMany(MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, List<double> weights, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties)
      {
        #if SILVERLIGHT
        var asyncResult = Begin_BlendMany(null, null, startPosture, targetPosture, weights, mask, properties);
        return End_BlendMany(asyncResult);

        #else
        send_BlendMany(startPosture, targetPosture, weights, mask, properties);
        return recv_BlendMany();

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_BlendMany(AsyncCallback callback, object state, MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, List<double> weights, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties)
      {
        oprot_.WriteMessageBegin(new TMessage("BlendMany", TMessageType.Call, seqid_));
        BlendMany_args args = new BlendMany_args();
        args.StartPosture = startPosture;
        args.TargetPosture = targetPosture;
        args.Weights = weights;
        args.Mask = mask;
        args.Properties = properties;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        return oprot_.Transport.BeginFlush(callback, state);
      }

      #else

      public void send_BlendMany(MMIStandard.MAvatarPostureValues startPosture, MMIStandard.MAvatarPostureValues targetPosture, List<double> weights, Dictionary<MMIStandard.MJointType, double> mask, Dictionary<string, string> properties)
      {
        oprot_.WriteMessageBegin(new TMessage("BlendMany", TMessageType.Call, seqid_));
        BlendMany_args args = new BlendMany_args();
        args.StartPosture = startPosture;
        args.TargetPosture = targetPosture;
        args.Weights = weights;
        args.Mask = mask;
        args.Properties = properties;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }
      #endif

      public List<MMIStandard.MAvatarPostureValues> recv_BlendMany()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        BlendMany_result result = new BlendMany_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "BlendMany failed: unknown result");
      }

    }
    public class Processor : MMIServiceBase.Processor, TProcessor {
      public Processor(ISync iface) : base(iface)
      {
        iface_ = iface;
        processMap_["Blend"] = Blend_Process;
        processMap_["BlendMany"] = BlendMany_Process;
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

      public void Blend_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        Blend_args args = new Blend_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        Blend_result result = new Blend_result();
        try
        {
          result.Success = iface_.Blend(args.StartPosture, args.TargetPosture, args.Weight, args.Mask, args.Properties);
          oprot.WriteMessageBegin(new TMessage("Blend", TMessageType.Reply, seqid)); 
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
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("Blend", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void BlendMany_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        BlendMany_args args = new BlendMany_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        BlendMany_result result = new BlendMany_result();
        try
        {
          result.Success = iface_.BlendMany(args.StartPosture, args.TargetPosture, args.Weights, args.Mask, args.Properties);
          oprot.WriteMessageBegin(new TMessage("BlendMany", TMessageType.Reply, seqid)); 
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
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("BlendMany", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class Blend_args : TBase
    {
      private MMIStandard.MAvatarPostureValues _startPosture;
      private MMIStandard.MAvatarPostureValues _targetPosture;
      private double _weight;
      private Dictionary<MMIStandard.MJointType, double> _mask;
      private Dictionary<string, string> _properties;

      public MMIStandard.MAvatarPostureValues StartPosture
      {
        get
        {
          return _startPosture;
        }
        set
        {
          __isset.startPosture = true;
          this._startPosture = value;
        }
      }

      public MMIStandard.MAvatarPostureValues TargetPosture
      {
        get
        {
          return _targetPosture;
        }
        set
        {
          __isset.targetPosture = true;
          this._targetPosture = value;
        }
      }

      public double Weight
      {
        get
        {
          return _weight;
        }
        set
        {
          __isset.weight = true;
          this._weight = value;
        }
      }

      public Dictionary<MMIStandard.MJointType, double> Mask
      {
        get
        {
          return _mask;
        }
        set
        {
          __isset.mask = true;
          this._mask = value;
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
        public bool startPosture;
        public bool targetPosture;
        public bool weight;
        public bool mask;
        public bool properties;
      }

      public Blend_args() {
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
                  StartPosture = new MMIStandard.MAvatarPostureValues();
                  StartPosture.Read(iprot);
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              case 2:
                if (field.Type == TType.Struct) {
                  TargetPosture = new MMIStandard.MAvatarPostureValues();
                  TargetPosture.Read(iprot);
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              case 3:
                if (field.Type == TType.Double) {
                  Weight = iprot.ReadDouble();
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              case 4:
                if (field.Type == TType.Map) {
                  {
                    Mask = new Dictionary<MMIStandard.MJointType, double>();
                    TMap _map108 = iprot.ReadMapBegin();
                    for( int _i109 = 0; _i109 < _map108.Count; ++_i109)
                    {
                      MMIStandard.MJointType _key110;
                      double _val111;
                      _key110 = (MMIStandard.MJointType)iprot.ReadI32();
                      _val111 = iprot.ReadDouble();
                      Mask[_key110] = _val111;
                    }
                    iprot.ReadMapEnd();
                  }
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              case 5:
                if (field.Type == TType.Map) {
                  {
                    Properties = new Dictionary<string, string>();
                    TMap _map112 = iprot.ReadMapBegin();
                    for( int _i113 = 0; _i113 < _map112.Count; ++_i113)
                    {
                      string _key114;
                      string _val115;
                      _key114 = iprot.ReadString();
                      _val115 = iprot.ReadString();
                      Properties[_key114] = _val115;
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
          TStruct struc = new TStruct("Blend_args");
          oprot.WriteStructBegin(struc);
          TField field = new TField();
          if (StartPosture != null && __isset.startPosture) {
            field.Name = "startPosture";
            field.Type = TType.Struct;
            field.ID = 1;
            oprot.WriteFieldBegin(field);
            StartPosture.Write(oprot);
            oprot.WriteFieldEnd();
          }
          if (TargetPosture != null && __isset.targetPosture) {
            field.Name = "targetPosture";
            field.Type = TType.Struct;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            TargetPosture.Write(oprot);
            oprot.WriteFieldEnd();
          }
          if (__isset.weight) {
            field.Name = "weight";
            field.Type = TType.Double;
            field.ID = 3;
            oprot.WriteFieldBegin(field);
            oprot.WriteDouble(Weight);
            oprot.WriteFieldEnd();
          }
          if (Mask != null && __isset.mask) {
            field.Name = "mask";
            field.Type = TType.Map;
            field.ID = 4;
            oprot.WriteFieldBegin(field);
            {
              oprot.WriteMapBegin(new TMap(TType.I32, TType.Double, Mask.Count));
              foreach (MMIStandard.MJointType _iter116 in Mask.Keys)
              {
                oprot.WriteI32((int)_iter116);
                oprot.WriteDouble(Mask[_iter116]);
              }
              oprot.WriteMapEnd();
            }
            oprot.WriteFieldEnd();
          }
          if (Properties != null && __isset.properties) {
            field.Name = "properties";
            field.Type = TType.Map;
            field.ID = 5;
            oprot.WriteFieldBegin(field);
            {
              oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
              foreach (string _iter117 in Properties.Keys)
              {
                oprot.WriteString(_iter117);
                oprot.WriteString(Properties[_iter117]);
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
        StringBuilder __sb = new StringBuilder("Blend_args(");
        bool __first = true;
        if (StartPosture != null && __isset.startPosture) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("StartPosture: ");
          __sb.Append(StartPosture== null ? "<null>" : StartPosture.ToString());
        }
        if (TargetPosture != null && __isset.targetPosture) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("TargetPosture: ");
          __sb.Append(TargetPosture== null ? "<null>" : TargetPosture.ToString());
        }
        if (__isset.weight) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Weight: ");
          __sb.Append(Weight);
        }
        if (Mask != null && __isset.mask) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Mask: ");
          __sb.Append(Mask);
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
    public partial class Blend_result : TBase
    {
      private MMIStandard.MAvatarPostureValues _success;

      public MMIStandard.MAvatarPostureValues Success
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

      public Blend_result() {
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
                  Success = new MMIStandard.MAvatarPostureValues();
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
          TStruct struc = new TStruct("Blend_result");
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
        StringBuilder __sb = new StringBuilder("Blend_result(");
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
    public partial class BlendMany_args : TBase
    {
      private MMIStandard.MAvatarPostureValues _startPosture;
      private MMIStandard.MAvatarPostureValues _targetPosture;
      private List<double> _weights;
      private Dictionary<MMIStandard.MJointType, double> _mask;
      private Dictionary<string, string> _properties;

      public MMIStandard.MAvatarPostureValues StartPosture
      {
        get
        {
          return _startPosture;
        }
        set
        {
          __isset.startPosture = true;
          this._startPosture = value;
        }
      }

      public MMIStandard.MAvatarPostureValues TargetPosture
      {
        get
        {
          return _targetPosture;
        }
        set
        {
          __isset.targetPosture = true;
          this._targetPosture = value;
        }
      }

      public List<double> Weights
      {
        get
        {
          return _weights;
        }
        set
        {
          __isset.weights = true;
          this._weights = value;
        }
      }

      public Dictionary<MMIStandard.MJointType, double> Mask
      {
        get
        {
          return _mask;
        }
        set
        {
          __isset.mask = true;
          this._mask = value;
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
        public bool startPosture;
        public bool targetPosture;
        public bool weights;
        public bool mask;
        public bool properties;
      }

      public BlendMany_args() {
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
                  StartPosture = new MMIStandard.MAvatarPostureValues();
                  StartPosture.Read(iprot);
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              case 2:
                if (field.Type == TType.Struct) {
                  TargetPosture = new MMIStandard.MAvatarPostureValues();
                  TargetPosture.Read(iprot);
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              case 3:
                if (field.Type == TType.List) {
                  {
                    Weights = new List<double>();
                    TList _list118 = iprot.ReadListBegin();
                    for( int _i119 = 0; _i119 < _list118.Count; ++_i119)
                    {
                      double _elem120;
                      _elem120 = iprot.ReadDouble();
                      Weights.Add(_elem120);
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
                    Mask = new Dictionary<MMIStandard.MJointType, double>();
                    TMap _map121 = iprot.ReadMapBegin();
                    for( int _i122 = 0; _i122 < _map121.Count; ++_i122)
                    {
                      MMIStandard.MJointType _key123;
                      double _val124;
                      _key123 = (MMIStandard.MJointType)iprot.ReadI32();
                      _val124 = iprot.ReadDouble();
                      Mask[_key123] = _val124;
                    }
                    iprot.ReadMapEnd();
                  }
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              case 5:
                if (field.Type == TType.Map) {
                  {
                    Properties = new Dictionary<string, string>();
                    TMap _map125 = iprot.ReadMapBegin();
                    for( int _i126 = 0; _i126 < _map125.Count; ++_i126)
                    {
                      string _key127;
                      string _val128;
                      _key127 = iprot.ReadString();
                      _val128 = iprot.ReadString();
                      Properties[_key127] = _val128;
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
          TStruct struc = new TStruct("BlendMany_args");
          oprot.WriteStructBegin(struc);
          TField field = new TField();
          if (StartPosture != null && __isset.startPosture) {
            field.Name = "startPosture";
            field.Type = TType.Struct;
            field.ID = 1;
            oprot.WriteFieldBegin(field);
            StartPosture.Write(oprot);
            oprot.WriteFieldEnd();
          }
          if (TargetPosture != null && __isset.targetPosture) {
            field.Name = "targetPosture";
            field.Type = TType.Struct;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            TargetPosture.Write(oprot);
            oprot.WriteFieldEnd();
          }
          if (Weights != null && __isset.weights) {
            field.Name = "weights";
            field.Type = TType.List;
            field.ID = 3;
            oprot.WriteFieldBegin(field);
            {
              oprot.WriteListBegin(new TList(TType.Double, Weights.Count));
              foreach (double _iter129 in Weights)
              {
                oprot.WriteDouble(_iter129);
              }
              oprot.WriteListEnd();
            }
            oprot.WriteFieldEnd();
          }
          if (Mask != null && __isset.mask) {
            field.Name = "mask";
            field.Type = TType.Map;
            field.ID = 4;
            oprot.WriteFieldBegin(field);
            {
              oprot.WriteMapBegin(new TMap(TType.I32, TType.Double, Mask.Count));
              foreach (MMIStandard.MJointType _iter130 in Mask.Keys)
              {
                oprot.WriteI32((int)_iter130);
                oprot.WriteDouble(Mask[_iter130]);
              }
              oprot.WriteMapEnd();
            }
            oprot.WriteFieldEnd();
          }
          if (Properties != null && __isset.properties) {
            field.Name = "properties";
            field.Type = TType.Map;
            field.ID = 5;
            oprot.WriteFieldBegin(field);
            {
              oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
              foreach (string _iter131 in Properties.Keys)
              {
                oprot.WriteString(_iter131);
                oprot.WriteString(Properties[_iter131]);
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
        StringBuilder __sb = new StringBuilder("BlendMany_args(");
        bool __first = true;
        if (StartPosture != null && __isset.startPosture) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("StartPosture: ");
          __sb.Append(StartPosture== null ? "<null>" : StartPosture.ToString());
        }
        if (TargetPosture != null && __isset.targetPosture) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("TargetPosture: ");
          __sb.Append(TargetPosture== null ? "<null>" : TargetPosture.ToString());
        }
        if (Weights != null && __isset.weights) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Weights: ");
          __sb.Append(Weights);
        }
        if (Mask != null && __isset.mask) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Mask: ");
          __sb.Append(Mask);
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
    public partial class BlendMany_result : TBase
    {
      private List<MMIStandard.MAvatarPostureValues> _success;

      public List<MMIStandard.MAvatarPostureValues> Success
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

      public BlendMany_result() {
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
                if (field.Type == TType.List) {
                  {
                    Success = new List<MMIStandard.MAvatarPostureValues>();
                    TList _list132 = iprot.ReadListBegin();
                    for( int _i133 = 0; _i133 < _list132.Count; ++_i133)
                    {
                      MMIStandard.MAvatarPostureValues _elem134;
                      _elem134 = new MMIStandard.MAvatarPostureValues();
                      _elem134.Read(iprot);
                      Success.Add(_elem134);
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
          TStruct struc = new TStruct("BlendMany_result");
          oprot.WriteStructBegin(struc);
          TField field = new TField();

          if (this.__isset.success) {
            if (Success != null) {
              field.Name = "Success";
              field.Type = TType.List;
              field.ID = 0;
              oprot.WriteFieldBegin(field);
              {
                oprot.WriteListBegin(new TList(TType.Struct, Success.Count));
                foreach (MMIStandard.MAvatarPostureValues _iter135 in Success)
                {
                  _iter135.Write(oprot);
                }
                oprot.WriteListEnd();
              }
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
        StringBuilder __sb = new StringBuilder("BlendMany_result(");
        bool __first = true;
        if (Success != null && __isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }

  }
}

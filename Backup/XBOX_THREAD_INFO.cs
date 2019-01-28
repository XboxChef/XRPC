// Decompiled with JetBrains decompiler
// Type: XDevkit.XBOX_THREAD_INFO
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  [StructLayout(LayoutKind.Sequential, Pack = 8)]
  public struct XBOX_THREAD_INFO
  {
    public uint ThreadId;
    public uint SuspendCount;
    public uint Priority;
    public uint TlsBase;
    public uint StartAddress;
    public uint StackBase;
    public uint StackLimit;
    public uint StackSlackSpace;
    [MarshalAs(UnmanagedType.Struct)]
    public object CreateTime;
    [MarshalAs(UnmanagedType.BStr)]
    public string Name;
  }
}

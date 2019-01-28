// Decompiled with JetBrains decompiler
// Type: XDevkit.XBOX_EVENT_INFO
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  [StructLayout(LayoutKind.Sequential, Pack = 4)]
  public struct XBOX_EVENT_INFO
  {
    public XboxDebugEventType Event;
    public short IsThreadStopped;
    [MarshalAs(UnmanagedType.Interface)]
    public IXboxThread Thread;
    [MarshalAs(UnmanagedType.Interface)]
    public IXboxModule Module;
    [MarshalAs(UnmanagedType.Interface)]
    public IXboxSection Section;
    public XboxExecutionState ExecState;
    [MarshalAs(UnmanagedType.BStr)]
    public string Message;
    public uint Code;
    public uint Address;
    public XboxExceptionFlags Flags;
    public uint ParameterCount;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
    public uint[] Parameters;
  }
}

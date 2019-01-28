// Decompiled with JetBrains decompiler
// Type: XDevkit.XBOX_PROCESS_INFO
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  [StructLayout(LayoutKind.Sequential, Pack = 4)]
  public struct XBOX_PROCESS_INFO
  {
    public uint ProcessId;
    [MarshalAs(UnmanagedType.BStr)]
    public string ProgramName;
  }
}

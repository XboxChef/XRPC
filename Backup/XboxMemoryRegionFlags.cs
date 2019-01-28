// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxMemoryRegionFlags
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxMemoryRegionFlags
  {
    NoAccess = 1,
    ReadOnly = 2,
    ReadWrite = 4,
    WriteCopy = 8,
    Execute = 16, // 0x00000010
    ExecuteRead = 32, // 0x00000020
    ExecuteReadWrite = 64, // 0x00000040
    ExecuteWriteCopy = 128, // 0x00000080
    Guard = 256, // 0x00000100
    NoCache = 512, // 0x00000200
    WriteCombine = 1024, // 0x00000400
    UserReadOnly = 4096, // 0x00001000
    UserReadWrite = 8192, // 0x00002000
  }
}

// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxDumpFlags
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxDumpFlags
  {
    Normal = 0,
    WithDataSegs = 1,
    WithFullMemory = 2,
    WithHandleData = 4,
    FilterMemory = 8,
    ScanMemory = 16, // 0x00000010
    WithUnloadedModules = 32, // 0x00000020
    WithIndirectlyReferencedMemory = 64, // 0x00000040
    FilterModulePaths = 128, // 0x00000080
    WithProcessThreadData = 256, // 0x00000100
    WithPrivateReadWriteMemory = 512, // 0x00000200
  }
}

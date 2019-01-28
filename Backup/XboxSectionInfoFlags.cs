// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxSectionInfoFlags
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxSectionInfoFlags
  {
    Loaded = 1,
    Readable = 2,
    Writeable = 4,
    Executable = 8,
    Uninitialized = 16, // 0x00000010
  }
}

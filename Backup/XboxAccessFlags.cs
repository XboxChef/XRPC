// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxAccessFlags
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxAccessFlags
  {
    Read = 1,
    Write = 2,
    Control = 4,
    Configure = 8,
    Manage = 16, // 0x00000010
  }
}

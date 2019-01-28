// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxEventDeferFlags
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxEventDeferFlags
  {
    CanDeferExecutionBreak = 1,
    CanDeferDebugString = 2,
    CanDeferSingleStep = 4,
    CanDeferAssertionFailed = 8,
    CanDeferAssertionFailedEx = 16, // 0x00000010
    CanDeferDataBreak = 32, // 0x00000020
    CanDeferRIP = 64, // 0x00000040
  }
}

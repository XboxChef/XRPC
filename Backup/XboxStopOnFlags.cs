// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxStopOnFlags
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxStopOnFlags
  {
    OnThreadCreate = 1,
    OnFirstChanceException = 2,
    OnDebugString = 4,
    OnStackTrace = 8,
    OnModuleLoad = 16, // 0x00000010
    OnTitleLaunch = 32, // 0x00000020
    OnPgoModuleStartup = 64, // 0x00000040
  }
}

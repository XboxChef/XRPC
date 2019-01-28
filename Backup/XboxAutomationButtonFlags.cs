// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxAutomationButtonFlags
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxAutomationButtonFlags
  {
    DPadUp = 1,
    DPadDown = 2,
    DPadLeft = 4,
    DPadRight = 8,
    StartButton = 16, // 0x00000010
    BackButton = 32, // 0x00000020
    LeftThumbButton = 64, // 0x00000040
    RightThumbButton = 128, // 0x00000080
    LeftShoulderButton = 256, // 0x00000100
    RightShoulderButton = 512, // 0x00000200
    Xbox360_Button = 1024, // 0x00000400
    Bind_Button = 2048, // 0x00000800
    A_Button = 4096, // 0x00001000
    B_Button = 8192, // 0x00002000
    X_Button = 16384, // 0x00004000
    Y_Button = 32768, // 0x00008000
  }
}

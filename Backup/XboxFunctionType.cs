// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxFunctionType
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxFunctionType
  {
    NoPData = -1,
    SaveMillicode = 0,
    NoHandler = 1,
    RestoreMillicode = 2,
    Handler = 3,
  }
}

// Decompiled with JetBrains decompiler
// Type: XDevkit.XBOX_USER
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  [StructLayout(LayoutKind.Sequential, Pack = 4)]
  public struct XBOX_USER
  {
    [MarshalAs(UnmanagedType.BStr)]
    public string UserName;
    public XboxAccessFlags Access;
  }
}

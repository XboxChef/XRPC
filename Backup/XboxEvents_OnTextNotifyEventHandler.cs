// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxEvents_OnTextNotifyEventHandler
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [TypeLibType(16)]
  [ComVisible(false)]
  public delegate void XboxEvents_OnTextNotifyEventHandler([MarshalAs(UnmanagedType.BStr), In] string Source, [MarshalAs(UnmanagedType.BStr), In] string Notification);
}

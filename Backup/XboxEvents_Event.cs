// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxEvents_Event
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComEventInterface(typeof (XboxEvents), typeof (XboxEvents_EventProvider))]
  [TypeLibType(16)]
  [ComVisible(false)]
  public interface XboxEvents_Event
  {
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_OnStdNotify(XboxEvents_OnStdNotifyEventHandler _param1);

    event XboxEvents_OnStdNotifyEventHandler OnStdNotify;

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_OnStdNotify(XboxEvents_OnStdNotifyEventHandler _param1);

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void add_OnTextNotify(XboxEvents_OnTextNotifyEventHandler _param1);

    event XboxEvents_OnTextNotifyEventHandler OnTextNotify;

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void remove_OnTextNotify(XboxEvents_OnTextNotifyEventHandler _param1);
  }
}

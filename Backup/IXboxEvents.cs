// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxEvents
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [TypeLibType(256)]
  [Guid("E3C9D73F-9DF0-4B57-8CEE-05F9CA6823BE")]
  [InterfaceType(1)]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxEvents
  {
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void OnStdNotify([In] XboxDebugEventType EventCode, [MarshalAs(UnmanagedType.Interface), In] IXboxEventInfo EventInfo);

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void OnTextNotify([MarshalAs(UnmanagedType.BStr), In] string Source, [MarshalAs(UnmanagedType.BStr), In] string Notification);
  }
}

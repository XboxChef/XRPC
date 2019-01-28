// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxEvents
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [TypeLibType(4096)]
  [Guid("420208DF-C38C-4EFB-9FC3-ACD50350941E")]
  [InterfaceType(2)]
  [ComVisible(true)]
  [ComImport]
  public interface XboxEvents
  {
    [DispId(1)]
    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void OnStdNotify([In] XboxDebugEventType EventCode, [MarshalAs(UnmanagedType.Interface), In] IXboxEventInfo EventInfo);

    [DispId(2)]
    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void OnTextNotify([MarshalAs(UnmanagedType.BStr), In] string Source, [MarshalAs(UnmanagedType.BStr), In] string Notification);
  }
}

// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxThread
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [Guid("8F1E63F5-85BA-4B2D-AD9C-1FA6B750D57F")]
  [TypeLibType(4160)]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxThread
  {
    [DispId(0)]
    [IndexerName("ThreadId")]
    uint this[] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(100)]
    XBOX_THREAD_INFO ThreadInfo { [DispId(100), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(101)]
    XBOX_EVENT_INFO StopEventInfo { [DispId(101), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(102)]
    IXboxStackFrame TopOfStack { [DispId(102), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(103)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Halt();

    [DispId(104)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Continue([In] bool Exception);

    [DispId(105)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Suspend();

    [DispId(106)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Resume();

    [DispId(107)]
    uint CurrentProcessor { [DispId(107), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(108)]
    uint LastError { [DispId(108), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}

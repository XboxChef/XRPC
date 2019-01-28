// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxDebugTarget
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [TypeLibType(4288)]
  [Guid("43CCAFD7-4636-43AA-B468-B7F6EDCA6651")]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxDebugTarget
  {
    [DispId(0)]
    [IndexerName("Name")]
    string this[] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [DispId(1)]
    bool IsDump { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(20)]
    XboxManager XboxManager { [DispId(20), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(21)]
    XboxConsole Console { [DispId(21), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(50)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void ConnectAsDebugger([MarshalAs(UnmanagedType.BStr), In] string DebuggerName, [In] XboxDebugConnectFlags Flags);

    [DispId(51)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void DisconnectAsDebugger();

    [DispId(52)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    bool IsDebuggerConnected([MarshalAs(UnmanagedType.BStr)] out string DebuggerName, [MarshalAs(UnmanagedType.BStr)] out string UserName);

    [DispId(100)]
    IXboxModules Modules { [DispId(100), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(101)]
    IXboxThreads Threads { [DispId(101), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(103)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void GetMemory([In] uint Address, [In] uint BytesToRead, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1), In, Out] byte[] Data, out uint BytesRead);

    [DispId(104)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetMemory([In] uint Address, [In] uint BytesToWrite, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1), In] byte[] Data, out uint BytesWritten);

    [DispId(105)]
    [TypeLibFunc(64)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void GetMemory_cpp([In] uint Address, [In] uint BytesToRead, out byte Data, out uint BytesRead);

    [TypeLibFunc(64)]
    [DispId(106)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetMemory_cpp([In] uint Address, [In] uint BytesToWrite, [In] ref byte Data, out uint BytesWritten);

    [DispId(107)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void InvalidateMemoryCache([In] bool ExecutablePages, [In] uint Address, [In] uint Size);

    [DispId(108)]
    bool MemoryCacheEnabled { [DispId(108), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(108), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    [DispId(109)]
    IXboxMemoryRegions MemoryRegions { [DispId(109), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(110)]
    XBOX_PROCESS_INFO RunningProcessInfo { [DispId(110), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(115)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void StopOn([In] XboxStopOnFlags StopOn, [In] bool Stop);

    [DispId(116)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Stop(out bool AlreadyStopped);

    [DispId(117)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Go(out bool NotStopped);

    [DispId(130)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetBreakpoint([In] uint Address);

    [DispId(131)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void RemoveBreakpoint([In] uint Address);

    [DispId(132)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void RemoveAllBreakpoints();

    [DispId(133)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetInitialBreakpoint();

    [DispId(134)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetDataBreakpoint([In] uint Address, [In] XboxBreakpointType Type, [In] uint Size);

    [DispId(135)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void IsBreakpoint([In] uint Address, out XboxBreakpointType Type);

    [DispId(136)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void WriteDump([MarshalAs(UnmanagedType.BStr), In] string Filename, [In] XboxDumpFlags Type);

    [DispId(140)]
    [TypeLibFunc(64)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void CopyEventInfo(out XBOX_EVENT_INFO EventInfoDest, [In] ref XBOX_EVENT_INFO EventInfoSource);

    [TypeLibFunc(64)]
    [DispId(150)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void FreeEventInfo([In, Out] ref XBOX_EVENT_INFO EventInfo);

    [DispId(160)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void PgoStartDataCollection(uint PgoModule);

    [DispId(161)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void PgoStopDataCollection(uint PgoModule);

    [DispId(162)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void PgoSaveSnapshot([MarshalAs(UnmanagedType.BStr)] string Phase, bool Reset, uint PgoModule);

    [DispId(163)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void PgoSetAllocScale(uint PgoModule, uint BufferAllocScale);
  }
}

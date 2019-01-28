// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxManagerClass
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [Guid("A5EB45D8-F3B6-49B9-984A-0D313AB60342")]
  [TypeLibType(2)]
  [ClassInterface(0)]
  [ComVisible(true)]
  [ComImport]
  public class XboxManagerClass : IXboxManager, XboxManager
  {
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public extern XboxManagerClass();

    [DispId(1)]
    public virtual extern string DefaultConsole { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: MarshalAs(UnmanagedType.BStr), In] set; }

    [DispId(2)]
    public virtual extern IXboxConsoles Consoles { [DispId(2), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(3)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void AddConsole([MarshalAs(UnmanagedType.BStr), In] string Xbox);

    [DispId(4)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void RemoveConsole([MarshalAs(UnmanagedType.BStr), In] string Xbox);

    [DispId(6)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    public virtual extern XboxConsole OpenConsole([MarshalAs(UnmanagedType.BStr), In] string XboxName);

    [DispId(7)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    public virtual extern IXboxDebugTarget OpenDumpFile(
      [MarshalAs(UnmanagedType.BStr), In] string Filename,
      [MarshalAs(UnmanagedType.BStr), In] string ImageSearchPath);

    [DispId(8)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void SelectConsole(
      [In] int ParentWindow,
      [MarshalAs(UnmanagedType.BStr)] out string SelectedXbox,
      [In] XboxAccessFlags DesiredAccess,
      [In] XboxSelectConsoleFlags Flags);

    [DispId(9)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void RunAddConsoleWizard([In] int ParentWindow, [In] bool Modal);

    [DispId(10)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void OpenWindowsExplorer([MarshalAs(UnmanagedType.BStr), In] string XboxName, [MarshalAs(UnmanagedType.BStr), In] string Path);

    [DispId(20)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.BStr)]
    public virtual extern string TranslateError([MarshalAs(UnmanagedType.Error), In] int hr);

    [DispId(21)]
    public virtual extern string SystemSymbolServerPath { [DispId(21), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [DispId(22)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void SelectConsoleEx(
      [In] long ParentWindow,
      [MarshalAs(UnmanagedType.BStr)] out string SelectedXbox,
      [In] XboxAccessFlags DesiredAccess,
      [In] XboxSelectConsoleFlags Flags);

    [DispId(23)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void RunAddConsoleWizardEx([In] long ParentWindow, [In] bool Modal);
  }
}

// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxModule
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [Guid("0EEE2AA0-60F0-4C18-B4ED-E3933E659847")]
  [TypeLibType(4288)]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxModule
  {
    [DispId(0)]
    [IndexerName("ModuleInfo")]
    XBOX_MODULE_INFO this[] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(1)]
    IXboxSections Sections { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(2)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void GetFunctionInfo([In] uint Address, out XBOX_FUNCTION_INFO FunctionInfo);

    [DispId(3)]
    uint OriginalSize { [DispId(3), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(4)]
    IXboxExecutable Executable { [DispId(4), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(5)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    uint GetEntryPointAddress();
  }
}

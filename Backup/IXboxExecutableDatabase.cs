// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxExecutableDatabase
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [TypeLibType(4288)]
  [Guid("CB8E47BA-2673-48AF-B0C5-FD5738FFCC6B")]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxExecutableDatabase
  {
    [DispId(1)]
    bool IsDirty { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(2)]
    string CurrentFileName { [DispId(2), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [DispId(100)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void LoadDatabase(
      [MarshalAs(UnmanagedType.BStr), In] string DatabaseFile,
      [In] bool ReadOnly,
      [In] XboxCreateDisposition CreateDisposition,
      [In] XboxShareMode ShareMode);

    [DispId(101)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SaveDatabase([MarshalAs(UnmanagedType.BStr), In] string DatabaseFile, [In] bool Remember);

    [DispId(102)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void CloseDatabase();

    [DispId(103)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void ResetDatabase();

    [DispId(120)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void AddExecutable(
      [MarshalAs(UnmanagedType.BStr), In] string XboxExecutablePath,
      [MarshalAs(UnmanagedType.BStr), In] string PortableExecutablePath,
      [MarshalAs(UnmanagedType.BStr), In] string SymbolPath,
      [MarshalAs(UnmanagedType.BStr), In] string PublicSymbolPath,
      [In] bool ExplictFilesOnly,
      [In] bool StoreRelativePath);

    [DispId(121)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void RemoveExecutable([MarshalAs(UnmanagedType.BStr), In] string Guid);

    [DispId(122)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    bool FindExecutableByGuid([MarshalAs(UnmanagedType.BStr), In] string Guid, [MarshalAs(UnmanagedType.Interface)] out IXboxExecutableInfo Info);

    [DispId(123)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    bool FindExecutableForSymServ(
      [MarshalAs(UnmanagedType.BStr), In] string ModuleName,
      [In] uint TimeDateStamp,
      [In] uint SizeOfImage,
      [MarshalAs(UnmanagedType.Interface)] out IXboxExecutableInfo Info);
  }
}

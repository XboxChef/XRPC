// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxExecutableDatabaseClass
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [ClassInterface(0)]
  [Guid("3151B328-4A0D-4B83-950F-6861AB6B3ECD")]
  [TypeLibType(2)]
  [ComVisible(true)]
  [ComImport]
  public class XboxExecutableDatabaseClass : IXboxExecutableDatabase, XboxExecutableDatabase
  {
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public extern XboxExecutableDatabaseClass();

    [DispId(1)]
    public virtual extern bool IsDirty { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(2)]
    public virtual extern string CurrentFileName { [DispId(2), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [DispId(100)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void LoadDatabase(
      [MarshalAs(UnmanagedType.BStr), In] string DatabaseFile,
      [In] bool ReadOnly,
      [In] XboxCreateDisposition CreateDisposition,
      [In] XboxShareMode ShareMode);

    [DispId(101)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void SaveDatabase([MarshalAs(UnmanagedType.BStr), In] string DatabaseFile, [In] bool Remember);

    [DispId(102)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void CloseDatabase();

    [DispId(103)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void ResetDatabase();

    [DispId(120)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void AddExecutable(
      [MarshalAs(UnmanagedType.BStr), In] string XboxExecutablePath,
      [MarshalAs(UnmanagedType.BStr), In] string PortableExecutablePath,
      [MarshalAs(UnmanagedType.BStr), In] string SymbolPath,
      [MarshalAs(UnmanagedType.BStr), In] string PublicSymbolPath,
      [In] bool ExplictFilesOnly,
      [In] bool StoreRelativePath);

    [DispId(121)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern void RemoveExecutable([MarshalAs(UnmanagedType.BStr), In] string Guid);

    [DispId(122)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern bool FindExecutableByGuid([MarshalAs(UnmanagedType.BStr), In] string Guid, [MarshalAs(UnmanagedType.Interface)] out IXboxExecutableInfo Info);

    [DispId(123)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public virtual extern bool FindExecutableForSymServ(
      [MarshalAs(UnmanagedType.BStr), In] string ModuleName,
      [In] uint TimeDateStamp,
      [In] uint SizeOfImage,
      [MarshalAs(UnmanagedType.Interface)] out IXboxExecutableInfo Info);
  }
}

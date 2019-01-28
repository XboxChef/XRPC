// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxSections
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.CustomMarshalers;

namespace XDevkit
{
  [Guid("9762DF66-9516-4531-A507-A11034056F5E")]
  [TypeLibType(4160)]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxSections : IEnumerable
  {
    [DispId(0)]
    IXboxSection this[[In] int Index] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(1)]
    int Count { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(-4)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (EnumeratorToEnumVariantMarshaler))]
    new IEnumerator GetEnumerator();
  }
}

// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxExecutable
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [Guid("4B103593-DB52-4E18-913D-B3B17824BD76")]
  [TypeLibType(4288)]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxExecutable
  {
    [DispId(1)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.BStr)]
    string GetPEModuleName();
  }
}

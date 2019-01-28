// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxSection
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [Guid("D6DF8112-0326-4D29-A6B8-CFB0D89C358A")]
  [TypeLibType(4160)]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxSection
  {
    [DispId(100)]
    XBOX_SECTION_INFO SectionInfo { [DispId(100), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}

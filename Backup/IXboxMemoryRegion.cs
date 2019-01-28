// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxMemoryRegion
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [Guid("4F882A21-7F2A-4BEA-A0A3-A3710A93DEEA")]
  [TypeLibType(4288)]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxMemoryRegion
  {
    [DispId(1)]
    int BaseAddress { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(2)]
    int RegionSize { [DispId(2), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(3)]
    XboxMemoryRegionFlags Flags { [DispId(3), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}

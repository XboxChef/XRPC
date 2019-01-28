// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxEventInfo
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [TypeLibType(4160)]
  [Guid("85C9127A-11ED-47F2-9E87-A83058FC264A")]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxEventInfo
  {
    [DispId(0)]
    [IndexerName("Info")]
    XBOX_EVENT_INFO this[] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}

// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxDumpReportFlags
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxDumpReportFlags
  {
    FormatFullHeap = 0,
    LocalDestination = 0,
    PromptToReport = 0,
    AlwaysReport = 1,
    NeverReport = 2,
    DestinationGroup = 15, // 0x0000000F
    ReportGroup = 15, // 0x0000000F
    RemoteDestination = 16, // 0x00000010
    FormatPartialHeap = 256, // 0x00000100
    FormatNoHeap = 512, // 0x00000200
    FormatRetail = 1024, // 0x00000400
    FormatGroup = 3840, // 0x00000F00
  }
}

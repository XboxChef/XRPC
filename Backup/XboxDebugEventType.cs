// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxDebugEventType
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ComVisible(true)]
  public enum XboxDebugEventType
  {
    NoEvent,
    ExecutionBreak,
    DebugString,
    ExecStateChange,
    SingleStep,
    ModuleLoad,
    ModuleUnload,
    ThreadCreate,
    ThreadDestroy,
    Exception,
    AssertionFailed,
    AssertionFailedEx,
    DataBreak,
    RIP,
    SectionLoad,
    SectionUnload,
    StackTrace,
    FiberCreate,
    FiberDestroy,
    BugCheck,
    PgoModuleStartup,
  }
}

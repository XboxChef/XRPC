// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxEvents_SinkHelper
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.InteropServices;

namespace XDevkit
{
  [ClassInterface(ClassInterfaceType.None)]
  [TypeLibType(TypeLibTypeFlags.FHidden)]
  [ComVisible(true)]
  public sealed class XboxEvents_SinkHelper : XboxEvents
  {
    public XboxEvents_OnStdNotifyEventHandler m_OnStdNotifyDelegate;
    public XboxEvents_OnTextNotifyEventHandler m_OnTextNotifyDelegate;
    public int m_dwCookie;

    public virtual void OnStdNotify(XboxDebugEventType _param1, IXboxEventInfo _param2)
    {
      if (this.m_OnStdNotifyDelegate == null)
        return;
      this.m_OnStdNotifyDelegate(_param1, _param2);
    }

    public virtual void OnTextNotify(string _param1, string _param2)
    {
      if (this.m_OnTextNotifyDelegate == null)
        return;
      this.m_OnTextNotifyDelegate(_param1, _param2);
    }

    internal XboxEvents_SinkHelper()
    {
      this.m_dwCookie = 0;
      this.m_OnStdNotifyDelegate = (XboxEvents_OnStdNotifyEventHandler) null;
      this.m_OnTextNotifyDelegate = (XboxEvents_OnTextNotifyEventHandler) null;
    }
  }
}

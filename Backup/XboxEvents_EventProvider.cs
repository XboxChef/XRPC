// Decompiled with JetBrains decompiler
// Type: XDevkit.XboxEvents_EventProvider
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace XDevkit
{
  internal sealed class XboxEvents_EventProvider : XboxEvents_Event, IDisposable
  {
    private IConnectionPointContainer m_ConnectionPointContainer;
    private ArrayList m_aEventSinkHelpers;
    private IConnectionPoint m_ConnectionPoint;

    private void Init()
    {
      IConnectionPoint ppCP = (IConnectionPoint) null;
      Guid riid = new Guid(new byte[16]
      {
        (byte) 223,
        (byte) 8,
        (byte) 2,
        (byte) 66,
        (byte) 140,
        (byte) 195,
        (byte) 251,
        (byte) 78,
        (byte) 159,
        (byte) 195,
        (byte) 172,
        (byte) 213,
        (byte) 3,
        (byte) 80,
        (byte) 148,
        (byte) 30
      });
      this.m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
      this.m_ConnectionPoint = ppCP;
      this.m_aEventSinkHelpers = new ArrayList();
    }

    public virtual void add_OnStdNotify(XboxEvents_OnStdNotifyEventHandler _param1)
    {
      Monitor.Enter((object) this);
      try
      {
        if (this.m_ConnectionPoint == null)
          this.Init();
        XboxEvents_SinkHelper eventsSinkHelper = new XboxEvents_SinkHelper();
        int pdwCookie = 0;
        this.m_ConnectionPoint.Advise((object) eventsSinkHelper, out pdwCookie);
        eventsSinkHelper.m_dwCookie = pdwCookie;
        eventsSinkHelper.m_OnStdNotifyDelegate = _param1;
        this.m_aEventSinkHelpers.Add((object) eventsSinkHelper);
      }
      finally
      {
        Monitor.Exit((object) this);
      }
    }

    public virtual void remove_OnStdNotify(XboxEvents_OnStdNotifyEventHandler _param1)
    {
      Monitor.Enter((object) this);
      try
      {
        if (this.m_aEventSinkHelpers == null)
          return;
        int count = this.m_aEventSinkHelpers.Count;
        int index = 0;
        if (0 >= count)
          return;
        do
        {
          XboxEvents_SinkHelper aEventSinkHelper = (XboxEvents_SinkHelper) this.m_aEventSinkHelpers[index];
          if (aEventSinkHelper.m_OnStdNotifyDelegate != null && ((aEventSinkHelper.m_OnStdNotifyDelegate.Equals((object) _param1) ? 1 : 0) & (int) byte.MaxValue) != 0)
          {
            this.m_aEventSinkHelpers.RemoveAt(index);
            this.m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
            if (count <= 1)
            {
              Marshal.ReleaseComObject((object) this.m_ConnectionPoint);
              this.m_ConnectionPoint = (IConnectionPoint) null;
              this.m_aEventSinkHelpers = (ArrayList) null;
              return;
            }
            goto label_10;
          }
          else
            ++index;
        }
        while (index < count);
        goto label_11;
label_10:
        return;
label_11:;
      }
      finally
      {
        Monitor.Exit((object) this);
      }
    }

    public virtual void add_OnTextNotify(XboxEvents_OnTextNotifyEventHandler _param1)
    {
      Monitor.Enter((object) this);
      try
      {
        if (this.m_ConnectionPoint == null)
          this.Init();
        XboxEvents_SinkHelper eventsSinkHelper = new XboxEvents_SinkHelper();
        int pdwCookie = 0;
        this.m_ConnectionPoint.Advise((object) eventsSinkHelper, out pdwCookie);
        eventsSinkHelper.m_dwCookie = pdwCookie;
        eventsSinkHelper.m_OnTextNotifyDelegate = _param1;
        this.m_aEventSinkHelpers.Add((object) eventsSinkHelper);
      }
      finally
      {
        Monitor.Exit((object) this);
      }
    }

    public virtual void remove_OnTextNotify(XboxEvents_OnTextNotifyEventHandler _param1)
    {
      Monitor.Enter((object) this);
      try
      {
        if (this.m_aEventSinkHelpers == null)
          return;
        int count = this.m_aEventSinkHelpers.Count;
        int index = 0;
        if (0 >= count)
          return;
        do
        {
          XboxEvents_SinkHelper aEventSinkHelper = (XboxEvents_SinkHelper) this.m_aEventSinkHelpers[index];
          if (aEventSinkHelper.m_OnTextNotifyDelegate != null && ((aEventSinkHelper.m_OnTextNotifyDelegate.Equals((object) _param1) ? 1 : 0) & (int) byte.MaxValue) != 0)
          {
            this.m_aEventSinkHelpers.RemoveAt(index);
            this.m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
            if (count <= 1)
            {
              Marshal.ReleaseComObject((object) this.m_ConnectionPoint);
              this.m_ConnectionPoint = (IConnectionPoint) null;
              this.m_aEventSinkHelpers = (ArrayList) null;
              return;
            }
            goto label_10;
          }
          else
            ++index;
        }
        while (index < count);
        goto label_11;
label_10:
        return;
label_11:;
      }
      finally
      {
        Monitor.Exit((object) this);
      }
    }

    public XboxEvents_EventProvider(object _param1)
    {
      this.m_ConnectionPointContainer = (IConnectionPointContainer) _param1;
    }

    public override void Finalize()
    {
      Monitor.Enter((object) this);
      try
      {
        if (this.m_ConnectionPoint == null)
          return;
        int count = this.m_aEventSinkHelpers.Count;
        int index = 0;
        if (0 < count)
        {
          do
          {
            this.m_ConnectionPoint.Unadvise(((XboxEvents_SinkHelper) this.m_aEventSinkHelpers[index]).m_dwCookie);
            ++index;
          }
          while (index < count);
        }
        Marshal.ReleaseComObject((object) this.m_ConnectionPoint);
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Monitor.Exit((object) this);
      }
    }

    public virtual void Dispose()
    {
      this.Finalize();
      GC.SuppressFinalize((object) this);
    }
  }
}

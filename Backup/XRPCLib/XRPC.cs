// Decompiled with JetBrains decompiler
// Type: XRPCLib.XRPC
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System;
using System.Text;
using System.Threading;
using XDevkit;

namespace XRPCLib
{
  public class XRPC
  {
    private string currentVersion = "1.7";
    private uint bufferAddressRead = 2445323722;
    private byte[] nulled = new byte[100];
    private uint[] buffcheck = new uint[15];
    public bool activeConnection;
    public bool activeTransfer;
    public IXboxManager xboxMgr;
    public \u002F\u002FboxConsolf xbCon;
    private uint xbConnection;
    private int sa;
    public static uint g;
    private static uint meh;
    private static int firstRan;
    private uint bufferAddress;
    private uint stringPointer;
    private uint floatPointer;
    private uint bytePointer;
    private int multiple;

    public void Connect()
    {
      this.initialize();
      if (!this.activeConnection || this.sa != 0)
        return;
      this.sa = 1;
    }

    public void initialize()
    {
      if (!this.activeConnection)
      {
        this.xboxMgr = (IXboxManager) new XboxManagerClass();
        this.xbCon = (\u002F\u002FboxConsolf) this.xboxMgr.OpenConsole(this.xboxMgr.DefaultConsole);
        try
        {
          this.xbConnection = this.xbCon.OpenConnection((string) null);
        }
        catch (Exception ex)
        {
          return;
        }
        string DebuggerName;
        string UserName;
        if (this.xbCon.DebugTarget.IsDebuggerConnected(out DebuggerName, out UserName))
        {
          this.activeConnection = true;
        }
        else
        {
          this.xbCon.DebugTarget.ConnectAsDebugger(nameof (XRPC), XboxDebugConnectFlags.Force);
          if (!this.xbCon.DebugTarget.IsDebuggerConnected(out DebuggerName, out UserName))
            return;
          this.activeConnection = true;
        }
      }
      else
      {
        string DebuggerName;
        string UserName;
        if (this.xbCon.DebugTarget.IsDebuggerConnected(out DebuggerName, out UserName))
          return;
        this.activeConnection = false;
        this.Connect();
      }
    }

    public byte[] GetMemory(uint address, uint length)
    {
      byte[] Data = new byte[(IntPtr) length];
      this.xbCon.DebugTarget.GetMemory(address, length, Data, out XRPC.g);
      this.xbCon.DebugTarget.InvalidateMemoryCache(true, address, length);
      return Data;
    }

    public byte[] WideChar(string text)
    {
      byte[] numArray = new byte[text.Length * 2 + 2];
      int index = 1;
      numArray[0] = (byte) 0;
      foreach (char ch in text)
      {
        numArray[index] = Convert.ToByte(ch);
        index += 2;
      }
      return numArray;
    }

    public void SetMemory(uint address, byte[] data)
    {
      this.xbCon.DebugTarget.SetMemory(address, (uint) data.Length, data, out XRPC.g);
    }

    private static byte[] getData(long[] argument)
    {
      byte[] numArray = new byte[argument.Length * 8];
      int index = 0;
      foreach (long num in argument)
      {
        byte[] bytes = BitConverter.GetBytes(num);
        Array.Reverse((Array) bytes);
        bytes.CopyTo((Array) numArray, index);
        index += 8;
      }
      return numArray;
    }

    public uint SystemCall(params object[] arg)
    {
      long[] numArray1 = new long[9];
      if (!this.activeConnection)
        this.Connect();
      if (XRPC.firstRan == 0)
      {
        byte[] Data = new byte[4];
        this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out XRPC.meh);
        this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
        Array.Reverse((Array) Data);
        this.bufferAddress = BitConverter.ToUInt32(Data, 0);
        XRPC.firstRan = 1;
        this.stringPointer = this.bufferAddress + 1500U;
        this.floatPointer = this.bufferAddress + 2700U;
        this.bytePointer = this.bufferAddress + 3200U;
        this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 100U, this.nulled, out XRPC.meh);
        this.xbCon.DebugTarget.SetMemory(this.stringPointer, 100U, this.nulled, out XRPC.meh);
      }
      if (this.bufferAddress == 0U)
      {
        byte[] Data = new byte[4];
        this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out XRPC.meh);
        this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
        Array.Reverse((Array) Data);
        this.bufferAddress = BitConverter.ToUInt32(Data, 0);
      }
      this.stringPointer = this.bufferAddress + 1500U;
      this.floatPointer = this.bufferAddress + 2700U;
      this.bytePointer = this.bufferAddress + 3200U;
      int num = 0;
      int index1 = 0;
      foreach (object obj in arg)
      {
        if (obj is byte)
        {
          byte[] numArray2 = (byte[]) obj;
          numArray1[index1] = (long) BitConverter.ToUInt32(numArray2, 0);
        }
        else if (obj is byte[])
        {
          byte[] Data = (byte[]) obj;
          this.xbCon.DebugTarget.SetMemory(this.bytePointer, (uint) Data.Length, Data, out XRPC.meh);
          numArray1[index1] = (long) this.bytePointer;
          this.bytePointer += (uint) (Data.Length + 2);
        }
        else if (obj is float)
        {
          byte[] bytes = BitConverter.GetBytes(float.Parse(Convert.ToString(obj)));
          this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint) bytes.Length, bytes, out XRPC.meh);
          numArray1[index1] = (long) this.floatPointer;
          this.floatPointer += (uint) (bytes.Length + 2);
        }
        else if (obj is float[])
        {
          byte[] Data = new byte[12];
          for (int index2 = 0; index2 <= 2; ++index2)
          {
            byte[] numArray2 = new byte[4];
            Buffer.BlockCopy((Array) obj, index2 * 4, (Array) numArray2, 0, 4);
            Array.Reverse((Array) numArray2);
            Buffer.BlockCopy((Array) numArray2, 0, (Array) Data, 4 * index2, 4);
          }
          this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint) Data.Length, Data, out XRPC.meh);
          numArray1[index1] = (long) this.floatPointer;
          this.floatPointer += 2U;
        }
        else if (obj is string)
        {
          byte[] bytes = Encoding.ASCII.GetBytes(Convert.ToString(obj));
          this.xbCon.DebugTarget.SetMemory(this.stringPointer, (uint) bytes.Length, bytes, out XRPC.meh);
          numArray1[index1] = (long) this.stringPointer;
          this.stringPointer += (uint) (Convert.ToString(obj).Length + 1);
        }
        else
          numArray1[index1] = Convert.ToInt64(obj);
        ++num;
        ++index1;
      }
      byte[] data = XRPC.getData(numArray1);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 8U, (uint) data.Length, data, out XRPC.meh);
      byte[] bytes1 = BitConverter.GetBytes(num);
      Array.Reverse((Array) bytes1);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 4U, 4U, bytes1, out XRPC.meh);
      Thread.Sleep(0);
      byte[] bytes2 = BitConverter.GetBytes(2181038080U);
      Array.Reverse((Array) bytes2);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 4U, bytes2, out XRPC.meh);
      Thread.Sleep(50);
      byte[] Data1 = new byte[4];
      this.xbCon.DebugTarget.GetMemory(this.bufferAddress + 4092U, 4U, Data1, out XRPC.meh);
      this.xbCon.DebugTarget.InvalidateMemoryCache(true, this.bufferAddress + 4092U, 4U);
      Array.Reverse((Array) Data1);
      return BitConverter.ToUInt32(Data1, 0);
    }

    public uint ResolveFunction(string titleID, uint ord)
    {
      if (XRPC.firstRan == 0)
      {
        byte[] Data = new byte[4];
        this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out XRPC.meh);
        this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
        Array.Reverse((Array) Data);
        this.bufferAddress = BitConverter.ToUInt32(Data, 0);
        XRPC.firstRan = 1;
        this.stringPointer = this.bufferAddress + 1500U;
        this.floatPointer = this.bufferAddress + 2700U;
        this.bytePointer = this.bufferAddress + 3200U;
        this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 100U, this.nulled, out XRPC.meh);
        this.xbCon.DebugTarget.SetMemory(this.stringPointer, 100U, this.nulled, out XRPC.meh);
      }
      byte[] bytes1 = Encoding.ASCII.GetBytes(titleID);
      this.xbCon.DebugTarget.SetMemory(this.stringPointer, (uint) bytes1.Length, bytes1, out XRPC.meh);
      long[] numArray = new long[2]
      {
        (long) this.stringPointer,
        0L
      };
      this.stringPointer += (uint) (Convert.ToString(titleID).Length + 1);
      numArray[1] = (long) ord;
      byte[] data = XRPC.getData(numArray);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 8U, (uint) data.Length, data, out XRPC.meh);
      byte[] bytes2 = BitConverter.GetBytes(2181038081U);
      Array.Reverse((Array) bytes2);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 4U, bytes2, out XRPC.meh);
      Thread.Sleep(50);
      byte[] Data1 = new byte[4];
      this.xbCon.DebugTarget.GetMemory(this.bufferAddress + 4092U, 4U, Data1, out XRPC.meh);
      this.xbCon.DebugTarget.InvalidateMemoryCache(true, this.bufferAddress + 4092U, 4U);
      Array.Reverse((Array) Data1);
      return BitConverter.ToUInt32(Data1, 0);
    }

    public void Notify(XRPC.XNotiyLogo type, string text)
    {
      byte[] numArray = this.WideChar(text);
      int num = (int) this.SystemCall((object) this.ResolveFunction("xam.xex", 656U), (object) Convert.ToUInt32((object) type), (object) 0, (object) 2, (object) numArray, (object) 0);
    }

    private float[] toFloatArray(double[] arr)
    {
      if (arr == null)
        return (float[]) null;
      int length = arr.Length;
      float[] numArray = new float[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = (float) arr[index];
      return numArray;
    }

    public uint Call(uint address, params object[] arg)
    {
      long[] numArray1 = new long[9];
      if (!this.activeConnection)
        this.Connect();
      if (XRPC.firstRan == 0)
      {
        byte[] Data = new byte[4];
        this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out XRPC.meh);
        this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
        Array.Reverse((Array) Data);
        this.bufferAddress = BitConverter.ToUInt32(Data, 0);
        XRPC.firstRan = 1;
        this.stringPointer = this.bufferAddress + 1500U;
        this.floatPointer = this.bufferAddress + 2700U;
        this.bytePointer = this.bufferAddress + 3200U;
        this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 100U, this.nulled, out XRPC.meh);
        this.xbCon.DebugTarget.SetMemory(this.stringPointer, 100U, this.nulled, out XRPC.meh);
      }
      if (this.bufferAddress == 0U)
      {
        byte[] Data = new byte[4];
        this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out XRPC.meh);
        this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
        Array.Reverse((Array) Data);
        this.bufferAddress = BitConverter.ToUInt32(Data, 0);
      }
      this.stringPointer = this.bufferAddress + 1500U;
      this.floatPointer = this.bufferAddress + 2700U;
      this.bytePointer = this.bufferAddress + 3200U;
      int num = 0;
      int index1 = 0;
      foreach (object obj in arg)
      {
        if (obj is byte)
        {
          byte[] numArray2 = (byte[]) obj;
          numArray1[index1] = (long) BitConverter.ToUInt32(numArray2, 0);
        }
        else if (obj is byte[])
        {
          byte[] Data = (byte[]) obj;
          this.xbCon.DebugTarget.SetMemory(this.bytePointer, (uint) Data.Length, Data, out XRPC.meh);
          numArray1[index1] = (long) this.bytePointer;
          this.bytePointer += (uint) (Data.Length + 2);
        }
        else if (obj is float)
        {
          byte[] bytes = BitConverter.GetBytes(float.Parse(Convert.ToString(obj)));
          this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint) bytes.Length, bytes, out XRPC.meh);
          numArray1[index1] = (long) this.floatPointer;
          this.floatPointer += (uint) (bytes.Length + 2);
        }
        else if (obj is float[])
        {
          byte[] Data = new byte[12];
          for (int index2 = 0; index2 <= 2; ++index2)
          {
            byte[] numArray2 = new byte[4];
            Buffer.BlockCopy((Array) obj, index2 * 4, (Array) numArray2, 0, 4);
            Array.Reverse((Array) numArray2);
            Buffer.BlockCopy((Array) numArray2, 0, (Array) Data, 4 * index2, 4);
          }
          this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint) Data.Length, Data, out XRPC.meh);
          numArray1[index1] = (long) this.floatPointer;
          this.floatPointer += 2U;
        }
        else if (obj is string)
        {
          byte[] bytes = Encoding.ASCII.GetBytes(Convert.ToString(obj));
          this.xbCon.DebugTarget.SetMemory(this.stringPointer, (uint) bytes.Length, bytes, out XRPC.meh);
          numArray1[index1] = (long) this.stringPointer;
          this.stringPointer += (uint) (Convert.ToString(obj).Length + 1);
        }
        else
          numArray1[index1] = Convert.ToInt64(obj);
        ++num;
        ++index1;
      }
      byte[] data = XRPC.getData(numArray1);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 8U, (uint) data.Length, data, out XRPC.meh);
      byte[] bytes1 = BitConverter.GetBytes(num);
      Array.Reverse((Array) bytes1);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 4U, 4U, bytes1, out XRPC.meh);
      Thread.Sleep(0);
      byte[] bytes2 = BitConverter.GetBytes(address);
      Array.Reverse((Array) bytes2);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 4U, bytes2, out XRPC.meh);
      Thread.Sleep(50);
      byte[] Data1 = new byte[4];
      this.xbCon.DebugTarget.GetMemory(this.bufferAddress + 4092U, 4U, Data1, out XRPC.meh);
      this.xbCon.DebugTarget.InvalidateMemoryCache(true, this.bufferAddress + 4092U, 4U);
      Array.Reverse((Array) Data1);
      return BitConverter.ToUInt32(Data1, 0);
    }

    public uint CallSysFunction(uint address, params object[] arg)
    {
      long[] numArray1 = new long[9];
      if (!this.activeConnection)
        this.Connect();
      if (XRPC.firstRan == 0)
      {
        byte[] Data = new byte[4];
        this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out XRPC.meh);
        this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
        Array.Reverse((Array) Data);
        this.bufferAddress = BitConverter.ToUInt32(Data, 0);
        XRPC.firstRan = 1;
        this.stringPointer = this.bufferAddress + 1500U;
        this.floatPointer = this.bufferAddress + 2700U;
        this.bytePointer = this.bufferAddress + 3200U;
        this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 100U, this.nulled, out XRPC.meh);
        this.xbCon.DebugTarget.SetMemory(this.stringPointer, 100U, this.nulled, out XRPC.meh);
      }
      if (this.bufferAddress == 0U)
      {
        byte[] Data = new byte[4];
        this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out XRPC.meh);
        this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
        Array.Reverse((Array) Data);
        this.bufferAddress = BitConverter.ToUInt32(Data, 0);
      }
      this.stringPointer = this.bufferAddress + 1500U;
      this.floatPointer = this.bufferAddress + 2700U;
      this.bytePointer = this.bufferAddress + 3200U;
      int num = 0;
      int index1 = 0;
      numArray1[index1] = (long) address;
      int index2 = index1 + 1;
      foreach (object obj in arg)
      {
        if (obj is byte)
        {
          byte[] numArray2 = (byte[]) obj;
          numArray1[index2] = (long) BitConverter.ToUInt32(numArray2, 0);
        }
        else if (obj is byte[])
        {
          byte[] Data = (byte[]) obj;
          this.xbCon.DebugTarget.SetMemory(this.bytePointer, (uint) Data.Length, Data, out XRPC.meh);
          numArray1[index2] = (long) this.bytePointer;
          this.bytePointer += (uint) (Data.Length + 2);
        }
        else if (obj is float)
        {
          byte[] bytes = BitConverter.GetBytes(float.Parse(Convert.ToString(obj)));
          this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint) bytes.Length, bytes, out XRPC.meh);
          numArray1[index2] = (long) this.floatPointer;
          this.floatPointer += (uint) (bytes.Length + 2);
        }
        else if (obj is float[])
        {
          byte[] Data = new byte[12];
          for (int index3 = 0; index3 <= 2; ++index3)
          {
            byte[] numArray2 = new byte[4];
            Buffer.BlockCopy((Array) obj, index3 * 4, (Array) numArray2, 0, 4);
            Array.Reverse((Array) numArray2);
            Buffer.BlockCopy((Array) numArray2, 0, (Array) Data, 4 * index3, 4);
          }
          this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint) Data.Length, Data, out XRPC.meh);
          numArray1[index2] = (long) this.floatPointer;
          this.floatPointer += 2U;
        }
        else if (obj is string)
        {
          byte[] bytes = Encoding.ASCII.GetBytes(Convert.ToString(obj));
          this.xbCon.DebugTarget.SetMemory(this.stringPointer, (uint) bytes.Length, bytes, out XRPC.meh);
          numArray1[index2] = (long) this.stringPointer;
          this.stringPointer += (uint) (Convert.ToString(obj).Length + 1);
        }
        else
          numArray1[index2] = Convert.ToInt64(obj);
        ++num;
        ++index2;
      }
      byte[] data = XRPC.getData(numArray1);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 8U, (uint) data.Length, data, out XRPC.meh);
      byte[] bytes1 = BitConverter.GetBytes(num);
      Array.Reverse((Array) bytes1);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 4U, 4U, bytes1, out XRPC.meh);
      Thread.Sleep(0);
      byte[] bytes2 = BitConverter.GetBytes(2181038080U);
      Array.Reverse((Array) bytes2);
      this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 4U, bytes2, out XRPC.meh);
      Thread.Sleep(50);
      byte[] Data1 = new byte[4];
      this.xbCon.DebugTarget.GetMemory(this.bufferAddress + 4092U, 4U, Data1, out XRPC.meh);
      this.xbCon.DebugTarget.InvalidateMemoryCache(true, this.bufferAddress + 4092U, 4U);
      Array.Reverse((Array) Data1);
      return BitConverter.ToUInt32(Data1, 0);
    }

    public struct wChar
    {
      public string Text;
    }

    public enum XNotiyLogo
    {
      XBOX_LOGO = 0,
      NEW_MESSAGE_LOGO = 1,
      FRIEND_REQUEST_LOGO = 2,
      NEW_MESSAGE = 3,
      FLASHING_XBOX_LOGO = 4,
      GAMERTAG_SENT_YOU_A_MESSAGE = 5,
      GAMERTAG_SINGED_OUT = 6,
      GAMERTAG_SIGNEDIN = 7,
      GAMERTAG_SIGNED_INTO_XBOX_LIVE = 8,
      GAMERTAG_SIGNED_IN_OFFLINE = 9,
      GAMERTAG_WANTS_TO_CHAT = 10, // 0x0000000A
      DISCONNECTED_FROM_XBOX_LIVE = 11, // 0x0000000B
      DOWNLOAD = 12, // 0x0000000C
      FLASHING_MUSIC_SYMBOL = 13, // 0x0000000D
      FLASHING_HAPPY_FACE = 14, // 0x0000000E
      FLASHING_FROWNING_FACE = 15, // 0x0000000F
      FLASHING_DOUBLE_SIDED_HAMMER = 16, // 0x00000010
      GAMERTAG_WANTS_TO_CHAT_2 = 17, // 0x00000011
      PLEASE_REINSERT_MEMORY_UNIT = 18, // 0x00000012
      PLEASE_RECONNECT_CONTROLLERM = 19, // 0x00000013
      GAMERTAG_HAS_JOINED_CHAT = 20, // 0x00000014
      GAMERTAG_HAS_LEFT_CHAT = 21, // 0x00000015
      GAME_INVITE_SENT = 22, // 0x00000016
      FLASH_LOGO = 23, // 0x00000017
      PAGE_SENT_TO = 24, // 0x00000018
      FOUR_2 = 25, // 0x00000019
      FOUR_3 = 26, // 0x0000001A
      ACHIEVEMENT_UNLOCKED = 27, // 0x0000001B
      FOUR_9 = 28, // 0x0000001C
      GAMERTAG_WANTS_TO_TALK_IN_VIDEO_KINECT = 29, // 0x0000001D
      VIDEO_CHAT_INVITE_SENT = 30, // 0x0000001E
      READY_TO_PLAY = 31, // 0x0000001F
      CANT_DOWNLOAD_X = 32, // 0x00000020
      DOWNLOAD_STOPPED_FOR_X = 33, // 0x00000021
      FLASHING_XBOX_CONSOLE = 34, // 0x00000022
      X_SENT_YOU_A_GAME_MESSAGE = 35, // 0x00000023
      DEVICE_FULL = 36, // 0x00000024
      FOUR_7 = 37, // 0x00000025
      FLASHING_CHAT_ICON = 38, // 0x00000026
      ACHIEVEMENTS_UNLOCKED = 39, // 0x00000027
      X_HAS_SENT_YOU_A_NUDGE = 40, // 0x00000028
      MESSENGER_DISCONNECTED = 41, // 0x00000029
      BLANK = 42, // 0x0000002A
      CANT_SIGN_IN_MESSENGER = 43, // 0x0000002B
      MISSED_MESSENGER_CONVERSATION = 44, // 0x0000002C
      FAMILY_TIMER_X_TIME_REMAINING = 45, // 0x0000002D
      DISCONNECTED_XBOX_LIVE_11_MINUTES_REMAINING = 46, // 0x0000002E
      KINECT_HEALTH_EFFECTS = 47, // 0x0000002F
      FOUR_5 = 48, // 0x00000030
      GAMERTAG_WANTS_YOU_TO_JOIN_AN_XBOX_LIVE_PARTY = 49, // 0x00000031
      PARTY_INVITE_SENT = 50, // 0x00000032
      GAME_INVITE_SENT_TO_XBOX_LIVE_PARTY = 51, // 0x00000033
      KICKED_FROM_XBOX_LIVE_PARTY = 52, // 0x00000034
      NULLED = 53, // 0x00000035
      DISCONNECTED_XBOX_LIVE_PARTY = 54, // 0x00000036
      DOWNLOADED = 55, // 0x00000037
      CANT_CONNECT_XBL_PARTY = 56, // 0x00000038
      GAMERTAG_HAS_JOINED_XBL_PARTY = 57, // 0x00000039
      GAMERTAG_HAS_LEFT_XBL_PARTY = 58, // 0x0000003A
      GAMER_PICTURE_UNLOCKED = 59, // 0x0000003B
      AVATAR_AWARD_UNLOCKED = 60, // 0x0000003C
      JOINED_XBL_PARTY = 61, // 0x0000003D
      PLEASE_REINSERT_USB_STORAGE_DEVICE = 62, // 0x0000003E
      PLAYER_MUTED = 63, // 0x0000003F
      PLAYER_UNMUTED = 64, // 0x00000040
      FLASHING_CHAT_SYMBOL = 65, // 0x00000041
      UPDATING = 76, // 0x0000004C
    }
  }
}

using System;
using System.Text;
using System.Threading;
using XDevkit;

namespace XRPCLib
{
    public class XRPC
    {
        private byte[] nulled = new byte[100];
        private uint[] buffcheck = new uint[15];
        public bool activeConnection;
        public bool activeTransfer;
        public IXboxManager xboxMgr;
        public IXboxConsole xbCon;
        private uint xbConnection;
        private int sa;
        public static uint g;
        private static uint meh;
        private static int firstRan;
        private uint bufferAddress;
        private uint stringPointer;
        private uint floatPointer;
        private uint bytePointer;

        public void Connect()
        {
            initialize();
            if (!activeConnection || sa != 0)
                return;
            sa = 1;
        }

        public void initialize()
        {
            if (!activeConnection)
            {
                xboxMgr = new XboxManagerClass();
                xbCon = xboxMgr.OpenConsole(xboxMgr.DefaultConsole);
                try
                {
                    xbConnection = xbCon.OpenConnection((string)null);
                }
                catch (Exception)
                {
                    return;
                }
                string DebuggerName;
                string UserName;
                if (xbCon.DebugTarget.IsDebuggerConnected(out DebuggerName, out UserName))
                {
                    activeConnection = true;
                }
                else
                {
                    xbCon.DebugTarget.ConnectAsDebugger(nameof(XRPC), XboxDebugConnectFlags.Force);
                    if (!xbCon.DebugTarget.IsDebuggerConnected(out DebuggerName, out UserName))
                        return;
                    activeConnection = true;
                }
            }
            else
            {
                string DebuggerName;
                string UserName;
                if (xbCon.DebugTarget.IsDebuggerConnected(out DebuggerName, out UserName))
                    return;
                activeConnection = false;
                Connect();
            }
        }

        public byte[] GetMemory(uint address, uint length)
        {
            byte[] Data = new byte[length];
            xbCon.DebugTarget.GetMemory(address, length, Data, out g);
            xbCon.DebugTarget.InvalidateMemoryCache(true, address, length);
            return Data;
        }

        public byte[] WideChar(string text)
        {
            byte[] numArray = new byte[text.Length * 2 + 2];
            int index = 1;
            numArray[0] = (byte)0;
            foreach (char ch in text)
            {
                numArray[index] = Convert.ToByte(ch);
                index += 2;
            }
            return numArray;
        }

        public void SetMemory(uint address, byte[] data)
        {
            xbCon.DebugTarget.SetMemory(address, (uint)data.Length, data, out g);
        }

        private static byte[] getData(long[] argument)
        {
            byte[] numArray = new byte[argument.Length * 8];
            int index = 0;
            foreach (long num in argument)
            {
                byte[] bytes = BitConverter.GetBytes(num);
                Array.Reverse((Array)bytes);
                bytes.CopyTo((Array)numArray, index);
                index += 8;
            }
            return numArray;
        }

        public uint SystemCall(params object[] arg)
        {
            long[] numArray1 = new long[9];
            if (!activeConnection)
                Connect();
            if (firstRan == 0)
            {
                byte[] Data = new byte[4];
                xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out meh);
                xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
                Array.Reverse((Array)Data);
                bufferAddress = BitConverter.ToUInt32(Data, 0);
                firstRan = 1;
                stringPointer = bufferAddress + 1500U;
                floatPointer = bufferAddress + 2700U;
                bytePointer = bufferAddress + 3200U;
                xbCon.DebugTarget.SetMemory(bufferAddress, 100U, nulled, out meh);
                xbCon.DebugTarget.SetMemory(stringPointer, 100U, nulled, out meh);
            }
            if (bufferAddress == 0U)
            {
                byte[] Data = new byte[4];
                xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out meh);
                xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
                Array.Reverse((Array)Data);
                bufferAddress = BitConverter.ToUInt32(Data, 0);
            }
            stringPointer = bufferAddress + 1500U;
            floatPointer = bufferAddress + 2700U;
            bytePointer = bufferAddress + 3200U;
            int num = 0;
            int index1 = 0;
            foreach (object obj in arg)
            {
                if (obj is byte)
                {
                    byte[] numArray2 = (byte[])obj;
                    numArray1[index1] = BitConverter.ToUInt32(numArray2, 0);
                }
                else if (obj is byte[])
                {
                    byte[] Data = (byte[])obj;
                    xbCon.DebugTarget.SetMemory(bytePointer, (uint)Data.Length, Data, out meh);
                    numArray1[index1] = bytePointer;
                    bytePointer += (uint)(Data.Length + 2);
                }
                else if (obj is float)
                {
                    byte[] bytes = BitConverter.GetBytes(float.Parse(Convert.ToString(obj)));
                    xbCon.DebugTarget.SetMemory(floatPointer, (uint)bytes.Length, bytes, out meh);
                    numArray1[index1] = floatPointer;
                    floatPointer += (uint)(bytes.Length + 2);
                }
                else if (obj is float[])
                {
                    byte[] Data = new byte[12];
                    for (int index2 = 0; index2 <= 2; ++index2)
                    {
                        byte[] numArray2 = new byte[4];
                        Buffer.BlockCopy((Array)obj, index2 * 4, numArray2, 0, 4);
                        Array.Reverse(numArray2);
                        Buffer.BlockCopy(numArray2, 0, Data, 4 * index2, 4);
                    }
                    xbCon.DebugTarget.SetMemory(floatPointer, (uint)Data.Length, Data, out meh);
                    numArray1[index1] = floatPointer;
                    floatPointer += 2U;
                }
                else if (obj is string)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(Convert.ToString(obj));
                    xbCon.DebugTarget.SetMemory(stringPointer, (uint)bytes.Length, bytes, out meh);
                    numArray1[index1] = stringPointer;
                    stringPointer += (uint)(Convert.ToString(obj).Length + 1);
                }
                else
                    numArray1[index1] = Convert.ToInt64(obj);
                ++num;
                ++index1;
            }
            byte[] data = getData(numArray1);
            xbCon.DebugTarget.SetMemory(bufferAddress + 8U, (uint)data.Length, data, out meh);
            byte[] bytes1 = BitConverter.GetBytes(num);
            Array.Reverse(bytes1);
            xbCon.DebugTarget.SetMemory(bufferAddress + 4U, 4U, bytes1, out meh);
            Thread.Sleep(0);
            byte[] bytes2 = BitConverter.GetBytes(2181038080U);
            Array.Reverse(bytes2);
            xbCon.DebugTarget.SetMemory(bufferAddress, 4U, bytes2, out meh);
            Thread.Sleep(50);
            byte[] Data1 = new byte[4];
            xbCon.DebugTarget.GetMemory(bufferAddress + 4092U, 4U, Data1, out meh);
            xbCon.DebugTarget.InvalidateMemoryCache(true, bufferAddress + 4092U, 4U);
            Array.Reverse(Data1);
            return BitConverter.ToUInt32(Data1, 0);
        }

        public uint ResolveFunction(string titleID, uint ord)
        {
            if (firstRan == 0)
            {
                byte[] Data = new byte[4];
                xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out meh);
                xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
                Array.Reverse(Data);
                bufferAddress = BitConverter.ToUInt32(Data, 0);
                firstRan = 1;
                stringPointer = bufferAddress + 1500U;
                floatPointer = bufferAddress + 2700U;
                bytePointer = bufferAddress + 3200U;
                xbCon.DebugTarget.SetMemory(bufferAddress, 100U, nulled, out meh);
                xbCon.DebugTarget.SetMemory(stringPointer, 100U, nulled, out meh);
            }
            byte[] bytes1 = Encoding.ASCII.GetBytes(titleID);
            xbCon.DebugTarget.SetMemory(stringPointer, (uint)bytes1.Length, bytes1, out meh);
            long[] numArray = new long[2]
            {
         stringPointer,
        0L
            };
            stringPointer += (uint)(Convert.ToString(titleID).Length + 1);
            numArray[1] = ord;
            byte[] data = getData(numArray);
            xbCon.DebugTarget.SetMemory(bufferAddress + 8U, (uint)data.Length, data, out meh);
            byte[] bytes2 = BitConverter.GetBytes(2181038081U);
            Array.Reverse((Array)bytes2);
            xbCon.DebugTarget.SetMemory(bufferAddress, 4U, bytes2, out meh);
            Thread.Sleep(50);
            byte[] Data1 = new byte[4];
            xbCon.DebugTarget.GetMemory(bufferAddress + 4092U, 4U, Data1, out meh);
            xbCon.DebugTarget.InvalidateMemoryCache(true, bufferAddress + 4092U, 4U);
            Array.Reverse((Array)Data1);
            return BitConverter.ToUInt32(Data1, 0);
        }

        public void Notify(XNotiyLogo type, string text)
        {
            byte[] numArray = WideChar(text);
            int num = (int)SystemCall((object)ResolveFunction("xam.xex", 656U), (object)Convert.ToUInt32((object)type), (object)0, (object)2, (object)numArray, (object)0);
        }

        private float[] toFloatArray(double[] arr)
        {
            if (arr == null)
                return (float[])null;
            int length = arr.Length;
            float[] numArray = new float[length];
            for (int index = 0; index < length; ++index)
                numArray[index] = (float)arr[index];
            return numArray;
        }

        public uint Call(uint address, params object[] arg)
        {
            long[] numArray1 = new long[9];
            if (!activeConnection)
                Connect();
            if (firstRan == 0)
            {
                byte[] Data = new byte[4];
                xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out meh);
                xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
                Array.Reverse((Array)Data);
                bufferAddress = BitConverter.ToUInt32(Data, 0);
                firstRan = 1;
                stringPointer = bufferAddress + 1500U;
                floatPointer = bufferAddress + 2700U;
                bytePointer = bufferAddress + 3200U;
                xbCon.DebugTarget.SetMemory(bufferAddress, 100U, nulled, out meh);
                xbCon.DebugTarget.SetMemory(stringPointer, 100U, nulled, out meh);
            }
            if (bufferAddress == 0U)
            {
                byte[] Data = new byte[4];
                xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out meh);
                xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
                Array.Reverse(Data);
                bufferAddress = BitConverter.ToUInt32(Data, 0);
            }
            stringPointer = bufferAddress + 1500U;
            floatPointer = bufferAddress + 2700U;
            bytePointer = bufferAddress + 3200U;
            int num = 0;
            int index1 = 0;
            foreach (object obj in arg)
            {
                if (obj is byte)
                {
                    byte[] numArray2 = (byte[])obj;
                    numArray1[index1] = BitConverter.ToUInt32(numArray2, 0);
                }
                else if (obj is byte[])
                {
                    byte[] Data = (byte[])obj;
                    xbCon.DebugTarget.SetMemory(bytePointer, (uint)Data.Length, Data, out meh);
                    numArray1[index1] = bytePointer;
                    bytePointer += (uint)(Data.Length + 2);
                }
                else if (obj is float)
                {
                    byte[] bytes = BitConverter.GetBytes(float.Parse(Convert.ToString(obj)));
                    xbCon.DebugTarget.SetMemory(floatPointer, (uint)bytes.Length, bytes, out meh);
                    numArray1[index1] = floatPointer;
                    floatPointer += (uint)(bytes.Length + 2);
                }
                else if (obj is float[])
                {
                    byte[] Data = new byte[12];
                    for (int index2 = 0; index2 <= 2; ++index2)
                    {
                        byte[] numArray2 = new byte[4];
                        Buffer.BlockCopy((Array)obj, index2 * 4, (Array)numArray2, 0, 4);
                        Array.Reverse((Array)numArray2);
                        Buffer.BlockCopy((Array)numArray2, 0, (Array)Data, 4 * index2, 4);
                    }
                    xbCon.DebugTarget.SetMemory(floatPointer, (uint)Data.Length, Data, out meh);
                    numArray1[index1] = floatPointer;
                    floatPointer += 2U;
                }
                else if (obj is string)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(Convert.ToString(obj));
                    xbCon.DebugTarget.SetMemory(stringPointer, (uint)bytes.Length, bytes, out meh);
                    numArray1[index1] = stringPointer;
                    stringPointer += (uint)(Convert.ToString(obj).Length + 1);
                }
                else
                    numArray1[index1] = Convert.ToInt64(obj);
                ++num;
                ++index1;
            }
            byte[] data = getData(numArray1);
            xbCon.DebugTarget.SetMemory(bufferAddress + 8U, (uint)data.Length, data, out meh);
            byte[] bytes1 = BitConverter.GetBytes(num);
            Array.Reverse((Array)bytes1);
            xbCon.DebugTarget.SetMemory(bufferAddress + 4U, 4U, bytes1, out meh);
            Thread.Sleep(0);
            byte[] bytes2 = BitConverter.GetBytes(address);
            Array.Reverse((Array)bytes2);
            xbCon.DebugTarget.SetMemory(bufferAddress, 4U, bytes2, out meh);
            Thread.Sleep(50);
            byte[] Data1 = new byte[4];
            xbCon.DebugTarget.GetMemory(bufferAddress + 4092U, 4U, Data1, out meh);
            xbCon.DebugTarget.InvalidateMemoryCache(true, bufferAddress + 4092U, 4U);
            Array.Reverse((Array)Data1);
            return BitConverter.ToUInt32(Data1, 0);
        }

        public uint CallSysFunction(uint address, params object[] arg)
        {
            long[] numArray1 = new long[9];
            if (!activeConnection)
                Connect();
            if (firstRan == 0)
            {
                byte[] Data = new byte[4];
                xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out meh);
                xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
                Array.Reverse((Array)Data);
                bufferAddress = BitConverter.ToUInt32(Data, 0);
                firstRan = 1;
                stringPointer = bufferAddress + 1500U;
                floatPointer = bufferAddress + 2700U;
                bytePointer = bufferAddress + 3200U;
                xbCon.DebugTarget.SetMemory(bufferAddress, 100U, nulled, out meh);
                xbCon.DebugTarget.SetMemory(stringPointer, 100U, nulled, out meh);
            }
            if (bufferAddress == 0U)
            {
                byte[] Data = new byte[4];
                xbCon.DebugTarget.GetMemory(2445314222U, 4U, Data, out meh);
                xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
                Array.Reverse((Array)Data);
                bufferAddress = BitConverter.ToUInt32(Data, 0);
            }
            stringPointer = bufferAddress + 1500U;
            floatPointer = bufferAddress + 2700U;
            bytePointer = bufferAddress + 3200U;
            int num = 0;
            int index1 = 0;
            numArray1[index1] = address;
            int index2 = index1 + 1;
            foreach (object obj in arg)
            {
                if (obj is byte)
                {
                    byte[] numArray2 = (byte[])obj;
                    numArray1[index2] = BitConverter.ToUInt32(numArray2, 0);
                }
                else if (obj is byte[])
                {
                    byte[] Data = (byte[])obj;
                    xbCon.DebugTarget.SetMemory(bytePointer, (uint)Data.Length, Data, out meh);
                    numArray1[index2] = bytePointer;
                    bytePointer += (uint)(Data.Length + 2);
                }
                else if (obj is float)
                {
                    byte[] bytes = BitConverter.GetBytes(float.Parse(Convert.ToString(obj)));
                    xbCon.DebugTarget.SetMemory(floatPointer, (uint)bytes.Length, bytes, out meh);
                    numArray1[index2] = floatPointer;
                    floatPointer += (uint)(bytes.Length + 2);
                }
                else if (obj is float[])
                {
                    byte[] Data = new byte[12];
                    for (int index3 = 0; index3 <= 2; ++index3)
                    {
                        byte[] numArray2 = new byte[4];
                        Buffer.BlockCopy((Array)obj, index3 * 4, (Array)numArray2, 0, 4);
                        Array.Reverse((Array)numArray2);
                        Buffer.BlockCopy((Array)numArray2, 0, (Array)Data, 4 * index3, 4);
                    }
                    xbCon.DebugTarget.SetMemory(floatPointer, (uint)Data.Length, Data, out meh);
                    numArray1[index2] = floatPointer;
                    floatPointer += 2U;
                }
                else if (obj is string)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(Convert.ToString(obj));
                    xbCon.DebugTarget.SetMemory(stringPointer, (uint)bytes.Length, bytes, out meh);
                    numArray1[index2] = stringPointer;
                    stringPointer += (uint)(Convert.ToString(obj).Length + 1);
                }
                else
                    numArray1[index2] = Convert.ToInt64(obj);
                ++num;
                ++index2;
            }
            byte[] data = getData(numArray1);
            xbCon.DebugTarget.SetMemory(bufferAddress + 8U, (uint)data.Length, data, out meh);
            byte[] bytes1 = BitConverter.GetBytes(num);
            Array.Reverse((Array)bytes1);
            xbCon.DebugTarget.SetMemory(bufferAddress + 4U, 4U, bytes1, out meh);
            Thread.Sleep(0);
            byte[] bytes2 = BitConverter.GetBytes(2181038080U);
            Array.Reverse((Array)bytes2);
            xbCon.DebugTarget.SetMemory(bufferAddress, 4U, bytes2, out meh);
            Thread.Sleep(50);
            byte[] Data1 = new byte[4];
            xbCon.DebugTarget.GetMemory(bufferAddress + 4092U, 4U, Data1, out meh);
            xbCon.DebugTarget.InvalidateMemoryCache(true, bufferAddress + 4092U, 4U);
            Array.Reverse((Array)Data1);
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
            GAMERTAG_WANTS_TO_CHAT = 10,
            DISCONNECTED_FROM_XBOX_LIVE = 11,
            DOWNLOAD = 12,
            FLASHING_MUSIC_SYMBOL = 13,
            FLASHING_HAPPY_FACE = 14,
            FLASHING_FROWNING_FACE = 15,
            FLASHING_DOUBLE_SIDED_HAMMER = 16,
            GAMERTAG_WANTS_TO_CHAT_2 = 17,
            PLEASE_REINSERT_MEMORY_UNIT = 18,
            PLEASE_RECONNECT_CONTROLLERM = 19,
            GAMERTAG_HAS_JOINED_CHAT = 20,
            GAMERTAG_HAS_LEFT_CHAT = 21,
            GAME_INVITE_SENT = 22,
            FLASH_LOGO = 23,
            PAGE_SENT_TO = 24,
            FOUR_2 = 25,
            FOUR_3 = 26,
            ACHIEVEMENT_UNLOCKED = 27,
            FOUR_9 = 28,
            GAMERTAG_WANTS_TO_TALK_IN_VIDEO_KINECT = 29,
            VIDEO_CHAT_INVITE_SENT = 30,
            READY_TO_PLAY = 31,
            CANT_DOWNLOAD_X = 32,
            DOWNLOAD_STOPPED_FOR_X = 33,
            FLASHING_XBOX_CONSOLE = 34,
            X_SENT_YOU_A_GAME_MESSAGE = 35,
            DEVICE_FULL = 36,
            FOUR_7 = 37,
            FLASHING_CHAT_ICON = 38,
            ACHIEVEMENTS_UNLOCKED = 39,
            X_HAS_SENT_YOU_A_NUDGE = 40,
            MESSENGER_DISCONNECTED = 41,
            BLANK = 42,
            CANT_SIGN_IN_MESSENGER = 43,
            MISSED_MESSENGER_CONVERSATION = 44,
            FAMILY_TIMER_X_TIME_REMAINING = 45,
            DISCONNECTED_XBOX_LIVE_11_MINUTES_REMAINING = 46,
            KINECT_HEALTH_EFFECTS = 47,
            FOUR_5 = 48,
            GAMERTAG_WANTS_YOU_TO_JOIN_AN_XBOX_LIVE_PARTY = 49,
            PARTY_INVITE_SENT = 50,
            GAME_INVITE_SENT_TO_XBOX_LIVE_PARTY = 51,
            KICKED_FROM_XBOX_LIVE_PARTY = 52,
            NULLED = 53,
            DISCONNECTED_XBOX_LIVE_PARTY = 54,
            DOWNLOADED = 55,
            CANT_CONNECT_XBL_PARTY = 56,
            GAMERTAG_HAS_JOINED_XBL_PARTY = 57,
            GAMERTAG_HAS_LEFT_XBL_PARTY = 58,
            GAMER_PICTURE_UNLOCKED = 59,
            AVATAR_AWARD_UNLOCKED = 60,
            JOINED_XBL_PARTY = 61,
            PLEASE_REINSERT_USB_STORAGE_DEVICE = 62,
            PLAYER_MUTED = 63,
            PLAYER_UNMUTED = 64,
            FLASHING_CHAT_SYMBOL = 65,
            UPDATING = 76,
        }
    }
}

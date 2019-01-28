// Decompiled with JetBrains decompiler
// Type: XDevkit.IXboxStackFrame
// Assembly: XRPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76786C01-8B8F-460F-885C-89B2A0240B23
// Assembly location: C:\Users\Serenity\Desktop\XRPC.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
  [TypeLibType(4160)]
  [Guid("EABF8976-1A2F-4AAA-BBBB-3ECAB03B2EE9")]
  [ComVisible(true)]
  [ComImport]
  public interface IXboxStackFrame
  {
    [DispId(1)]
    bool TopOfStack { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(2)]
    bool Dirty { [DispId(2), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(3)]
    IXboxStackFrame NextStackFrame { [DispId(3), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(100)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    bool GetRegister32([In] XboxRegisters32 Register, out int Value);

    [DispId(101)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetRegister32([In] XboxRegisters32 Register, [In] int Value);

    [DispId(102)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    bool GetRegister64([In] XboxRegisters64 Register, out long Value);

    [DispId(103)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetRegister64([In] XboxRegisters64 Register, [In] long Value);

    [DispId(104)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    bool GetRegisterDouble([In] XboxRegistersDouble Register, out double Value);

    [DispId(105)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetRegisterDouble([In] XboxRegistersDouble Register, [In] double Value);

    [DispId(106)]
    [TypeLibFunc(64)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    bool GetRegisterVector_cpp([In] XboxRegistersVector Register, out float Value);

    [TypeLibFunc(64)]
    [DispId(107)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetRegisterVector_cpp([In] XboxRegistersVector Register, [In] ref float Value);

    [DispId(108)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    bool GetRegisterVector([In] XboxRegistersVector Register, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R4)] float[] Value);

    [DispId(109)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetRegisterVector([In] XboxRegistersVector Register, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R4)] float[] Value);

    [DispId(110)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void FlushRegisterChanges();

    [DispId(111)]
    XBOX_FUNCTION_INFO FunctionInfo { [DispId(111), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(112)]
    uint StackPointer { [DispId(112), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [DispId(113)]
    uint ReturnAddress { [DispId(113), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}

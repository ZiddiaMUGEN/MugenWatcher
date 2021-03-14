using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MugenWatcher
{
    public class ExternalFuncs
    {
        public struct CONTEXT
        {
            public uint ContextFlags;
            public uint Dr0;
            public uint Dr1;
            public uint Dr2;
            public uint Dr3;
            public uint Dr6;
            public uint Dr7;
            public FLOATING_SAVE_AREA FloatSave;
            public uint SegGs;
            public uint SegFs;
            public uint SegEs;
            public uint SegDs;
            public uint Edi;
            public uint Esi;
            public uint Ebx;
            public uint Edx;
            public uint Ecx;
            public uint Eax;
            public uint Ebp;
            public uint Eip;
            public uint SegCs;
            public uint EFlags;
            public uint Esp;
            public uint SegSs;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public byte[] ExtendedRegisters;
        }
        public struct FLOATING_SAVE_AREA
        {
            public uint ControlWord;
            public uint StatusWord;
            public uint TagWord;
            public uint ErrorOffset;
            public uint ErrorSelector;
            public uint DataOffset;
            public uint DataSelector;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
            public byte[] RegisterArea;
            public uint Cr0NpxState;
        }

        internal enum CONTEXT_FLAGS : uint
        {
            CONTEXT_i386 = 65536, // 0x00010000
            CONTEXT_i486 = 65536, // 0x00010000
            CONTEXT_CONTROL = 65537, // 0x00010001
            CONTEXT_INTEGER = 65538, // 0x00010002
            CONTEXT_SEGMENTS = 65540, // 0x00010004
            CONTEXT_FULL = 65543, // 0x00010007
            CONTEXT_FLOATING_POINT = 65544, // 0x00010008
            CONTEXT_DEBUG_REGISTERS = 65552, // 0x00010010
            CONTEXT_EXTENDED_REGISTERS = 65568, // 0x00010020
            CONTEXT_ALL = 65599, // 0x0001003F
        }

        // reference for setting flags in child thread
        [Flags]
        internal enum ThreadAccessFlags
        {
            TERMINATE = 1,
            SUSPEND_RESUME = 2,
            GET_CONTEXT = 8,
            SET_CONTEXT = 16, // 0x00000010
            SET_INFORMATION = 32, // 0x00000020
            QUERY_INFORMATION = 64, // 0x00000040
            SET_THREAD_TOKEN = 128, // 0x00000080
            IMPERSONATE = 256, // 0x00000100
            DIRECT_IMPERSONATION = 512, // 0x00000200
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct HIGHWORD
        {
            [FieldOffset(0)]
            public BYTES Bytes;
            [FieldOffset(0)]
            public BITS Bits;
        }

        internal struct LDT_ENTRY
        {
            public ushort LimitLow;
            public ushort BaseLow;
            public HIGHWORD HighWord;
        }

        internal struct BYTES
        {
            public byte BaseMid;
            public byte Flags1;
            public byte Flags2;
            public byte BaseHi;
        }

        internal struct BITS
        {
            private int Value;

            public int BaseMid
            {
                get => this.Value & (int)byte.MaxValue;
                set => this.Value = this.Value & -256 | value & (int)byte.MaxValue;
            }

            public int Type
            {
                get => (this.Value & 7936) >> 8;
                set => this.Value = this.Value & -7937 | (value & 31) << 8;
            }

            public int Dpl
            {
                get => (this.Value & 24576) >> 13;
                set => this.Value = this.Value & -24577 | (value & 3) << 13;
            }

            public int Pres
            {
                get => (this.Value & 16384) >> 15;
                set => this.Value = this.Value & -16385 | (value & 1) << 15;
            }

            public int LimitHi
            {
                get => (this.Value & 983040) >> 16;
                set => this.Value = this.Value & -983041 | (value & 15) << 16;
            }

            public int Sys
            {
                get => (this.Value & 1048576) >> 20;
                set => this.Value = this.Value & -1048577 | (value & 1) << 20;
            }

            public int Reserved_0
            {
                get => (this.Value & 2097152) >> 21;
                set => this.Value = this.Value & -2097153 | (value & 1) << 21;
            }

            public int Default_Big
            {
                get => (this.Value & 4194304) >> 22;
                set => this.Value = this.Value & -4194305 | (value & 1) << 22;
            }

            public int Granularity
            {
                get => (this.Value & 8388608) >> 23;
                set => this.Value = this.Value & -8388609 | (value & 1) << 23;
            }

            public int BaseHi
            {
                get => (this.Value & -16777216) >> 24;
                set => this.Value = this.Value & 16777215 | (value & (int)byte.MaxValue) << 24;
            }
        }

        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenThread(
          ThreadAccessFlags dwDesiredAccess,
          [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle,
          uint dwThreadId);

        internal static int SuspendThreadEx(IntPtr hThread) => IntPtr.Size == 4 ? SuspendThread(hThread) : Wow64SuspendThread(hThread);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(IntPtr handle);

        internal static bool GetThreadContextEx(IntPtr hThread, ref CONTEXT context) => IntPtr.Size == 4 ? GetThreadContext(hThread, ref context) : Wow64GetThreadContext(hThread, ref context);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ReadProcessMemory(
          IntPtr hProcess,
          IntPtr lpBaseAddress,
          byte[] lpBuffer,
          UIntPtr nSize,
          out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteProcessMemory(
          IntPtr hProcess,
          IntPtr lpBaseAddress,
          byte[] lpBuffer,
          uint nSize,
          out UIntPtr lpNumberOfBytesWritten);

        internal static bool SetThreadContextEx(IntPtr hThread, ref CONTEXT context) => IntPtr.Size == 4 ? SetThreadContext(hThread, ref context) : Wow64SetThreadContext(hThread, ref context);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetThreadContext(IntPtr hThread, ref CONTEXT lpContext);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool Wow64GetThreadContext(
          IntPtr hThread,
          ref CONTEXT lpContext);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetThreadContext(IntPtr hThread, ref CONTEXT lpContext);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool Wow64SetThreadContext(
          IntPtr hThread,
          ref CONTEXT lpContext);

        [DllImport("kernel32.dll")]
        internal static extern int ResumeThread(IntPtr hThread);

        internal static int ResumeThreadEx(IntPtr hThread) => ResumeThread(hThread);

        [DllImport("kernel32.dll")]
        internal static extern int SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        internal static extern int Wow64SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool GetThreadSelectorEntry(
          IntPtr hThread,
          uint dwSelector,
          ref LDT_ENTRY lpSelectorEntry);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool Wow64GetThreadSelectorEntry(
          IntPtr hThread,
          uint dwSelector,
          ref LDT_ENTRY lpSelectorEntry);

        internal static bool GetThreadSelectorEntryEx(
          IntPtr hThread,
          uint dwSelector,
          ref LDT_ENTRY lpSelectorEntry)
        {
            return IntPtr.Size == 4 ? GetThreadSelectorEntry(hThread, dwSelector, ref lpSelectorEntry) : Wow64GetThreadSelectorEntry(hThread, dwSelector, ref lpSelectorEntry);
        }
    }
}

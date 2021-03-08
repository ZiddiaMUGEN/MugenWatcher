using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MugenWatcher
{
    internal class ExternalFuncs
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(
          IntPtr hProcess,
          IntPtr lpBaseAddress,
          byte[] lpBuffer,
          UIntPtr nSize,
          out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(
          IntPtr hProcess,
          IntPtr lpBaseAddress,
          byte[] lpBuffer,
          uint nSize,
          out UIntPtr lpNumberOfBytesWritten);
    }
}

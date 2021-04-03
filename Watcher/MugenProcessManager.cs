using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MugenWatcher.Watcher
{
    /// <summary>
    /// multi-purpose handler for the Process object, including memory read/write ops.
    /// </summary>
    internal class MugenProcessManager
    {

        /// <summary>
        /// process handle for the Mugen window
        /// </summary>
        private Process mugenProcess;

        /// <summary>
        /// Gets the current Mugen process handle, or null if it is not running.
        /// </summary>
        /// <returns></returns>
        internal Process GetMugenProcess() => this.mugenProcess == null || !this.mugenProcess.HasExited ? this.mugenProcess : (Process)null;

        /// <summary>
        /// gets the mugen process in an unsafe way (no null/exit checking)
        /// </summary>
        /// <returns></returns>
        internal Process GetMugenProcessUnsafe() => this.mugenProcess;

        /// <summary>
        /// returns true if the Mugen process has started and has not exited.
        /// </summary>
        /// <returns></returns>
        internal bool CheckMugenProcessActive() => this.mugenProcess != null && !this.mugenProcess.HasExited;

        /// <summary>
        /// Attempts to kill running Mugen process + await its exit.
        /// </summary>
        internal void KillAndAwaitMugenProcessEnd()
        {
            if (this.mugenProcess != null)
            {
                if (!this.mugenProcess.HasExited)
                    this.mugenProcess.Kill();
                this.mugenProcess.WaitForExit(2000);
                this.mugenProcess.Close();
                this.mugenProcess.Dispose();
                this.mugenProcess = (Process)null;
            }
        }

        /// <summary>
        /// launches the process.
        /// </summary>
        /// <param name="startInfo"></param>
        internal void Launch(ProcessStartInfo startInfo)
        {
            this.mugenProcess = Process.Start(startInfo);
        }

        /// <summary>
        /// Returns true if the mugen window is active, or false if it is inactive (crashed or loading).
        /// </summary>
        /// <returns></returns>
        internal bool CheckMugenWindowStatus() => !this.mugenProcess.MainWindowHandle.Equals((object)IntPtr.Zero);

        /// <summary>
        /// sets the process to null.
        /// TODO: safety check
        /// </summary>
        internal void DestroyMugenProcess() { this.mugenProcess = null; }

        /// <summary>
        /// just a clean helper to get the MainWindowHandle
        /// </summary>
        /// <returns></returns>
        internal IntPtr GetMugenWindowHandle() => this.mugenProcess.MainWindowHandle;

        /// <summary>
        /// directly reads memory from the Mugen process in a safe manner, writes to a buffer, and returns the size.
        /// </summary>
        /// <param name="addr">address to read from</param>
        /// <param name="buf">buffer to write to</param>
        /// <param name="bufLen">length of the buffer</param>
        /// <returns></returns>
        private int ReadMemory(IntPtr addr, ref byte[] buf, uint bufLen)
        {
            if (!this.CheckMugenProcessActive())
                return 0;
            int lpNumberOfBytesRead;
            try
            {
                if (!ExternalFuncs.ReadProcessMemory(this.GetMugenProcess().Handle, addr, buf, (UIntPtr)bufLen, out lpNumberOfBytesRead))
                    return 0;
            }
            catch
            {
                return 0;
            }
            return lpNumberOfBytesRead;
        }

        /// <summary>
        /// writes values in a buffer to an address in memory
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="buf"></param>
        /// <param name="bufLen"></param>
        private void WriteMemory(IntPtr addr, ref byte[] buf, uint bufLen)
        {
            if (!this.CheckMugenProcessActive())
                return;
            try
            {
                ExternalFuncs.WriteProcessMemory(this.GetMugenProcess().Handle, addr, buf, bufLen, out UIntPtr _);
            }
            catch
            {
            }
        }

        internal int ReadMemoryEx(uint baseAddr, uint offset, ref byte[] buf)
        {
            uint len = (uint)buf.Length;
            return this.ReadMemory((IntPtr)(baseAddr + offset), ref buf, len);
        }

        internal void WriteMemoryEx(uint baseAddr, uint offset, byte[] buf)
        {
            uint len = (uint)buf.Length;
            this.WriteMemory((IntPtr)(baseAddr + offset), ref buf, len);
        }

        /// <summary>
        /// helper function to read an integer from a specified address+offset combo
        /// </summary>
        /// <param name="addr">base address to read at</param>
        /// <param name="offset">offset from addr</param>
        /// <returns>data stored in memory as an integer</returns>
        internal int GetInt32Data(uint addr, uint offset)
        {
            int num = 0;
            byte[] buf = new byte[4];
            if (this.ReadMemory((IntPtr)(long)(addr + offset), ref buf, 4U) > 0)
                num = BitConverter.ToInt32(buf, 0);
            return num;
        }

        /// <summary>
        /// sets one int of data in Mugen's memory.
        /// </summary>
        /// <param name="addr">address to write to</param>
        /// <param name="offset">offset from addr to write to</param>
        /// <param name="value">value to write</param>
        internal void SetInt32Data(uint addr, uint offset, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            this.WriteMemory((IntPtr)(long)(addr + offset), ref bytes, 4U);
        }

        internal void SetUInt32Data(uint addr, uint offset, uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            this.WriteMemory((IntPtr)(long)(addr + offset), ref bytes, 4U);
        }

        internal void SetByteData(uint addr, uint offset, byte[] values)
        {
            this.WriteMemory((IntPtr)(long)(addr + offset), ref values, (uint) values.Length);
        }

        /// <summary>
        /// helper function to read a float from a specified address+offset combo
        /// </summary>
        /// <param name="addr">base address to read at</param>
        /// <param name="offset">offset from addr</param>
        /// <returns>data stored in memory as a float (4-byte)</returns>
        internal float GetFloatData(uint addr, uint offset)
        {
            float num = 0.0f;
            byte[] buf = new byte[4];
            if (this.ReadMemory((IntPtr)(long)(addr + offset), ref buf, 4U) > 0)
                num = BitConverter.ToSingle(buf, 0);
            return num;
        }

        internal void SetFloatData(uint addr, uint offset, float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            this.WriteMemory((IntPtr)(long)(addr + offset), ref bytes, 4U);
        }

        /// <summary>
        /// helper function to read a double from a specified address+offset combo
        /// </summary>
        /// <param name="addr">base address to read at</param>
        /// <param name="offset">offset from addr</param>
        /// <returns>data stored in memory as a double (8-byte float)</returns>
        internal double GetDoubleData(uint addr, uint offset)
        {
            double num = 0.0;
            byte[] buf = new byte[8];
            if (this.ReadMemory((IntPtr)(long)(addr + offset), ref buf, 8U) > 0)
                num = BitConverter.ToDouble(buf, 0);
            return num;
        }

        internal void SetDoubleData(uint addr, uint offset, double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            this.WriteMemory((IntPtr)(long)(addr + offset), ref bytes, 8U);
        }

    }
}

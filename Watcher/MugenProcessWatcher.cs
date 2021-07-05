using Microsoft.Samples.Debugging.Native;
using MugenWatcher.Databases;
using MugenWatcher.EnumTypes;
using MugenWatcher.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using static MugenWatcher.ExternalFuncs;

namespace MugenWatcher.Watcher
{
    /// <summary>
    /// the actual process watcher. manages memory/debug and offers methods to read or modify the running process.
    /// </summary>
    public class MugenProcessWatcher
    {
        /// <summary>
        /// addresses to use for this watcher
        /// </summary>
        public MugenAddrDatabase MugenDatabase { get; private set; }

        /// <summary>
        /// version of mugen being run
        /// </summary>
        public MugenType_t MugenVersion { get; private set; }
        public int BaseAddress { get; internal set; }

        private readonly MugenProcessManager processManager;
        private readonly DebugProcessManager debugManager;

        public MugenProcessWatcher(bool infinite = false)
        {
            this.processManager = new MugenProcessManager();
            this.debugManager = new DebugProcessManager(infinite);
        }

        /// <summary>
        /// resets Mugen version to NONE.
        /// </summary>
        public void ResetMugenVersion()
        {
            this.MugenVersion = MugenType_t.MUGEN_TYPE_NONE;
        }

        /// <summary>
        /// Sets the current Mugen version if it's set to NONE, additionally updating the address DB.
        /// Else throws an exception.
        /// </summary>
        /// <param name="newVersion"></param>
        public void SetMugenVersion(MugenType_t newVersion)
        {
            // reset base addr
            this.BaseAddress = 0;
            if (this.MugenVersion == MugenType_t.MUGEN_TYPE_NONE)
            {
                this.MugenVersion = newVersion;
                this.MugenDatabase = MugenAddrDatabase.GetAddrDatabase(this.MugenVersion);
            }
            else throw new MugenVersionException("Cannot set MUGEN version - has already been set!");
        }



        /// <summary>
        /// Attempts to kill running Mugen process + await its exit.
        /// </summary>
        public void KillAndAwaitMugenProcessEnd()
        {
            this.processManager.KillAndAwaitMugenProcessEnd();
        }

        /// <summary>
        /// Launches Mugen based on the passed ProcessStartInfo. Expects it to be fully populated.
        /// <br/>The calling code is responsible for finding the EXE, setting up params, etc.
        /// </summary>
        /// <param name="startInfo"></param>
        public void LaunchMugenProcess(ProcessStartInfo startInfo)
        {
            // save cwd
            string currentDirectory = Environment.CurrentDirectory;
            // update to cwd for Mugen process
            Environment.CurrentDirectory = startInfo.WorkingDirectory;
            try
            {
                // launch process
                this.processManager.Launch(startInfo);
            } catch
            {
                // failed
                this.ResetMugenVersion();
            } finally
            {
                // reset the cwd
                Environment.CurrentDirectory = currentDirectory;
            }
        }

        /// <summary>
        /// returns true if the Mugen process is active + not exited.
        /// </summary>
        /// <returns></returns>
        public bool CheckMugenProcessActive() => this.processManager.CheckMugenProcessActive();

        /// <summary>
        /// returns the currently-running Mugen process.
        /// </summary>
        /// <param name="isUnsafe">if this is true, no error checking is performed, and the returned Process may be null or exited.</param>
        /// <returns></returns>
        public Process GetMugenProcess(bool isUnsafe = false) => (isUnsafe ? this.processManager.GetMugenProcessUnsafe() : this.processManager.GetMugenProcess());

        /// <summary>
        /// returns true if Mugen's main window is active.
        /// </summary>
        /// <returns></returns>
        public bool CheckMugenWindowStatus() => this.processManager.CheckMugenWindowStatus();

        /// <summary>
        /// destroys the stored Mugen Process object.
        /// </summary>
        public void DestroyMugenProcess() => this.processManager.DestroyMugenProcess();

        /// <summary>
        /// fetches the main window handle for Mugen
        /// TODO: add safety
        /// </summary>
        /// <returns></returns>
        public IntPtr GetMugenWindowHandle() => this.processManager.GetMugenWindowHandle();

        /// <summary>
        /// Gets the int from a specified address and offset.
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public int GetInt32Data(uint addr, uint offset) => this.processManager.GetInt32Data(addr, offset);

        public float GetFloatData(uint addr, uint offset) => this.processManager.GetFloatData(addr, offset);

        public NativePipeline GetDebugController()
        {
            return this.debugManager.DebugControl;
        }

        public double GetDoubleData(uint addr, uint offset) => this.processManager.GetDoubleData(addr, offset);

        public void SetInt32Data(uint addr, uint offset, int value) => this.processManager.SetInt32Data(addr, offset, value);

        public void SetUInt32Data(uint addr, uint offset, uint value) => this.processManager.SetUInt32Data(addr, offset, value);

        public void SetByteData(uint addr, uint offset, byte[] values) => this.processManager.SetByteData(addr, offset, values);

        public void SetFloatData(uint addr, uint offset, float value) => this.processManager.SetFloatData(addr, offset, value);

        public void SetDoubleData(uint addr, uint offset, double value) => this.processManager.SetDoubleData(addr, offset, value);

        public int ReadMemoryEx(uint baseAddr, uint offset, ref byte[] buf)
        {
            return this.processManager.ReadMemoryEx(baseAddr, offset, ref buf);
        }

        public void WriteMemoryEx(uint baseAddr, uint offset, byte[] buf)
        {
            this.processManager.WriteMemoryEx(baseAddr, offset, buf);
        }

        public bool DetectMugenVersion(FileVersionInfo versionInfo)
        {
            this.SetMugenVersion(MugenType_t.MUGEN_TYPE_WINMUGEN);
            if (versionInfo != null)
            {
                if (string.Compare("M.U.G.E.N", versionInfo.ProductName, true) == 0)
                {
                    if (versionInfo.FileMajorPart == 1 && versionInfo.FileMinorPart == 0)
                    {
                        this.ResetMugenVersion();
                        this.SetMugenVersion(MugenType_t.MUGEN_TYPE_MUGEN10);
                    }
                    else if (versionInfo.FileMajorPart == 1 && versionInfo.FileMinorPart == 1 && versionInfo.FileVersion == "1.1.0 Alpha 4")
                    {
                        this.ResetMugenVersion();
                        this.SetMugenVersion(MugenType_t.MUGEN_TYPE_MUGEN11A4);
                    }
                    else if (versionInfo.FileMajorPart == 1 && versionInfo.FileMinorPart == 1 && versionInfo.FileVersion == "1.1.0 Beta 1 P1")
                    {
                        this.ResetMugenVersion();
                        this.SetMugenVersion(MugenType_t.MUGEN_TYPE_MUGEN11B1);
                    }
                    else
                    {
                        this.ResetMugenVersion();
                        return false;
                    }
                }
                else if (versionInfo.FileVersion != null)
                {
                    this.ResetMugenVersion();
                    return false;
                }
            }
            return true;
        }

        public void SetThreadContext(CONTEXT ctx)
        {
            this.debugManager.SetDebugThreadContext(this, ctx, 0);
        }

        public BackgroundWorker GetProcessWatcher()
        {
            return debugManager.ProcessWatcher;
        }

        public NativeDbgProcess GetDebugProcess()
        {
            return debugManager.DebugProcess;
        }

        public bool SetInstructionBreakpoint(uint targetAddress, int debugSlot = 0)
        {
            return this.debugManager.SetInstructionBreakpoint(targetAddress, debugSlot);
        }

        public bool SetDataBreakpoint(uint targetAddress)
        {
            return this.debugManager.SetDataBreakpoint(targetAddress);
        }

        public void ClearHardwareBreakpoint()
        {
            this.debugManager.ClearHardwareBreakpoint();
        }

        public uint GetStackPointer()
        {
            return this.debugManager.GetStackPointer(this);
        }

        public void AttachDebugProcess()
        {
            this.debugManager.AttachDebugProcess(this.processManager.GetMugenProcess().Id);
        }

        public void ContinueEvent(NativeEvent awaitedNativeEvent, bool bNotHandle)
        {
            this.debugManager.DebugControl.ContinueEvent(awaitedNativeEvent, bNotHandle);
        }

        public void DisposeDebugProcess()
        {
            this.debugManager.DisposeDebugProcess();
        }

        public void SetDebugProcessRunner(IDebugProcessRunner runner)
        {
            this.debugManager.SetDebugProcessRunner(runner);
        }

        public CONTEXT GetDebugThreadContext(int threadID = 0)
        {
            return this.debugManager.GetDebugThreadContext(this, threadID);
        }
    }
}

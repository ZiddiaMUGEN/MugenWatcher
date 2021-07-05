using Microsoft.Samples.Debugging.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static MugenWatcher.ExternalFuncs;

namespace MugenWatcher.Watcher
{
    internal class DebugProcessManager
    {
        internal NativePipeline DebugControl { get; private set; }
        internal BackgroundWorker ProcessWatcher { get; private set; }

        // debugging Mugen process (used with trigger breakpoints)
        internal NativeDbgProcess DebugProcess { get; private set; }
        internal int DebugTargetThread { get; private set; }
        internal IDebugProcessRunner DebugRunner { get; private set; }

        internal bool WaitInfinite { get; set; }

        internal DebugProcessManager(bool infinite = false)
        {
            this.WaitInfinite = infinite;
            this.DebugControl = new NativePipeline();
            this.DebugRunner = null;
            this.ProcessWatcher = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            this.ProcessWatcher.DoWork += new DoWorkEventHandler(this.ProcessWatcherEventHandler);
        }

        internal void SetDebugProcessRunner(IDebugProcessRunner runner)
        {
            this.DebugRunner = runner;
        }

        internal bool SetInstructionBreakpoint(uint breakpointAddress, int debugSlot)
        {
            // verify debug thread obtained
            if (this.DebugTargetThread == 0) return false;

            // verify debug process running
            if (this.DebugProcess == null)
                return false;

            // context for the debugging
            CONTEXT context = new CONTEXT
            {
                ContextFlags = (uint)CONTEXT_FLAGS.CONTEXT_DEBUG_REGISTERS
            };

            IntPtr num = IntPtr.Zero;

            try
            {
                num = OpenThread(ThreadAccessFlags.SUSPEND_RESUME | ThreadAccessFlags.GET_CONTEXT | ThreadAccessFlags.SET_CONTEXT | ThreadAccessFlags.QUERY_INFORMATION, false, (uint)this.DebugTargetThread);
                if (num == IntPtr.Zero || SuspendThreadEx(num) == -1)
                    return false;
                if (GetThreadContextEx(num, ref context))
                {
                    switch(debugSlot)
                    {
                        case 0:
                            context.Dr0 = breakpointAddress;
                            context.Dr7 |= 0x103U;
                            break;
                        case 1:
                            context.Dr1 = breakpointAddress;
                            context.Dr7 |= 0x10CU;
                            break;
                        case 2:
                            context.Dr2 = breakpointAddress;
                            context.Dr7 |= 0x130U;
                            break;
                        case 3:
                            context.Dr3 = breakpointAddress;
                            context.Dr7 |= 0x1C0U;
                            break;
                    }
                    
                    
                    SetThreadContextEx(num, ref context);
                }
                ResumeThreadEx(num);
            }
            finally
            {
                if (num != IntPtr.Zero)
                    CloseHandle(num);
            }

            return true;
        }

        internal bool SetDataBreakpoint(uint breakpointAddress)
        {
            // verify debug thread obtained
            if (this.DebugTargetThread == 0) return false;

            // verify debug process running
            if (this.DebugProcess == null)
                return false;

            // context for the debugging
            CONTEXT context = new CONTEXT
            {
                ContextFlags = (uint)CONTEXT_FLAGS.CONTEXT_DEBUG_REGISTERS
            };

            IntPtr num = IntPtr.Zero;

            try
            {
                num = OpenThread(ThreadAccessFlags.SUSPEND_RESUME | ThreadAccessFlags.GET_CONTEXT | ThreadAccessFlags.SET_CONTEXT | ThreadAccessFlags.QUERY_INFORMATION, false, (uint)this.DebugTargetThread);
                if (num == IntPtr.Zero || SuspendThreadEx(num) == -1)
                    return false;
                if (GetThreadContextEx(num, ref context))
                {
                    context.Dr0 = breakpointAddress;
                    context.Dr7 = 851969U;
                    SetThreadContextEx(num, ref context);
                }
                ResumeThreadEx(num);
            }
            finally
            {
                if (num != IntPtr.Zero)
                    CloseHandle(num);
            }

            return true;
        }

        /// <summary>
        /// clears a set hardware breakpoint
        /// </summary>
        /// <param name="threadId"></param>
        internal void ClearHardwareBreakpoint()
        {
            if (this.DebugTargetThread == 0)
                return;
            if (this.DebugProcess == null)
                return;

            CONTEXT context = new CONTEXT
            {
                ContextFlags = 65552U
            };
            IntPtr num = IntPtr.Zero;

            try
            {
                num = OpenThread(ThreadAccessFlags.SUSPEND_RESUME | ThreadAccessFlags.GET_CONTEXT | ThreadAccessFlags.SET_CONTEXT | ThreadAccessFlags.QUERY_INFORMATION, false, (uint)this.DebugTargetThread);
                if (!(num != IntPtr.Zero) || SuspendThreadEx(num) == -1)
                    return;
                if (GetThreadContextEx(num, ref context))
                {
                    context.Dr0 = 0U;
                    context.Dr7 = 0U;
                    SetThreadContextEx(num, ref context);
                }
                ResumeThreadEx(num);
            }
            finally
            {
                if (num != IntPtr.Zero)
                    CloseHandle(num);
            }
        }

        internal CONTEXT GetDebugThreadContext(MugenProcessWatcher watcher, int threadID)
        {
            if (threadID == 0) threadID = this.DebugTargetThread;
            CONTEXT context = new CONTEXT
            {
                ContextFlags = (uint)CONTEXT_FLAGS.CONTEXT_ALL
            };

            if (this.DebugProcess == null || threadID == 0)
                return context;

            IntPtr debugPtr = IntPtr.Zero;

            try
            {
                debugPtr = OpenThread(ThreadAccessFlags.GET_CONTEXT | ThreadAccessFlags.QUERY_INFORMATION, false, (uint)threadID);
                if (debugPtr != IntPtr.Zero)
                {
                    GetThreadContextEx(debugPtr, ref context);
                }
            }
            finally
            {
                if (debugPtr != IntPtr.Zero)
                    CloseHandle(debugPtr);
            }

            return context;
        }

        internal void SetDebugThreadContext(MugenProcessWatcher watcher, CONTEXT context, int threadID)
        {
            if (threadID == 0) threadID = this.DebugTargetThread;

            if (this.DebugProcess == null || threadID == 0)
                return;

            IntPtr debugPtr = IntPtr.Zero;

            try
            {
                debugPtr = OpenThread(ThreadAccessFlags.SET_CONTEXT | ThreadAccessFlags.SET_INFORMATION, false, (uint)threadID);
                if (debugPtr != IntPtr.Zero)
                {
                    SetThreadContextEx(debugPtr, ref context);
                }
            }
            finally
            {
                if (debugPtr != IntPtr.Zero)
                    CloseHandle(debugPtr);
            }
        }

        internal uint GetStackPointer(MugenProcessWatcher watcher)
        {
            if (this.DebugProcess == null || this.DebugTargetThread == 0)
                return 0;

            CONTEXT context = new CONTEXT
            {
                ContextFlags = 65541U
            };
            IntPtr num1 = IntPtr.Zero;

            uint num2 = 0;
            try
            {
                num1 = OpenThread(ThreadAccessFlags.GET_CONTEXT | ThreadAccessFlags.QUERY_INFORMATION, false, (uint)this.DebugTargetThread);
                if (num1 != IntPtr.Zero)
                {
                    if (GetThreadContextEx(num1, ref context))
                    {
                        LDT_ENTRY lpSelectorEntry = new LDT_ENTRY();
                        if (GetThreadSelectorEntryEx(num1, context.SegFs, ref lpSelectorEntry))
                            num2 = (uint)(watcher.GetInt32Data((uint)(lpSelectorEntry.HighWord.Bits.BaseHi << 24 | lpSelectorEntry.HighWord.Bits.BaseMid << 16) | (uint)lpSelectorEntry.BaseLow, 4U) - 8192);
                    }
                }
            }
            finally
            {
                if (num1 != IntPtr.Zero)
                    CloseHandle(num1);
            }
            return num2;
        }

        internal void DisposeDebugProcess()
        {
            try
            {
                this.DebugControl.Detach(this.DebugProcess);
                this.DebugProcess.Dispose();
            }
            catch
            {
            }
            this.DebugProcess = (NativeDbgProcess)null;
        }

        internal void AttachDebugProcess(int processID)
        {
            this.DebugProcess = this.DebugControl.Attach(processID);
        }

        private void ProcessWatcherEventHandler(object sender, DoWorkEventArgs e)
        {
            if (DebugRunner != null) DebugRunner.Initialize();
            // will represent the thread we set BPs in
            this.DebugTargetThread = 0;
            while (!this.ProcessWatcher.CancellationPending)
            {
                // check if it's time to trigger a debug event callback
                if (this.DebugProcess != null)
                {
                    NativeEvent awaitedNativeEvent = this.WaitInfinite ? this.DebugControl.WaitForDebugEventInfinite() : this.DebugControl.WaitForDebugEvent(16);
                    // handle bp event if it was found
                    if (awaitedNativeEvent != null)
                    {
                        // safety check if it's our hw bp that activated
                        awaitedNativeEvent.Process.HandleIfLoaderBreakpoint(awaitedNativeEvent);
                        if (awaitedNativeEvent is ExceptionNativeEvent)
                        {
                            // callback to the hooked debug event
                            if (DebugRunner != null) DebugRunner.HandleNativeEvent(awaitedNativeEvent);
                        }
                        // boilerplate
                        else if (awaitedNativeEvent is CreateProcessDebugEvent)
                        {
                            this.DebugControl.ContinueEvent(awaitedNativeEvent);
                            this.DebugTargetThread = awaitedNativeEvent.ThreadId;
                        }
                        else if (awaitedNativeEvent is ExitProcessDebugEvent)
                        {
                            this.DebugControl.ContinueEvent(awaitedNativeEvent);
                            this.DisposeDebugProcess();
                        }
                        else
                            this.DebugControl.ContinueEvent(awaitedNativeEvent);
                    }
                }
                // check the status of the trigger check/apply next command
                else
                {
                    if (DebugRunner != null) DebugRunner.HandleUnsetDebugProcess();
                }
                if (DebugRunner != null)
                    if (!DebugRunner.MainLoop()) 
                        break;
            }
            if (DebugRunner != null) DebugRunner.Cleanup();

            while (this.DebugProcess != null)
            {
                NativeEvent nativeEvent2 = this.DebugControl.WaitForDebugEvent(16);
                if (nativeEvent2 != null)
                {
                    nativeEvent2.Process.HandleIfLoaderBreakpoint(nativeEvent2);
                    this.DebugControl.ContinueEvent(nativeEvent2);
                    if (nativeEvent2 is ExitProcessDebugEvent)
                    {
                        this.DisposeDebugProcess();
                    }
                }
                else
                {
                    this.DisposeDebugProcess();
                }
            }
            if (DebugRunner != null) DebugRunner.Uninitialize();
        }
    }
}

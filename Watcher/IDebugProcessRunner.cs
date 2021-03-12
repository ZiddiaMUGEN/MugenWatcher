using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Samples.Debugging.Native;

namespace MugenWatcher.Watcher
{
    public interface IDebugProcessRunner
    {
        /// <summary>
        /// Called when the background thread is starting up.
        /// </summary>
        void Initialize();
        /// <summary>
        /// Called when a native event is triggered in the debugger step of the main loop.
        /// </summary>
        /// <param name="awaitedNativeEvent"></param>
        void HandleNativeEvent(NativeEvent awaitedNativeEvent);
        /// <summary>
        /// Called when the debugging process is not set during main loop.
        /// </summary>
        void HandleUnsetDebugProcess();
        /// <summary>
        /// Called after the debugger step of the main loop.
        /// </summary>
        /// <returns></returns>
        bool MainLoop();
        /// <summary>
        /// Called when the main loop exits.
        /// </summary>
        /// <returns></returns>
        void Cleanup();
        /// <summary>
        /// Called once after debugging objects have been cleaned up.
        /// </summary>
        /// <returns></returns>
        void Uninitialize();
    }
}

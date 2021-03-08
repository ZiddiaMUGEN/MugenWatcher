using MugenWatcher.Watcher;
using System;
using System.Collections.Generic;
using System.Text;

namespace MugenWatcher.Utils
{
    /// <summary>
    /// utils for reading/writing predefined mem locations for player structure.
    /// </summary>
    public static class PlayerUtils
    {
        public static int GetPlayerInfoAddress(MugenProcessWatcher watcher, uint playerAddr) => watcher.GetInt32Data(playerAddr, 0);

        public static int GetDisplayName(MugenProcessWatcher watcher, uint playerAddr, ref string displayName)
        {
            uint playerInfo = (uint) GetPlayerInfoAddress(watcher, playerAddr);
            if (playerInfo == 0) return 0;

            byte[] buf = new byte[256];
            int numBytes = watcher.ReadMemoryEx(playerInfo, watcher.MugenDatabase.DISPLAY_NAME_PLAYER_INFO_OFFSET, ref buf);
            if (numBytes == 0) return 0;

            string str = Encoding.ASCII.GetString(buf);
            int length = str.IndexOf(char.MinValue);
            displayName = str.Substring(0, length);
            return length;
        }

        public static int GetProjBaseAddress(MugenProcessWatcher watcher, uint playerAddr)
        {
            uint projStruct = (uint) watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PROJ_BASE_PLAYER_OFFSET);
            return watcher.GetInt32Data(projStruct, 0);
        }

        public static int GetProjListAddress(MugenProcessWatcher watcher, uint projBaseAddr) => watcher.GetInt32Data(projBaseAddr, watcher.MugenDatabase.PROJ_LIST_PROJ_BASE_OFFSET);

        public static bool DoesPlayerExist(MugenProcessWatcher watcher, uint playerAddr) => watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.EXIST_PLAYER_OFFSET) > 0U;
    }
}

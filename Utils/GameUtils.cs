using MugenWatcher.EnumTypes;
using MugenWatcher.Watcher;
using System;
using System.Collections.Generic;
using System.Text;

namespace MugenWatcher.Utils
{
    /// <summary>
    /// utils for reading/writing predefined mem locations for Mugen game structure/exe structure.
    /// </summary>
    public static class GameUtils
    {
        /// <summary>
        /// fetches base address of the Mugen game structure.
        /// </summary>
        /// <param name="watcher"></param>
        /// <returns></returns>
        public static int GetBaseAddress(MugenProcessWatcher watcher)
        {
            if (watcher.BaseAddress == 0)
                watcher.BaseAddress = watcher.GetInt32Data(watcher.MugenDatabase.MUGEN_POINTER_BASE_OFFSET, 0);

            return watcher.BaseAddress;
        }

        /// <summary>
        /// gets the offset for a player - playerNum should be a number between 1 and 60
        /// </summary>
        /// <param name="watcher"></param>
        /// <param name="baseAddr"></param>
        /// <param name="playerNum"></param>
        /// <returns></returns>
        public static int GetPlayerAddress(MugenProcessWatcher watcher, uint baseAddr, int playerNum)
        {
            if (playerNum < 1 || playerNum > 60) throw new ArgumentException("playerNum must be between 1 and 60!");
            uint playerOffset = (uint) (watcher.MugenDatabase.PLAYER_1_BASE_OFFSET + 4 * (playerNum - 1));
            return watcher.GetInt32Data(baseAddr, playerOffset);
        }

        public static int GetExplodListAddress(MugenProcessWatcher watcher, uint baseAddr)
        {
            uint explodStruct = (uint) watcher.GetInt32Data(baseAddr, watcher.MugenDatabase.EXPLOD_LIST_BASE_OFFSET);
            return watcher.GetInt32Data(explodStruct, 0);
        }

        public static bool IsPaused(MugenProcessWatcher watcher) => watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11A4 || watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11B1
            ? watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.PAUSE_ADDR) > 0U
            : watcher.GetInt32Data(watcher.MugenDatabase.PAUSE_ADDR, 0U) > 0U;

        public static bool IsDemo(MugenProcessWatcher watcher) => (uint)watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.DEMO_BASE_OFFSET) > 0U;

        public static bool IsMugenActive(MugenProcessWatcher watcher) => (uint)watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.MUGEN_ACTIVE_BASE_OFFSET) > 0U;

        public static bool IsSpeedMode(MugenProcessWatcher watcher) => (uint)watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.SPEED_MODE_BASE_OFFSET) > 0U;

        public static int GetSkipFrames(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.SKIP_MODE_BASE_OFFSET);

        public static bool IsSkipMode(MugenProcessWatcher watcher) => (uint) GameUtils.GetSkipFrames(watcher) > 0U;

        public static int GetDebugTargetNo(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.DEBUG_TARGET_BASE_OFFSET);
        public static bool IsDebugMode(MugenProcessWatcher watcher) => 
            (uint) watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.DEBUG_MODE_BASE_OFFSET) > 0U
            && (uint) GameUtils.GetDebugTargetNo(watcher) > 0U;

        public static int GetGameTime(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.GAMETIME_BASE_OFFSET);

        public static int GetScreenX(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.SCREEN_X_BASE_OFFSET);

        public static int GetScreenY(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.SCREEN_Y_BASE_OFFSET);

        public static int GetRoundState(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.ROUND_STATE_BASE_OFFSET);

        public static int GetRoundNo(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.ROUND_NO_BASE_OFFSET);

        public static int GetRoundTime(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.ROUND_TIME_BASE_OFFSET);

        public static int GetRoundNoOfMatch(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.ROUND_NO_OF_MATCH_TIME_BASE_OFFSET);

        public static bool IsTurnsMode(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TURNS_MODE_BASE_OFFSET) == 0U;

        public static bool IsTeam1Win(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TEAM_WIN_BASE_OFFSET) == 1;
        public static bool IsTeam1WinKO(MugenProcessWatcher watcher) =>
            GameUtils.IsTeam1Win(watcher)
            && watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TEAM_WIN_KO_BASE_OFFSET) == 2;

        public static bool IsTeam2Win(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TEAM_WIN_BASE_OFFSET) == 1;
        public static bool IsTeam2WinKO(MugenProcessWatcher watcher) =>
            GameUtils.IsTeam2Win(watcher)
            && watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TEAM_WIN_KO_BASE_OFFSET) == 1;

        public static int GetTeam1WinCount(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TEAM_1_WIN_COUNT_BASE_OFFSET);

        public static int GetTeam2WinCount(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TEAM_2_WIN_COUNT_BASE_OFFSET);

        public static int GetDrawGameCount(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.DRAW_GAME_COUNT_BASE_OFFSET);

        public static uint GetP1Addr(MugenProcessWatcher watcher) => (uint)GameUtils.GetPlayerAddress(watcher, (uint)GameUtils.GetBaseAddress(watcher), 1);

        public static uint GetP2Addr(MugenProcessWatcher watcher) => (uint)GameUtils.GetPlayerAddress(watcher, (uint)GameUtils.GetBaseAddress(watcher), 2);

        public static uint GetP3Addr(MugenProcessWatcher watcher) => (uint)GameUtils.GetPlayerAddress(watcher, (uint)GameUtils.GetBaseAddress(watcher), 3);

        public static uint GetP4Addr(MugenProcessWatcher watcher) => (uint)GameUtils.GetPlayerAddress(watcher, (uint)GameUtils.GetBaseAddress(watcher), 4);
    }
}

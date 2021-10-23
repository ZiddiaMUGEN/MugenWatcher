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

        public static uint GetExplodAddress(MugenProcessWatcher watcher, uint explodListAddr, uint index) => explodListAddr + index * watcher.MugenDatabase.OFFSET_EXPLOD_LIST_OFFSET;

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

        public static bool IsTeam2Win(MugenProcessWatcher watcher) => watcher.GetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TEAM_WIN_BASE_OFFSET) == 2;
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


        public static void SetRoundState(MugenProcessWatcher watcher, int state) => watcher.SetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.ROUND_STATE_BASE_OFFSET, state);

        public static void SetRoundNo(MugenProcessWatcher watcher, int num) => watcher.SetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.ROUND_NO_BASE_OFFSET, num);

        public static void SetTeam1WinCount(MugenProcessWatcher watcher, int value) => watcher.SetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TEAM_1_WIN_COUNT_BASE_OFFSET, value);

        public static void SetTeam2WinCount(MugenProcessWatcher watcher, int value) => watcher.SetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.TEAM_2_WIN_COUNT_BASE_OFFSET, value);

        public static void SetDrawGameCount(MugenProcessWatcher watcher, int value) => watcher.SetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.DRAW_GAME_COUNT_BASE_OFFSET, value);



        public static bool DoesExplodExist(MugenProcessWatcher watcher, uint explodAddr) => (uint)watcher.GetInt32Data(explodAddr, watcher.MugenDatabase.EXIST_EXPLOD_OFFSET) > 0U;

        public static int GetExplodId(MugenProcessWatcher watcher, uint explodAddr) => watcher.GetInt32Data(explodAddr, watcher.MugenDatabase.EXPLOD_ID_EXPLOD_OFFSET);

        public static int GetExplodOwnerId(MugenProcessWatcher watcher, uint explodAddr) => watcher.GetInt32Data(explodAddr, watcher.MugenDatabase.EXPLOD_OWNER_ID_EXPLOD_OFFSET);

        public static int GetAnimIndex(MugenProcessWatcher watcher, uint explodAddr)
        {
            uint int32Data = (uint)watcher.GetInt32Data(explodAddr, watcher.MugenDatabase.ANIM_ADDR_EXPLOD_OFFSET);
            return int32Data != 0U ? watcher.GetInt32Data(int32Data, watcher.MugenDatabase.ANIM_INDEX_EXPLOD_OFFSET) : -1;
        }

        public static int GetPauseTime(MugenProcessWatcher watcher, uint baseAddr) => baseAddr != 0U ? watcher.GetInt32Data(baseAddr, watcher.MugenDatabase.PAUSE_TIME_BASE_OFFSET) : 0;

        public static int GetSuperPauseTime(MugenProcessWatcher watcher, uint baseAddr) => baseAddr != 0U ? watcher.GetInt32Data(baseAddr, watcher.MugenDatabase.SUPER_PAUSE_TIME_BASER_OFFSET) : 0;

        public static int GetDebugModeClsnDisplayMode(MugenProcessWatcher watcher, uint baseAddr) => baseAddr != 0U ? watcher.GetInt32Data(baseAddr, watcher.MugenDatabase.DEBUG_CLSN_DISPLAY_MODE) : 0;

        /// <summary>
        /// fetches the global AssertSpecial flags.
        /// <br/>these are a list of sequential int flags relative to the base address.
        /// </summary>
        /// <param name="baseAddr"></param>
        /// <returns></returns>
        public static bool[] GetGlobalAssertSpecials(MugenProcessWatcher watcher, uint baseAddr)
        {
            bool[] flagArray = new bool[11];
            if (baseAddr == 0U)
                return flagArray;
            int int32Data1 = watcher.GetInt32Data(baseAddr, watcher.MugenDatabase.ASSERT_1_PLAYER_OFFSET);
            if (int32Data1 == 0)
                return flagArray;
            flagArray[0] = (uint)(int32Data1 & 1) > 0U;
            flagArray[1] = (uint)(int32Data1 & 256) > 0U;
            flagArray[2] = (uint)(int32Data1 & 65536) > 0U;
            flagArray[3] = (uint)(int32Data1 & 16777216) > 0U;
            int int32Data2 = watcher.GetInt32Data(baseAddr, watcher.MugenDatabase.ASSERT_1_PLAYER_OFFSET + 4U);
            if (int32Data2 == 0)
                return flagArray;
            flagArray[4] = (uint)(int32Data2 & 1) > 0U;
            flagArray[5] = (uint)(int32Data2 & 256) > 0U;
            flagArray[6] = (uint)(int32Data2 & 65536) > 0U;
            flagArray[7] = (uint)(int32Data2 & 16777216) > 0U;
            int int32Data3 = watcher.GetInt32Data(baseAddr, watcher.MugenDatabase.ASSERT_1_PLAYER_OFFSET + 8U);
            if (int32Data3 == 0)
                return flagArray;
            flagArray[8] = (uint)(int32Data3 & 1) > 0U;
            flagArray[9] = (uint)(int32Data3 & 256) > 0U;
            flagArray[10] = (uint)(int32Data3 & 65536) > 0U;
            return flagArray;
        }

        public static void SetSpeedMode(MugenProcessWatcher watcher, uint baseAddr, bool isSpeedMode)
        {
            int num = isSpeedMode ? 1 : 0;
            watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.SPEED_MODE_BASE_OFFSET, num);
        }

        public static void SetSkipMode(MugenProcessWatcher watcher, uint baseAddr, bool isSkipMode, int _skipModeFrames)
        {
            int num = isSkipMode ? _skipModeFrames : -1;
            watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.SKIP_MODE_BASE_OFFSET, num);
        }

        /// <summary>
        /// enables or disables Mugen's debug text with a focus on player 1.
        /// </summary>
        /// <param name="baseAddr"></param>
        /// <param name="isDebugMode"></param>
        public static void EnableDebugKey(MugenProcessWatcher watcher, uint baseAddr, bool isDebugMode)
        {
            if (isDebugMode)
            {
                watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.DEBUG_MODE_BASE_OFFSET, 0);
                watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.DEBUG_TARGET_BASE_OFFSET, 1);
            }
            else
            {
                watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.DEBUG_MODE_BASE_OFFSET, 0);
                watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.DEBUG_TARGET_BASE_OFFSET, 0);
            }
        }

        public static void SetDebugMode(MugenProcessWatcher watcher, uint baseAddr, bool isDebugMode)
        {
            if (isDebugMode)
            {
                watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.DEBUG_MODE_BASE_OFFSET, 1);
                if (GetDebugTargetNo(watcher) != 0)
                    return;
                watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.DEBUG_TARGET_BASE_OFFSET, 1);
            }
            else
                watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.DEBUG_MODE_BASE_OFFSET, 0);
        }

        /// <summary>
        /// sets the current focus for debug text to the indicated targetNo (value from 1 to 60).
        /// </summary>
        /// <param name="baseAddr"></param>
        /// <param name="targetNo"></param>
        public static void SetDebugTargetNo(MugenProcessWatcher watcher, uint baseAddr, int targetNo) => watcher.SetInt32Data(baseAddr, watcher.MugenDatabase.DEBUG_TARGET_BASE_OFFSET, targetNo);

        /// <summary>
        /// injects a debug key into Mugen by setting the CMD_KEY addresses.
        /// <br/>notice keycodes changed between Win,1.0,1.1a4.
        /// </summary>
        /// <param name="keyCode"></param>
        public static void _InjectCommand(MugenProcessWatcher watcher, int keyCode)
        {
            if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11A4)
            {
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR, keyCode | 256);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR + 4U, keyCode | 768);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_NEXT_INDEX_ADDR, 3);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_CURRENT_INDEX_ADDR, 0);
            }
            else if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN10)
            {
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR, keyCode | 256);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR + 4U, keyCode | 768);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_CURRENT_INDEX_ADDR, 0);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_NEXT_INDEX_ADDR, 1);
            }
            else
            {
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR, keyCode);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_CURRENT_INDEX_ADDR, 0);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_NEXT_INDEX_ADDR, 1);
            }
        }

        /// <summary>
        /// injects a debug key into Mugen by setting the CMD_KEY addresses.
        /// <br/>notice keycodes/cmd indexes changed between Win,1.0,1.1a4.
        /// </summary>
        /// <param name="keyCode"></param>
        public static void InjectCommand(MugenProcessWatcher watcher, int keyCode)
        {
            if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11A4 || watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11B1)
            {
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR, keyCode | 256);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR + 4U, keyCode | 768);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_NEXT_INDEX_ADDR, 1);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_CURRENT_INDEX_ADDR, 0);
            }
            else if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN10)
            {
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR, keyCode | 256);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR + 4U, keyCode | 768);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_CURRENT_INDEX_ADDR, 0);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_NEXT_INDEX_ADDR, 1);
            }
            else
            {
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_CURRENT_INDEX_ADDR, 0);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_NEXT_INDEX_ADDR, 1);
                watcher.SetInt32Data(0U, watcher.MugenDatabase.CMD_KEY_ADDR, keyCode);
            }
        }

        /// <summary>
        /// checks the debug key which is going to be processed next by Mugen
        /// </summary>
        /// <returns></returns>
        public static int CheckNextCommand(MugenProcessWatcher watcher)
        {
            int int32Data = watcher.GetInt32Data(0U, watcher.MugenDatabase.CMD_NEXT_INDEX_ADDR);
            int num = -1;
            if (int32Data > 0)
                num = watcher.GetInt32Data(0U, (uint)((ulong)watcher.MugenDatabase.CMD_KEY_ADDR + (ulong)(int32Data * 4)));
            return num;
        }

        public static void SetPaused(MugenProcessWatcher watcher, bool isPaused)
        {
            if (watcher.MugenDatabase is Databases.Mugen11A4DB)
                watcher.SetInt32Data((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.PAUSE_ADDR, isPaused ? 1 : 0);
            watcher.SetInt32Data(0U, watcher.MugenDatabase.PAUSE_ADDR, isPaused ? 1 : 0);
        }
    }
}

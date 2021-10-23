using MugenWatcher.EnumTypes;
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

        public static int GetProjHitID(MugenProcessWatcher watcher, uint playerAddr)
        {
            return watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PROJ_HIT_ID_PLAYER_OFFSET);
        }

        public static int GetProjHitTime(MugenProcessWatcher watcher, uint playerAddr)
        {
            return watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PROJ_HIT_TIME_PLAYER_OFFSET);
        }

        public static int GetProjBaseAddress(MugenProcessWatcher watcher, uint playerAddr)
        {
            uint projStruct = (uint) watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PROJ_BASE_PLAYER_OFFSET);
            return watcher.GetInt32Data(projStruct, 0);
        }

        public static int GetIntegerConstant(MugenProcessWatcher watcher, uint playerAddr, int constValue)
        {
            if (constValue == -1) return 0;
            return watcher.GetInt32Data(playerAddr, 0x50 + (0x04 * (uint)constValue));
        }

        public static float GetFloatConstant(MugenProcessWatcher watcher, uint playerAddr, int constValue)
        {
            if (constValue == -1) return 0;
            return watcher.GetFloatData(playerAddr, 0x50 + (0x04 * (uint)constValue));
        }

        public static void SetIntegerConstant(MugenProcessWatcher watcher, uint playerAddr, int constValue, int value)
        {
            if (constValue == -1) return;
            watcher.SetInt32Data(playerAddr, 0x50 + (0x04 * (uint)constValue), value);
        }

        public static void SetFloatConstant(MugenProcessWatcher watcher, uint playerAddr, int constValue, float value)
        {
            if (constValue == -1) return;
            watcher.SetFloatData(playerAddr, 0x50 + (0x04 * (uint)constValue), value);
        }

        public static uint GetParentAddress(MugenProcessWatcher watcher, uint playerAddr) => (uint)watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PARENT_ID_PLAYER_OFFSET + 0x04);
        public static uint GetRootAddress(MugenProcessWatcher watcher, uint playerAddr) => (uint)watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PARENT_ID_PLAYER_OFFSET + 0x08);
        public static int GetTeamSide(MugenProcessWatcher watcher, uint playerAddr)
        {
            bool isLeftTeam = GameUtils.GetP1Addr(watcher) == playerAddr || GameUtils.GetP3Addr(watcher) == playerAddr;
            if (!isLeftTeam) isLeftTeam |= GameUtils.GetP1Addr(watcher) == GetRootAddress(watcher, playerAddr) || GameUtils.GetP3Addr(watcher) == GetRootAddress(watcher, playerAddr);

            return isLeftTeam ? 1 : 2;
        }

        public static uint GetEnemyAddress(MugenProcessWatcher watcher, uint playerAddr)
        {
            int teamside = GetTeamSide(watcher, playerAddr);
            if (teamside == 1) return GameUtils.GetP1Addr(watcher);
            else return GameUtils.GetP2Addr(watcher);
        }

        public static int GetProjListAddress(MugenProcessWatcher watcher, uint projBaseAddr) => watcher.GetInt32Data(projBaseAddr, watcher.MugenDatabase.PROJ_LIST_PROJ_BASE_OFFSET);

        public static bool DoesPlayerExist(MugenProcessWatcher watcher, uint playerAddr) => watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.EXIST_PLAYER_OFFSET) > 0U;

        public static int GetPlayerId(MugenProcessWatcher watcher, uint playerAddr) => watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PLAYER_ID_PLAYER_OFFSET);

        public static int GetHelperId(MugenProcessWatcher watcher, uint playerAddr) => watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.HELPER_ID_PLAYER_OFFSET);

        public static int GetParentId(MugenProcessWatcher watcher, uint playerAddr) => watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PARENT_ID_PLAYER_OFFSET);

        public static uint GetProjAddress(MugenProcessWatcher watcher, uint projListAddr, uint index) => projListAddr + index * watcher.MugenDatabase.OFFSET_PROJ_LIST_OFFSET;

        public static bool DoesProjExist(MugenProcessWatcher watcher, uint projBase, int projNo, uint projAddr)
        {
            int int32Data = watcher.GetInt32Data(projBase, watcher.MugenDatabase.PROJ_MAX_PROJ_BASE_OFFSET);
            return projNo <= int32Data && watcher.GetInt32Data(projAddr, watcher.MugenDatabase.EXIST_PROJ_OFFSET) == 1;
        }

        public static int GetProjId(MugenProcessWatcher watcher, uint projAddr) => watcher.GetInt32Data(projAddr, watcher.MugenDatabase.PROJ_ID_PROJ_OFFSET);

        public static int GetProjX(MugenProcessWatcher watcher, uint playerAddr, uint projAddr)
        {
            if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11A4 || watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11B1)
            {
                double projPosX = watcher.GetDoubleData(projAddr, watcher.MugenDatabase.PROJ_X_PROJ_OFFSET);
                float camPosX = watcher.GetFloatData((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.CAMERAPOS_X_BASE_OFFSET);

                float stageLocalX = GameUtils.GetScreenX(watcher);
                double playerLocalX = GetLocalCoordX(watcher, playerAddr);

                float scale = (float)(playerLocalX / stageLocalX);
                return (int)((projPosX - camPosX) * scale);
            }
            return watcher.MugenVersion != MugenType_t.MUGEN_TYPE_MUGEN10 ? watcher.GetInt32Data(projAddr, watcher.MugenDatabase.PROJ_X_PROJ_OFFSET) : 320 + (int)watcher.GetFloatData(projAddr, watcher.MugenDatabase.PROJ_X_PROJ_OFFSET);
        }

        public static int GetProjY(MugenProcessWatcher watcher, uint playerAddr, uint projAddr)
        {
            if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11A4 || watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11B1)
            {
                double projPosY = watcher.GetDoubleData(projAddr, watcher.MugenDatabase.PROJ_Y_PROJ_OFFSET);
                float camPosY = watcher.GetFloatData((uint)GameUtils.GetBaseAddress(watcher), watcher.MugenDatabase.CAMERAPOS_Y_BASE_OFFSET);

                float stageLocalY = GameUtils.GetScreenY(watcher);
                double playerLocalY = GetLocalCoordY(watcher, playerAddr);

                float scale = (float)(playerLocalY / (playerLocalY + stageLocalY));

                return (int)((projPosY - camPosY) * scale);
            }
            return watcher.MugenVersion != MugenType_t.MUGEN_TYPE_MUGEN10 ? watcher.GetInt32Data(projAddr, watcher.MugenDatabase.PROJ_Y_PROJ_OFFSET) : 240 + (int)watcher.GetFloatData(projAddr, watcher.MugenDatabase.PROJ_Y_PROJ_OFFSET);
        }

        public static int GetStateOwner(MugenProcessWatcher watcher, uint baseAddr, uint playerAddr)
        {
            int int32Data = watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.STATE_OWNER_PLAYER_OFFSET);
            if (int32Data <= 0 || int32Data > 60)
                return -1;
            uint playerAddr1 = (uint)GameUtils.GetPlayerAddress(watcher, baseAddr, int32Data);
            return playerAddr1 != 0U ? GetPlayerId(watcher, playerAddr1) : 0;
        }

        public static int GetStateNo(MugenProcessWatcher watcher, uint playerAddr) => watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.STATE_NO_PLAYER_OFFSET);

        public static int GetPrevStateNo(MugenProcessWatcher watcher, uint playerAddr) => watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PREV_STATE_NO_PLAYER_OFFSET);

        public static int GetPalno(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PALNO_PLAYER_OFFSET) + 1 : 0;

        public static int GetAlive(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.ALIVE_PLAYER_OFFSET) : 0;

        public static int GetLife(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.LIFE_PLAYER_OFFSET) : 0;

        public static int GetPower(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.POWER_PLAYER_OFFSET) : 0;

        /// <summary>
        /// navigates anim structures to read anim list address
        /// <br/>this one is a complicated one due to 3x redirected pointers.
        /// </summary>
        /// <param name="baseAddr"></param>
        /// <param name="playerAddr"></param>
        /// <returns></returns>
        public static uint GetAnimListAddr(MugenProcessWatcher watcher, uint baseAddr, uint playerAddr)
        {
            if (playerAddr == 0U)
                return 0;
            uint playerInfoAdder = (uint) GetPlayerInfoAddress(watcher, playerAddr);
            if (playerInfoAdder == 0U)
                return 0;
            uint int32Data1 = (uint)watcher.GetInt32Data(playerInfoAdder, watcher.MugenDatabase.ANIM_LIST_REF1_PLAYER_INFO_OFFSET);
            if (int32Data1 == 0U)
                return 0;
            try
            {
                uint int32Data2 = (uint)watcher.GetInt32Data(int32Data1, watcher.MugenDatabase.ANIM_LIST_REF2_PLAYER_INFO_OFFSET);
                if (int32Data2 == 0U)
                    return 0;
                uint int32Data3 = (uint)watcher.GetInt32Data(int32Data2, watcher.MugenDatabase.ANIM_LIST_REF3_PLAYER_INFO_OFFSET);
                if (_CheckAnimList(watcher, int32Data3))
                    return int32Data3;
            }
            catch
            {
            }
            return 0;
        }

        /// <summary>
        /// helper function to verify the anim list was found, this appears to be some sort of 'checksum'.
        /// </summary>
        /// <param name="targetAddr"></param>
        /// <returns></returns>
        internal static bool _CheckAnimList(MugenProcessWatcher watcher, uint targetAddr)
        {
            try
            {
                int int32Data1 = watcher.GetInt32Data(targetAddr, 0U);
                int int32Data2 = watcher.GetInt32Data(targetAddr, 4U);
                int int32Data3 = watcher.GetInt32Data(targetAddr, 16U);
                int int32Data4 = watcher.GetInt32Data(targetAddr, 20U);
                int int32Data5 = watcher.GetInt32Data(targetAddr, 32U);
                int int32Data6 = watcher.GetInt32Data(targetAddr, 36U);
                if (int32Data1 == 1)
                {
                    if (int32Data2 == 0)
                    {
                        if (int32Data3 == 1)
                        {
                            if (int32Data4 == 1)
                            {
                                if (int32Data5 == 1)
                                {
                                    if (int32Data6 == 2)
                                        return true;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        public static int GetAnimNo(MugenProcessWatcher watcher, uint animListAddr, int index) => animListAddr != 0U ? watcher.GetInt32Data(animListAddr, (uint)((ulong)index * (ulong)watcher.MugenDatabase.OFFSET_ANIM_LIST_OFFSET + (ulong)watcher.MugenDatabase.ANIM_NO_ANIM_OFFSET)) : -1;

        public static int GetAnim(MugenProcessWatcher watcher, uint baseAddr, uint playerAddr) => -1;

        public static int GetDamage(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.DAMAGE_PLAYER_OFFSET) : 0;

        public static int GetCtrl(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.CTRL_PLAYER_OFFSET) : 0;

        public static int GetStateType(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.STATE_TYPE_PLAYER_OFFSET) : 0;

        public static int GetMoveType(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_TYPE_PLAYER_OFFSET) : 0;

        public static int GetHitPauseTime(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.HIT_PAUSE_TIME_PLAYER_OFFSET) : 0;

        public static int GetMoveContact(MugenProcessWatcher watcher, uint playerAddr)
        {
            if (playerAddr == 0U)
                return 0;
            switch (watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_CONTACT_PLAYER_OFFSET))
            {
                case 1:
                    return watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_HIT_PLAYER_OFFSET);
                case 2:
                    return watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_HIT_PLAYER_OFFSET);
                default:
                    return 0;
            }
        }

        public static int GetMoveHit(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U && watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_CONTACT_PLAYER_OFFSET) == 2 ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_HIT_PLAYER_OFFSET) : 0;

        public static int GetMoveGuarded(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U && watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_CONTACT_PLAYER_OFFSET) == 1 ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_HIT_PLAYER_OFFSET) : 0;

        public static int GetMoveReversed(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U && watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_CONTACT_PLAYER_OFFSET) == 4 ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MOVE_HIT_PLAYER_OFFSET) : 0;

        public static int GetNoClsn2Flag(MugenProcessWatcher watcher, uint playerAddr)
        {
            if (playerAddr == 0U)
                return 1;
            uint int32Data1 = (uint)watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.ANIM_ADDR_PLAYER_OFFSET);
            if (int32Data1 == 0U)
                return 1;
            uint int32Data2 = (uint)watcher.GetInt32Data(int32Data1, watcher.MugenDatabase.ANIM_INFO_ANIM_OFFSET);
            return int32Data2 == 0U || watcher.GetInt32Data(int32Data2, watcher.MugenDatabase.CLSN2_ADDR_ANIM_INFO_OFFSET) == 0 ? 1 : 0;
        }

        public static int GetHasClsn1Flag(MugenProcessWatcher watcher, uint playerAddr)
        {
            if (playerAddr == 0U)
                return 1;
            uint int32Data1 = (uint)watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.ANIM_ADDR_PLAYER_OFFSET);
            if (int32Data1 == 0U)
                return 1;
            uint int32Data2 = (uint)watcher.GetInt32Data(int32Data1, watcher.MugenDatabase.ANIM_INFO_ANIM_OFFSET);
            return int32Data2 == 0U || watcher.GetInt32Data(int32Data2, watcher.MugenDatabase.CLSN1_ADDR_ANIM_INFO_OFFSET) == 0 ? 0 : 1;
        }

        public static int GetMuteki(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.MUTEKI_PLAYER_OFFSET) : 0;

        public static int GetHitBy(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.HITBY_1_PLAYER_OFFSET) & watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.HITBY_2_PLAYER_OFFSET) : 0;

        public static int GetHitOverRide(MugenProcessWatcher watcher, uint playerAddr, int indexFrom0)
        {
            if (playerAddr == 0U || indexFrom0 < 0 || indexFrom0 > 7)
                return 0;
            uint addr = (uint)((ulong)(playerAddr + watcher.MugenDatabase.HITOVERRIDE_LIST_PLAYER_OFFSET) + (ulong)watcher.MugenDatabase.OFFSET_HITOVERRIDE_LIST_OFFSET * (ulong)indexFrom0);
            return watcher.GetInt32Data(addr, watcher.MugenDatabase.EXIST_HITOVERRIDE_OFFSET) != 0 ? watcher.GetInt32Data(addr, watcher.MugenDatabase.ATTR_HITOVERRIDE_OFFSET) : 0;
        }

        public static int GetTarget(MugenProcessWatcher watcher, uint playerAddr, int targetNo)
        {
            if (playerAddr == 0U)
                return 0;
            uint int32Data1 = (uint)watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.TARGET_ENTRY_PLAYER_OFFSET);
            if (int32Data1 == 0U || watcher.GetInt32Data(int32Data1, watcher.MugenDatabase.NUMTARGET_TARGET_ENTRY_OFFSET) <= targetNo)
                return 0;
            uint int32Data2 = (uint)watcher.GetInt32Data(int32Data1, watcher.MugenDatabase.TARGET_LIST_TARGET_ENTRY_OFFSET);
            if (int32Data2 == 0U)
                return 0;
            uint int32Data3 = (uint)watcher.GetInt32Data(int32Data2, (uint)((ulong)watcher.MugenDatabase.OFFSET_TARGET_LIST_OFFSET * (ulong)targetNo));
            return int32Data3 != 0U ? GetPlayerId(watcher, int32Data3) : 0;
        }

        public static int GetFallDamage(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.FALL_DAMAGE_PLAYER_OFFSET) : 0;

        public static int GetFacing(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.FACING_PLAYER_OFFSET) : 0;

        public static float GetPosX(MugenProcessWatcher watcher, uint baseAddr, uint playerAddr)
        {
            if (playerAddr == 0U)
                return 0.0f;
            if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11A4 || watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11B1)
            {
                double stagePosX = watcher.GetDoubleData(playerAddr, watcher.MugenDatabase.STAGEPOS_X_PLAYER_OFFSET);
                float camPosX = watcher.GetFloatData(baseAddr, watcher.MugenDatabase.CAMERAPOS_X_BASE_OFFSET);

                float stageLocalX = GameUtils.GetScreenX(watcher);
                double playerLocalX = GetLocalCoordX(watcher, playerAddr);

                float scale = (float)(playerLocalX / stageLocalX);
                return (float)((stagePosX - camPosX) * scale);
            }
            else if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN10)
            {
                // awkwardly done because datatypes changed from 1.0 to 1.1, so regular LocalCoord and Screen funcs fail here.
                float stagePosX = watcher.GetFloatData(playerAddr, watcher.MugenDatabase.STAGEPOS_X_PLAYER_OFFSET);
                float camPosX = watcher.GetFloatData(baseAddr, watcher.MugenDatabase.CAMERAPOS_X_BASE_OFFSET);

                float stageLocalX = watcher.GetFloatData(baseAddr, watcher.MugenDatabase.SCREEN_X_BASE_OFFSET);
                double playerLocalX = watcher.GetFloatData((uint)watcher.GetInt32Data(playerAddr, 0), watcher.MugenDatabase.LOCALCOORD_X_PLAYER_INFO_OFFSET);

                float scale = (float)(playerLocalX / stageLocalX) * (float)2.0;
                return (float)((stagePosX - camPosX) * scale);
            }
            return watcher.MugenVersion != MugenType_t.MUGEN_TYPE_WINMUGEN ? (float)(((double)watcher.GetFloatData(playerAddr, watcher.MugenDatabase.POS_X_PLAYER_OFFSET) - (double)GameUtils.GetScreenX(watcher)) / 2.0) : (float)((double)watcher.GetFloatData(playerAddr, watcher.MugenDatabase.POS_X_PLAYER_OFFSET) - (double)GameUtils.GetScreenX(watcher) - 160.0);
        }

        public static float GetPosY(MugenProcessWatcher watcher, uint baseAddr, uint playerAddr)
        {
            if (playerAddr == 0U)
                return 0.0f;
            if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11A4 || watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11B1)
            {
                double stagePosY = watcher.GetDoubleData(playerAddr, watcher.MugenDatabase.STAGEPOS_Y_PLAYER_OFFSET);
                float camPosY = watcher.GetFloatData(baseAddr, watcher.MugenDatabase.CAMERAPOS_Y_BASE_OFFSET);

                float stageLocalY = GameUtils.GetScreenY(watcher);
                double playerLocalY = GetLocalCoordY(watcher, playerAddr);

                float scale = (float)(playerLocalY / (playerLocalY + stageLocalY));

                return (float)((stagePosY - camPosY) * scale);
            }
            else if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN10)
            {
                float stagePosY = watcher.GetFloatData(playerAddr, watcher.MugenDatabase.STAGEPOS_Y_PLAYER_OFFSET);
                return stagePosY;
            }
            return watcher.MugenVersion != MugenType_t.MUGEN_TYPE_WINMUGEN ? watcher.GetFloatData(playerAddr, watcher.MugenDatabase.POS_Y_PLAYER_OFFSET) / 2f : watcher.GetFloatData(playerAddr, watcher.MugenDatabase.POS_Y_PLAYER_OFFSET);
        }

        public static float GetVelX(MugenProcessWatcher watcher, uint baseAddr, uint playerAddr)
        {
            if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11A4)
            {
                double doubleData = watcher.GetDoubleData(playerAddr, watcher.MugenDatabase.VEL_X_PLAYER_OFFSET);
                double localCoordX = GetLocalCoordX(watcher, playerAddr);
                double num = (double)GameUtils.GetScreenX(watcher) / localCoordX;
                return (float)(doubleData / num) * (float)GetFacing(watcher, playerAddr);
            }
            return playerAddr != 0U ? watcher.GetFloatData(playerAddr, watcher.MugenDatabase.VEL_X_PLAYER_OFFSET) : 0.0f;
        }

        public static float GetVelY(MugenProcessWatcher watcher, uint baseAddr, uint playerAddr)
        {
            if (watcher.MugenVersion == MugenType_t.MUGEN_TYPE_MUGEN11A4)
            {
                double doubleData = watcher.GetDoubleData(playerAddr, watcher.MugenDatabase.VEL_Y_PLAYER_OFFSET);
                double localCoordY = GetLocalCoordY(watcher, playerAddr);
                double num = (double)GameUtils.GetScreenY(watcher) / localCoordY;
                return (float)(doubleData / num);
            }
            return playerAddr != 0U ? watcher.GetFloatData(playerAddr, watcher.MugenDatabase.VEL_Y_PLAYER_OFFSET) : 0.0f;
        }

        public static double GetLocalCoordX(MugenProcessWatcher watcher, uint playerAddr)
        {
            if ((watcher.MugenVersion == MugenType_t.MUGEN_TYPE_WINMUGEN) || playerAddr == 0U)
                return 0.0;
            else return watcher.GetDoubleData((uint)watcher.GetInt32Data(playerAddr, 0U), watcher.MugenDatabase.LOCALCOORD_X_PLAYER_INFO_OFFSET);
        }

        public static double GetLocalCoordY(MugenProcessWatcher watcher, uint playerAddr)
        {
            if ((watcher.MugenVersion == MugenType_t.MUGEN_TYPE_WINMUGEN) || playerAddr == 0U)
                return 0.0;
            else return watcher.GetDoubleData((uint)watcher.GetInt32Data(playerAddr, 0U), watcher.MugenDatabase.LOCALCOORD_Y_PLAYER_INFO_OFFSET);
        }

        public static int GetSysvar(MugenProcessWatcher watcher, uint playerAddr, int index) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, (uint)((ulong)watcher.MugenDatabase.SYS_VAR_PLAYER_OFFSET + (ulong)(index * 4))) : 0;

        public static float GetSysfvar(MugenProcessWatcher watcher, uint playerAddr, int index) => playerAddr != 0U ? watcher.GetFloatData(playerAddr, (uint)((ulong)watcher.MugenDatabase.SYS_FVAR_PLAYER_OFFSET + (ulong)(index * 4))) : 0.0f;

        public static int GetVar(MugenProcessWatcher watcher, uint playerAddr, int index) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, (uint)((ulong)watcher.MugenDatabase.VAR_PLAYER_OFFSET + (ulong)(index * 4))) : 0;

        public static float GetFvar(MugenProcessWatcher watcher, uint playerAddr, int index) => playerAddr != 0U ? watcher.GetFloatData(playerAddr, (uint)((ulong)watcher.MugenDatabase.FVAR_PLAYER_OFFSET + (ulong)(index * 4))) : 0.0f;

        public static int GetActiveFlag(MugenProcessWatcher watcher, uint baseAddr, int playerNo) => baseAddr != 0U ? watcher.GetInt32Data(baseAddr, (uint)((ulong)watcher.MugenDatabase.ACTIVE_PLAYER_OFFSET + (ulong)(playerNo * 4))) : 0;

        public static int GetPauseMoveTime(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.PAUSE_MOVE_TIME_PLAYER_OFFSET) : 0;

        public static int GetSuperPauseMoveTime(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.SUPER_PAUSE_MOVE_TIME_PLAYER_OFFSET) : 0;

        public static float GetAttackMulSet(MugenProcessWatcher watcher, uint playerAddr) => playerAddr != 0U ? watcher.GetFloatData(playerAddr, watcher.MugenDatabase.ATTACK_MUL_SET_PLAYER_OFFSET) : 0.0f;

        /// <summary>
        /// fetches the player AssertSpecial flags.
        /// <br/>these are a list of sequential int flags relative to the player's address.
        /// </summary>
        /// <param name="playerAddr"></param>
        /// <returns></returns>
        public static bool[] GetSelfAssertSpecials(MugenProcessWatcher watcher, uint playerAddr)
        {
            bool[] flagArray = new bool[9];
            if (!(watcher.MugenDatabase is Databases.Mugen11A4DB))
                return new bool[0];
            if (playerAddr == 0U)
                return flagArray;
            int int32Data1 = watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.SELF_ASSERT_PLAYER_OFFSET);
            if (int32Data1 == 0)
                return flagArray;
            flagArray[0] = (uint)(int32Data1 & 1) > 0U;
            flagArray[1] = (uint)(int32Data1 & 256) > 0U;
            flagArray[2] = (uint)(int32Data1 & 65536) > 0U;
            flagArray[3] = (uint)(int32Data1 & 16777216) > 0U;
            int int32Data2 = watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.SELF_ASSERT_PLAYER_OFFSET + 4U);
            if (int32Data2 == 0)
                return flagArray;
            flagArray[4] = (uint)(int32Data2 & 1) > 0U;
            flagArray[5] = (uint)(int32Data2 & 256) > 0U;
            flagArray[6] = (uint)(int32Data2 & 65536) > 0U;
            flagArray[7] = (uint)(int32Data2 & 16777216) > 0U;
            int int32Data3 = watcher.GetInt32Data(playerAddr, watcher.MugenDatabase.SELF_ASSERT_PLAYER_OFFSET + 8U);
            if (int32Data3 == 0)
                return flagArray;
            flagArray[8] = (uint)(int32Data3 & 1) > 0U;
            return flagArray;
        }

        public static void SetCtrl(MugenProcessWatcher watcher, uint playerAddr, bool ctrl)
        {
            int num = ctrl ? 1 : 0;
            watcher.SetInt32Data(playerAddr, watcher.MugenDatabase.CTRL_PLAYER_OFFSET, num);
        }
    }
}

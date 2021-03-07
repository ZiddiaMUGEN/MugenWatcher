// Decompiled with JetBrains decompiler
// Type: SwissArmyKnifeForMugen.Mugen10DB
// Assembly: SAKnifeWM, Version=1.0.8.0, Culture=neutral, PublicKeyToken=null
// MVID: 09478AD8-365C-4BF3-BEA1-B5785151259B
// Assembly location: C:\Users\ziddi\Downloads\Swiss Army Knife 1.1 Conversion\Swiss Army Knife 1.1 Conversion\SAKnifeWM.exe

namespace MugenWatcher.Databases
{
    /// <summary>
    /// Contains addresses and offsets for MUGEN 1.0.
    /// </summary>
    public class Mugen10DB : MugenAddrDatabase
    {
        public Mugen10DB()
        {
            USE_NEW_DEBUG_COLOR_ADDR = true;
            NEW_DEBUG_COLOR_OFFSETS = new uint[] { 0x44F011, 0x44F189, 0x44F2A3, 0x44F3AD, 0x44EF8B };
            NEW_DEBUG_COLOR_SN_OFFSETS = new uint[] {  };

            MUGEN_POINTER_BASE_OFFSET = 0x52B40C;
            PAUSE_ADDR = 0x52B950;
            CMD_CURRENT_INDEX_ADDR = 0x52A9E8;
            CMD_NEXT_INDEX_ADDR = 0x52A9EC;
            CMD_KEY_ADDR = 0x52A5E8;
            DEMO_BASE_OFFSET = 0x11668;
            MUGEN_ACTIVE_BASE_OFFSET = 0x11664;
            SPEED_MODE_BASE_OFFSET = 0x1245C;
            SKIP_MODE_BASE_OFFSET = 0x10EAC;
            DEBUG_MODE_BASE_OFFSET = 0x12048;
            DEBUG_TARGET_BASE_OFFSET = 0x12040;
            GAMETIME_BASE_OFFSET = 0x10EA8;
            SCREEN_X_BASE_OFFSET = 0x1B60;
            SCREEN_Y_BASE_OFFSET = 0x1B64;
            ROUND_STATE_BASE_OFFSET = 0x11710;
            ROUND_NO_BASE_OFFSET = 0x116E4;
            ROUND_TIME_BASE_OFFSET = 0x11724;
            ROUND_NO_OF_MATCH_TIME_BASE_OFFSET = 0xA18;
            TURNS_MODE_BASE_OFFSET = 0xA1C;
            TEAM_WIN_BASE_OFFSET = 0x11714;
            TEAM_WIN_KO_BASE_OFFSET = 0x11718;
            TEAM_1_WIN_COUNT_BASE_OFFSET = 0x116E8;
            TEAM_2_WIN_COUNT_BASE_OFFSET = 0x116EC;
            DRAW_GAME_COUNT_BASE_OFFSET = 0x116F4;
            PLAYER_1_BASE_OFFSET = 0x11234;
            EXPLOD_LIST_BASE_OFFSET = 0xFCB0;
            PAL_TIME_BASE_OFFSET = 0xB338;
            PAL_GRAY_BASE_OFFSET = 0xB33C;
            PAL_R_BASE_OFFSET = 0xB340;
            PAL_G_BASE_OFFSET = 0xB344;
            PAL_B_BASE_OFFSET = 0xB348;
            PAUSE_TIME_BASE_OFFSET = 0xBBD4;
            SUPER_PAUSE_TIME_BASER_OFFSET = 0xBBF8;
            OFFSET_EXPLOD_LIST_OFFSET = 0x108;
            ANIM_ADDR_EXPLOD_OFFSET = 0x80;
            ANIM_INDEX_EXPLOD_OFFSET = 0xC;
            EXIST_EXPLOD_OFFSET = 0x0;
            EXPLOD_ID_EXPLOD_OFFSET = 0x10;
            EXPLOD_OWNER_ID_EXPLOD_OFFSET = 0xC;
            PROJ_LIST_PROJ_BASE_OFFSET = 0x18;
            PROJ_MAX_PROJ_BASE_OFFSET = 0x28;
            OFFSET_PROJ_LIST_OFFSET = 0x2E0;
            EXIST_PROJ_OFFSET = 0x4;
            PROJ_ID_PROJ_OFFSET = 0x0;
            PROJ_X_PROJ_OFFSET = 0x44;
            PROJ_Y_PROJ_OFFSET = 0x48;
            OFFSET_ANIM_LIST_OFFSET = 0x10;
            ANIM_NO_ANIM_OFFSET = 0xC;
            ANIM_INFO_ANIM_OFFSET = 0x10;
            CLSN1_ADDR_ANIM_INFO_OFFSET = 0x28;
            CLSN2_ADDR_ANIM_INFO_OFFSET = 0x2C;
            OFFSET_HITOVERRIDE_LIST_OFFSET = 0x14;
            EXIST_HITOVERRIDE_OFFSET = 0x0;
            ATTR_HITOVERRIDE_OFFSET = 0x4;
            NUMTARGET_TARGET_ENTRY_OFFSET = 0x8;
            TARGET_LIST_TARGET_ENTRY_OFFSET = 0x18;
            OFFSET_TARGET_LIST_OFFSET = 0x1C;
            EXIST_PLAYER_OFFSET = 0x1B0;
            PLAYER_ID_PLAYER_OFFSET = 0x4;
            HELPER_ID_PLAYER_OFFSET = 0x1474;
            PARENT_ID_PLAYER_OFFSET = 0x1478;
            PROJ_BASE_PLAYER_OFFSET = 0x268;
            STATE_OWNER_PLAYER_OFFSET = 0xC48;
            STATE_NO_PLAYER_OFFSET = 0xC4C;
            PREV_STATE_NO_PLAYER_OFFSET = 0xC50;
            PALNO_PLAYER_OFFSET = 0x1420;
            ALIVE_PLAYER_OFFSET = 0xE80;
            LIFE_PLAYER_OFFSET = 0x1BC;
            POWER_PLAYER_OFFSET = 0x1D8;
            DAMAGE_PLAYER_OFFSET = 0x1084;
            CTRL_PLAYER_OFFSET = 0xE64;
            STATE_TYPE_PLAYER_OFFSET = 0xE58;
            MOVE_TYPE_PLAYER_OFFSET = 0xE5C;
            HIT_PAUSE_TIME_PLAYER_OFFSET = 0xE70;
            MOVE_CONTACT_PLAYER_OFFSET = 0xE8C;
            MOVE_HIT_PLAYER_OFFSET = 0xE90;
            ANIM_ADDR_PLAYER_OFFSET = 0x1418;
            MUTEKI_PLAYER_OFFSET = 0x1054;
            HITBY_1_PLAYER_OFFSET = 0x1058;
            HITBY_2_PLAYER_OFFSET = 0x105C;
            HITOVERRIDE_LIST_PLAYER_OFFSET = 0x1104;
            TARGET_ENTRY_PLAYER_OFFSET = 0x26C;
            FALL_DAMAGE_PLAYER_OFFSET = 0x10CC;
            FACING_PLAYER_OFFSET = 0x1E8;
            POS_X_PLAYER_OFFSET = 0x1F4;
            POS_Y_PLAYER_OFFSET = 0x1F8;
            VEL_X_PLAYER_OFFSET = 0x204;
            VEL_Y_PLAYER_OFFSET = 0x208;
            SYS_VAR_PLAYER_OFFSET = 0x102C;
            SYS_FVAR_PLAYER_OFFSET = 0x1040;
            VAR_PLAYER_OFFSET = 0xE9C;
            FVAR_PLAYER_OFFSET = 0xF8C;
            ACTIVE_PLAYER_OFFSET = 0xBA68;
            ASSERT_1_PLAYER_OFFSET = 0xBB78;
            PAUSE_MOVE_TIME_PLAYER_OFFSET = 0x228;
            SUPER_PAUSE_MOVE_TIME_PLAYER_OFFSET = 0x22C;
            ATTACK_MUL_SET_PLAYER_OFFSET = 0x1E0;
            DISPLAY_NAME_PLAYER_INFO_OFFSET = 0x30;
            ANIM_LIST_REF1_PLAYER_INFO_OFFSET = 0x438;
            ANIM_LIST_REF2_PLAYER_INFO_OFFSET = 0x0;
            ANIM_LIST_REF3_PLAYER_INFO_OFFSET = 0x1C;
            LOCALCOORD_X_PLAYER_INFO_OFFSET = 0x90;
            LOCALCOORD_Y_PLAYER_INFO_OFFSET = 0x98;

            STAGEPOS_X_PLAYER_OFFSET = 0x1F4;
            STAGEPOS_Y_PLAYER_OFFSET = 0x1F8;

            CAMERAPOS_X_BASE_OFFSET = 0x10EF8;
            CAMERAPOS_Y_BASE_OFFSET = 0x10EFC;
        }
    }
}

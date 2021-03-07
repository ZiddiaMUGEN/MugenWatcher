// Decompiled with JetBrains decompiler
// Type: SwissArmyKnifeForMugen.Mugen11A4DB
// Assembly: SAKnifeWM, Version=1.0.8.0, Culture=neutral, PublicKeyToken=null
// MVID: 09478AD8-365C-4BF3-BEA1-B5785151259B
// Assembly location: C:\Users\ziddi\Downloads\Swiss Army Knife 1.1 Conversion\Swiss Army Knife 1.1 Conversion\SAKnifeWM.exe

namespace MugenWatcher.Databases
{
    /// <summary>
    /// Contains addresses and offsets for MUGEN 1.1a4.
    /// </summary>
    public class Mugen11A4DB : MugenAddrDatabase
    {
        public Mugen11A4DB()
        {
            USE_NEW_DEBUG_COLOR_ADDR = true;
            NEW_DEBUG_COLOR_OFFSETS = new uint[] { 0x419A95, 0x4198F8, 0x419962, 0x419B90 };
            NEW_DEBUG_COLOR_SN_OFFSETS = new uint[] { 0x419C78, 0x419C84, 0x419C89 };

            MUGEN_POINTER_BASE_OFFSET = 0x5040E8;
            CMD_CURRENT_INDEX_ADDR = 0x503870;
            CMD_NEXT_INDEX_ADDR = 0x503874;
            CMD_KEY_ADDR = 0x503470;
            DEMO_BASE_OFFSET = 0xBB88;
            MUGEN_ACTIVE_BASE_OFFSET = 0xBB84;
            SPEED_MODE_BASE_OFFSET = 0x130EC;
            SKIP_MODE_BASE_OFFSET = 0x11E9C;
            DEBUG_MODE_BASE_OFFSET = 0x130CC;
            DEBUG_TARGET_BASE_OFFSET = 0x130C4;
            PAUSE_ADDR = 0x11EB0;
            SCREEN_X_BASE_OFFSET = 0x128A8;
            SCREEN_Y_BASE_OFFSET = 0x128AC;
            PAL_TIME_BASE_OFFSET = 0xB338;
            PAL_GRAY_BASE_OFFSET = 0xB33C;
            PAL_R_BASE_OFFSET = 0xB340;
            PAL_G_BASE_OFFSET = 0xB344;
            PAL_B_BASE_OFFSET = 0xB348;
            GAMETIME_BASE_OFFSET = 0x11E98;
            ROUND_STATE_BASE_OFFSET = 0x12754;
            ROUND_NO_BASE_OFFSET = 0x12728;
            ROUND_TIME_BASE_OFFSET = 0x12764;
            ROUND_NO_OF_MATCH_TIME_BASE_OFFSET = 0xA18;
            TURNS_MODE_BASE_OFFSET = 0xA1C;
            TEAM_WIN_BASE_OFFSET = 0x12758;
            TEAM_WIN_KO_BASE_OFFSET = 0x1275C;
            TEAM_1_WIN_COUNT_BASE_OFFSET = 0x1272C;
            TEAM_2_WIN_COUNT_BASE_OFFSET = 0x12730;
            DRAW_GAME_COUNT_BASE_OFFSET = 0x12738;
            PAUSE_TIME_BASE_OFFSET = 0x126F8;
            SUPER_PAUSE_TIME_BASER_OFFSET = 0x1271C;
            ACTIVE_PLAYER_OFFSET = 0x1258C;
            ASSERT_1_PLAYER_OFFSET = 0x1269C;
            PLAYER_1_BASE_OFFSET = 0x12278;
            EXPLOD_LIST_BASE_OFFSET = 0x10C20;
            HITOVERRIDE_LIST_PLAYER_OFFSET = 0x1180;
            OFFSET_HITOVERRIDE_LIST_OFFSET = 0x14;
            EXIST_HITOVERRIDE_OFFSET = 0x0;
            ATTR_HITOVERRIDE_OFFSET = 0x4;
            TARGET_ENTRY_PLAYER_OFFSET = 0x2C8;
            NUMTARGET_TARGET_ENTRY_OFFSET = 0x8;
            TARGET_LIST_TARGET_ENTRY_OFFSET = 0x18;
            OFFSET_TARGET_LIST_OFFSET = 0x1C;
            EXIST_PLAYER_OFFSET = 0x1B0;
            PLAYER_ID_PLAYER_OFFSET = 0x4;
            HELPER_ID_PLAYER_OFFSET = 0x1644;
            PARENT_ID_PLAYER_OFFSET = 0x1648;
            PROJ_BASE_PLAYER_OFFSET = 0x2C4;
            STATE_OWNER_PLAYER_OFFSET = 0xCC8;
            STATE_NO_PLAYER_OFFSET = 0xCCC;
            PREV_STATE_NO_PLAYER_OFFSET = 0xCD0;
            PALNO_PLAYER_OFFSET = 0x153C;
            ALIVE_PLAYER_OFFSET = 0xF00;
            LIFE_PLAYER_OFFSET = 0x1B8;
            POWER_PLAYER_OFFSET = 0x1D0;
            DAMAGE_PLAYER_OFFSET = 0x1104;
            CTRL_PLAYER_OFFSET = 0xEE4;
            STATE_TYPE_PLAYER_OFFSET = 0xED8;
            MOVE_TYPE_PLAYER_OFFSET = 0xEDC;
            HIT_PAUSE_TIME_PLAYER_OFFSET = 0xEF4;
            MOVE_CONTACT_PLAYER_OFFSET = 0xF0C;
            MOVE_HIT_PLAYER_OFFSET = 0xF10;
            MUTEKI_PLAYER_OFFSET = 0x10D4;
            HITBY_1_PLAYER_OFFSET = 0x10D8;
            HITBY_2_PLAYER_OFFSET = 0x10DC;
            FALL_DAMAGE_PLAYER_OFFSET = 0x114C;
            FACING_PLAYER_OFFSET = 0x1E8;
            POS_X_PLAYER_OFFSET = 0x1F8;
            POS_Y_PLAYER_OFFSET = 0x200;
            VEL_X_PLAYER_OFFSET = 0x248;
            VEL_Y_PLAYER_OFFSET = 0x250;
            SYS_VAR_PLAYER_OFFSET = 0x10AC;
            SYS_FVAR_PLAYER_OFFSET = 0x10C0;
            VAR_PLAYER_OFFSET = 0xF1C;
            FVAR_PLAYER_OFFSET = 0x100C;
            ATTACK_MUL_SET_PLAYER_OFFSET = 0x1E0;
            DISPLAY_NAME_PLAYER_INFO_OFFSET = 0x30;
            ANIM_LIST_REF1_PLAYER_INFO_OFFSET = 0x434;
            ANIM_LIST_REF2_PLAYER_INFO_OFFSET = 0x0;
            ANIM_LIST_REF3_PLAYER_INFO_OFFSET = 0x1C;
            OFFSET_EXPLOD_LIST_OFFSET = 0x268;
            ANIM_ADDR_EXPLOD_OFFSET = 0x1E0;
            ANIM_INDEX_EXPLOD_OFFSET = 0xC;
            EXIST_EXPLOD_OFFSET = 0x0;
            EXPLOD_ID_EXPLOD_OFFSET = 0x10;
            EXPLOD_OWNER_ID_EXPLOD_OFFSET = 0xC;
            OFFSET_PROJ_LIST_OFFSET = 0x508;
            PROJ_LIST_PROJ_BASE_OFFSET = 0x18;
            PROJ_MAX_PROJ_BASE_OFFSET = 0xC;
            EXIST_PROJ_OFFSET = 0x4;
            PROJ_ID_PROJ_OFFSET = 0x0;
            PROJ_X_PROJ_OFFSET = 0xA4;
            PROJ_Y_PROJ_OFFSET = 0xA8;
            OFFSET_ANIM_LIST_OFFSET = 0x10;
            ANIM_NO_ANIM_OFFSET = 0xC;
            ANIM_ADDR_PLAYER_OFFSET = 0x1534;
            ANIM_INFO_ANIM_OFFSET = 0x10;
            CLSN1_ADDR_ANIM_INFO_OFFSET = 0x84;
            CLSN2_ADDR_ANIM_INFO_OFFSET = 0x88;
            PAUSE_MOVE_TIME_PLAYER_OFFSET = 0x228;
            SUPER_PAUSE_MOVE_TIME_PLAYER_OFFSET = 0x22C;
            SELF_ASSERT_PLAYER_OFFSET = 0x2AC;
            LOCALCOORD_X_PLAYER_INFO_OFFSET = 0x90;
            LOCALCOORD_Y_PLAYER_INFO_OFFSET = 0x98;

            STAGEPOS_X_PLAYER_OFFSET = 0x220;
            STAGEPOS_Y_PLAYER_OFFSET = 0x228;

            CAMERAPOS_X_BASE_OFFSET = 0x11F00;
            CAMERAPOS_Y_BASE_OFFSET = 0x11F04;
        }
    }
}

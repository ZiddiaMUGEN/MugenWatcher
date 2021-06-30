﻿// Decompiled with JetBrains decompiler
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
            DEBUG_CLSN_DISPLAY_MODE = 0x130DC;
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
            CONST_PLAYER_OFFSET = 0x50;
            AILEVEL_PLAYER_OFFSET = 0x2424;
            AIENABLED_PLAYER_OFFSET = 0x1658;

            STAGEPOS_X_PLAYER_OFFSET = 0x220;
            STAGEPOS_Y_PLAYER_OFFSET = 0x228;

            CAMERAPOS_X_BASE_OFFSET = 0x11F00;
            CAMERAPOS_Y_BASE_OFFSET = 0x11F04;

            CONST_SIZE_Z_WIDTH = -1; // removed in 1.0
            CONST_DATA_LIFE = 0;
            CONST_DATA_POWER = 1;
            CONST_DATA_ATTACK = 2;
            CONST_SIZE_ATTACK_Z_WIDTH_FRONT = 3;
            CONST_SIZE_ATTACK_Z_WIDTH_BACK = 4;
            CONST_DATA_AIRJUGGLE = 5;
            CONST_SIZE_ATTACK_DIST = 6;
            CONST_SIZE_PROJ_ATTACK_DIST = 7;
            CONST_DATA_DEFENCE = 8;
            CONST_DATA_FALL_DEFENCE_MUL = 9;
            CONST_DATA_LIEDOWN_TIME = 10;
            CONST_SIZE_XSCALE = 11;
            CONST_SIZE_YSCALE = 12;
            CONST_SIZE_GROUND_BACK = 13;
            CONST_SIZE_GROUND_FRONT = 14;
            CONST_SIZE_AIR_BACK = 15;
            CONST_SIZE_AIR_FRONT = 16;
            CONST_SIZE_HEIGHT = 17;
            CONST_SIZE_PROJ_DOSCALE = 18;
            CONST_SIZE_HEAD_POS_X = 19;
            CONST_SIZE_HEAD_POS_Y = 20;
            CONST_SIZE_MID_POS_X = 21;
            CONST_SIZE_MID_POS_Y = 22;
            CONST_SIZE_SHADOWOFFSET = 23;
            CONST_VELOCITY_WALK_FWD_X = 24;
            CONST_VELOCITY_WALK_BACK_X = 25;
            CONST_VELOCITY_WALK_UP_X = 26;
            CONST_VELOCITY_WALK_DOWN_X = 27;
            CONST_VELOCITY_RUN_FWD_X = 28;
            CONST_VELOCITY_RUN_FWD_Y = 29;
            CONST_VELOCITY_RUN_BACK_X = 30;
            CONST_VELOCITY_RUN_BACK_Y = 31;
            CONST_VELOCITY_RUN_DOWN_X = 32;
            CONST_VELOCITY_RUN_DOWN_Y = 33;
            CONST_VELOCITY_RUN_UP_X = 34;
            CONST_VELOCITY_RUN_UP_Y = 35;
            CONST_VELOCITY_JUMP_Y = 36;
            CONST_VELOCITY_JUMP_NEU_X = 37;
            CONST_VELOCITY_JUMP_FWD_X = 38;
            CONST_VELOCITY_JUMP_BACK_X = 39;
            CONST_VELOCITY_JUMP_UP_X = 40;
            CONST_VELOCITY_JUMP_DOWN_X = 41;
            CONST_VELOCITY_RUNJUMP_FWD_Y = 42;
            CONST_VELOCITY_RUNJUMP_FWD_X = 43;
            CONST_VELOCITY_RUNJUMP_BACK_X = 44;
            CONST_VELOCITY_RUNJUMP_UP_X = 45;
            CONST_VELOCITY_RUNJUMP_DOWN_X = 46;
            CONST_MOVEMENT_AIRJUMP_NUM = 47;
            CONST_MOVEMENT_AIRJUMP_HEIGHT = 48;
            CONST_VELOCITY_AIRJUMP_Y = 49;
            CONST_VELOCITY_AIRJUMP_NEU_X = 50;
            CONST_VELOCITY_AIRJUMP_FWD_X = 51;
            CONST_VELOCITY_AIRJUMP_BACK_X = 52;
            CONST_VELOCITY_AIRJUMP_UP_X = 53;
            CONST_VELOCITY_AIRJUMP_DOWN_X = 54;
            CONST_MOVEMENT_YACCEL = 55;
            CONST_MOVEMENT_STAND_FRICTION = 56;
            CONST_MOVEMENT_CROUCH_FRICTION = 57;
            CONST_DATA_SPARKNO = 58;
            CONST_DATA_GUARD_SPARKNO = 59;
            CONST_DATA_KO_ECHO = 60;
            CONST_SIZE_DRAW_OFFSET_X = 61;
            CONST_SIZE_DRAW_OFFSET_Y = 62;
            CONST_DATA_INTPERSISTINDEX = 63;
            CONST_DATA_FLOATPERSISTINDEX = 64;
            CONST_VELOCITY_AIR_GETHIT_GROUNDRECOVER_X = 65;
            CONST_VELOCITY_AIR_GETHIT_GROUNDRECOVER_Y = 66;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_MUL_X = 67;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_MUL_Y = 68;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_ADD_X = 69;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_ADD_Y = 70;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_BACK = 71;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_FWD = 72;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_UP = 73;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_DOWN = 74;
            CONST_MOVEMENT_STAND_FRICTION_THRESHOLD = 75;
            CONST_MOVEMENT_CROUCH_FRICTION_THRESHOLD = 76;
            CONST_MOVEMENT_AIR_GETHIT_GROUNDLEVEL = 77;
            CONST_MOVEMENT_AIR_GETHIT_GROUNDRECOVER_GROUND_THRESHOLD = 78;
            CONST_MOVEMENT_AIR_GETHIT_GROUNDRECOVER_GROUNDLEVEL = 79;
            CONST_MOVEMENT_AIR_GETHIT_AIRRECOVER_THRESHOLD = 80;
            CONST_MOVEMENT_AIR_GETHIT_AIRRECOVER_YACCEL = 81;
            CONST_MOVEMENT_AIR_GETHIT_TRIP_GROUNDLEVEL = 82;
            CONST_MOVEMENT_DOWN_BOUNCE_OFFSET_X = 83;
            CONST_MOVEMENT_DOWN_BOUNCE_OFFSET_Y = 84;
            CONST_MOVEMENT_DOWN_BOUNCE_YACCEL = 85;
            CONST_MOVEMENT_DOWN_BOUNCE_GROUNDLEVEL = 86;
            CONST_MOVEMENT_DOWN_FRICTION_THRESHOLD = 87;
        }
    }
}

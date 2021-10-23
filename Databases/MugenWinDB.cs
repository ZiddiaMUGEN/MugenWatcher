using System;
using System.Collections.Generic;
using System.Text;

namespace MugenWatcher.Databases
{
    public class MugenWinDB : MugenAddrDatabase
    {
        public MugenWinDB()
        {
            /* Global Offsets -- relative to nothing */
            this.USE_NEW_DEBUG_COLOR_ADDR = false;
            this.NEW_DEBUG_COLOR_OFFSETS = null;
            this.NEW_DEBUG_COLOR_SN_OFFSETS = null;
            this.MUGEN_POINTER_BASE_OFFSET = 0x4B5B4C;
            this.PAUSE_ADDR = 0x4B6A81;
            this.CMD_CURRENT_INDEX_ADDR = 0x4B5948;
            this.CMD_NEXT_INDEX_ADDR = 0x4B594C;
            this.CMD_KEY_ADDR = 0x4B5548;

            /* Game Offsets - relative to MUGEN_POINTER_BASE_OFFSET */
            this.DEMO_BASE_OFFSET = 0xBB8C;
            this.MUGEN_ACTIVE_BASE_OFFSET = 0xBB88;
            this.SPEED_MODE_BASE_OFFSET = 0xC934;
            this.SKIP_MODE_BASE_OFFSET = 0xB400;
            this.DEBUG_MODE_BASE_OFFSET = 0xC520;
            this.DEBUG_TARGET_BASE_OFFSET = 0xC518;
            this.DEBUG_CLSN_DISPLAY_MODE = 0xC530;
            this.GAMETIME_BASE_OFFSET = 0xB3FC;
            this.SCREEN_X_BASE_OFFSET = 0xB428;
            this.SCREEN_Y_BASE_OFFSET = 0xB434;
            this.ROUND_STATE_BASE_OFFSET = 0xBC30;
            this.ROUND_NO_BASE_OFFSET = 0xBC04;
            this.ROUND_TIME_BASE_OFFSET = 0xBC40;
            this.ROUND_NO_OF_MATCH_TIME_BASE_OFFSET = 0x5BF8;
            this.TURNS_MODE_BASE_OFFSET = 0x5BFC;
            this.TEAM_WIN_BASE_OFFSET = 0xBC34;
            this.TEAM_WIN_KO_BASE_OFFSET = 0xBC38;
            this.TEAM_1_WIN_COUNT_BASE_OFFSET = 0xBC08;
            this.TEAM_2_WIN_COUNT_BASE_OFFSET = 0xBC0C;
            this.DRAW_GAME_COUNT_BASE_OFFSET = 0xBC14;
            this.PLAYER_1_BASE_OFFSET = 0xB754;
            this.EXPLOD_LIST_BASE_OFFSET = 0xA2E4;
            this.PAL_TIME_BASE_OFFSET = 0xB180;
            this.PAL_GRAY_BASE_OFFSET = 0xB184;
            this.PAL_R_BASE_OFFSET = 0xB188;
            this.PAL_G_BASE_OFFSET = 0xB18C;
            this.PAL_B_BASE_OFFSET = 0xB190;
            this.PAUSE_TIME_BASE_OFFSET = 0xBBD4;
            this.SUPER_PAUSE_TIME_BASER_OFFSET = 0xBBF8;
            this.ASSERT_1_PLAYER_OFFSET = 0xBB78;
            this.AILEVEL_PLAYER_OFFSET = 0x33F8;
            this.AIENABLED_PLAYER_OFFSET = 0x262C;

            /* Explod Offsets - relative to EXPLOD_LIST_BASE_OFFSET */
            this.OFFSET_EXPLOD_LIST_OFFSET = 0xE4;
            this.ANIM_ADDR_EXPLOD_OFFSET = 0x80;
            this.ANIM_INDEX_EXPLOD_OFFSET = 0xC;
            this.EXPLOD_ID_EXPLOD_OFFSET = 0x10;
            this.EXPLOD_OWNER_ID_EXPLOD_OFFSET = 0xC;

            /* Projectile Metadata Offsets - relative to PROJ_BASE_PLAYER_OFFSET */
            this.PROJ_LIST_PROJ_BASE_OFFSET = 0x14;
            this.PROJ_MAX_PROJ_BASE_OFFSET = 0x28;

            /* Projectile Offsets - relative to PROJ_LIST_PROJ_BASE_OFFSET */
            this.OFFSET_PROJ_LIST_OFFSET = 0x2DC;
            this.EXIST_PROJ_OFFSET = 0x4;
            this.PROJ_X_PROJ_OFFSET = 0x5C;
            this.PROJ_Y_PROJ_OFFSET = 0x60;
            this.PROJ_ANIM_INDEX_PROJ_OFFSET = 0x290;

            /* Player Offsets - relative to PLAYER_1_BASE_OFFSET */
            this.EXIST_PLAYER_OFFSET = 0x158;
            this.PLAYER_ID_PLAYER_OFFSET = 0x4;
            this.HELPER_ID_PLAYER_OFFSET = 0x2618;
            this.PARENT_ID_PLAYER_OFFSET = 0x261C;
            this.PROJ_BASE_PLAYER_OFFSET = 0x21C;
            this.STATE_OWNER_PLAYER_OFFSET = 0xBF0;
            this.STATE_NO_PLAYER_OFFSET = 0xBF4;
            this.PREV_STATE_NO_PLAYER_OFFSET = 0xBF8;
            this.PALNO_PLAYER_OFFSET = 0x13C4;
            this.ALIVE_PLAYER_OFFSET = 0xE24;
            this.LIFE_PLAYER_OFFSET = 0x160;
            this.POWER_PLAYER_OFFSET = 0x178;
            this.DAMAGE_PLAYER_OFFSET = 0x1028;
            this.CTRL_PLAYER_OFFSET = 0xE0C;
            this.STATE_TYPE_PLAYER_OFFSET = 0xE00;
            this.MOVE_TYPE_PLAYER_OFFSET = 0xE04;
            this.HIT_PAUSE_TIME_PLAYER_OFFSET = 0xE18;
            this.MOVE_CONTACT_PLAYER_OFFSET = 0xE30;
            this.MOVE_HIT_PLAYER_OFFSET = 0xE34;
            this.ANIM_ADDR_PLAYER_OFFSET = 0x13BC;
            this.MUTEKI_PLAYER_OFFSET = 0xFF8;
            this.HITBY_1_PLAYER_OFFSET = 0xFFC;
            this.HITBY_2_PLAYER_OFFSET = 0x1000;
            this.HITOVERRIDE_LIST_PLAYER_OFFSET = 0x10A8;
            this.TARGET_ENTRY_PLAYER_OFFSET = 0x220;
            this.FALL_DAMAGE_PLAYER_OFFSET = 0x1074;
            this.FACING_PLAYER_OFFSET = 0x190;
            this.POS_X_PLAYER_OFFSET = 0x19C;
            this.POS_Y_PLAYER_OFFSET = 0x1A0;
            this.VEL_X_PLAYER_OFFSET = 0x1B4;
            this.VEL_Y_PLAYER_OFFSET = 0x1B8;
            this.SYS_VAR_PLAYER_OFFSET = 0xFD0;
            this.SYS_FVAR_PLAYER_OFFSET = 0xFE4;
            this.VAR_PLAYER_OFFSET = 0xE40;
            this.FVAR_PLAYER_OFFSET = 0xF30;
            this.ACTIVE_PLAYER_OFFSET = 0xBA68;
            this.PAUSE_MOVE_TIME_PLAYER_OFFSET = 0x1DC;
            this.SUPER_PAUSE_MOVE_TIME_PLAYER_OFFSET = 0x1E0;
            this.ATTACK_MUL_SET_PLAYER_OFFSET = 0x188;
            this.CONST_PLAYER_OFFSET = 0x50;
            this.PROJ_HIT_TIME_PLAYER_OFFSET = 0x218;
            this.PROJ_HIT_ID_PLAYER_OFFSET = 0x210;

            /* Player Info Offsets - relative to the pointer at the first byte of [PLAYER_1_BASE_OFFSET]. */
            this.DISPLAY_NAME_PLAYER_INFO_OFFSET = 0x30;
            this.ANIM_LIST_REF1_PLAYER_INFO_OFFSET = 0x3CC;
            this.ANIM_LIST_REF3_PLAYER_INFO_OFFSET = 0x18;

            /* Anim-related. */
            this.OFFSET_ANIM_LIST_OFFSET = 0x10;
            this.ANIM_NO_ANIM_OFFSET = 0xC;

            this.ANIM_INFO_ANIM_OFFSET = 0x10;
            this.CLSN1_ADDR_ANIM_INFO_OFFSET = 0x28;
            this.CLSN2_ADDR_ANIM_INFO_OFFSET = 0x2C;

            /* Misc. */
            this.OFFSET_HITOVERRIDE_LIST_OFFSET = 0x14;
            this.ATTR_HITOVERRIDE_OFFSET = 0x4;
            this.NUMTARGET_TARGET_ENTRY_OFFSET = 0x8;
            this.TARGET_LIST_TARGET_ENTRY_OFFSET = 0x14;
            this.OFFSET_TARGET_LIST_OFFSET = 0x20;

            /* Constant offsets. */
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
            CONST_SIZE_Z_WIDTH = 17;
            CONST_SIZE_HEIGHT = 18;
            CONST_SIZE_PROJ_DOSCALE = 19;
            CONST_SIZE_HEAD_POS_X = 20;
            CONST_SIZE_HEAD_POS_Y = 21;
            CONST_SIZE_MID_POS_X = 22;
            CONST_SIZE_MID_POS_Y = 23;
            CONST_SIZE_SHADOWOFFSET = 24;
            CONST_VELOCITY_WALK_FWD_X = 25;
            CONST_VELOCITY_WALK_BACK_X = 26;
            CONST_VELOCITY_WALK_UP_X = 27;
            CONST_VELOCITY_WALK_DOWN_X = 28;
            CONST_VELOCITY_RUN_FWD_X = 29;
            CONST_VELOCITY_RUN_FWD_Y = 30;
            CONST_VELOCITY_RUN_BACK_X = 31;
            CONST_VELOCITY_RUN_BACK_Y = 32;
            CONST_VELOCITY_RUN_DOWN_X = 33;
            CONST_VELOCITY_RUN_DOWN_Y = 34;
            CONST_VELOCITY_RUN_UP_X = 35;
            CONST_VELOCITY_RUN_UP_Y = 36;
            CONST_VELOCITY_JUMP_Y = 37;
            CONST_VELOCITY_JUMP_NEU_X = 38;
            CONST_VELOCITY_JUMP_FWD_X = 39;
            CONST_VELOCITY_JUMP_BACK_X = 40;
            CONST_VELOCITY_JUMP_UP_X = 41;
            CONST_VELOCITY_JUMP_DOWN_X = 42;
            CONST_VELOCITY_RUNJUMP_FWD_Y = 43;
            CONST_VELOCITY_RUNJUMP_FWD_X = 44;
            CONST_VELOCITY_RUNJUMP_BACK_X = 45;
            CONST_VELOCITY_RUNJUMP_UP_X = 46;
            CONST_VELOCITY_RUNJUMP_DOWN_X = 47;
            CONST_MOVEMENT_AIRJUMP_NUM = 48;
            CONST_MOVEMENT_AIRJUMP_HEIGHT = 49;
            CONST_VELOCITY_AIRJUMP_Y = 50;
            CONST_VELOCITY_AIRJUMP_NEU_X = 51;
            CONST_VELOCITY_AIRJUMP_FWD_X = 52;
            CONST_VELOCITY_AIRJUMP_BACK_X = 53;
            CONST_VELOCITY_AIRJUMP_UP_X = 54;
            CONST_VELOCITY_AIRJUMP_DOWN_X = 55;
            CONST_MOVEMENT_YACCEL = 56;
            CONST_MOVEMENT_STAND_FRICTION = 57;
            CONST_MOVEMENT_CROUCH_FRICTION = 58;
            CONST_DATA_SPARKNO = 59;
            CONST_DATA_GUARD_SPARKNO = 60;
            CONST_DATA_KO_ECHO = 61;
            CONST_SIZE_DRAW_OFFSET_X = 62;
            CONST_SIZE_DRAW_OFFSET_Y = 63;
            CONST_DATA_INTPERSISTINDEX = 64;
            CONST_DATA_FLOATPERSISTINDEX = 65;

            /* These were added in 1.0. */
            CONST_VELOCITY_AIR_GETHIT_GROUNDRECOVER_X = -1;
            CONST_VELOCITY_AIR_GETHIT_GROUNDRECOVER_Y = -1;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_MUL_X = -1;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_MUL_Y = -1;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_ADD_X = -1;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_ADD_Y = -1;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_BACK = -1;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_FWD = -1;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_UP = -1;
            CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_DOWN = -1;
            CONST_MOVEMENT_STAND_FRICTION_THRESHOLD = -1;
            CONST_MOVEMENT_CROUCH_FRICTION_THRESHOLD = -1;
            CONST_MOVEMENT_AIR_GETHIT_GROUNDLEVEL = -1;
            CONST_MOVEMENT_AIR_GETHIT_GROUNDRECOVER_GROUND_THRESHOLD = -1;
            CONST_MOVEMENT_AIR_GETHIT_GROUNDRECOVER_GROUNDLEVEL = -1;
            CONST_MOVEMENT_AIR_GETHIT_AIRRECOVER_THRESHOLD = -1;
            CONST_MOVEMENT_AIR_GETHIT_AIRRECOVER_YACCEL = -1;
            CONST_MOVEMENT_AIR_GETHIT_TRIP_GROUNDLEVEL = -1;
            CONST_MOVEMENT_DOWN_BOUNCE_OFFSET_X = -1;
            CONST_MOVEMENT_DOWN_BOUNCE_OFFSET_Y = -1;
            CONST_MOVEMENT_DOWN_BOUNCE_YACCEL = -1;
            CONST_MOVEMENT_DOWN_BOUNCE_GROUNDLEVEL = -1;
            CONST_MOVEMENT_DOWN_FRICTION_THRESHOLD = -1;
        }
    }
}

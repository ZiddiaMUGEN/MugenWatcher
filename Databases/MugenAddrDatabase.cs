// Decompiled with JetBrains decompiler
// Type: SwissArmyKnifeForMugen.MugenAddrDatabase
// Assembly: SAKnifeWM, Version=1.0.8.0, Culture=neutral, PublicKeyToken=null
// MVID: 09478AD8-365C-4BF3-BEA1-B5785151259B
// Assembly location: C:\Users\ziddi\Downloads\Swiss Army Knife 1.1 Conversion\Swiss Army Knife 1.1 Conversion\SAKnifeWM.exe

using MugenWatcher.EnumTypes;

namespace MugenWatcher.Databases
{
    /// <summary>
    /// Contains addresses and offsets for a particular MUGEN version.
    /// </summary>
    public class MugenAddrDatabase
    {
        /// <summary>
        /// WinMUGEN database instance.
        /// </summary>
        private static MugenWinDB _default_db;
        /// <summary>
        /// Mugen 1.0 database instance.
        /// </summary>
        private static Mugen10DB _mugen10_db;
        /// <summary>
        /// Mugen 1.1a4 database instance.
        /// </summary>
        private static Mugen11A4DB _mugen11a4_db;
        /// <summary>
        /// Mugen 1.1b1 database instance.
        /// </summary>
        private static Mugen11B1DB _mugen11b1_db;

        /* Global Offsets -- relative to nothing */
        /// <summary>
        /// determines whether to use the new Debug color offsets
        /// <para>
        /// false=overwrite the values MUGEN stores in memory<br/>
        /// true=patch MUGEN code to overwrite hardcoded color arguments
        /// </para>
        /// </summary>
        public bool USE_NEW_DEBUG_COLOR_ADDR;
        /// <summary>
        /// list of offsets in MUGEN code which comprise debug color offsets
        /// </summary>
        public uint[] NEW_DEBUG_COLOR_OFFSETS;
        /// <summary>
        /// debug colors for the StateNo line are structured differently, so need a separated list.
        /// </summary>
        public uint[] NEW_DEBUG_COLOR_SN_OFFSETS;
        /// <summary>
        /// Game structure base offset.
        /// </summary>
        public uint MUGEN_POINTER_BASE_OFFSET;
        /// <summary>
        /// Location of the Pause flag.
        /// </summary>
        public uint PAUSE_ADDR;
        /// <summary>
        /// Pointer to the current index in the keyboard input buffer.
        /// </summary>
        public uint CMD_CURRENT_INDEX_ADDR;
        /// <summary>
        /// Pointer to the current index in the keyboard input buffer.
        /// </summary>
        public uint CMD_NEXT_INDEX_ADDR;
        ///  <summary> 
        ///  Location of the keyboard input buffer. 
        ///  </summary> 
        public uint CMD_KEY_ADDR;

        /* Game Offsets - relative to MUGEN_POINTER_BASE_OFFSET */
        /// <summary>
        /// Demo mode flag.
        /// </summary>
        public uint DEMO_BASE_OFFSET;
        /// <summary>
        /// Mugen active flag.
        /// </summary>
        public uint MUGEN_ACTIVE_BASE_OFFSET;
        /// <summary>
        /// High-speed/uncapped FPS mode flag.
        /// </summary>
        public uint SPEED_MODE_BASE_OFFSET;
        /// <summary>
        /// Skip mode flag (for frameskip).
        /// </summary>
        public uint SKIP_MODE_BASE_OFFSET;
        /// <summary>
        /// Debug mode flag (for bottom-left debug text).
        /// </summary>
        public uint DEBUG_MODE_BASE_OFFSET;
        /// <summary>
        /// Offset to int identifying the target for displayed debug text.
        /// </summary>
        public uint DEBUG_TARGET_BASE_OFFSET;
        /// <summary>
        /// Debug mode CLSN display flag (0=none, 1=outline, 2=filled)
        /// </summary>
        public uint DEBUG_CLSN_DISPLAY_MODE;
        /// <summary>
        /// Current gametime for match.
        /// </summary>
        public uint GAMETIME_BASE_OFFSET;
        /// <summary>
        /// Width of the screen.
        /// </summary>
        public uint SCREEN_X_BASE_OFFSET;
        /// <summary>
        /// Height of the screen.
        /// </summary>
        public uint SCREEN_Y_BASE_OFFSET;
        /// <summary>
        /// Current value of RoundState.
        /// </summary>
        public uint ROUND_STATE_BASE_OFFSET;
        /// <summary>
        /// Current value of RoundNo.
        /// </summary>
        public uint ROUND_NO_BASE_OFFSET;
        /// <summary>
        /// Total time spent in current round.
        /// </summary>
        public uint ROUND_TIME_BASE_OFFSET;
        /// <summary>
        /// TODO
        /// </summary>
        public uint ROUND_NO_OF_MATCH_TIME_BASE_OFFSET;
        /// <summary>
        /// Turns mode flag.
        /// </summary>
        public uint TURNS_MODE_BASE_OFFSET;
        /// <summary>
        /// Stores an int showing which TeamSide won the current round.
        /// </summary>
        public uint TEAM_WIN_BASE_OFFSET;
        /// <summary>
        /// Flag indicating the round was won by KO (rather than Judgement/timeout).
        /// </summary>
        public uint TEAM_WIN_KO_BASE_OFFSET;
        /// <summary>
        /// Number of rounds team 1 has won.
        /// </summary>
        public uint TEAM_1_WIN_COUNT_BASE_OFFSET;
        /// <summary>
        /// Number of rounds team 2 has won.
        /// </summary>
        public uint TEAM_2_WIN_COUNT_BASE_OFFSET;
        /// <summary>
        /// Number of drawn rounds.
        /// </summary>
        public uint DRAW_GAME_COUNT_BASE_OFFSET;
        /// <summary>
        /// Offset to the player list (technically location of player 1's base address).
        /// </summary>
        public uint PLAYER_1_BASE_OFFSET;
        /// <summary>
        /// Offset to the explod list pointer.
        /// </summary>
        public uint EXPLOD_LIST_BASE_OFFSET;
        /// <summary>
        /// Location of the display timer for WinMUGEN debug text color.
        /// <br/>Only used if <c>USE_NEW_DEBUG_COLOR_ADDR</c> is false.
        /// </summary>
        public uint PAL_TIME_BASE_OFFSET;
        /// <summary>
        /// TODO: has to do with WinMUGEN debug text color.
        /// <br/>Only used if <c>USE_NEW_DEBUG_COLOR_ADDR</c> is false.
        /// </summary>
        public uint PAL_GRAY_BASE_OFFSET;
        /// <summary>
        /// Location of the red value for WinMUGEN debug text color.
        /// <br/>Only used if <c>USE_NEW_DEBUG_COLOR_ADDR</c> is false.
        /// </summary>
        public uint PAL_R_BASE_OFFSET;
        /// <summary>
        /// Location of the green value for WinMUGEN debug text color.
        /// <br/>Only used if <c>USE_NEW_DEBUG_COLOR_ADDR</c> is false.
        /// </summary>
        public uint PAL_G_BASE_OFFSET;
        /// <summary>
        /// Location of the green value for WinMUGEN debug text color.
        /// <br/>Only used if <c>USE_NEW_DEBUG_COLOR_ADDR</c> is false.
        /// </summary>
        public uint PAL_B_BASE_OFFSET;
        /// <summary>
        /// Current amount of global PauseTime.
        /// </summary>
        public uint PAUSE_TIME_BASE_OFFSET;
        /// <summary>
        /// Current amount of global SuperPauseTime.
        /// </summary>
        public uint SUPER_PAUSE_TIME_BASER_OFFSET;
        /// <summary>
        /// Offset to the Global AssertSpecial flags.
        /// </summary>
        public uint ASSERT_1_PLAYER_OFFSET;
        /// <summary>
        /// X-position of the camera relative to its origin (1.0+)
        /// </summary>
        public uint CAMERAPOS_X_BASE_OFFSET;
        /// <summary>
        /// Y-position of the camera relative to its origin (1.0+)
        /// </summary>
        public uint CAMERAPOS_Y_BASE_OFFSET;

        /* Explod Offsets - relative to EXPLOD_LIST_BASE_OFFSET */
        /// <summary>
        /// Length of each entry in the Explod list (offset to each new Explod in the list).
        /// </summary>
        public uint OFFSET_EXPLOD_LIST_OFFSET;
        /// <summary>
        /// Pointer to the animation in use for an Explod (for data lookup).
        /// </summary>
        public uint ANIM_ADDR_EXPLOD_OFFSET;
        /// <summary>
        /// Index of the animation in use, relative to <c>ANIM_ADDR_EXPLOD_OFFSET</c>.
        /// </summary>
        public uint ANIM_INDEX_EXPLOD_OFFSET;
        /// <summary>
        /// Offset to the Explod ID.
        /// </summary>
        public uint EXPLOD_ID_EXPLOD_OFFSET;
        /// <summary>
        /// Offset to the Explod's Owner ID.
        /// </summary>
        public uint EXPLOD_OWNER_ID_EXPLOD_OFFSET;
        /// <summary>
        /// Indicates whether an explod exists or if this list entry is deleted.
        /// </summary>
        public uint EXIST_EXPLOD_OFFSET;

        /* Projectile Metadata Offsets - relative to PROJ_BASE_PLAYER_OFFSET */
        /// <summary>
        /// Offset to the list of Projectiles.
        /// </summary>
        public uint PROJ_LIST_PROJ_BASE_OFFSET;
        /// <summary>
        /// Offset to the max number of Projectiles (global).
        /// </summary>
        public uint PROJ_MAX_PROJ_BASE_OFFSET;

        /* Projectile Offsets - relative to PROJ_LIST_PROJ_BASE_OFFSET */
        /// <summary>
        /// Length of each entry in the Projectile list (offset to each new Projectile in the list).
        /// </summary>
        public uint OFFSET_PROJ_LIST_OFFSET;
        /// <summary>
        /// Flag showing if a Projectile exists (as entries in the list can become 'dead').
        /// </summary>
        public uint EXIST_PROJ_OFFSET;
        /// <summary>
        /// X-pos of the Projectile.
        /// </summary>
        public uint PROJ_X_PROJ_OFFSET;
        /// <summary>
        /// Y-pos of the Projectile.
        /// </summary>
        public uint PROJ_Y_PROJ_OFFSET;
        /// <summary>
        /// Offset to the ProjID.
        /// </summary>
        public uint PROJ_ID_PROJ_OFFSET;
        /// <summary>
        /// Offset to the proj animation index.
        /// </summary>
        public uint PROJ_ANIM_INDEX_PROJ_OFFSET;


        /* Player Offsets - relative to PLAYER_1_BASE_OFFSET */
        /// <summary>
        /// Flag indicating if a player exists (used for e.g. unfilled Helper slots).
        /// </summary>
        public uint EXIST_PLAYER_OFFSET;
        /// <summary>
        /// Offset to unique PlayerID.
        /// </summary>
        public uint PLAYER_ID_PLAYER_OFFSET;
        /// <summary>
        /// Offset to HelperID.
        /// </summary>
        public uint HELPER_ID_PLAYER_OFFSET;
        /// <summary>
        /// Offset to parent's PlayerID value.
        /// </summary>
        public uint PARENT_ID_PLAYER_OFFSET;
        /// <summary>
        /// Offset to this player's Projectile list.
        /// </summary>
        public uint PROJ_BASE_PLAYER_OFFSET;
        /// <summary>
        /// Offset to a PlayerID showing the current state owner (for custom states).
        /// </summary>
        public uint STATE_OWNER_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the StateNo value.
        /// </summary>
        public uint STATE_NO_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the PrevStateNo value.
        /// </summary>
        public uint PREV_STATE_NO_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the PalNo value.
        /// </summary>
        public uint PALNO_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Alive value.
        /// </summary>
        public uint ALIVE_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the current Life value.
        /// </summary>
        public uint LIFE_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the current Power value.
        /// </summary>
        public uint POWER_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Damage value (i.e. GetHitVar(damage)).
        /// </summary>
        public uint DAMAGE_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Ctrl value.
        /// </summary>
        public uint CTRL_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the StateType value (represented by an int).
        /// </summary>
        public uint STATE_TYPE_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the MoveType value (represented by an int).
        /// </summary>
        public uint MOVE_TYPE_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the HitPauseTime value.
        /// </summary>
        public uint HIT_PAUSE_TIME_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the MoveContact value.
        /// </summary>
        public uint MOVE_CONTACT_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the MoveHit value.
        /// </summary>
        public uint MOVE_HIT_PLAYER_OFFSET;
        /// <summary>
        /// Pointer to the animation data block.
        /// </summary>
        public uint ANIM_ADDR_PLAYER_OFFSET;
        /// <summary>
        /// Flag indicating if the player is unhittable (ex due to Throw immunity).
        /// </summary>
        public uint MUTEKI_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the HitBy value1 enum (represented as an int).
        /// </summary>
        public uint HITBY_1_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the HitBy value2 enum (represented as an int).
        /// </summary>
        public uint HITBY_2_PLAYER_OFFSET;
        /// <summary>
        /// Pointer to the list of active HitOverrides.
        /// </summary>
        public uint HITOVERRIDE_LIST_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Target structure.
        /// </summary>
        public uint TARGET_ENTRY_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Fall Damage value (i.e. GetHitVar(fall.damage)).
        /// </summary>
        public uint FALL_DAMAGE_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Facing flag.
        /// </summary>
        public uint FACING_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Pos x value (represented as stage co-ords).
        /// </summary>
        public uint POS_X_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Pos y value (represented as stage co-ords).
        /// </summary>
        public uint POS_Y_PLAYER_OFFSET;
        /// <summary>
        /// X-position of the player within the overall stage bounds. (1.0+)
        /// </summary>
        public uint STAGEPOS_X_PLAYER_OFFSET;
        /// <summary>
        /// Y-position of the player within the overall stage bounds. (1.0+)
        /// </summary>
        public uint STAGEPOS_Y_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Vel x value (before LocalCoord conversion).
        /// </summary>
        public uint VEL_X_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Vel y value (before LocalCoord conversion).
        /// </summary>
        public uint VEL_Y_PLAYER_OFFSET;
        /// <summary>
        /// Offset to sysvar(0) - start of sysvar list.
        /// </summary>
        public uint SYS_VAR_PLAYER_OFFSET;
        /// <summary>
        /// Offset to sysfvar(0) - start of sysfvar list.
        /// </summary>
        public uint SYS_FVAR_PLAYER_OFFSET;
        /// <summary>
        /// Offset to var(0) - start of var list.
        /// </summary>
        public uint VAR_PLAYER_OFFSET;
        /// <summary>
        /// Offset to fvar(0) - start of fvar list.
        /// </summary>
        public uint FVAR_PLAYER_OFFSET;
        /// <summary>
        /// TODO
        /// </summary>
        public uint ACTIVE_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the Player AssertSpecial flags.
        /// </summary>
        public uint SELF_ASSERT_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the PauseMoveTime granted to the Player.
        /// </summary>
        public uint PAUSE_MOVE_TIME_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the SuperPauseMoveTime granted to the Player.
        /// </summary>
        public uint SUPER_PAUSE_MOVE_TIME_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the AttackMulSet multiplier.
        /// </summary>
        public uint ATTACK_MUL_SET_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the AiLevel trigger's value. Note this will be set even if AI is disabled, so you must look at both this and AILEVEL_PLAYER_OFFSET to be sure.
        /// </summary>
        public uint AILEVEL_PLAYER_OFFSET;
        /// <summary>
        /// Offset to the AI enabled flag.
        /// </summary>
        public uint AIENABLED_PLAYER_OFFSET;
        /// <summary>
        /// ID of the last Projectile landed by this player.
        /// </summary>
        public uint PROJ_HIT_ID_PLAYER_OFFSET;
        /// <summary>
        /// Time since the last Projectile was landed.
        /// </summary>
        public uint PROJ_HIT_TIME_PLAYER_OFFSET;

        /* Player Info Offsets - relative to the pointer at the first byte of [PLAYER_1_BASE_OFFSET]. */
        /// <summary>
        /// Offset to the DisplayName string from the player info block.
        /// </summary>
        public uint DISPLAY_NAME_PLAYER_INFO_OFFSET;
        /// <summary>
        /// Offset to the first anim list pointer, relative to the player info block.
        /// </summary>
        public uint ANIM_LIST_REF1_PLAYER_INFO_OFFSET;
        /// <summary>
        /// Offset to the second anim list pointer, relative to <c>ANIM_LIST_REF1_PLAYER_INFO_OFFSET</c>.
        /// </summary>
        public uint ANIM_LIST_REF2_PLAYER_INFO_OFFSET;
        /// <summary>
        /// Offset to the third anim list pointer, relative to <c>ANIM_LIST_REF2_PLAYER_INFO_OFFSET</c>.
        /// </summary>
        public uint ANIM_LIST_REF3_PLAYER_INFO_OFFSET;
        /// <summary>
        /// Offset to the LocalCoord X-value.
        /// <br/>Does not exist in WinMUGEN.
        /// </summary>
        public uint LOCALCOORD_X_PLAYER_INFO_OFFSET;
        /// <summary>
        /// Offset to the LocalCoord Y-value.
        /// <br/>Does not exist in WinMUGEN.
        /// </summary>
        public uint LOCALCOORD_Y_PLAYER_INFO_OFFSET;

        /* Anim-related. */
        /// <summary>
        /// Length of each animation metadata entry.
        /// </summary>
        public uint OFFSET_ANIM_LIST_OFFSET;
        /// <summary>
        /// Location of the action number for an animation, relative to <c>ANIM_LIST_REF3_PLAYER_INFO_OFFSET</c>.
        /// </summary>
        public uint ANIM_NO_ANIM_OFFSET;
        /// <summary>
        /// Location of the animation info for a player, relative to <c>ANIM_ADDR_PLAYER_OFFSET</c>.
        /// <br/>Used in Clsn1/Clsn2 reading.
        /// </summary>
        public uint ANIM_INFO_ANIM_OFFSET;
        /// <summary>
        /// Offset to Clsn1 data, relative to <c>ANIM_INFO_ANIM_OFFSET</c>.
        /// </summary>
        public uint CLSN1_ADDR_ANIM_INFO_OFFSET;
        /// <summary>
        /// Offset to Clsn2 data, relative to <c>ANIM_INFO_ANIM_OFFSET</c>.
        /// </summary>
        public uint CLSN2_ADDR_ANIM_INFO_OFFSET;

        /* Misc. */
        /// <summary>
        /// Length of HitOverride entries.
        /// </summary>
        public uint OFFSET_HITOVERRIDE_LIST_OFFSET;
        /// <summary>
        /// HitOverride attribute enum as an int.
        /// </summary>
        public uint ATTR_HITOVERRIDE_OFFSET;
        /// <summary>
        /// HitOverride existence flag.
        /// </summary>
        public uint EXIST_HITOVERRIDE_OFFSET;
        /// <summary>
        /// Location of NumTarget value, relative to <c>TARGET_ENTRY_PLAYER_OFFSET</c>.
        /// </summary>
        public uint NUMTARGET_TARGET_ENTRY_OFFSET;
        /// <summary>
        /// Location of the first target entry, relative to <c>TARGET_ENTRY_PLAYER_OFFSET</c>.
        /// </summary>
        public uint TARGET_LIST_TARGET_ENTRY_OFFSET;
        /// <summary>
        /// Length of each target entry.
        /// </summary>
        public uint OFFSET_TARGET_LIST_OFFSET;

        /// <summary>
        /// Base offset to constant values.
        /// </summary>
        public uint CONST_PLAYER_OFFSET;
        /**
         * Constant value offsets within base constant structure.
         */
        public int CONST_DATA_LIFE;
        public int CONST_DATA_POWER;
        public int CONST_DATA_ATTACK;
        public int CONST_SIZE_ATTACK_Z_WIDTH_FRONT;
        public int CONST_SIZE_ATTACK_Z_WIDTH_BACK;
        public int CONST_DATA_AIRJUGGLE;
        public int CONST_SIZE_ATTACK_DIST;
        public int CONST_SIZE_PROJ_ATTACK_DIST;
        public int CONST_DATA_DEFENCE;
        public int CONST_DATA_FALL_DEFENCE_MUL;
        public int CONST_DATA_LIEDOWN_TIME;
        public int CONST_SIZE_XSCALE;
        public int CONST_SIZE_YSCALE;
        public int CONST_SIZE_GROUND_BACK;
        public int CONST_SIZE_GROUND_FRONT;
        public int CONST_SIZE_AIR_BACK;
        public int CONST_SIZE_AIR_FRONT;
        public int CONST_SIZE_Z_WIDTH;
        public int CONST_SIZE_HEIGHT;
        public int CONST_SIZE_PROJ_DOSCALE;
        public int CONST_SIZE_HEAD_POS_X;
        public int CONST_SIZE_HEAD_POS_Y;
        public int CONST_SIZE_MID_POS_X;
        public int CONST_SIZE_MID_POS_Y;
        public int CONST_SIZE_SHADOWOFFSET;
        public int CONST_VELOCITY_WALK_FWD_X;
        public int CONST_VELOCITY_WALK_BACK_X;
        public int CONST_VELOCITY_WALK_UP_X;
        public int CONST_VELOCITY_WALK_DOWN_X;
        public int CONST_VELOCITY_RUN_FWD_X;
        public int CONST_VELOCITY_RUN_FWD_Y;
        public int CONST_VELOCITY_RUN_BACK_X;
        public int CONST_VELOCITY_RUN_BACK_Y;
        public int CONST_VELOCITY_RUN_DOWN_X;
        public int CONST_VELOCITY_RUN_DOWN_Y;
        public int CONST_VELOCITY_RUN_UP_X;
        public int CONST_VELOCITY_RUN_UP_Y;
        public int CONST_VELOCITY_JUMP_Y;
        public int CONST_VELOCITY_JUMP_NEU_X;
        public int CONST_VELOCITY_JUMP_FWD_X;
        public int CONST_VELOCITY_JUMP_BACK_X;
        public int CONST_VELOCITY_JUMP_UP_X;
        public int CONST_VELOCITY_JUMP_DOWN_X;
        public int CONST_VELOCITY_RUNJUMP_FWD_Y;
        public int CONST_VELOCITY_RUNJUMP_FWD_X;
        public int CONST_VELOCITY_RUNJUMP_BACK_X;
        public int CONST_VELOCITY_RUNJUMP_UP_X;
        public int CONST_VELOCITY_RUNJUMP_DOWN_X;
        public int CONST_MOVEMENT_AIRJUMP_NUM;
        public int CONST_MOVEMENT_AIRJUMP_HEIGHT;
        public int CONST_VELOCITY_AIRJUMP_Y;
        public int CONST_VELOCITY_AIRJUMP_NEU_X;
        public int CONST_VELOCITY_AIRJUMP_FWD_X;
        public int CONST_VELOCITY_AIRJUMP_BACK_X;
        public int CONST_VELOCITY_AIRJUMP_UP_X;
        public int CONST_VELOCITY_AIRJUMP_DOWN_X;
        public int CONST_MOVEMENT_YACCEL;
        public int CONST_MOVEMENT_STAND_FRICTION;
        public int CONST_MOVEMENT_CROUCH_FRICTION;
        public int CONST_DATA_SPARKNO;
        public int CONST_DATA_GUARD_SPARKNO;
        public int CONST_DATA_KO_ECHO;
        public int CONST_SIZE_DRAW_OFFSET_X;
        public int CONST_SIZE_DRAW_OFFSET_Y;
        public int CONST_DATA_INTPERSISTINDEX;
        public int CONST_DATA_FLOATPERSISTINDEX;
        public int CONST_VELOCITY_AIR_GETHIT_GROUNDRECOVER_X;
        public int CONST_VELOCITY_AIR_GETHIT_GROUNDRECOVER_Y;
        public int CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_MUL_X;
        public int CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_MUL_Y;
        public int CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_ADD_X;
        public int CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_ADD_Y;
        public int CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_BACK;
        public int CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_FWD;
        public int CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_UP;
        public int CONST_VELOCITY_AIR_GETHIT_AIRRECOVER_DOWN;
        public int CONST_MOVEMENT_STAND_FRICTION_THRESHOLD;
        public int CONST_MOVEMENT_CROUCH_FRICTION_THRESHOLD;
        public int CONST_MOVEMENT_AIR_GETHIT_GROUNDLEVEL;
        public int CONST_MOVEMENT_AIR_GETHIT_GROUNDRECOVER_GROUND_THRESHOLD;
        public int CONST_MOVEMENT_AIR_GETHIT_GROUNDRECOVER_GROUNDLEVEL;
        public int CONST_MOVEMENT_AIR_GETHIT_AIRRECOVER_THRESHOLD;
        public int CONST_MOVEMENT_AIR_GETHIT_AIRRECOVER_YACCEL;
        public int CONST_MOVEMENT_AIR_GETHIT_TRIP_GROUNDLEVEL;
        public int CONST_MOVEMENT_DOWN_BOUNCE_OFFSET_X;
        public int CONST_MOVEMENT_DOWN_BOUNCE_OFFSET_Y;
        public int CONST_MOVEMENT_DOWN_BOUNCE_YACCEL;
        public int CONST_MOVEMENT_DOWN_BOUNCE_GROUNDLEVEL;
        public int CONST_MOVEMENT_DOWN_FRICTION_THRESHOLD;

        public uint PLAYER_FLAGS_EXIST;
        public uint PLAYER_FLAGS_FROZEN;




        /// <summary>
        /// Gets the address database instance for an input MugenType_t.
        /// </summary>
        /// <param name="mugen_type">a <c>MugenType_t</c> representing the current Mugen version.</param>
        /// <returns>an instance of <c>MugenAddrDatabase</c></returns>
        public static MugenAddrDatabase GetAddrDatabase(
          MugenType_t mugen_type)
        {
            switch (mugen_type)
            {
                case MugenType_t.MUGEN_TYPE_MUGEN10:
                    if (_mugen10_db == null)
                        _mugen10_db = new Mugen10DB();
                    return _mugen10_db;
                case MugenType_t.MUGEN_TYPE_MUGEN11A4:
                    if (_mugen11a4_db == null)
                        _mugen11a4_db = new Mugen11A4DB();
                    return _mugen11a4_db;
                case MugenType_t.MUGEN_TYPE_MUGEN11B1:
                    if (_mugen11b1_db == null)
                        _mugen11b1_db = new Mugen11B1DB();
                    return _mugen11b1_db;
                default:
                    if (_default_db == null)
                        _default_db = new MugenWinDB();
                    return _default_db;
            }
        }
    }
}

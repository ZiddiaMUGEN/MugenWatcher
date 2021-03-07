// Decompiled with JetBrains decompiler
// Type: SwissArmyKnifeForMugen.Mugen11B1DB
// Assembly: SAKnifeWM, Version=1.0.8.0, Culture=neutral, PublicKeyToken=null
// MVID: 09478AD8-365C-4BF3-BEA1-B5785151259B
// Assembly location: C:\Users\ziddi\Downloads\Swiss Army Knife 1.1 Conversion\Swiss Army Knife 1.1 Conversion\SAKnifeWM.exe

namespace MugenWatcher.Databases
{
    /// <summary>
    /// Contains addresses and offsets for MUGEN 1.1b1.
    /// <br/>Most are shared with <c>Mugen11A4DB</c>.
    /// </summary>
    public class Mugen11B1DB : Mugen11A4DB
    {
        public Mugen11B1DB()
        {
            USE_NEW_DEBUG_COLOR_ADDR = true;
            NEW_DEBUG_COLOR_OFFSETS = new uint[] { 0x419678, 0x4196E2, 0x419910, 0x419815 };
            NEW_DEBUG_COLOR_SN_OFFSETS = new uint[] { 0x4199F8, 0x419A04, 0x419A09 };

            SPEED_MODE_BASE_OFFSET = 78064U;
            OFFSET_EXPLOD_LIST_OFFSET = 624U;
            ANIM_ADDR_EXPLOD_OFFSET = 484U;
        }
    }
}

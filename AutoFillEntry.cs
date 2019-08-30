using System;
using System.Collections.Generic;

namespace DAP_Filler
{
    [Serializable()]

    public class AutoFillEntry
    {
        public string entry;
        public int uses;

        public AutoFillEntry(string entry, int count)
        {
            this.entry = entry;
            this.uses = count;
        }

        public AutoFillEntry()
        {
            this.entry = "";
            this.uses = 1;
        }

        public AutoFillEntry(string entry)
        {
            this.entry = entry;
            this.uses = 1;
        }

        public int Uses { get { return uses; } set { uses = value; } }
        public string Entry { get { return entry; }  set { entry = value; } }
    }


}
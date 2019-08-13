using System;
namespace DAP_Filler
{
    [Serializable]

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
            this.uses = 0;
        }

        public AutoFillEntry(string entry)
        {
            this.entry = entry;
            this.uses = 0;
        }
    }


}
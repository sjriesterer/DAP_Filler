using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAP_Filler
    {
    [Serializable()]

    class Patient
        {
        public DateTime date;
        public String name;
        public Boolean isMale;
        public String entryBoxText_D;
        public String entryBoxText_A;
        public String entryBoxText_P;

        public Patient()
            {
            name = "";
            entryBoxText_D = "";
            }
        public Patient(String name, Boolean isMale, String entryBoxText_D, String entryBoxText_A, String entryBoxText_P)
            {
            this.name = name;
            this.isMale = isMale;
            this.entryBoxText_D = entryBoxText_D;
            this.entryBoxText_A = entryBoxText_A;
            this.entryBoxText_P = entryBoxText_P;
            Date = DateTime.Now;
            }

        public DateTime Date { get { return date; } set { date = value; } }
        public String Name { get { return name; } set { name = value; } }
        public String EntryBoxyText_D { get { return entryBoxText_D; } set { entryBoxText_D = value; } }
        public String EntryBoxyText_A { get { return entryBoxText_A; } set { entryBoxText_A = value; } }
        public String EntryBoxyText_P { get { return entryBoxText_P; } set { entryBoxText_P = value; } }

        }
    }

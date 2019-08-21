using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAP_Filler
    {
    public static class C
        {
//        public static List<int> checkboxClicks_D = new List<int>();
        public static Boolean learnMode = true;

        public static String newCellText = "<Edit Entry>";


        public static String patientNamePlaceholder = "<Name>";
        public static String oldPatientName = patientNamePlaceholder;
        public static String patientName = patientNamePlaceholder;

        public static String genericNamePlaceholder = "<Name>";
        public static String oldGenericName = genericNamePlaceholder;
        public static String genericName = genericNamePlaceholder;

        public static String genericPatientNamePlaceholder = "<Patient>";
        public static String oldGenericPatientName = genericPatientNamePlaceholder;
        public static String genericPatientName = genericPatientNamePlaceholder;

        public static String genericPeerNamePlaceholder = "<Peer>";
        public static String oldGenericPeerName = genericPeerNamePlaceholder;
        public static String genericPeerName = genericPeerNamePlaceholder;

        public static Boolean oldIsMale = true;
        public static Boolean isMale = true;

        public static String enterNameFirstText = "You must enter the patient's name before learning autofill entries";

        }
    }

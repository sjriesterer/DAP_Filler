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


        public static String realNamePlaceholder = "<Name>";
        public static String oldRealName = realNamePlaceholder;
        public static String realName = realNamePlaceholder;

        public static String genericRealNamePlaceholder = "<Name>";
        public static String oldGenericName = genericRealNamePlaceholder;
        public static String genericName = genericRealNamePlaceholder;

        public static String genericPatientNamePlaceholder = "<Patient>";
        public static String oldGenericPatientName = genericPatientNamePlaceholder;
        public static String genericPatientName = genericPatientNamePlaceholder;

        public static String genericPeerNamePlaceholder = "<Peer>";
        public static String oldGenericPeerName = genericPeerNamePlaceholder;
        public static String genericPeerName = genericPeerNamePlaceholder;

        public static Boolean oldIsMale = true;
        public static Boolean isMale = true;

        public static String enterNameFirstText = "You must enter the patient's name before learning autofill entries";

        public static String CapitalizeWithArrows(String input)
            {
            return "<" + Char.ToUpper(input[1]) + input.Substring(2);
            }
        public static String LowerCaseWithArrows(String input)
            {
            return "<" + Char.ToLower(input[1]) + input.Substring(2);
            }
        public static String Capitalize(String input)
            {
            return Char.ToUpper(input[0]) + input.Substring(1);
            }


        }
    }

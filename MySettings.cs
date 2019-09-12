using nucs.JsonSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAP_Filler
    {
    class MySettings : JsonSettings
        {
        //Step 2: override a default FileName or keep it empty. Just make sure to specify it when calling Load!
        //This is used for default saving and loading so you won't have to specify the filename/path every time.
        //Putting just a filename without folder will put it inside the executing file's directory.
        public override string FileName { get; set; } = C.settingsFilename; //for loading and saving.

        #region Settings

        [Required] public Boolean learnMode { get; set; } = true;
        [Required] public Boolean autoArrows { get; set; } = true;

        [Required] [MaxLength(30)] public String oldRealName { get; set; } = C.realNamePlaceholder;
        [Required] [MaxLength(30)] public String realName { get; set; } = C.realNamePlaceholder;
        [Required] [MaxLength(20)] public String oldGenericName { get; set; } = C.genericRealNamePlaceholder;
        [Required] [MaxLength(20)] public String genericName { get; set; } = C.genericRealNamePlaceholder;
        [Required] [MaxLength(20)] public String oldGenericPatientName { get; set; } = C.genericPatientNamePlaceholder;
        [Required] [MaxLength(20)] public String genericPatientName { get; set; } = C.genericPatientNamePlaceholder;
        [Required] [MaxLength(20)] public String oldGenericPeerName { get; set; } = C.genericPeerNamePlaceholder;
        [Required] [MaxLength(20)] public String genericPeerName { get; set; } = C.genericPeerNamePlaceholder;

        [Required] public Boolean oldIsMale { get; set; } = true;
        [Required] public Boolean isMale { get; set; } = true;

        [Required] [MaxLength(1000)] public String entryBoxText_D { get; set; } = "";
        [Required] [MaxLength(1000)] public String entryBoxText_A { get; set; } = "";
        [Required] [MaxLength(1000)] public String entryBoxText_P { get; set; } = "";

        [Required] [Range(0, 4)] public int autoSort_D { get; set; } = 0;
        [Required] [Range(0, 4)] public int autoSort_A { get; set; } = 0;
        [Required] [Range(0, 4)] public int autoSort_P { get; set; } = 0;

        [Required] public string gridEntries_D { get; set; } = "";
        [Required] public string gridEntries_A { get; set; } = "";
        [Required] public string gridEntries_P { get; set; } = "";

        #endregion
        //Step 3: Override parent's constructors
        public MySettings() { }
        public MySettings(string fileName) : base(fileName) { }
        }
    }

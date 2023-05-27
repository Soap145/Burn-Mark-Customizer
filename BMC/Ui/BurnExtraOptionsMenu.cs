using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;


namespace BurnMarkCustomizer
{
    class BurnExtraOptionsMenu : BSMLResourceViewController
    {
        public override string ResourceName => "BurnMarkCustomizer.BMC.Views.ExtraOptionsMenu.bsml";

        [UIValue("burn-mark-customizer-enabled")]
        public bool Burn_Mark_Customizer_Enabled
        {

            get => Config.Instance.burn_mark_customizer_enabled;
            set
            {
                Config.Instance.burn_mark_customizer_enabled = value;
            }
        }

        [UIValue("burnmarksenabled")]
        public bool burnmarksenabled
        {

            get => Config.Instance.burn_marks_enabled;
            set
            {
                Config.Instance.burn_marks_enabled = value;
            }
        }

        [UIValue("permanentburnmarks")]
        public bool permanentburnmarks
        {

            get => Config.Instance.permanate_burn_marks;
            set
            {
                Config.Instance.permanate_burn_marks = value;
            }
        }

    }
}

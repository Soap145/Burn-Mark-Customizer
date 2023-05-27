
using BeatSaberMarkupLanguage.ViewControllers;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components.Settings;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using HMUI;
using BurnMarkCustomizer.BMC.Helpers;
using System.Linq;

namespace BurnMarkCustomizer
{
    class BurnMainMenu : BSMLResourceViewController, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null!;
        public override string ResourceName => "BurnMarkCustomizer.BMC.Views.MainMenu.bsml";
        internal Color _LeftColor = ColorHelper.HexToColor(Config.Instance.ColorLeftSaber);
        internal Color _RightColor = ColorHelper.HexToColor(Config.Instance.ColorRightSaber);

        public bool CustomColoredEnabled()
        {  
       
     
                    if (Config.Instance.color_mark == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


       
        }

        [UIValue("burncolor_filter")]
        public int burncolor_filter
        {
            get => Config.Instance.color_mark;
            set
            {
                Config.Instance.color_mark = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(burncolor_filter)));

            }
        }

        [UIValue("allow_custom_colors")]

        public bool Allow_Custom_olors
        {

            get => CustomColoredEnabled();

        }



        [UIValue("burn-opacity")]
        public float Burn_Opacity
        {
            get => Config.Instance.burn_opacity;
            set
            {
                Config.Instance.burn_opacity = value;

            }
        }

        [UIValue("burn-scale")]
        public float Burn_Scale
        {
            get => Config.Instance.burn_size;
            set
            {
                Config.Instance.burn_size = value;

            }
        }

        [UIValue("burn-lifetime")]
        public float Burn_Lifetime
        {
            get => Config.Instance.burn_lifetime;
            set
            {
                Config.Instance.burn_lifetime = value;

            }
        }



        [UIValue("left-color")]

        internal Color Left_Color
        {

            get => _LeftColor;
            set
            {
                Config.Instance.ColorLeftSaber = ColorHelper.ColorToHex(value);

            }

        }

        [UIValue("right-color")]

        internal Color Right_Color
        {

            get => _RightColor;
            set
            {
                Config.Instance.ColorRightSaber = ColorHelper.ColorToHex(value);
                NotifyPropertyChanged();
            }

        }


        [UIAction("burncolor_formatter")]
        public string burncolor_formatter(int value) => ((PreferenceEnum)value).ToString();


        internal enum PreferenceEnum
        {
            Default = 0,
            Custom = 1,
            Rainbow = 2 
        }

  
    }
}

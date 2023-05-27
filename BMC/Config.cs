using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;
using System.Collections.Generic;
using UnityEngine;

namespace BurnMarkCustomizer
{
    public class Config
    {
        public static Config? Instance { get; set; }

        public virtual bool burn_mark_customizer_enabled { get; set; } = true;

        public virtual bool burn_marks_enabled { get; set; } = true;

        public virtual bool permanate_burn_marks { get; set; } = false;
        //  public virtual float volume { get; set; } = 0.75f;
        public virtual int color_mark { get; set; } = 0;

        public virtual float burn_opacity { get; set; } = 1f;
        public virtual float burn_lifetime { get; set; } = 1f;
        public virtual float burn_size { get; set; } = 1f;


        public virtual string ColorLeftSaber { get; set; } = "#FF0000";
        public virtual string ColorRightSaber { get; set; } = "#0000FF";

    }
}
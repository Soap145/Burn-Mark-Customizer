using BeatSaberMarkupLanguage;
using BS_Utils.Utilities;
using BurnMarkCustomizer.BMC.Helpers;
using HarmonyLib;
using IPA.Utilities;
using System;
using System.Reflection;
using UnityEngine;

namespace BurnMarkCustomizer.HarmonyPatches
{
    [HarmonyAfter("com.noodle.BeatSaber.Chroma")]
    [HarmonyPatch(typeof(SaberBurnMarkArea), "Start")]
    internal class SaberBurnMarkArea_Start
    {
        internal static void Prefix(SaberBurnMarkArea __instance)
        {
            
            float clampedOpacity = Math.Max(0.4f, Config.Instance.burn_opacity);
            if (Config.Instance.burn_mark_customizer_enabled == true)
            {
                if (Config.Instance.burn_marks_enabled == false)
                {
                    __instance.enabled = false;
                }

           
            }
       
        }

        internal static void Postfix(SaberBurnMarkArea __instance, ref LineRenderer[] ____lineRenderers)
        {
            if (Config.Instance.burn_mark_customizer_enabled == true)
            {
                var config = Config.Instance;
                float clampedOpacity = Math.Max(0.4f, config.burn_opacity);

                if (Config.Instance.permanate_burn_marks == true)
                {
                    __instance.SetField("_burnMarksFadeOutStrength", (5.0f / clampedOpacity) * 10000000000000000);
                }
                else
                {
                    __instance.SetField("_burnMarksFadeOutStrength", (5.0f / clampedOpacity) * config.burn_lifetime);
                }

                LineRenderer[] burnRenderers = ____lineRenderers;

                for (int i = 0; i < burnRenderers.Length; i++)
                {
                    LineRenderer renderer = ____lineRenderers[i];
                        Color burnColor = renderer.startColor;

                     if (Config.Instance.color_mark == 1)
                                {
                                     if (i == 0) burnColor = ColorHelper.HexToColor(Config.Instance.ColorLeftSaber);
                                    else burnColor = ColorHelper.HexToColor(Config.Instance.ColorRightSaber);
                                }

                     renderer.transform.localScale = Vector3.one * Config.Instance.burn_size;
                    
                      burnColor.a = clampedOpacity;
                      renderer.startColor = burnColor;
                     renderer.endColor = burnColor;

                }

                //  LineRenderer[] burnRenderers = __instance.GetField< "LineRenderer" >;
                //  ref LineRenderer[] burnRenderers ____lineRenderers;

                //  static void prefix(LineRenderer ____lineRenderers)
                // {
                ///     var config = Config.Instance;
                //   var burnRenderers = ____lineRenderers;
                //    for (int i = 0; i < burnRenderers.Length; i++)
                //    {
                //         Color burnColor = renderer.startColor;
                //
                //         if (Config.Instance.color_mark == 1)
                //         {
                //               if (i == 0) burnColor = ColorHelper.HexToColor(config.ColorLeftSaber);
                //              else burnColor = ColorHelper.HexToColor(config.ColorRightSaber);
                //           }
                //
                //           renderer.transform.localScale = Vector3.one * config.burn_size;

                //           burnColor.a = clampedOpacity;
                //         renderer.startColor = burnColor;
                //         renderer.endColor = burnColor;
                //}
                // }
            }
        }
    }

}
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using Conf = IPA.Config.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SiraUtil.Zenject;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using BurnMarkCustomizer.BMC;
using UnityEngine.SceneManagement;
using BurnMarkCustomizer.BMC.Installers;
using IPALogger = IPA.Logging.Logger;

namespace BurnMarkCustomizer
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger, Conf conf, Zenjector zenjector)
        {
            Instance = this;
            Log = logger;
            Log.Info("BurnMarkCustomizer initialized.");
            Config.Instance = conf.Generated<Config>();
            zenjector.Install<GameInstaller>(Location.StandardPlayer);

        }

        #region BSIPA Config
        //Uncomment to use BSIPA's config
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        */
        #endregion

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("Mod Startup");
            new GameObject("BurnMarkCustomizerController").AddComponent<BurnMarkCustomizerController>();
            MenuButtonLoader.RegMenuButton();
            var harmony = new Harmony("SoapNoap.BurnMarkCustomizer");
            harmony.PatchAll(Assembly);
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("Mod Quit");

        }
    }
}

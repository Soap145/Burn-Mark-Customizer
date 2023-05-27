using System;
using System.Reflection;
using BeatSaberMarkupLanguage.Components.Settings;
using BeatSaberMarkupLanguage.Tags;
using HMUI;
using IPA.Utilities;
using SiraUtil.Logging;
using SiraUtil.Services;
using SiraUtil.Submissions;
using SiraUtil.Tools;
using UnityEngine;
using Zenject;

namespace BurnMarkCustomizer.BMC
{
    internal class GameplayManager
    {
     //   private readonly PluginConfig _config;
        private readonly SiraLog _logger;
        private readonly Submission _submission;
        private readonly PauseMenuManager _pauseMenuManager;

        public GameplayManager(SiraLog logger, Submission submission, [InjectOptional] PauseMenuManager pauseMenuManager)
        {
            _logger = logger;
            _submission = submission;
            _pauseMenuManager = pauseMenuManager;
        }

        public void Initialize()
        {

            try
            {
                CreateCheckbox();
            }
            catch
            {
                _logger.Warn($"No checkbox for you sir");
            }
        }

        public void CreateCheckbox()
        {
            if (_pauseMenuManager == null) return;

            var canvas = _pauseMenuManager.GetField<LevelBar, PauseMenuManager>("_levelBar")
                .transform
                .parent
                .parent
                .GetComponent<Canvas>();
            if (!canvas) return;

            var toggleObject = new ToggleSettingTag().CreateObject(canvas.transform);

            (toggleObject.transform as RectTransform).anchoredPosition = new Vector2(26, -15);
            (toggleObject.transform as RectTransform).sizeDelta = new Vector2(-130, 7);

            toggleObject.transform.Find("NameText").GetComponent<CurvedTextMeshPro>().text = "Burn Mark Customizer Enabled";

            var toggleSetting = toggleObject.GetComponent<ToggleSetting>();
            toggleSetting.Value = Config.Instance.burn_mark_customizer_enabled;
            toggleSetting.toggle.onValueChanged.AddListener(enabled => { Config.Instance.burn_mark_customizer_enabled = enabled; });
        }
    }
}
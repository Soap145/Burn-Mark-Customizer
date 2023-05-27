using System;
using SiraUtil.Logging;
using SiraUtil.Tools;
using UnityEngine;
using Zenject;

namespace BurnMarkCustomizer.BMC.Installers
{
    internal class GameInstaller : Installer
    {
        private readonly SiraLog _logger;

        private GameInstaller(SiraLog logger)
        {
            _logger = logger;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameplayManager>().AsSingle();

        }


    }
}
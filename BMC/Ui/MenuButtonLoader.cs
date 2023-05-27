using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;

namespace BurnMarkCustomizer
{

    public class MenuButtonLoader
    {
        public static MenuButton dtButton = new MenuButton("Burn Mark Customizer", "Change your saber burn mark settings.", OpenBGMenu);
        public static BurnFlowCoordinator flowCoordinator;

        private static void OpenBGMenu()
       {
            if (flowCoordinator == null)
            {
               flowCoordinator = BeatSaberUI.CreateFlowCoordinator<BurnFlowCoordinator>();
          }
            BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(flowCoordinator, null, HMUI.ViewController.AnimationDirection.Vertical, false);
        }
        public static void RegMenuButton()
        {
            MenuButtons.instance.RegisterButton(dtButton);

        }
        public static void RemoveMenuButton()
        {
            MenuButtons.instance.UnregisterButton(dtButton);
        }
    }
}

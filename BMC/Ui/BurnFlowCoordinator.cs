using BeatSaberMarkupLanguage;
using HMUI;

namespace BurnMarkCustomizer
{

    public class BurnFlowCoordinator : FlowCoordinator
    {
        private BurnMainMenu mainView;
        private BurnExtraOptionsMenu sideView;

        public void ReloadUIValues()
        {
           // if (sideView) sideView.ReloadValues();
        }

        private void Awake()
        {
            if (!mainView)
            {
                mainView = BeatSaberUI.CreateViewController<BurnMainMenu>();
            }
            if (!sideView)
            {
                sideView = BeatSaberUI.CreateViewController<BurnExtraOptionsMenu>();
            }
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Burn Mark Customizer");
                showBackButton = true;
                ProvideInitialViewControllers(mainView, sideView);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Vertical);
        }
    }
}

using Foundation;
using UIKit;
using Xamarin.Themes;
using Xamarin.Forms;
using JSQMessagesViewController;
using Cards;

namespace SwitchingTabbedPageDemo.iOS {
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate {
		public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
			global::Xamarin.Forms.Forms.Init();

			FoodyTheme.Apply();
			UIWindow window;
			UIViewController root;
			root = new UIViewController();

			Page2 vc1;
			CardView cardviews;
			// You must set your senderId and display name
			LoadApplication(new App());
			UIApplication.SharedApplication.SetStatusBarStyle (UIStatusBarStyle.LightContent, false);
			UIApplication.SharedApplication.SetStatusBarHidden (false, UIStatusBarAnimation.Slide);
			return base.FinishedLaunching(app, options);
		}
	}

	public class Application {
		// This is the main entry point of the application.
		static void Main(string[] args) {
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}

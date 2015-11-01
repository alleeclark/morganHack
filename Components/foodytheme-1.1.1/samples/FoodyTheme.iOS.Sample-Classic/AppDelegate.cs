using Xamarin.Themes;

#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
#endif

namespace ThemeSample {
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		public override UIWindow Window { get; set; }

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			FoodyTheme.Apply ();

			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

			var idiom = UIDevice.CurrentDevice.UserInterfaceIdiom;
			if (idiom == UIUserInterfaceIdiom.Phone)
				PhoneInit ();
			else
				PadInit ();

			return true;
		}

		void PadInit ()
		{
			var split = Window.RootViewController as UISplitViewController;

			var ind = split.ViewControllers.Length - 1;
			split.WeakDelegate = split.ViewControllers [ind];

			var md = split.ViewControllers [ind] as DetailThemeControllerIPad;

			var nav = split.ViewControllers [0] as UINavigationController;
			var master = nav.ViewControllers [0] as MasterViewController;

			master.Delegate = md;
		}

		void PhoneInit ()
		{
			var tabarController = Window.RootViewController as UITabBarController;

			var nav1 = tabarController.ViewControllers [0] as UINavigationController;
			var icon1 = UIImage.FromFile ("icon1.png");
			var item1 = new UITabBarItem ("Recipes", icon1, 0);
			item1.SetFinishedImages (icon1, icon1);
			nav1.TabBarItem = item1;

			var nav2 = tabarController.ViewControllers [1] as UINavigationController;
			var icon2 = UIImage.FromFile ("icon2.png");
			var item2 = new UITabBarItem ("Steps", icon2, 1);
			item2.SetFinishedImages (icon2, icon2);
			nav2.TabBarItem = item2;

			var nav3 = tabarController.ViewControllers [2] as UIViewController;
			var icon3 = UIImage.FromFile ("icon3.png");
			var item3 = new UITabBarItem ("Elements", icon3, 2);
			item3.SetFinishedImages (icon3, icon3);
			nav3.TabBarItem = item3;

			var nav4 = tabarController.ViewControllers [3] as UIViewController;
			var item4 = new UITabBarItem ("License", icon3, 3);
			item4.SetFinishedImages (icon3, icon3);
			nav4.TabBarItem = item4;
		}
	}
}


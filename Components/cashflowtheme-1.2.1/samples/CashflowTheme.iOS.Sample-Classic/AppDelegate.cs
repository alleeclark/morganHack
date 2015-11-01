using System;
using System.Collections.Generic;
#if __UNIFIED__
using Foundation;
using UIKit;
using ObjCRuntime;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
#endif
using Xamarin.Themes;

namespace ThemeSample.UI {
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		// class-level declarations
		public override UIWindow Window { get; set; }
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Xamarin.Themes.CashflowTheme.Apply (Xamarin.Themes.ColorScheme.Black);

			UIUserInterfaceIdiom idiom = UIDevice.CurrentDevice.UserInterfaceIdiom;
			
			if (idiom == UIUserInterfaceIdiom.Pad) {
				CustomizeiPadTheme ();
			}
			IPhoneInit ();

		
			return true;
		}

		void IPhoneInit ()
		{
			UITabBarController tabBarController = (UITabBarController)Window.RootViewController;
			
			UIViewController controller1 = tabBarController.ViewControllers [0];
			
			UIImage icon1 = UIImage.FromFile ("Images/iPhone/tabbar-icon1.png");

			UITabBarItem updatesItem = new UITabBarItem ("List", icon1, 0);
			updatesItem.SetFinishedImages (icon1, icon1);
			controller1.TabBarItem = updatesItem;

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
			{
				UIImage icon2 = UIImage.FromFile ("Images/iPhone/tabbar-icon2.png");
				UITabBarItem item2 = new UITabBarItem ("Elements", icon2, 1);
				item2.SetFinishedImages (icon2, icon2);


				UIViewController controller2 = tabBarController.ViewControllers [1];
				controller2.TabBarItem = item2;

				UIViewController controller3 = tabBarController.ViewControllers [3];
				UIImage icon3 = UIImage.FromFile ("Images/iPhone/tabbar-icon3.png");
				UITabBarItem item3 = new UITabBarItem ("More Elements", icon3, 3);
				item3.SetFinishedImages (icon3, icon3);
				controller3.TabBarItem = item3;

				UIViewController controller4 = tabBarController.ViewControllers [4];
				UIImage icon4 = UIImage.FromFile ("Images/iPhone/tabbar-icon4.png");
				UITabBarItem item4 = new UITabBarItem ("Agreement", icon4, 4);
				item4.SetFinishedImages (icon4, icon4);
				controller4.TabBarItem = item4;
			}

		}

		void CustomizeiPadTheme ()
		{
			UITabBarController tabBarController = (UITabBarController)Window.RootViewController;
			UISplitViewController splitViewController = (UISplitViewController)(tabBarController.ViewControllers [0]);
			
			var ind = splitViewController.ViewControllers.Length - 1;
			UINavigationController navDetail = (UINavigationController)splitViewController.ViewControllers[ind];
			splitViewController.WeakDelegate = navDetail.ViewControllers [0];
		}
	}
}


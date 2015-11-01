// This file has been autogenerated from parsing an Objective-C header file added in Xcode.using System;
using System;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
namespace ThemeSample.UI {
	public partial class IntelligentSplitViewController : UISplitViewController {
		public IntelligentSplitViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Xamarin.Themes.CashflowTheme.Apply (View, Xamarin.Themes.ColorScheme.Black);
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			NSNotificationCenter.DefaultCenter.AddObserver (UIApplication.WillChangeStatusBarOrientationNotification, WillRotate);
			NSNotificationCenter.DefaultCenter.AddObserver (UIApplication.DidChangeStatusBarOrientationNotification, DidRotate);
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

		void WillRotate (NSNotification notification)
		{
			if (!IsViewLoaded) // we haven't even loaded up yet, let's turn away from this place
				return;
			
			if (notification == null)
				return;
			
			#if __UNIFIED__
			UIInterfaceOrientation toOrientation = 
					(UIInterfaceOrientation)
					(((NSNumber)notification.UserInfo.ValueForKey (UIApplication.StatusBarOrientationUserInfoKey)).Int64Value);
			#else
			UIInterfaceOrientation toOrientation = 
					(UIInterfaceOrientation)
					(((NSNumber)notification.UserInfo.ValueForKey (UIApplication.StatusBarOrientationUserInfoKey)).IntValue);
			#endif
			
			UITabBarController tabBar = TabBarController;
			bool notModal = (tabBar.PresentedViewController == null);
			bool isSelectedTab = TabBarController.SelectedViewController == this;
			
			var duration = UIApplication.SharedApplication.StatusBarOrientationAnimationDuration;
			
			if (!isSelectedTab || !notModal) { 
				// Looks like we're not "visible" ... propogate rotation info
				base.WillRotate (toOrientation, duration);
				
				UIViewController master = ViewControllers [0];
				var theDelegate = WeakDelegate as DetailViewController;
				
				UIBarButtonItem button = (UIBarButtonItem)base.ValueForKey (new NSString("_barButtonItem"));

				if (toOrientation == UIInterfaceOrientation.Portrait || toOrientation == UIInterfaceOrientation.PortraitUpsideDown) {
					if (theDelegate != null) {
						UIPopoverController popover = (UIPopoverController)base.ValueForKey (new NSString("_hiddenPopoverController"));
						theDelegate.SplitViewControllerWillHide (this, master, button, popover);
					}
				} else if (theDelegate != null) {
						theDelegate.SplitViewControllerWillShow (this, master, button);
				}

			}
		}

		void DidRotate (NSNotification notification)
		{
			if (!IsViewLoaded) // we haven't even loaded up yet, let's turn away from this place
				return;
			
			if (notification == null)
				return;

				#if __UNIFIED__
			UIInterfaceOrientation fromOrientation = 
						(UIInterfaceOrientation)
						(((NSNumber)notification.UserInfo.ValueForKey (UIApplication.StatusBarOrientationUserInfoKey)).Int64Value);
				#else
				UIInterfaceOrientation fromOrientation = 
						(UIInterfaceOrientation)
						(((NSNumber)notification.UserInfo.ValueForKey (UIApplication.StatusBarOrientationUserInfoKey)).IntValue);
				#endif
			
			UITabBarController tabBar = TabBarController;
			bool notModal = (tabBar.PresentedViewController == null);
			bool isSelectedTab = TabBarController.SelectedViewController == this;
			
			if (!isSelectedTab || !notModal) { 
				// Looks like we're not "visible" ... propogate rotation info
				base.DidRotate (fromOrientation);
			}
		}
	}
}
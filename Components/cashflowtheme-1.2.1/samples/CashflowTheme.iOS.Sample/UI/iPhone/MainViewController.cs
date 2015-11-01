using System;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using Xamarin.Themes;

namespace ThemeSample.UI {
	public partial class MainViewController : GHRevealViewController {
		public MainViewController (NSCoder aDecoder) : base (aDecoder)
		{
		}

		public MainViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			UIViewController frontVC = (UIViewController)Storyboard.InstantiateViewController ("FrontVC");
			UIViewController rearVC = (UIViewController)Storyboard.InstantiateViewController ("RearVC");
			
			frontVC.View.AutoresizingMask = (UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight);
			UINavigationController nav = new UINavigationController (frontVC);
			
			base.ViewDidLoad ();
			ContentViewController = nav;
			SidebarViewController = rearVC;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		    Title = ContentViewController.Title;
			
			View.BackgroundColor = UIColor.Black;
		}

		public void RevealToggle ()
		{
			MenuViewController rearVC = (MenuViewController)SidebarViewController;
			rearVC.searchBar.ResignFirstResponder ();
			
			base.ToggleSidebar (!SidebarShowing, kGHRevealSidebarDefaultAnimationDuration);
		}

		public void RevealGesture (UIPanGestureRecognizer recognizer)
		{
			MenuViewController rearVC = (MenuViewController)SidebarViewController;
			rearVC.searchBar.ResignFirstResponder ();
			
			base.DragContentView (recognizer);
		}
			
	}
}

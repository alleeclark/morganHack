using System;
using System.Drawing;
using System.Linq;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace ThemeSample.UI {
	public partial class SecondViewController : UIViewController {
		UIPanGestureRecognizer navigationBarPanGestureRecognizer;

		public SecondViewController (IntPtr handle) : base (handle)
		{
			Title = "Cards View";
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			
			UINavigationController nav = NavigationController;
			MainViewController controller = (MainViewController)nav.ParentViewController; // MainViewController : ZUUIRevealController

			// Check if a UIPanGestureRecognizer already sits atop our NavigationBar.
			if (nav.NavigationBar.GestureRecognizers == null || 
				!(nav.NavigationBar.GestureRecognizers.Contains (navigationBarPanGestureRecognizer))) {
				// If not, allocate one and add it.
				UIPanGestureRecognizer panGestureRecognizer = new UIPanGestureRecognizer (controller.RevealGesture);
				navigationBarPanGestureRecognizer = panGestureRecognizer;
					
				NavigationController.NavigationBar.AddGestureRecognizer (navigationBarPanGestureRecognizer);
			}
				
			// Check if we have a revealButton already.
			if (NavigationItem.LeftBarButtonItem == null) {
				// If not, allocate one and add it.
				UIImage imageMenu = UIImage.FromFile ("action_menu.png");
				UIButton menuButton = new UIButton (UIButtonType.Custom);
				menuButton.SetImage (imageMenu, UIControlState.Normal);
				menuButton.Frame = new RectangleF (0.0f, 0.0f, (float)imageMenu.Size.Width, (float)imageMenu.Size.Height);
				menuButton.TouchUpInside += (sender, e) => controller.RevealToggle ();
					
				NavigationItem.LeftBarButtonItem = new UIBarButtonItem (menuButton);
			}

		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				return toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown;
			} else {
				return toInterfaceOrientation == UIInterfaceOrientation.Portrait;
			}
		}
	}
}

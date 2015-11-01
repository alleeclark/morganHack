using System;
using System.Drawing;
#if __UNIFIED__
using Foundation;
using UIKit;
using SizeF=CoreGraphics.CGSize;
using RectangleF=CoreGraphics.CGRect;
using PointF=CoreGraphics.CGPoint;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace ThemeSample.UI {
	public partial class CustomTabBarViewController : UITabBarController {
		public CustomTabBarViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			AddCenterButton ("Images/iPhone/black/tabbar-center.png");
		}
		// Create a custom UIButton and add it to the center of our tab bar
		void AddCenterButton (string buttonImageName)
		{
			UIImage buttonImage = UIImage.FromFile (buttonImageName);
			UIButton button = UIButton.FromType (UIButtonType.Custom);
			button.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleTopMargin;
			UIView item = TabBar.Subviews [TabBar.Subviews.Length/2];
			SizeF itemSize = item.Frame.Size;
			
			button.Frame = new RectangleF (0, 0, itemSize.Width, itemSize.Height);
			button.SetImage (buttonImage, UIControlState.Normal);
			button.ContentMode = UIViewContentMode.Center;
			button.TouchUpInside += (sender, e) => ShowModalController (sender as UIButton);
			
			float heightDifference = (float)(buttonImage.Size.Height - TabBar.Frame.Height);
			if (heightDifference < 0)
				button.Center = TabBar.Center;
			else {
				PointF center = TabBar.Center;
				center.Y = center.Y - heightDifference / 2;
				button.Center = center;
			}
			
			View.AddSubview (button);
		}

		UIPopoverController popover;

		void ShowModalController (UIButton button)
		{
			if (UIImagePickerController.IsCameraDeviceAvailable (UIImagePickerControllerCameraDevice.Rear)) 
			{
				var modal = (UIViewController)Storyboard.InstantiateViewController ("modalController") as UIImagePickerController;
				//modal.View.BackgroundColor = UIColor.Black;
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ||
					modal.SourceType == UIImagePickerControllerSourceType.Camera) {
					PresentViewController (modal, true, null);
				} else {
					popover = new UIPopoverController (modal);
					popover.PresentFromRect (button.Frame, View, UIPopoverArrowDirection.Down, true);
				}
			}
			else
			{
				var message = new UIAlertView("Doh!","You need a real device for this one",null,"OK",null);
				message.Show();
			}

		}

		[Obsolete ("Deprecated in iOS 6.0")]
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			ReleaseDesignerOutlets ();
		}
	}
}

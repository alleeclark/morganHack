using System;
using System.Collections.Generic;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using Xamarin.Themes;

namespace ThemeSample.UI {
	public partial class DetailViewController : UIViewController {
		Dictionary<string, object> _detailItem;
		UIPopoverController masterPopoverController;

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		public void SetDetailItem (Dictionary<string, object> newDetailItem)
		{
			if (_detailItem != newDetailItem) {
				_detailItem = newDetailItem;
				
				ConfigureView ();
			}
			
			if (masterPopoverController != null) {
				masterPopoverController.Dismiss (true);
			}        
		}

		void ConfigureView ()
		{
			if (_detailItem != null && lblTitle != null) {
				lblTitle.Text = _detailItem ["title"].ToString ();
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			ConfigureView ();
			var p = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad ? "iPad" : "iPhone";
			View.BackgroundColor = CashflowTheme.SharedTheme.ViewBackground;

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				lblTitle.Font = UIFont.FromName ("DINPro-Light", 32);
				txtDescription.Font = UIFont.FromName ("Segoe Print", 20);
			} else {
				txtDescription.Font = UIFont.FromName ("Segoe Print", 11);
				lblTitle.Font = UIFont.FromName ("DINPro-Light", 26);
				lblValue.Font = UIFont.FromName ("DINPro-Medium", 16);
				lblCurrency.Font = UIFont.FromName ("DINPro-Medium", 16);
				
				imageViewDescBg.Image = UIImage.FromFile ("Images/iPhone/card_notes.png").CreateResizableImage (new UIEdgeInsets(50, 10, 50, 10));
			}
			
		}

		[Obsolete ("Deprecated in iOS 6.0")]
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			ReleaseDesignerOutlets ();
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return (toInterfaceOrientation == UIInterfaceOrientation.Portrait);
			}
		}

		[Export("splitViewController:willHideViewController:withBarButtonItem:forPopoverController:")]
		public void SplitViewControllerWillHide (UISplitViewController splitController, UIViewController viewController, UIBarButtonItem barButtonItem, UIPopoverController popoverController)
		{
			barButtonItem.Title = "List";
			NavigationItem.SetLeftBarButtonItem (barButtonItem, true);
			masterPopoverController = popoverController;
		}

		[Export("splitViewController:willShowViewController:invalidatingBarButtonItem:")]
		public void SplitViewControllerWillShow (UISplitViewController splitController, UIViewController viewController, UIBarButtonItem barButtonItem)
		{
			// Called when the view is shown again in the split view, invalidating the button and popover controller.
			NavigationItem.SetLeftBarButtonItem (null, true);
			masterPopoverController = null;
		}
			
	}
}
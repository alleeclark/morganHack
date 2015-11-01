using System;
using System.Drawing;
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
	public partial class MasterViewControlleriPad : UITableViewController {
		DetailViewController detailViewController;
		List<Dictionary<string, object>> rows;

		public MasterViewControlleriPad (IntPtr handle) : base (handle)
		{
		}

		public override void AwakeFromNib ()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				ClearsSelectionOnViewWillAppear = false;
				ContentSizeForViewInPopover = new SizeF (320, 600);
			}
			base.AwakeFromNib ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//CashflowTheme.Apply (View, ColorScheme.Black);

			var ind = SplitViewController.ViewControllers.Length - 1;
			detailViewController = (DetailViewController)(((UINavigationController)SplitViewController.ViewControllers [ind]).ViewControllers [0]);
			
			String defaultDesc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
			rows = new List<Dictionary<string, object>> () {
				new Dictionary<string, object>(){
					{"title", "Car early revision"},
					{"value", 600.0f},
					{"description", defaultDesc},
					{"icon", "Images/iPad/activity-car.png"},
				},
				new Dictionary<string, object>(){
					{"title", @"House cleaning"},
					{"value", 100.0f},
					{"description", defaultDesc},
					{"icon", "Images/iPad/activity-car.png"},
				},
				new Dictionary<string, object>(){
					{"title", "Weekend holiday"},
					{"value", 300.0f},
					{"description", defaultDesc},
					{"icon", "Images/iPad/activity-car.png"},
				},
				new Dictionary<string, object>(){
					{"title", "Food provisions"},
					{"value", 50.0f},
					{"description", defaultDesc},
					{"icon", "Images/iPad/activity-car.png"},
				}
			};
			Title = "List";
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

		[Export("numberOfSectionsInTableView:")]
		int NumberOfSectionsInTableView (UITableView tableView)
		{
			return 1;
		}

		[Export("tableView:numberOfRowsInSection:")]
		int TableViewNumberOfRowsInSection (UITableView tableView, int section)
		{
			return rows.Count;
		}

		[Export("tableView:cellForRowAtIndexPath:")]
		UITableViewCell TableViewCellForRowAtIndexPath (UITableView tableView, NSIndexPath indexPath)
		{
			MasterCelliPad cell = (MasterCelliPad)tableView.DequeueReusableCell ("MasterCell");
			if (cell == null)
				return null;
			var item = rows [indexPath.Row];
			cell.iconActivity.Image = UIImage.FromFile (item["icon"].ToString());
			cell.lblTitle.Text = item ["title"].ToString ();
			cell.lblTitle.Font = UIFont.FromName ("DINPro-Medium", 16);
			cell.lblValue.Font = UIFont.FromName ("DINPro-Medium", 20);
			cell.lblValue.Text = String.Format ("{0:N2}", item ["value"]);
			cell.lblValue.TextColor = UIColor.FromRGB (229, 45, 40);
			cell.lblCurrency.Font = UIFont.FromName ("DINPro-Medium", 20);
			cell.lblCurrency.TextColor = UIColor.FromRGB (0.89f, 0.89f, 0.89f);
			cell.lblValue.TextColor = UIColor.FromRGB (229, 45, 40);

			return cell;
		}

		[Export("tableView:heightForRowAtIndexPath:")]
		float TableViewHeightForRowAtIndexPath (UITableView tableView, NSIndexPath indexPath)
		{
			return 69;
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		void TableViewDidSelectRowAtIndexPath (UITableView aTableView, NSIndexPath indexPath)
		{
			detailViewController.SetDetailItem (rows[indexPath.Row]);
		}
	}
}

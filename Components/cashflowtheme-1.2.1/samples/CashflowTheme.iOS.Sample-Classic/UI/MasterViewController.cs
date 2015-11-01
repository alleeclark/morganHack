using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using Xamarin.Themes;

namespace ThemeSample.UI {
	public partial class MasterViewController : UIViewController {

		UIPanGestureRecognizer navigationBarPanGestureRecognizer;
		NSIndexPath currentlyEditedItem;
		List<Dictionary<string, object>> rows;

		public MasterViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Title = "Cards View";
			tableView.AutoresizingMask = (UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight);
			
			tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			View.BackgroundColor = CashflowTheme.SharedTheme.ViewBackground;
			tableView.BackgroundColor = UIColor.Clear;
			
			//detailViewController = (DetailViewController)(SplitViewController.ViewControllers.Last().topViewController);
			
			String defaultDesc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
			
			
			//tableViewRecognizer = tableView.enableGestureTableViewWithDelegate:this];
			rows = new List<Dictionary<string, object>> () {
				new Dictionary<string, object>(){
					{"title", "Car early revision"},
					{"value", 600.0f},
					{"description", defaultDesc},
					{"icon", "Images/iPhone/activity-car.png"},
				},
				new Dictionary<string, object>(){
					{"title", @"House cleaning"},
					{"value", 100.0f},
					{"description", defaultDesc},
					{"icon", "Images/iPhone/activity-house.png"},
				},
				new Dictionary<string, object>(){
					{"title", "Weekend holiday"},
					{"value", 300.0f},
					{"description", defaultDesc},
					{"icon", "Images/iPhone/activity-holiday.png"},
				},
				new Dictionary<string, object>(){
					{"title", "Food provisions"},
					{"value", 50.0f},
					{"description", defaultDesc},
					{"icon", "Images/iPhone/activity-food.png"},
				}/*, null*/
			};
			
			imageViewBg.Image = UIImage.FromFile ("Images/iPhone/black/revisions-bg.png").CreateResizableImage (new UIEdgeInsets(50, 10, 200, 10));
		}

		[Obsolete ("Deprecated in iOS 6.0")]
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();

			NSNotificationCenter.DefaultCenter.RemoveObserver (this);
			ReleaseDesignerOutlets ();
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			
			//*
			UINavigationController nav = NavigationController;
			MainViewController controller = (MainViewController)nav.ParentViewController; // MainViewController : ZUUIRevealController
			//if (controller.RespondsToSelector(@selector(revealGesture)) && controller.RespondsToSelector(selector(revealToggle)))
			{
				// Check if a UIPanGestureRecognizer already sits atop our NavigationBar.
				if (nav.NavigationBar.GestureRecognizers == null || !(nav.NavigationBar.GestureRecognizers.Contains (navigationBarPanGestureRecognizer))) {
					// If not, allocate one and add it.
					UIPanGestureRecognizer panGestureRecognizer = new UIPanGestureRecognizer (controller.RevealGesture);
					navigationBarPanGestureRecognizer = panGestureRecognizer;
					
					NavigationController.NavigationBar.AddGestureRecognizer (navigationBarPanGestureRecognizer);
				}
				
				// Check if we have a revealButton already.
				if (NavigationItem.LeftBarButtonItem == null) {
					//NSNotificationCenter.DefaultCenter.AddObserver(this, @selector(menuControllerSelectedOption), "MenuSelectedOption", null);
					// If not, allocate one and add it.

					//UIImage imageMenu = UIImage.FromFile ("Images/iPhone/brown/button-menu.png");
					UIImage imageMenu = UIImage.FromFile ("action_menu.png");
					UIButton menuButton = new UIButton (UIButtonType.Custom);
					menuButton.SetImage (imageMenu, UIControlState.Normal);
					menuButton.Frame = new RectangleF (0.0f, 0.0f, (float)imageMenu.Size.Width, (float)imageMenu.Size.Height);
					menuButton.TouchUpInside += (sender, e) => controller.RevealToggle ();
					
					NavigationItem.LeftBarButtonItem = new UIBarButtonItem (menuButton);
				}
			}//*/
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
		UITableViewCell TableViewCellForRowAtIndexPath (UITableView aTableView, NSIndexPath indexPath)
		{
			MasterCell cell = (MasterCell)aTableView.DequeueReusableCell ("MasterCell");
			var item = rows [indexPath.Row];
			if (item.ContainsKey ("icon"))
				cell.iconActivity.Image = UIImage.FromFile (item ["icon"].ToString ());
			else 
				cell.iconActivity.Image = null;
			cell.lblTitle.Text = item ["title"].ToString ();
			cell.lblTitle.Font = UIFont.FromName ("DINPro-Medium", 16);
			cell.lblValue.Text = ((float)item ["value"]).ToString ("N2");
			cell.lblValue.Font = UIFont.FromName ("DINPro-Medium", 20);
			cell.lblValue.TextColor = UIColor.FromHSBA (0.02f, 0.79f, 0.81f, 1.00f);
			cell.lblCurrency.Font = UIFont.FromName ("DINPro-Medium", 20);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				cell.lblCurrency.TextColor = UIColor.FromRGBA (0.43f, 0.43f, 0.43f, 1.00f);
			}

			cell.ContentView.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile ("table-row-bkg.png"));
			
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
			aTableView.DeselectRow (indexPath, true);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail") {
				NSIndexPath indexPath = tableView.IndexPathForSelectedRow;
				((DetailViewController)segue.DestinationViewController).SetDetailItem (rows[indexPath.Row]);
			}
		}


		[Export("showEditPanel")]
		void ShowEditPanel ()
		{
			MKEntryPanel.ShowPanel ("Edit the new item", View,
			                        (enteredValues) => {
				if (enteredValues != null) {
					rows [currentlyEditedItem.Row] = enteredValues;
					tableView.ReloadRows (new NSIndexPath[]{currentlyEditedItem}, UITableViewRowAnimation.None);
				} else {
					rows.RemoveAt (currentlyEditedItem.Row);
					tableView.DeleteRows (new NSIndexPath[]{currentlyEditedItem}, UITableViewRowAnimation.None);
				}
			});
		}

		partial void addItem (UIButton sender)
		{
			rows.Insert (0, new Dictionary<string, object> () {
				{"title", "Just Added!"},
				{"value", 0.0f},
				{"description", string.Empty}
			});
			
			NSIndexPath indexPath = NSIndexPath.FromRowSection (0, 0);
			currentlyEditedItem = indexPath;
			tableView.InsertRows (new NSIndexPath[]{indexPath}, UITableViewRowAnimation.Top);
			NSTimer.CreateScheduledTimer 
							(0.2d, 
								#if __UNIFIED__
								timer 
								#else
								()
								#endif
								=> 
								{
								   ShowEditPanel(); // I'm a dirty ass-whole mc++
								}
							);
		}
	}
}

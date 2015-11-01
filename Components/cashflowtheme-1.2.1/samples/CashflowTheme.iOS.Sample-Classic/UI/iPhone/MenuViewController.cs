using System;
using System.Drawing;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
using SizeF=CoreGraphics.CGSize;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
#endif
using ThemeSample.Model;
using Xamarin.Themes;

namespace ThemeSample.UI {
	public partial class MenuViewController : UIViewController {
		DataSource dataSource;

		public MenuViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			dataSource = DataSource.Source ();
			tableView.ReloadData ();
			tableView.BackgroundColor = UIColor.Clear;
			searchBar.SetTextColor (UIColor.Black);

			//var aField = searchBar.GetField ();/*.LeftView = new UIView (new RectangleF(0, 0, 15, 15));*/

			var searchFrame = searchBar.Frame;
			searchFrame.Height = 64;
			searchBar.Frame = searchFrame;

			var tableFrame = tableView.Frame;
			tableFrame.Y = 64;
			tableFrame.Height = tableFrame.Height -tableFrame.Y;
			tableView.Frame = tableFrame;

			CashflowTheme.Apply (View, ColorScheme.Black);
		}

		[Obsolete("Deprecated in iOS 6.0")]
		public override void ViewDidUnload ()
		{
			ReleaseDesignerOutlets ();
			base.ViewDidUnload ();
		}

		[Export("numberOfSectionsInTableView:")]
		int NumberOfSectionsInTableView (UITableView tableView)
		{
			return 2;
		}

		[Export("tableView:numberOfRowsInSection:")]
		int TableViewNumberOfRowsInSection (UITableView tableView, int section)
		{
			switch (section) {
			case 0:
				return 1;
			case 1:
				return dataSource.items.Length;
			default:
				return 0;
			}
		}

		[Export("tableView:heightForRowAtIndexPath:")]
		float TableViewHeightForRowAtIndexPath (UITableView tableView, NSIndexPath indexPath)
		{
			return 45;
		}

		[Export("tableView:heightForHeaderInSection:")]
		float TableViewHeightForHeaderInSection (UITableView tableView, int section)
		{
			if (section == 0) {
				return 0;
			} else {
				return 23;
			}
		}

		[Export("tableView:viewForHeaderInSection:")]
		UIView TableViewViewForHeaderInSection (UITableView tableView, int section)
		{
			UIImageView bkg = new UIImageView (UIImage.FromFile("Images/iPhone/black/menu-header.png"));
			UILabel lblTitle = new UILabel (new RectangleF(7, 0, 200, (float)bkg.Bounds.Height));
			lblTitle.Text = "FAVORITES";
			lblTitle.TextColor = UIColor.White;
			lblTitle.BackgroundColor = UIColor.Clear;
			lblTitle.Font = UIFont.FromName ("HelveticaNeue-Bold", 12.0f);
			
			bkg.AddSubview (lblTitle);
			
			return bkg;
		}

		[Export("tableView:cellForRowAtIndexPath:")]
		UITableViewCell TableViewCellForRowAtIndexPath (UITableView aTableView, NSIndexPath indexPath)
		{
			UITableViewCell cell;
			cell = aTableView.DequeueReusableCell ("MenuCell");
			if (indexPath.Section == 0) {
				cell.BackgroundColor = UIColor.Clear;
				
				UIImageView imgRow = (UIImageView)cell.ViewWithTag (1);
				imgRow.Image = UIImage.FromFile ("Images/Common/user_1.png");
				
				UILabel lblText = (UILabel)cell.ViewWithTag (2);
				lblText.Text = "Virgil Pana";
			} else {
				cell.BackgroundColor = UIColor.Clear;
				MenuItem item = dataSource.items [indexPath.Row];
				
				UIImageView imgRow = (UIImageView)cell.ViewWithTag (1);
				imgRow.Image = item.Image;
				UILabel lblText = (UILabel)cell.ViewWithTag (2);
				lblText.Text = item.Name;
				
				UIView countView = null;
				if (item.EventCount > 0) {
					string countString = item.EventCount.ToString ();
					#if __UNIFIED__
					SizeF sizeCount = UIStringDrawing.StringSize (countString, UIFont.SystemFontOfSize (14.0f));
					#else
					SizeF sizeCount = View.StringSize (countString, UIFont.SystemFontOfSize (14.0f));
					#endif		
								
					UIImage bkgImg = UIImage.FromFile ("Images/iPhone/sidemenu-count.png");
					countView = new UIImageView (bkgImg.StretchableImage(12, 0));

					#if __UNIFIED__
					countView.Frame = 
						new RectangleF (0, 0, (float)sizeCount.Width + 2 * 10, (float)bkgImg.Size.Height)
								//.Inegral()
								;
					UILabel lblCount = 
								new UILabel 
								(
							new RectangleF(10, (float)(bkgImg.Size.Height-sizeCount.Height)/2-2, (float) sizeCount.Width, (float) sizeCount.Height)
								);
					#else
					countView.Frame = 
						new RectangleF (0, 0, (float)sizeCount.Width + 2 * 10, (float)bkgImg.Size.Height)
								.Integral ()
								;
					UILabel lblCount = 
								new UILabel 
								(
									new RectangleF(10, (float)(bkgImg.Size.Height-sizeCount.Height)/2-2, sizeCount.Width, sizeCount.Height)
										.Integral()
								);
					#endif
					lblCount.Text = countString;
					lblCount.BackgroundColor = UIColor.Clear;
					lblCount.TextColor = UIColor.White;
					lblCount.TextAlignment = UITextAlignment.Center;
					lblCount.Font = UIFont.SystemFontOfSize (14.0f);
					lblCount.ShadowColor = UIColor.Black;
					lblCount.ShadowOffset = new SizeF (0, 1);
					countView.AddSubview (lblCount);
				}
				cell.AccessoryView = countView;
			}
			return cell;
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		void TableViewDidSelectRowAtIndexPath (UITableView aTableView, NSIndexPath indexPath)
		{
			if (indexPath.Section == 0) {
				return;
			}
			searchBar.ResignFirstResponder ();

			MainViewController mainController = (MainViewController)ParentViewController;
			
			// Either change the view displayed as a Master View
			if (indexPath.Row == 0) {
				if ((mainController.ContentViewController is UINavigationController)
					&& !(((UINavigationController)mainController.ContentViewController).TopViewController is MasterViewController)) {
					MasterViewController frontVC = (MasterViewController)Storyboard.InstantiateViewController ("FrontVC");
					UINavigationController nav = new UINavigationController (frontVC);
					mainController.ContentViewController = nav;
				} 
				mainController.ToggleSidebar (!mainController.SidebarShowing);
			} else {
				if ((mainController.ContentViewController is UINavigationController)
					&& !(((UINavigationController)mainController.ContentViewController).TopViewController is SecondViewController)) {
					SecondViewController secondVC = (SecondViewController)Storyboard.InstantiateViewController ("SecondVC");
					UINavigationController nav = new UINavigationController (secondVC);
					mainController.ContentViewController = nav;
				} 
				mainController.ToggleSidebar (!mainController.SidebarShowing);
			}
		}
	}
}

// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using System.CodeDom.Compiler;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace ThemeSample.UI
{
	[Register ("MasterViewController")]
	partial class MasterViewController
	{
		[Outlet]
		UITableView tableView { get; set; }

		[Outlet]
		UIImageView imageViewBg { get; set; }

		[Action ("addItem:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void addItem (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
		}
	}
}

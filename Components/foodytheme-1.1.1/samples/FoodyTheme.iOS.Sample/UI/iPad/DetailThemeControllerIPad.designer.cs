// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using System.CodeDom.Compiler;

#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
#endif

namespace ThemeSample
{
	[Register ("DetailThemeControllerIPad")]
	partial class DetailThemeControllerIPad
	{
		[Outlet]
		UIImageView DishImage { get; set; }

		[Outlet]
		UITableView IngredientsTableView { get; set; }

		[Outlet]
		UIImageView PaperBackground { get; set; }

		[Outlet]
		UITableView StepsTableView { get; set; }

		[Outlet]
		UIToolbar Toolbar { get; set; }

		[Outlet]
		UIToolbar BottomToolbar { get; set; }

		[Outlet]
		UIView ViewsContainer { get; set; }

		void ReleaseDesignerOutlets ()
		{
		}
	}
}

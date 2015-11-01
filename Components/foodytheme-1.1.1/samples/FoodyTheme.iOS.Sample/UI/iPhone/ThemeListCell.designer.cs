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
	[Register ("ThemeListCell")]
	partial class ThemeListCell
	{
		[Outlet]
		UIButton CountryButton { get; set; }

		[Outlet]
		UILabel TimeLabel { get; set; }

		[Outlet]
		UILabel DishLabel { get; set; }

		[Outlet]
		UIImageView DishImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView CellBackground { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CellBackground != null) {
				CellBackground.Dispose ();
				CellBackground = null;
			}
		}
	}
}

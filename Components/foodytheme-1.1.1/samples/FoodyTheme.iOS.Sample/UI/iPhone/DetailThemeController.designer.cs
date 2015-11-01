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
	[Register ("DetailThemeController")]
	partial class DetailThemeController
	{
		[Outlet]
		UIImageView DishImage { get; set; }

		[Outlet]
		UITextView IngredientsTextView { get; set; }

		[Outlet]
		UITableView TableSteps { get; set; }

		[Outlet]
		UIScrollView ScrollView { get; set; }

		void ReleaseDesignerOutlets ()
		{
		}
	}
}

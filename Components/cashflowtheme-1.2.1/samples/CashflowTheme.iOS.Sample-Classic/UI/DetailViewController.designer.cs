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
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UITextView txtDescription { get; set; }

		[Outlet]
		UILabel lblDay { get; set; }

		[Outlet]
		UILabel lblMonth { get; set; }

		[Outlet]
		UILabel lblTitle { get; set; }

		[Outlet]
		UILabel lblValue { get; set; }

		[Outlet]
		UILabel lblCurrency { get; set; }

		[Outlet]
		UIImageView imageViewDescBg { get; set; }

		void ReleaseDesignerOutlets ()
		{
		}
	}
}

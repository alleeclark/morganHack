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
	[Register ("MasterCell")]
	partial class MasterCell
	{
		[Outlet]
		UIImageView BgImageView { get; set; }

		[Outlet]
		UIImageView CountBg { get; set; }

		[Outlet]
		UILabel CountLabel { get; set; }

		[Outlet]
		UILabel DishLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
		}
	}
}

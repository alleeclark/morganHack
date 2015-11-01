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
	[Register ("StepListCell")]
	partial class StepListCell
	{
		[Outlet]
		UILabel BulletLabel { get; set; }

		[Outlet]
		UILabel CountLabel { get; set; }

		[Outlet]
		UILabel StepLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
		}
	}
}

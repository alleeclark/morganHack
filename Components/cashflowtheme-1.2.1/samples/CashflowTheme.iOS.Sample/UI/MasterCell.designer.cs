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
	[Register ("MasterCell")]
	partial class MasterCell
	{
		[Outlet]
		public UIImageView iconActivity { get; set; }

		[Outlet]
		public UILabel lblTitle { get; set; }

		[Outlet]
		public UILabel lblDescription { get; set; }

		[Outlet]
		public UILabel lblValue { get; set; }

		[Outlet]
		public UILabel lblCurrency { get; set; }

		void ReleaseDesignerOutlets ()
		{
		}
	}
}

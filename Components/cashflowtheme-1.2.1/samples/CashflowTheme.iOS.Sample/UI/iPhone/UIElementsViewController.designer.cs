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
	[Register ("UIElementsViewController")]
	partial class UIElementsViewController
	{
		[Outlet]
		UIScrollView scrollView { get; set; }

		[Outlet]
		UIButton colorButton { get; set; }

		[Outlet]
		UIButton colorButtonSelected { get; set; }

		[Outlet]
		UITextField textField { get; set; }

		[Outlet]
		UIImageView imageViewBg { get; set; }

		[Action ("sliderValueChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void sliderValueChanged (UISlider sender);

		void ReleaseDesignerOutlets ()
		{
		}
	}
}

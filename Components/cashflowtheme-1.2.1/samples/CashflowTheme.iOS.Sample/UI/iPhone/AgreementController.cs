// This file has been autogenerated from parsing an Objective-C header file added in Xcode.using System;
using System;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using Xamarin.Themes;

namespace ThemeSample.UI {
	public partial class AgreementController : UIViewController {
		public AgreementController (IntPtr handle) : base (handle)
		{
			Title = "Agreement";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			CashflowTheme.Apply (View, ColorScheme.Black);


		}

		[Obsolete ("Deprecated in iOS 6.0")]
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			ReleaseDesignerOutlets ();
		}

	}
}
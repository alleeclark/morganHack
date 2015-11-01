// This file has been autogenerated from parsing an Objective-C header file added in Xcode.
using System;
using Xamarin.Themes;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;

using System.Drawing;
using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif


namespace ThemeSample {
	public partial class ElementThemeController : UIViewController {
		public ElementThemeController (IntPtr handle) : base (handle)
		{
		}

		UILabel label;
		UIButton normalButton;
		UIButton pressedButton;
		UIProgressView progress;
		UISlider slider;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			normalButton = GetButton (new CGRect (10, 120, 295, 48),
			                          FoodyTheme.SharedTheme.ButtonImage,
			                          "Standard Button");
			View.AddSubview (normalButton);

			pressedButton = GetButton (new CGRect (10, 190, 295, 48),
			                           FoodyTheme.SharedTheme.PressedButtonImage, 
			                           "Button Pressed");
			View.AddSubview (pressedButton);


			label = new UILabel (new CGRect (15, 40, 400, 30));
			FoodyTheme.Apply (label);
			label.Text = "Label";
			View.AddSubview (label);


			var paddingView = new UIView (new CGRect (0, 0, 5, 20));
			TextField.LeftView = paddingView;
			TextField.LeftViewMode = UITextFieldViewMode.Always;
			TextField.ShouldReturn = TextFieldShouldReturn;
			TextField.Background = FoodyTheme.SharedTheme.TextFieldBackground;


			progress = new UIProgressView (new CGRect (13, 300, 292, 10));
			progress.Progress = 0.5f;
			View.AddSubview (progress);

			slider = new UISlider (new CGRect (10, 330, 298, 10));
			slider.Value = 0.5f;
			slider.ValueChanged += HandleValueChanged;
			View.AddSubview (slider);

			FoodyTheme.Apply (View);
		}

		void HandleValueChanged (object sender, EventArgs e)
		{
			progress.Progress = slider.Value;
		}

		bool TextFieldShouldReturn (UITextField textField)
		{
			textField.ResignFirstResponder ();
			return true;
		}

		UIButton GetButton (CGRect rect, UIImage backImage, string title)
		{
			var button = new UIButton (rect);
			button.SetBackgroundImage (backImage, UIControlState.Normal);
			button.SetTitle (title, UIControlState.Normal);
			button.SetTitleShadowColor (UIColor.DarkGray, UIControlState.Normal);
			button.TitleLabel.ShadowOffset = new CGSize (1, -1);
			button.TitleLabel.Font = FoodyTheme.SharedTheme.MainFont;
			return button;
		}

		[Obsolete ("Deprecated in iOS 6.0")]
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			ReleaseDesignerOutlets ();

			slider.ValueChanged -= HandleValueChanged;
			slider.Dispose ();
			slider = null;

			progress.Dispose ();
			progress = null;

			normalButton.Dispose ();
			normalButton = null;

			pressedButton.Dispose ();
			pressedButton = null;

			label.Dispose ();
			label = null;
		}
	}
}

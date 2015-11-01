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

namespace ThemeSample.UI
{
    public partial class AgreementController : UIViewController
    {
        UIButton agreeButton;

        UIButton disagreeButton;

        public AgreementController(IntPtr handle) : base (handle)
        {
        }

        public AgreementController() : base ("AgreementController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            agreeButton = GetButton(new CGRect(105 , 155 , 110 , 45),
                                    FoodyTheme.SharedTheme.ButtonImage,
                                    "Agree");
            agreeButton.TouchUpInside += HandleAgreeTouchUpInside;

            View.AddSubview (agreeButton);

			disagreeButton = GetButton(new CGRect(105 , 215 , 110 , 45),
                                       FoodyTheme.SharedTheme.ButtonImage, 
                                       "Disagree");
            disagreeButton.TouchUpInside += HandleDisagreeTouchUpInside;

            View.AddSubview (disagreeButton);

            FoodyTheme.Apply(View);
            // Perform any additional setup after loading the view, typically from a nib.
        }

        [Obsolete ("Deprecated in iOS 6.0")]
        public override void ViewDidUnload()
        {

            agreeButton.TouchUpInside -= HandleAgreeTouchUpInside;
            agreeButton.Dispose();
            agreeButton = null;

            disagreeButton.TouchUpInside -= HandleDisagreeTouchUpInside;
            disagreeButton.Dispose();
            disagreeButton = null;

            base.ViewDidUnload();
        }

        void HandleAgreeTouchUpInside (object sender, EventArgs e)
        {
            (new UIAlertView ("Message", "You agree the license", null, "OK", null)).Show ();
        }

        void HandleDisagreeTouchUpInside (object sender, EventArgs e)
        {
            (new UIAlertView ("Message", "You disagree the license", null, "OK", null)).Show ();
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
    }
}


using System;
using System.Drawing;
using System.Collections.Generic;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreAnimation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
#endif
using Xamarin.Themes;

namespace ThemeSample.UI {
	public class MKEntryPanel : UIView {
		Action<Dictionary<string, object>> closeBlock;
		static double kAnimationDuration = 0.35;
		UIControl dimView;
		UILabel titleLabel;
		UITextField entryField;
		UITextField valueField;
		UILabel currencyLabel;
		UIImageView activityImage;
		UIImageView background;

		public MKEntryPanel (IntPtr handle) : base (handle)
		{
			InitSubviews ();
		}

		public MKEntryPanel () : base (new RectangleF(0,0,320,78))
		{
			InitSubviews ();
		}

		void InitSubviews ()
		{
			Alpha = 0.920000016689301f;
			BackgroundColor = UIColor.GroupTableViewBackgroundColor;
			background = new UIImageView (new RectangleF(0,0,320,78));
			background.AutoresizingMask = UIViewAutoresizing.All;
			background.Image = UIImage.FromFile ("table-row-bkg.png");

			titleLabel = new UILabel (new RectangleF(15,6,290,21));
			titleLabel.BackgroundColor = UIColor.Clear;
			titleLabel.Text = "Edit the new entry";
			titleLabel.TextAlignment = UITextAlignment.Center;
			titleLabel.BaselineAdjustment = UIBaselineAdjustment.AlignCenters;
			titleLabel.ShadowColor = UIColor.White;
			titleLabel.Font = UIFont.FromName ("Helvetica-Bold", 15);
			titleLabel.TextColor = UIColor.FromRGBA (.2f, .2f, .2f, 1f);

			currencyLabel = new UILabel (new RectangleF(288,32,17,29));
			currencyLabel.BackgroundColor = UIColor.Clear;
			currencyLabel.Text = "€";
			currencyLabel.Font = UIFont.BoldSystemFontOfSize (19);
			currencyLabel.TextColor = UIColor.DarkGray;
			currencyLabel.HighlightedTextColor = UIColor.DarkGray;
			currencyLabel.ShadowColor = UIColor.White;
			currencyLabel.ShadowOffset = new SizeF (0, 1);


			activityImage = new UIImageView (new RectangleF(8,34,24,24));
			activityImage.Image = new UIImage ("activity-car.png");

			entryField = new UITextField (new RectangleF(40,31,174,31));
			entryField.Font = UIFont.BoldSystemFontOfSize (17);
			entryField.TextAlignment = UITextAlignment.Left;
			entryField.BorderStyle = UITextBorderStyle.None;
			entryField.Placeholder = "Title";
			entryField.MinimumFontSize = 17;
			entryField.ClearButtonMode = UITextFieldViewMode.Never;
			entryField.Background = CashflowTheme.SharedTheme.TextBackground;
			entryField.ReturnKeyType = UIReturnKeyType.Next;
			entryField.ShouldReturn = TextFieldShouldReturn;
			entryField.AdjustsFontSizeToFitWidth = true;
			entryField.VerticalAlignment = UIControlContentVerticalAlignment.Center;

			valueField = new UITextField (new RectangleF(222,31,63,31));
			valueField.TextColor = UIColor.FromRGB (195 / 255f, 58 / 255f, 42 / 255f);
			valueField.Font = UIFont.BoldSystemFontOfSize (19);
			valueField.Placeholder = "Value";
			valueField.MinimumFontSize = 17;
			valueField.TextAlignment = UITextAlignment.Right;
			valueField.Background = CashflowTheme.SharedTheme.TextBackground;
			valueField.ReturnKeyType = UIReturnKeyType.Done;
			valueField.ShouldReturn = TextFieldShouldReturn;
			valueField.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
			valueField.AdjustsFontSizeToFitWidth = true;
			valueField.VerticalAlignment = UIControlContentVerticalAlignment.Center;

			AddSubviews (background, titleLabel, currencyLabel, activityImage, entryField, valueField);

		}

		static MKEntryPanel GetPanel ()
		{
			MKEntryPanel panel = new MKEntryPanel (); 

			CATransition transition = CATransition.CreateAnimation ();
			transition.Duration = kAnimationDuration;
			transition.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.EaseInEaseOut);
			transition.Type = CATransition.TransitionPush.ToString ();
			transition.Subtype = CATransition.TransitionFromBottom.ToString ();
			panel.Layer.AddAnimation (transition, null);
			
			return panel;
		}

		public static void ShowPanel (string title, UIView view, Action<Dictionary<string, object>> editingEndedBlock)
		{
			MKEntryPanel panel = GetPanel ();
			panel.closeBlock = editingEndedBlock;
			panel.titleLabel.Text = title;
			panel.titleLabel.BackgroundColor = UIColor.Clear;
			panel.entryField.Font = UIFont.FromName ("DINPro-Medium", 16);
			panel.entryField.LeftView = new UIView (new RectangleF(0, 0, 5, 31));
			panel.entryField.LeftViewMode = UITextFieldViewMode.Always;
			panel.entryField.Background = CashflowTheme.SharedTheme.TextBackground.CreateResizableImage (new UIEdgeInsets(5, 10, 5, 10));
			panel.valueField.Font = UIFont.FromName ("DINPro-Medium", 16);
			panel.valueField.RightView = new UIView (new RectangleF(0, 0, 5, 31));
			panel.valueField.RightViewMode = UITextFieldViewMode.Always;
			panel.valueField.Background = CashflowTheme.SharedTheme.TextBackground.CreateResizableImage (new UIEdgeInsets(5, 10, 5, 10));
			panel.valueField.TextAlignment = UITextAlignment.Right;
			panel.entryField.BecomeFirstResponder ();

			panel.dimView = new UIControl (UIScreen.MainScreen.Bounds);
			CATransition transition = CATransition.CreateAnimation ();
			transition.Duration = kAnimationDuration;
			transition.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.EaseInEaseOut);
			transition.Type = CATransition.TransitionFade.ToString ();
			panel.dimView.Layer.AddAnimation (transition, null);
			panel.dimView.BackgroundColor = UIColor.Black;
			panel.dimView.Alpha = 0.8f;
			panel.dimView.TouchDown += (sender, e) => panel.CancelTapped ();
			view.AddSubview (panel.dimView);
			view.AddSubview (panel);
		}

		bool TextFieldShouldReturn (UITextField textField)
		{
			if (textField == entryField) {
				valueField.BecomeFirstResponder ();
				return false;
			}
			
			InvokeOnMainThread (HidePanel);  

			float tmp;
			float value = float.TryParse (entryField.Text, out tmp) ? tmp : 0f;

			var values = new Dictionary<string, object> () {
				{"title", entryField.Text},
				{"value", value},
				{"icon", "Images/iPhone/activity-car.png"}
			};
			
			closeBlock (values);

			return false;
		}

		void CancelTapped ()
		{
			InvokeOnMainThread (HidePanel);  
			closeBlock (null);
		}

		void HidePanel ()
		{
			entryField.ResignFirstResponder ();
			CATransition transition = CATransition.CreateAnimation ();
			transition.Duration = kAnimationDuration;
			transition.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.EaseInEaseOut);
			transition.Type = CATransition.TransitionPush.ToString ();
			transition.Subtype = CATransition.TransitionFromTop.ToString ();
			Layer.AddAnimation (transition, null);
			Frame = new RectangleF (0, (float) -Frame.Height, 320, (float) Frame.Height); 
			
			transition = CATransition.CreateAnimation ();
			transition.Duration = kAnimationDuration;
			transition.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.EaseInEaseOut);
			transition.Type = CATransition.TransitionFade.ToString ();
			dimView.Alpha = 0;
			dimView.Layer.AddAnimation (transition, null);
			
			NSTimer.CreateScheduledTimer (0.40, 
												#if __UNIFIED__
												timer 
												#else
												()
												#endif
												=>
													{
														dimView.RemoveFromSuperview();
													}
										);
			NSTimer.CreateScheduledTimer (0.45, 
												#if __UNIFIED__
												timer 
												#else
												()
												#endif
												=>
													{
														RemoveFromSuperview();
													}
										);
		}
	}
}

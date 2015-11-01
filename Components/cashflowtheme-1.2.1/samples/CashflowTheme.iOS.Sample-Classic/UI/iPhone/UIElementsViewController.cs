using System;
using System.Drawing;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using Xamarin.Controls.iOS.PopoverProgressBar;
using Xamarin.Controls.iOS.Switches;
using Xamarin.Themes;

namespace ThemeSample.UI {
	public partial class UIElementsViewController : UIViewController {

		ADVPopoverProgressBar progressBar;

		public UIElementsViewController (IntPtr handle) : base (handle)
		{
		}

		public UIElementsViewController (String nibName, NSBundle nibBundle) : base (nibName, nibBundle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			View.BackgroundColor = CashflowTheme.SharedTheme.ViewBackground;

			RCSwitchOnOff onSwitch = new RCSwitchOnOff (new RectangleF(72, 50, 76, 33));
			onSwitch.IsOn = true;
			scrollView.AddSubview (onSwitch);
			
			RCSwitchOnOff offSwitch = new RCSwitchOnOff (new RectangleF(176, 50, 76, 33));
			offSwitch.IsOn = false;
			scrollView.AddSubview (offSwitch);
			
			progressBar = new ADVPopoverProgressBar (new RectangleF(20, 135, 280, 23));
			progressBar.SetProgress (0.5f);
			scrollView.AddSubview (progressBar);
			
			UISegmentedControl segment = new UISegmentedControl (new object[] {"Yes", "No"});
			segment.Frame = new RectangleF (85, 245, 150, 42);
			segment.SelectedSegment = 0;
			
			scrollView.AddSubview (segment);

			imageViewBg.Image = UIImage.FromFile ("Images/iPhone/black/revisions-bg.png").CreateResizableImage (
				new UIEdgeInsets (50, 10, 200, 10));
		}

		[Obsolete ("Deprecated in iOS 6.0")]
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			ReleaseDesignerOutlets ();
		}

		partial void sliderValueChanged (UISlider sender)
		{
			var slider = sender as UISlider;

			if (slider != null) {
				if (slider.Value >= 0 && slider.Value <= 1) {
					progressBar.SetProgress (slider.Value);
				}
			}
		}
			
	}
}

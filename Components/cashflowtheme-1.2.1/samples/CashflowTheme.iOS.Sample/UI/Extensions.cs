using System;
using System.Drawing;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif

namespace ThemeSample.UI {
	static class Extensions {

		public static RectangleF OffsetNew (this RectangleF @this, float x, float y)
		{
			var result = @this;
			result.Offset (x, y);
			return result;
		}

		// HACK: This may not work in future iOS versions
		public static UITextField GetField (this UISearchBar bar)
		{
			foreach (UIView subview in bar.Subviews) {
				if (subview is UITextField) {
					return (UITextField)subview;
				}

				foreach (UIView subview2 in subview.Subviews) {
					if (subview2 is UITextField) {
						return (UITextField)subview2;
					}
				}
			}
			return null;
		}

		public static void SetTextColor (this UISearchBar bar, UIColor color)
		{
			bar.GetField ().TextColor = color;
		}
	}
}


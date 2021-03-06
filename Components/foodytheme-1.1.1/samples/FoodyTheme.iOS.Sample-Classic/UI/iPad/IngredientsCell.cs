// This file has been autogenerated from parsing an Objective-C header file added in Xcode.using System;
using System;

#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
#endif

namespace ThemeSample {
	public partial class IngredientsCell : UITableViewCell {
		public IngredientsCell (IntPtr handle) : base (handle)
		{
		}

		public void Init (string ingredient)
		{
			if (ingredient == null)
				throw new ArgumentNullException ("ingredient");

			IngredientLabel.Text = ingredient;

			var img = UIImage.FromFile ("ipad-dotted-pattern.png");
			DottedLineView.BackgroundColor = UIColor.FromPatternImage (img);
		}

		protected override void Dispose (bool disposing)
		{
			ReleaseDesignerOutlets ();
			base.Dispose (disposing);
		}
	}
}

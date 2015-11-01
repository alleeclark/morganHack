using System;

#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
#endif

namespace ThemeSample {
	public class Recipe {
		public string Name { get; set; }
		public string PreparationTime { get; set; }
		public string Country { get; set; }
		public UIImage Image { get; set; }
		public string [] Ingredients { get; set; }
		public string [] PreparationSteps { get; set; }
	}
}


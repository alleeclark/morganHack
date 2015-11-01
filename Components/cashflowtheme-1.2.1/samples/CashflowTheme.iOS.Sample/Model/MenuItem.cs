#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif
namespace ThemeSample.Model {
	sealed class MenuItem {
		UIImage image;

		public string Name { get; set; }

		public string ImageName { get; set; }

		public int EventCount { get; set; }

		public UIImage Image {
			get {
				if (string.IsNullOrWhiteSpace (ImageName)) {
					return null;
				}

				if (image == null) {
					image = UIImage.FromFile (ImageName);
				}

				return image;
			}
		}
	}
}
using System;
using System.Drawing;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
#endif

namespace ThemeSample.Model {
	sealed class DataSource {
		public MenuItem[] items;

		public static DataSource Source ()
		{
			DataSource source = new DataSource ();
			
			source.items = new MenuItem[] {
				new MenuItem () { Name = "Home", ImageName = "Images/iPhone/black/menu-home.png" },
				new MenuItem () { Name = "Popular", ImageName = "Images/iPhone/black/menu-eye.png" },
				new MenuItem () { Name = "Around me", ImageName = "Images/iPhone/black/menu-pin.png", EventCount = 8 },
				new MenuItem () { Name = "Recent", ImageName = "Images/iPhone/black/menu-clock.png", EventCount = 11 },
			};

			return source;
		}
	}
}

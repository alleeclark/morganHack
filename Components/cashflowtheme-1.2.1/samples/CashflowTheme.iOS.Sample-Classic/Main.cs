#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif
namespace ThemeSample.UI {
	public static class Application {
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}

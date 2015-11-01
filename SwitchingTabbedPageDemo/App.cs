using Xamarin.Forms;
using Cards;

namespace SwitchingTabbedPageDemo {
	public class App : Application, ILoginManager 
	{
		static ILoginManager loginManager;
		public static App Current;
		//static ILoginManager loginManger;
		//public static App Current;

		public App ()
		{
			Current = this;
			var isLoggedIn = Properties.ContainsKey("IsLoggedIn")?(bool)Properties ["IsLoggedIn"]:false;

			//if (isLoggedIn)
		//		MainPage = new MainTabbedPage();
		//	else
				MainPage = new LoginModalPage(this);
		}

		public void ShowMainPage ()
		{
			MainPage = new MainTabbedPage();
		}
		public void Logout ()
		{
			Properties["IsLoggedIn"] = false;
			MainPage = new LoginModalPage(this);
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}

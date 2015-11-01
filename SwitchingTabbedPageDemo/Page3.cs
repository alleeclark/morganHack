using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SwitchingTabbedPageDemo {
	public class Page3 : ContentPage {
		public Page3() {
			Title = "TRANSACTIONS";
			var label = new Label { Text = "Hello ContentPage 3" };
			Device.OnPlatform(
				iOS: () => {
					var parentTabbedPage = this.ParentTabbedPage() as MainTabbedPage;
					if (parentTabbedPage != null) {
						// HACK: get content out from under status bar if a navigation bar isn't doing that for us already.
						Padding = new Thickness(Padding.Left, Padding.Top + 25f, Padding.Right, Padding.Bottom);
					}
				}
			);


			var button = new Button() {
				Text = "Switch to Tab 1; add a Page 2 there",
			};
			button.Clicked += async (sender, e) => {
				var tabbedPage = this.ParentTabbedPage() as MainTabbedPage;
				var partPage = new Page3() { Title = "Added page 3" };
				await tabbedPage.SwitchToTab1(partPage, resetToRootFirst: false);
			};

			Content = new StackLayout { 
				Children = {
					button,
					label,
				}
			};


		}
	}
}

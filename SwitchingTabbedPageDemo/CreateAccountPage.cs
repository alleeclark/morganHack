using System;

using Xamarin.Forms;

namespace SwitchingTabbedPageDemo {
	public class CreateAccountPage : ContentPage {
		public CreateAccountPage(ILoginManager ilm) {
			var button = new Button {Text = "Create Account"};
			button.Clicked += (sender, e) => {
				DisplayAlert("Account created", "Add processing login here", "OK");
				ilm.ShowMainPage();
			};
			var cancel = new Button { Text = "Cancel" };
			cancel.Clicked += (sender, e) => {
				MessagingCenter.Send<ContentPage>(this, "Login");
			};

			Content = new StackLayout { 
				Padding = new Thickness (10, 40, 10, 10),
				Children = {
					new Label { Text = "Create Account",},
					new Label {Text = "Choose a Username"},
					new Label {Text = ""},
					new Label {Text = "Password"},
					new Label {Text = ""},
					new Label {Text = "Re-enter Password"},
					new Label {Text = ""},
					button, cancel
				}
			};
		}
	}
}



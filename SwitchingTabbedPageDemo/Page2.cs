using Xamarin.Forms;
using System;
using Cards;

namespace SwitchingTabbedPageDemo {
	public class Page2 : ContentPage {
		public Page2() {
			Title = "Messages";
			BindingContext = new Page2ViewModel ();

			// Send messages when buttons are pressed
			var button1 = new Button { Text = "Say Hi" };
			button1.Clicked += (sender, e) => {
				MessagingCenter.Send<Page2> (this, "Hi");
			};
			var button2 = new Button { Text = "Say Hi to John" };
			button2.Clicked += (sender, e) => {
				MessagingCenter.Send<Page2, string> (this, "Hi", "John");
			};

			var button3 = new Button { Text = "Unsubscribe from alert" };
			button3.Clicked += (sender, e) => {
				MessagingCenter.Unsubscribe<Page2, string> (this, "Hi");
				DisplayAlert("Unsubscribed", 
					"This page has stopped listening, so no more alerts; however the ViewModel is still receiving messages.",
					"OK");
			};

			// Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
			MessagingCenter.Subscribe<Page2, string> (this, "Hi", (sender, arg) => {
				DisplayAlert("Message Received", "arg=" + arg, "OK");
			});

			var listView = new ListView ();
			listView.SetBinding (ListView.ItemsSourceProperty, "Greetings");

			Content = new StackLayout { 
				Padding = new Thickness (0, 20, 0, 0),
				Children = {button1, button2, button3, listView }
			};
	}
	}
}

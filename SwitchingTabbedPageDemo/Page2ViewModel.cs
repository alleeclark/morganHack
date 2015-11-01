using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace SwitchingTabbedPageDemo {
	public class Page2ViewModel {

		public ObservableCollection<string> Greetings { get; set; }

		public Page2ViewModel ()
		{
			Greetings = new ObservableCollection<string> ();

			MessagingCenter.Subscribe<Page2> (this, "Hi", (sender) => {
				Greetings.Add("Hi");
			});

			MessagingCenter.Subscribe<Page2, string> (this, "Hi", (sender, arg) => {
				Greetings.Add("Hi " + arg);
			});
	}
}
}

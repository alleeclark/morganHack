using Xamarin.Forms;
using System;
using Cards;

namespace SwitchingTabbedPageDemo {
	class Page5 : ContentPage {
		public Page5 ()
		{
			// Some presidential data. http://www.americanpresidents.org/gallery/
			List<President> presidents = new List<President> {
				new Presidents ("George Washington", 1, "$29", "http://www.americanpresidents.org/images/01_150.gif"),
				new Presidents ("John Adams", 2, "$29","http://www.americanpresidents.org/images/02_150.gif"),
				new Presidents ("Thomas  Jefferson", 3,"$29", "http://www.americanpresidents.org/images/03_150.gif"),
				new Presidents ("James Madison", 4, "$29","http://www.americanpresidents.org/images/04_150.gif"),
				new Presidents ("James Monroe", 5, "$29","http://www.americanpresidents.org/images/05_150.gif"),
				new Presidents ("John Quincy Adams", 6, "$29","http://www.americanpresidents.org/images/06_150.gif"),
				new Presidents ("Andrew Jackson", 7, "$29","http://www.americanpresidents.org/images/07_150.gif"),
				new Presidents ("Martin Van Buren", 8, "$29","http://www.americanpresidents.org/images/08_150.gif"),
				new Presidents ("William Henry Harrison", 9, "$29","http://www.americanpresidents.org/images/09_150.gif"),
				new Presidents ("John Tyler", 10, "$29","http://www.americanpresidents.org/images/10_150.gif"),
				new Presidents ("James K. Polk", 11, "$29","http://www.americanpresidents.org/images/11_150.gif"),
				new Presidents ("Zachary Taylor", 12, "$29","http://www.americanpresidents.org/images/12_150.gif"),
				new Presidents ("Millard Fillmore", 13, "$29","http://www.americanpresidents.org/images/13_150.gif"),
				new Presidents ("Franklin Pierce", 14, "$29","http://www.americanpresidents.org/images/14_150.gif"),
				new Presidents ("James Buchanan", 15, "$29","http://www.americanpresidents.org/images/15_150.gif"),
			};

			Label header = new Label {
				Text = "Presidents",
				Font = Font.SystemFontOfSize (35),
				HorizontalOptions = LayoutOptions.Center
			};

			// Create a data template from the type ImageCell
			var cell = new DataTemplate (typeof(ImageCell));

			cell.SetBinding (TextCell.TextProperty, "Name");
			cell.SetBinding (TextCell.TextProperty, "Price");
			cell.SetBinding (ImageCell.ImageSourceProperty, "Image");

			ListView listView = new ListView {
				ItemsSource = presidents,
				ItemTemplate = cell // Set the ImageCell to the item template for the listview
			};

			// Push the list view down below the status bar on iOS.
			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			// Set the content for the page.
			this.Content = new StackLayout {
				Children = {
					header,
					listView
				}
			};
		}
	}
	}
}
}
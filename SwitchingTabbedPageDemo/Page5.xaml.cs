using Xamarin.Forms;
using System;
using Cards;
using System.Collections.Generic;
namespace SwitchingTabbedPageDemo {
	partial class Page5 : ContentPage {
		public Page5 ()
		{
			// Some presidential data. http://www.americanpresidents.org/gallery/
			List<Presidents> presidents = new List<Presidents> {
				new Presidents ("Brew & Bourbon Classic Laurel Park", "$29  November 14th", "http://s3-media3.fl.yelpcdn.com/ephoto/a7cuUCCabhJ5EKa9CgqoqA/o.jpg"),
				new Presidents ("", "$29","<img src = 'http://s3-media1.fl.yelpcdn.com/ephoto/VGncUbW6mRZPTPSArI80tw/o.jpg' height = '100px' width = '50px' />\' "),
				new Presidents ("Thomas  Jefferson", "$29", "http://www.americanpresidents.org/images/03_150.gif"),
				new Presidents ("James Madison", "$29","http://www.americanpresidents.org/images/04_150.gif"),
				new Presidents ("James Monroe",  "$29","http://www.americanpresidents.org/images/05_150.gif"),
				new Presidents ("John Quincy Adams", "$29","http://www.americanpresidents.org/images/06_150.gif"),
				new Presidents ("Andrew Jackson",  "$29","http://www.americanpresidents.org/images/07_150.gif"),
				new Presidents ("Martin Van Buren",  "$29","http://www.americanpresidents.org/images/08_150.gif"),
				new Presidents ("William Henry Harrison",  "$29","http://www.americanpresidents.org/images/09_150.gif"),
				new Presidents ("John Tyler",  "$29","http://www.americanpresidents.org/images/10_150.gif"),
				new Presidents ("James K. Polk",  "$29","http://www.americanpresidents.org/images/11_150.gif"),
				new Presidents ("Zachary Taylor",  "$29","http://www.americanpresidents.org/images/12_150.gif"),
				new Presidents ("Millard Fillmore",  "$29","http://www.americanpresidents.org/images/13_150.gif"),
				new Presidents ("Franklin Pierce",  "$29","http://www.americanpresidents.org/images/14_150.gif"),
				new Presidents ("James Buchanan", "$29","http://www.americanpresidents.org/images/15_150.gif"),
			};
			Label header = new Label {
				Text = "Events",
				Font = Font.SystemFontOfSize (35),
				HorizontalOptions = LayoutOptions.Center
			};

			// Create a data template from the type ImageCell
			var cell = new DataTemplate (typeof(ImageCell));

			cell.SetBinding (TextCell.TextProperty, "Name");
			cell.SetBinding (TextCell.DetailProperty, "Price");
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

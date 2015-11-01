using System;

namespace SwitchingTabbedPageDemo {
	public class Presidents{
	public Presidents(string name, string price, string image)
	{
		this.Name = name;
		this.Price = price;
		this.Image = image;
	}

	public string Name { private set; get; }

	public string Price { private set; get; }

	public string Image { private set; get; }
	
	
};

}

using System;

#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
#endif

namespace ThemeSample {
	public static class DataLoader {
		public static Recipe [] GetRecipes ()
		{
			var rec1 = new Recipe {
				Name = "Spaghetti Bolognese",
				PreparationTime = "2hrs 30",
				Country = "italian",
				Image = UIImage.FromFile("dish-bolognese.jpg"),
				PreparationSteps = new string [] {
					"Peel and chop the onions. Pour the olive oil into a sizeable saucepan, Bring the water to a boil. Add the olive oil and salt, then the spaghetti",
					"Heat it and fry the onions until translucent, use a timer to keep track of the cooking time (check the pasta package)", 
					"Add the mince and fry until the mince is brown and crumbly, Check at the lower end of the cooking time to see if they are done", 
					"Now add the wine, worcester sauce, spices, tomatoes, squeezed garlic, chili paste, honey and tomato concentrate, Turn on the cold water and rinse the spaghetti under the water"},
				Ingredients = new string [] {
					"1 kg chopped tomatoes(1100 grams)",
					"350 grams beef mince",	
					"2 onions",
					"60 grams tomato concentrate2",	
					"2 1/2 teaspoons\thoney (12 grams)" }
			};

			var rec2 = new Recipe {
				Name = "Spaghetti Carbonara",
				PreparationTime = "1hr 30",
				Country = "italian", 
				Image = UIImage.FromFile("dish-carbonara.jpg"),
				PreparationSteps = new string [] {
					"Cook the bacon, adjusting the heat as necessary to render fat out of the bacon, Peel and chop the onions. Pour the olive oil into a sizeable saucepan",
					"Quickly dump the pasta in the strainer and shake quickly, Heat it and fry the onions until translucent", 
					"Pour the contents of the frying pan (bacon and fat), Add the mince and fry until the mince is brown and crumbly", 
					"Now add the wine, worcester sauce, spices, tomatoes, squeezed garlic, chili paste, honey and tomato concentrate"
				},
				Ingredients = new string [] {
					"1 kg chopped tomatoes(1100 grams)",
					"350 grams beef mince",	
					"2 onions",
					"60 grams tomato concentrate2",	
					"2 1/2 teaspoons\thoney (12 grams)"
				}
			};

			var rec3 = new Recipe {
				Name = "Chicken Fajitas",
				PreparationTime = "1hr 30",
				Country = "mexican",
				Image = UIImage.FromFile("dish-fajitas.jpg"),
				PreparationSteps = new string [] {
					"Prepare the vegetables. De-seed the peppers",
					"Use the grater against one of the lime to get grated rind, Slice the chicken into thin slices of 3 centimeters long", 
					" Place the bowl on the side for about 30 minutes, Make the marinade", 
					"juices will soak into the chicken pieces, Place the shavings into a bowl, tomatoes"},
				Ingredients = new string [] {
					"2 boneless chicken breasts",
					"2 limes",
					"1/2 tablespoon caster sugar",
					"2 teaspoon dried oregano",
					"1/2 teaspoon cinnamon powder",
					"2 onions"
				}
			};

			var rec4 = new Recipe {
				Name = "Beef Stroganoff",
				PreparationTime = "1hr 30",
				Country = "russian",
				Image = UIImage.FromFile("dish-beef.jpg"),
				PreparationSteps = new string [] {
					"Cut away any excess fat from the beef, cook the beef strips quickly - cooking in about three batches",
					"Combine the flour and the sour cream in a small bowl, Season with salt and pepper", 
					"Add the onion and continue to cook a few minutes more, Heat a large frying pan until very hot", 
					"Add the oil and cook the beef strips quickly, Add the onion and continue to cook a few minutes more"
				},
				Ingredients = new string [] {
					"1 pound (600 gm) lean beef", 
					"6 - 8 white button mushrooms, sliced",
					"3 medium onions chopped",
					"2 cloves garlic, minced",
					"2 cups (500 ml) beef stock"
				}
			};

			return new Recipe[] { rec1, rec2, rec3, rec4 };
		}
	}
}


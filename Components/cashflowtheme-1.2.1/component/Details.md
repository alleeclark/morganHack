To style your app with theme from this application, call
`CashflowTheme.Apply` from your AppDelegate's `FinishedLaunching` method:

```csharp
using Xamarin.Themes;
...

public override bool FinishedLaunching (UIApplication app, NSDictionary options)
{
	...
	CashflowTheme.Apply ();
}
```
 
*Screenshot assembled with [PlaceIt](http://placeit.breezi.com/).*
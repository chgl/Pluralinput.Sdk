# Pluralinput.Sdk

## Code samples

### Basic usage
```csharp

using Pluralinput.Sdk;

...

// the InputManager initializes the SDK and
// should only be created once per application
var im = new InputManager();
// returns a list of all mouse devices
var mice = im.DeviceEnumerator.EnumerateMice();
// listen to the first mouse's button up event
mice.First().ButtonUp += (o, e) =>
{
    Console.WriteLine($"{o}: ButtonDown {e.Button}");
};
```
# Simple Password Generator
This library will generate a password given the options provided.

## Example
Use the Simple Password Generator like so:

```csharp
var generator = new Generator();
var myPassword = generator.Generate(passwordLength: 32, 
                                    Casing = Casing.Mixed,
                                    useSpecials: true,
                                    useNumerics: true,
                                    filter: "@");
```
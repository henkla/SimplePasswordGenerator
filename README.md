# Simple Password Generator
This library will generate a password given the options provided. It is a .NET Standard 2.0 library, so it works in both .NET Core and .NET Framework. It has no external dependencies and is light weight.

## Installation
First, install the nuget package. You can check out the package on the [NuGet website](https://www.nuget.org/packages/SimplePasswordGenerator/) if you like. To install it, chose your prefered method below:

##### Visual Studio Package Manager
```
Install-Package SimplePasswordGenerator -Version 1.2.0
```

##### Visual Studio NuGet manager
just search for `SimplePasswordGenerator`


##### .NET CLI
```
dotnet add package SimplePasswordGenerator --version 1.2.0
```

##### PackageReference
```
<PackageReference Include="SimplePasswordGenerator" Version="1.2.0" />
```

##### Paket CLI
```
paket add SimplePasswordGenerator --version 1.2.0
```

## Usage

Then, create the generator object:

```csharp
var generator = new Generator();
```
or, if you prefer to have more control of which characters to be uses as seed for the password:

```csharp
var generator = new Generator(letters: "abc", numerics: "123", specials: "@#?");
```
_NOTE: the letters, numerics and specials provided by default (if none are provided in the constructor as shown above) are:_
+ _letters: ABCDEFGHIJKLMNOPQRSTUVWXYZ_
+ _numerics: 1234567890_
+ _specials: !@#$%&[]()=?+*-\__

After that, you can generate your password by calling the generators `Generate()` function like so:

```csharp
var myPassword = generator.Generate(16);
```

where `16` is the desired length of your password. Any length beginning with 1 and ending with 1024 is valid. The type returned from `Generate()` is a simple string.

You can also provide additional parameters when generating passwords. All these parameters are optional. The default value of each follows each listing below:

+ `casing (Casing (enum))` - default: `Casing.Mixed`
+ `useSpecials (bool)` - default: `true` 
+ `useNumerics (bool)` - default: `true` 
+ `filter (string)` - default: `null` (no filter provided)

#### Filter
You can chose to filter out specific characters, i.e preventing those characters from ever ending up in the password generated. Simply provide the characters you want to avoid as a string for the `filter` parameter as shown above.

## Example
Here is a full example of how to use the generator, with all valid parameters provided for the sake of the demonstration:

```csharp

public class Program 
{
    static void Main(string[] args) 
    {
        var generator = new Generator(letters: "ABCDEFGHIJKLMNOPQRSTUVWXYZ", numerics: "1234567890", specials: "!@#$%&[]()=?+*-_");
        var myPassword = generator.Generate(passwordLength: 32, 
                                            casing = Casing.Mixed,
                                            useSpecials: true,
                                            useNumerics: true,
                                            filter: "@#?");

        Console.WriteLine($"The password is: {myPassword}");
    }
}
```

This will print out (at least in this case) the following in the console:
```
The password is: AwMHK)fzhQqKF*&ymoKu-Uofhp8lY5Ug
```
# Simple Password Generator
This library will generate a password given the options provided. It is a .NET Standard 2.0 library, so it works in both .NET Core and .NET Framework. It has no external dependencies and is light weight.

##### License
[![GitHub license](https://img.shields.io/github/license/Naereen/StrapDown.js.svg)](https://github.com/Naereen/StrapDown.js/blob/master/LICENSE)

## :gift: Provided in the repository
Here is a run-down of what the repository contains (at least the code parts):

##### SimplePasswordGenerator.**Example**
This is a .NET Core console application, making use of the library as a way to offer a quick showoff.

##### SimplePasswordGenerator.**Test**
The library itself is covered by unit tests (`xUnit`), which are hooked up in the CI/CD pipeline (`GitHub Actions`). In other words - no new package release will see the light of the day if any of the unit tests should fail.

#### SimplePasswordGenerator
This is the actual library itself. It consists of only three files, each representing a class (or enum). *I told you it was light-weight!*

---

## :hammer: Getting Started
First, install the nuget package. You can check out the package on the [NuGet website](https://www.nuget.org/packages/SimplePasswordGenerator/) if you like. To install it, chose your prefered method below:

##### Visual Studio Package Manager
```
Install-Package SimplePasswordGenerator -Version 1.2.0
```

##### Visual Studio NuGet manager
just search for `SimplePasswordGenerator`, select it and hit `install` 


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

---

## :key: Using the Simple Password Generator

Before generating a password, we need the actual generator. Create the generator object as shown below:

```csharp
var generator = new Generator();
```
or, if you prefer to have more control over which characters to be used as seed for the password:

```csharp
var generator = new Generator(letters: "abc", numerics: "123", specials: "@#?");
```

##### :bulb: Setting specials characters later on
It is possible to set the special characters at a later point (after the generator object has been created). Simply access the `Specials` field and provide whatever `string` value you like:

```csharp
var generator = new Generator();
generator.Specials = "!#@";
```

*__NOTE__: A blank space is not accepted and will throw a `GeneratorException` if provided. Also, any duplicate character will be removed. In other words - `@@!!@!` is equal to `@!`.*

##### :bulb: Default password seed
The letters, numerics and specials provided by default (if none are provided in the constructor as shown above) are:
+ _letters: **ABCDEFGHIJKLMNOPQRSTUVWXYZ**_
+ _numerics: **1234567890**_
+ _specials: **!@#$%&[]()=?+*-\_**_

After that, you can generate your password by calling the generators `Generate()` function like so:

```csharp
var myPassword = generator.Generate(16);
```

where `16` is the desired length of your password. Any length beginning with `1` and ending with `1024` is valid. The type returned from `Generate()` is a simple `string`.

You can also provide **additional** parameters when generating passwords. All these parameters are **optional**. The default value of each follows each listing below:

| Parameter                | Type     | Default value    |
| ------------------------ |:--------:| ---------------- |
| `casing`                 | **enum**   | `Casing.Mixed`   |
| `useSpecials`            | **bool**   | `true`           |
| `useNumerics`            | **bool**   | `true`           |
| `filter`                 | **string** | `null` (no filter provided) |

#### :bulb: How filters work
You can chose to filter out specific characters, i.e preventing those characters from ever ending up in the password generated. Simply provide the characters you want to avoid as a string for the `filter` parameter as shown above.

---

## :construction: Full blown example
Here is a full example of how to use the generator, with all valid parameters provided for the sake of the demonstration:

```csharp
public class Program 
{
    static void Main(string[] args) 
    {
        var generator = new Generator(letters: "ABCDEFGHIJKLMNOPQRSTUVWXYZ", 
                                      numerics: "1234567890", 
                                      specials: "!@#$%&[]()=?+*-_");

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

---

## :no_entry: What if something goes wrong?
If anything goes wrong, the Simple Password Generator will throw a `GeneratorException` (which is an extension of `ApplicationException`). That way, you can easily cherry pick exceptions that originates from the generator specifically, without having to parse any exception origin.

##### Example
``` csharp
try
{
    var generator = new Generator();
    var myPassword = generator.Generate(1025);
    Console.WriteLine($"The password is: {myPassword}");
}
catch (GeneratorException e)
{
    Console.WriteLine($"Error: {e.Message}");
    // do what you like
}
```

---

## :construction_worker: To be implemented
+ Accept only alpha's in the `letters` parameter
+ Accept only numerics in the `numerics` parameter
+ Make sure the final seed has no duplicates
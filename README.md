# Simple Password Generator
This library will generate a password given the options provided.

## Usage
First, install the nuget package:

#### Visual Studio Package Manager
```
Install-Package SimplePasswordGenerator -Version 1.2.0
```

#### .NET CLI
```
dotnet add package SimplePasswordGenerator --version 1.2.0
```

#### PackageReference
```
<PackageReference Include="SimplePasswordGenerator" Version="1.2.0" />
```

#### Paket CLI
```
paket add SimplePasswordGenerator --version 1.2.0
```

Then, create the generator object:

```csharp
var generator = new Generator();
```
or if you prefer to have more control of which characters to use as seed for the password:

```csharp
var generator = new Generator(letters: "abc", numerics: "123", specials: "@#?");
```
_NOTE: the letters, numerics and specials provided by default are:_
+ _letters: ABCDEFGHIJKLMNOPQRSTUVWXYZ_
+ _numerics: 1234567890_
+ _specials: !@#$%&[]()=?+*-\__

Then, 

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
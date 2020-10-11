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

After that, you can generate your password by calling the generators `Generate()` function like so:

```csharp
var myPassword = generator.Generate(16);
```

where `16` is the desired length of your password. Any length beginning with 1 and ending with 1024 is valid. 

You can also provide additional parameters when generating passwords. All these parameters are optional. The default value of each follows each listing below:

+ `casing (Casing (enum))` - default: `Casing.Mixed`
+ `useSpecials (bool)` - default: `true` 
+ `useNumerics (bool)` - default: `true` 
+ `filter (string)` - default: `null` (no filter provided)

## Example
Use the Simple Password Generator like so:



```csharp
var generator = new Generator();
var myPassword = generator.Generate(passwordLength: 32, 
                                    casing = Casing.Mixed,
                                    useSpecials: true,
                                    useNumerics: true,
                                    filter: "@");
```
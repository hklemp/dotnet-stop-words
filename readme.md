# dotnet-stop-words
Get list of common stop words in various languages in dotnet. Based on the list of [Alir3z4](https://github.com/Alir3z4/stop-words/)    
[![NuGet version (dotnet-stop-words)](https://img.shields.io/nuget/v/dotnet-stop-words.svg?style=flat-square)](https://www.nuget.org/packages/dotnet-stop-words/)
[![Build Status](https://travis-ci.org/hklemp/dotnet-stop-words.svg?branch=master)](https://travis-ci.org/hklemp/dotnet-stop-words/)


## Available languages
* Arabic
* Bulgarian
* Catalan
* Czech
* Danish
* Dutch
* English
* Finnish
* French
* German
* Hindi
* Hungarian
* Indonesian
* Italian
* Norwegian
* Polish
* Portuguese
* Romanian
* Russian
* Slovak
* Spanish
* Swedish
* Turkish
* Ukrainian
* Vietnamese
 
## Installation
``` bash
Install-Package dotnet-stop-words -Version 1.0.2
``` 
or
``` bash
dotnet add package dotnet-stop-words --version 1.0.2
``` 
or
``` bash
paket add dotnet-stop-words --version 1.0.2
``` 

## Usage
```csharp
var testString = "Hello this is a test";
var newString = s.RemoveStopWords("en");
// newstring is now Hello
```

```csharp
var stopWords = StopWords.GetStopWords("en");
// stopWords has a list of all englisch stop words
```

# Support for .NET 5.0
.NET 5.0 Preview 1 was released on 16th March 2020. 

- [Announcing .NET 5 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-1/)
- [Download .NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/5.0)

Preview 1 uses the C# 8.0 compiler so there aren't any new language features. Preview 1 also does not include any new features for the base class libraries or app models like ASP.NET Core. .NET 5.0 Preview 1 is functionally equivalent to a .NET Core 3.1.1 since it only includes a few bug fixes. 

I expect Microsoft to release new previews each month until the final version in November 2020. 

## Most chapters
The code examples in most of the chapters in the fourth edition work with .NET 5.0, and of course all of the code examples are 100% compatible with either .NET Core 3.0 or .NET Core 3.1.

After installing the .NET 5.0 SDK, following the step-by-step instructions in the book should work as normal since the project file will automatically reference .NET 5.0 as the target framework. 

To upgrade a console application solution from the GitHub repository from .NET Core 3.1 to .NET 5.0 simply requires a version number change in your project file.

Change this:
```
<TargetFramework>netcoreapp3.0</TargetFramework>
```
To this:
```
<TargetFramework>netcoreapp5.0</TargetFramework>
```
For projects that use additional NuGet packages, use the equivalent Preview 1 package version instead of the version given in the book. 
## Chapter 4
For the `Instrumenting` project, the additional referenced NuGet packages should use the Preview 1 versions, as shown in the following markup: 
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="5.0.0-preview.1.20120.4" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="5.0.0-preview.1.20120.4" />
    <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="5.0.0-preview.1.20120.4" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="5.0.0-preview.1.20120.4" />
  </ItemGroup>

</Project>
```
For the `CalculatorLibUnitTests` project, the additional referenced NuGet packages for unit testing can use the latest versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp5.0</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.6.0-preview-20200318-01" />
    <PackageReference Include="xunit" Version="2.4.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.1" />
    <PackageReference Include="coverlet.collector" Version="1.2.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference 
      Include="..\CalculatorLib\CalculatorLib.csproj" />
  </ItemGroup>

</Project>
```

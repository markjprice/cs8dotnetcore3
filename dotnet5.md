# Support for .NET 5.0
.NET 5.0 Preview 1 was released on 16th March 2020. Most chapters in the fourth edition work with this version, as well as .NET Core 3.0 and .NET Core 3.1.
- [Announcing .NET 5 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-1/)
- [Download .NET 5.0](https://dotnet.microsoft.com/download/dotnet-core/5.0)
## Most chapters
After installing the .NET 5.0 SDK, to upgrade a console application from .NET Core 3.0 to .NET 5.0 simply requires a version number change in your project file.
Change this:
```
<TargetFramework>netcoreapp3.0</TargetFramework>
```
To this:
```
<TargetFramework>netcoreapp5.0</TargetFramework>
```
## Chapter 4
For the `Instrumenting` project, the additional NuGet packages should use the Preview 1 versions, as shown in the following markup: 
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
For the `CalculatorLibUnitTests` project, the additional NuGet packages should use the Preview 1 versions, as shown in the following markup:
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

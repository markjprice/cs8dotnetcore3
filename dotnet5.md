# Support for .NET 5.0
.NET 5.0 Preview 1 was released on 16th March 2020. Most chapters in the fourth edition work with this version.
- [Announcing .NET 5 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-1/)
- [Download .NET 5.0](https://dotnet.microsoft.com/download/dotnet-core/5.0)
To upgrade a console application from .NET Core 3.0 to .NET 5.0 simply requires a small change in your project file.
Change this:
```
<TargetFramework>netcoreapp3.0</TargetFramework>
```
To this:
```
<TargetFramework>netcoreapp5.0</TargetFramework>
```

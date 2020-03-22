# December 2019 update for .NET Core 3.1
.NET Core 3.0 was released on 23rd September 2019. This version is a Current release meaning that three months after a subsequent release it loses official support. 
.NET Core 3.1 was released on 3rd December 2019. This version is a Long Term Support (LTS) release meaning that it will be supported for three years. Microsoft recommends all .NET Core developers upgrade to .NET Core 3.1 as soon as possible.
- [Announcing .NET Core 3.1](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-1/)
- [Download .NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
## Chapters 1 to 16, 18 and 19
18 of the 21 chapters in the fourth edition of this book work with either .NET Core 3.0 or .NET Core 3.1. 
To upgrade a console application from .NET Core 3.0 to .NET Core 3.1 simply requires a small change in your project file.

Change this:
```
<TargetFramework>netcoreapp3.0</TargetFramework>
```
To this:
```
<TargetFramework>netcoreapp3.1</TargetFramework>
```
The projects for chapters 1 to 19 in this GitHub repository have been upgraded to .NET Core 3.1, as shown in the following screenshot:

![GitHub update to .NET Core 3.1](github-update-30-to-31.png)
## Chapter 17 and Piranha CMS
See [Upgrading to Piranha CMS 8.1](piranha-cms.md)
## Chapter 20 and Windows Desktop Apps
### Windows Forms and WPF apps
As with console applications, for Windows Forms and WPF apps, simply change the target framework to 3.1.
### Universal Windows Platform apps
UWP apps use a custom version of .NET Core.
## Chapter 21 and Mobile apps
Mobile apps currently use Xamarin so they are not affected by .NET Core 3.1.

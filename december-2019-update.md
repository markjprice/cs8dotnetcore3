# December 2019 update for .NET Core 3.1
.NET Core 3.0 was released on 23rd September 2019. This version is a Current release meaning that three months after the release of a subsequent release it loses official support. 
.NET Core 3.1 was released on 3rd December 2019. This version is a Long Term Support (LTS) release meaning that it will be supported for three years. Microsoft recommends all .NET Core developers upgrade to .NET Core 3.1 as soon as possible.
- [Announcing .NET Core 3.1](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-1/)
- [Download .NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
## Chapters 1 to 16, 18 and 19
All but three of the chapters in the fourth edition of this book were written using .NET Core 3.0. 
Any projects that target .NET Core 3.0 must upgrade to .NET Core 3.1 by 3rd March 2020.
To upgrade from .NET Core 3.0 to .NET Core 3.1 simply requires a change in your project file.
Change this:
```
<TargetFramework>netcoreapp3.0</TargetFramework>
```
To this:
```
<TargetFramework>netcoreapp3.1</TargetFramework>
```
## Chapter 17 and Piranha CMS
Chapter 17 was written using Piranha CMS 7.0 that targets .NET Core 2.2. This version loses support three months after the release of .NET Core 3.0 meaning on 23rd December 2019. 
The solution code for this chapter has been updated to use Piranha CMS 8.0 which targets .NET Core 3.1.
[Announcing 8.0 for .NET Core 3.1](http://piranhacms.org/blog/announcing-80-for-net-core-31)

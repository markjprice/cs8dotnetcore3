# Fourth Edition's support for .NET 5.0
Microsoft originally hoped that .NET 5.0 would unify all .NET platforms including mobile development using Xamarin but that plan is delayed; "we expect these features to be available in preview by November 2020, but the unification will be truly completed with .NET 6, our Long-Term Support (LTS) release. Our vision hasn’t changed, but our timeline has."

Microsoft will release new previews of .NET 5.0 regularly until the final version in November 2020. They say, "We expect that the release will be feature-complete with Preview 8." I plan to keep this page updated with any necessary changes to support the code examples in the fourth edition of my book.

- [Download .NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/5.0)
- November 10, 2020: Announcing .NET 5.0 (coming soon)
- October, 2020: Announcing .NET 5.0 Release Candidate 2 (coming soon)
- September 14, 2020: [Announcing .NET 5.0 RC 1](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-rc-1/)
- August 25, 2020: [Announcing .NET 5.0 Preview 8](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-8/)
- July 21, 2020: [Announcing .NET 5.0 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-7/)
- June 25, 2020: [Announcing .NET 5.0 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-6/)
- June 10, 2020: [Announcing .NET 5.0 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-5/)
- May 19, 2020: [Announcing .NET 5 Preview 4 and our journey to one .NET](https://devblogs.microsoft.com/dotnet/announcing-net-5-preview-4-and-our-journey-to-one-net/)
- April 23, 2020: [Announcing .NET 5 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-3/)
- April 2, 2020: [Announcing .NET 5 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-2/)
- March 16, 2020: [Announcing .NET 5 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-net-5-0-preview-1/)

Preview 4 and later can use the C# 9.0 compiler but many new C# language features like those discussed in the following link are not yet supported: [Welcome to C# 9.0](https://devblogs.microsoft.com/dotnet/welcome-to-c-9-0/)

To use the C# 9.0 compiler, add an element to set language version to preview in your project file:
```
<LangVersion>preview</LangVersion>
```
## Chapters 1 to 19
After [downloading](https://dotnet.microsoft.com/download/dotnet-core/5.0) and installing .NET 5.0 SDK, follow the step-by-step instructions in the book and they should work as expected since the project file will automatically reference .NET 5.0 as the target framework. 

To upgrade a project in the GitHub repository from .NET Core 3.1 to .NET 5.0 just requires a target framework change in your project file.

Change this:
```
<TargetFramework>netcoreapp3.1</TargetFramework>
```
To this:
```
<TargetFramework>net5.0</TargetFramework>
```
Previews 1 to 2 used `netcoreapp5.0` as the target framework name. This changed to `net5.0` in Preview 3 and later as described in detail at the following link: https://github.com/dotnet/designs/blob/master/accepted/2020/net5/net5.md

For projects that reference additional NuGet packages, use the latest NuGet package version (including preview versions), as shown in the rest of this page, instead of the version given in the book.

If I have not updated this page immediately after a new preview is released then you can search for the correct NuGet package version numbers yourself at the following link: https://www.nuget.org

## Chapter 4 - Writing, Debugging, and Testing Functions
For the `Instrumenting` project, the additional referenced NuGet packages should use the latest preview versions, as shown in the following markup: 
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="5.0.0-preview.*" />
  </ItemGroup>

</Project>
```
For the `CalculatorLibUnitTests` project, the additional referenced NuGet packages for unit testing can use the latest versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.7.0-*" />
    <PackageReference Include="xunit" Version="2.4.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.1" />
    <PackageReference Include="coverlet.collector" Version="1.3.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference 
      Include="..\CalculatorLib\CalculatorLib.csproj" />
  </ItemGroup>

</Project>
```
## Chapter 11 - Working with Databases Using Entity Framework Core
For the `WorkingWithEFCore` project, the additional referenced NuGet packages should use the preview versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="5.0.0-preview.*" />
  </ItemGroup>

</Project>
```
## Chapter 12 - Querying and Manipulating Data Using LINQ
For the `LinqWithEFCore` and `Exercise02` projects, the additional referenced NuGet packages should use the preview version, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.0-preview.*" />
  </ItemGroup>

</Project>
```
## Chapter 14 - Practical Applications of C# and .NET
For the `NorthwindContextLib` project, the referenced NuGet package for SQLite should use the preview version, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindEntitiesLib\NorthwindEntitiesLib.csproj" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SQLite" Version="5.0.0-preview.*" />
  </ItemGroup>

</Project>
```
## Chapter 16 - Building Websites Using the Model-View-Controller Pattern
For the `NorthwindMvc` project, the referenced NuGet packages should use the preview versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
    <UserSecretsId>aspnet-NorthwindMvc-72F8E5E5-AF15-4520-91A9-EF8090AF2961</UserSecretsId>
  </PropertyGroup>

  <ItemGroup>
    <None Update="app.db" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.0-preview.*" />
    
    <!-- added in Chapter 18 to call a web service -->
    <PackageReference Include="Newtonsoft.Json" Version="12.0.3" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />
  </ItemGroup>

</Project>
```
## Chapter 17 - Building Websites Using a Content Management System
Also read [Upgrading to Piranha CMS 8.1 or later](piranha-cms.md)

For the `NorthwindCms` project, the referenced NuGet packages should use the latest or preview versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <Folder Include="wwwroot\" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.0-preview.*" />
    <PackageReference Include="Piranha" Version="8.3.0" />
    <PackageReference Include="Piranha.AspNetCore" Version="8.3.0" />
    <PackageReference Include="Piranha.AspNetCore.Identity.SQLite" Version="8.3.0" />
    <PackageReference Include="Piranha.AttributeBuilder" Version="8.3.0" />
    <PackageReference Include="Piranha.Data.EF.SQLite" Version="8.3.0" />
    <PackageReference Include="Piranha.ImageSharp" Version="8.3.0-rc1" />
    <PackageReference Include="Piranha.Local.FileStorage" Version="8.3.0" />
    <PackageReference Include="Piranha.Manager" Version="8.3.0" />
    <PackageReference Include="Piranha.Manager.TinyMCE" Version="8.3.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindEntitiesLib\NorthwindEntitiesLib.csproj" />
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />
  </ItemGroup>

</Project>
```
## Chapter 18 - Building and Consuming Web Services
For the `NorthwindService` project, the referenced NuGet packages should use the latest or preview versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />

    <PackageReference Include="Swashbuckle.AspNetCore" Version="5.4.1" />
    <PackageReference Include="Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore" 
                      Version="5.0.0-preview.*" />
  </ItemGroup>

</Project>
```
## Chapter 19 - Building Intelligent Apps Using Machine Learning
For the `NorthwindML` project, the referenced NuGet packages should use the latest or preview versions, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.0-preview.*" />
    <PackageReference Include="Microsoft.ML" Version="1.5.0" />
    <PackageReference Include="Microsoft.ML.Recommender" Version="0.17.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />
    <ProjectReference Include="..\NorthwindEmployees\NorthwindEmployees.csproj" />
  </ItemGroup>

</Project>
```

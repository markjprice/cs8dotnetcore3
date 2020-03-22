# Upgrading to Piranha CMS 8.1
[Announcing 8.0 for .NET Core 3.1](http://piranhacms.org/blog/announcing-80-for-net-core-31)

Chapter 17 was written using Piranha CMS 7.0 that targets .NET Core 2.2. The solution code for this chapter has been updated to use Piranha CMS 8.1 which targets .NET Core 3.1. As well as targetting .NET Core 3.1, Piranha CMS 8.0 and 8.1 have the following changes that affect Chapter 17.
## Page 557 - Creating and exploring a Piranha CMS website
The project file will use Piranha CMS NuGet packages version 8.1, as shown in the following markup:
```
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <Folder Include="wwwroot\" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="3.1.0" />
    <PackageReference Include="Piranha" Version="8.1.0" />
    <PackageReference Include="Piranha.AspNetCore" Version="8.1.0" />
    <PackageReference Include="Piranha.AspNetCore.Identity.SQLite" Version="8.1.0" />
    <PackageReference Include="Piranha.AttributeBuilder" Version="8.1.0" />
    <PackageReference Include="Piranha.Data.EF.SQLite" Version="8.1.2" />
    <PackageReference Include="Piranha.ImageSharp" Version="8.1.0-rc1" />
    <PackageReference Include="Piranha.Local.FileStorage" Version="8.1.0" />
    <PackageReference Include="Piranha.Manager" Version="8.1.0" />
    <PackageReference Include="Piranha.Manager.TinyMCE" Version="8.1.0" />
  </ItemGroup>

</Project>
```
## Page 567 - Reviewing the blog archive
The **Save** button does not have a dropdown arrow with **Preview** as an option. Instead, there is a separate Preview icon button.
## Page 569 - Exploring authentication and authorization
When creating a new user, the prompt placeholder text has not been localized into English.
## Page 579 - Reviewing some content types
`ArchivePage<T>` has been replaced with a `Page<T>`, the `[PageType]` attribute now has a parameter named `IsArchive` that should be set to `true`, and a property named `Archive` of type `PostArchive<DynamicPost>`. 
## Page 587 - Creating custom regions
The `[Field]` attribute has moved from the `Piranha.AttributeBuilder` namespace to the `Piranha.Extend` namespace.
## Page 588 - Creating an entity data model
Now that Piranha CMS 8.0 is compatible with .NET Core 3.1, we can reuse both the entities and database context libraries instead of needing to recreate a local database context.
```
<ItemGroup>
  <ProjectReference Include=
    "..\NorthwindEntitiesLib\NorthwindEntitiesLib.csproj" />
  <ProjectReference Include=
    "..\NorthwindContextLib\NorthwindContextLib.csproj" />
</ItemGroup>
```
## Page 589 - Creating custom page types
The `[Region]` attribute has moved from the `Piranha.AttributeBuilder` namespace to the `Piranha.Extend` namespace.
## Page 595 - Configuring start up and importing from a database
In Piranha CMS 7.0, `PageTypeBuilder` was used to manually add each page type. This has been replaced with `ContentTypeBuilder` that only needs to have an assembly added and all content types in that assembly will be registered.
## Page 597 - Configuring start up and importing from a database
The `Page<T>.Create` method has been replaced by the `Page<T>.CreateAsync()` method. 

In `ImportController.cs`, change the following code:
```
categoryPage = CategoryPage.Create(api);
```
To:
```
categoryPage = await CategoryPage.CreateAsync(api);
```
The `GetAllAsync()` extension method has been replaced by `GetAllByFolderIdAsync()` with no folder ID passed.

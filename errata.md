# Errata
## Page 14 - Comparing .NET technologies
In the table row for Xamarin, the description should be "Mobile _and desktop_ apps only."
## Page 30 - Discovering your C# compiler versions
In Step 5, the command `csc -langversion:?` works on macOS but on Windows it returns the error `The name "csc" is not recognized as the name of a command, function, script file, or executable program. Check the spelling of the name, as well as the presence and correctness of the path.` To fix this issue, use the following link: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/command-line-building-with-csc-exe
## Page 63 - Getting key input from the user
In the first paragraph, the second sentence:
"This method waits for the user to type some text, then as soon as the user presses Enter, whatever the user has typed is returned as a `string` value."
Should be:
"This method waits for the user to press a key or key combination that is then returned as a `ConsoleKeyInfo` value."
## Page 203 - Managing memory with reference and value types
In the second paragraph, the phrase "first-in, first-out" should be "last-in, first-out".
## Page 217 - Inheriting exceptions
In Step 3, the variable named `e1` should be named `john`.
## Page 363 - Creating the Northwind sample database for SQLite
If the < character is not supported on your operating system because you use a non-English language, try using `sqlite3 Northwind.db ".read Northwind.sql"` or `sqlite3 Northwind.db -init Northwind.sql`
## Page 374 - Filtering and sorting products
In Step 1, the LINQ query requires an explicit call to the `AsEnumerable` method to force execution on the client-side because the final release version of EF Core 3.0 dropped support for server-side sorting using SQLite Money type.
```
IOrderedEnumerable<Product> prods = db.Products
  .AsEnumerable() ' force execution on client-side
  .Where(product => product.Cost > price)
  .OrderByDescending(product => product.Cost);
```
## Page 503 - Using Razor class libraries
In Step 4, the command: `dotnet new razorclasslib` should be: `dotnet new razorclasslib -s` or `dotnet new razorclasslib --support-pages-and-views`

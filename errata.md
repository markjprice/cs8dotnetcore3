# Errata
If you find any mistakes in the fourth edition, C# 8.0 and .NET Core 3.0, then please raise an issue in this repository or email me at markjprice (at) gmail.com. All of the errata listed below have been corrected in the [fifth edition](https://github.com/markjprice/cs9dotnet5).

## Page 14 - Comparing .NET technologies
In the table row for Xamarin, the description should be "Mobile _and desktop_ apps only."

## Page 30 - Discovering your C# compiler versions
In steps 5 and 6, I show the C# compiler (csc) command listing the supported language versions on macOS. I regret including steps 5 and 6 because they cause some readers problems without adding any real value because the csc command is never used again. In the next edition I will remove steps 5 and 6. I recommend that readers skip over steps 5 and 6.

In Step 5, the command `csc -langversion:?` shoyld work on macOS but on Windows it returns the error `The name "csc" is not recognized as the name of a command, function, script file, or executable program. Check the spelling of the name, as well as the presence and correctness of the path.` To fix this issue, use the following link: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/command-line-building-with-csc-exe

## Page 47 - Comparing double and decimal types

In the book, I say that the `double` type has some special static members, including one named `Infinity`. This is wrong. There are two members named `PositiveInfinity` and `NegativeInfinity`.

## Page 47 - Using Visual Studio Code workspaces

The book says, "Visual Studio has a feature called workspaces that enables this." It should have said, "Visual Studio **Code** has a feature called workspaces that enables this."

## Page 49 - Storing dynamic types

In the code example, I show assigning a `string` value to a dynamically-typed variable, as shown in the following code:

```cs
// storing a string in a dynamic object
dynamic anotherName = "Ahmed";

// this compiles but would throw an exception at run-time
// if you later store a data type that does not have a 
// property named Length
int length = anotherName.Length;
```

The above example code does not throw an exception because at the time we get the `Length` property, the value stored in `anotherName` is a `string` which does have a `Length` property.

The example would have been clearer if I had shown some examples of assigning values with other data types that do and do not have a `Length` property, as shown in the following code:

```cs
// storing a string in a dynamic object
// string has a Length property
dynamic anotherName = "Ahmed";

// int does not have a Length property
anotherName = 12;

// an array of any type has a Length property
// anotherName = new[] { 3, 5, 7 };

// this compiles but would throw an exception at run-time
// if you had stored a value with a data type that does not 
// have a property named Length
int length = anotherName.Length;
```

The above example code does throw an exception because at the time we get the `Length` property, the value stored in `anotherName` is an `int` which does not have a `Length` property, as shown in the following output:

```
Unhandled exception. Microsoft.CSharp.RuntimeBinder.RuntimeBinderException: 'int' does not contain a definition for 'Length'
   at CallSite.Target(Closure , CallSite , Object )
   at System.Dynamic.UpdateDelegates.UpdateAndExecute1[T0,TRet](CallSite site, T0 arg0)
   at Variables.Program.Main(String[] args) in /Users/markjprice/Code/Chapter02/Variables/Program.cs:line 34
```

If you uncomment the statement that assigns an array of `int` values, then the code works without throwing an exception because all arrays have a `Length` property.

## Page 58 - Exploring console applications further
The command line example of passing arguments used `-name`, as shown in the following command:
```
dotnet new console -lang "F#" -name "ExploringConsole"
```
But it should use `--name`, as shown in the following command:
```
dotnet new console -lang "F#" --name "ExploringConsole"
```

## Page 63 - Getting key input from the user
In the first paragraph, the second sentence:

"This method waits for the user to type some text, then as soon as the user presses Enter, whatever the user has typed is returned as a `string` value."

Should be:

"This method waits for the user to press a key or key combination that is then returned as a `ConsoleKeyInfo` value."

## Page 84 - Pattern matching with the switch statement
In Step 2, you write code to open a file and then branch depending on its properties, for example to show if it is readonly or writeable. Since the code to open the file always uses the default of read/write, then the switch statement will always use the first branch indicating that it is writeable. It will never be readonly or a memory stream or use the default branchg or be null.

If you manually change the file in your filesystem to be readonly and run the code again, then the file open code throws an exception unless you change the code to open the file readonly.

To make the example code a little more interesting but still very artificial, then modify the statements as shown in the following code:
```cs
string path = "/Users/markjprice/Code/Chapter03";
// string path = @"C:\Code\Chapter03";

Write("Press R for readonly or W for write: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();

Stream s = null;

if (key.Key == ConsoleKey.R)
{
  s = File.Open(
    Path.Combine(path, "file.txt"),
    FileMode.OpenOrCreate,
    FileAccess.Read);
}
else
{
  s = File.Open(
    Path.Combine(path, "file.txt"),
    FileMode.OpenOrCreate,
    FileAccess.Write);
}

string message = string.Empty;

switch (s)
{
  case FileStream writeableFile when s.CanWrite:
    message = "The stream is a file that I can write to.";
    break;
  case FileStream readOnlyFile:
    message = "The stream is a read-only file.";
    break;
  case MemoryStream ms:
    message = "The stream is a memory address.";
    break;
  default: // always evaluated last despite its current position
    message = "The stream is some other type.";
    break;
  case null:
    message = "The stream is null.";
    break;
}

WriteLine(message);
```

## Page 113 - Writing a function that returns a value
The `switch case` value of `ME` is commented as Maryland. `ME` is the abbreviation for Maine.

## Page 114 - Writing a function that returns a value
In Step 2, the code block calls a method named `RunSalesTax`. The method name should be `RunCalculateTax`:
```cs
// RunTimesTable();
RunCalculateTax();
```

## Page 117 - Calculating factorials with recursion

In Step 1, the `Factorial` function does not check for overflows and the `RunFactorial` function prompts the user to enter a number and then calculates its factorial. This led me to incorrectly state that the `Factorial` function overflows when passed integers of 32 or higher when it will actually overflow when passed integers of 13 or higher. Improved implementations of the two functions that illustrate this are shown in the following code: 

```cs
static int Factorial(int number)
{
  if (number < 1)
  {
    return 0;
  }
  else if (number == 1)
  {
    return 1;
  }
  else
  {
    checked // for overflow
    {
      return number * Factorial(number - 1);
    }
  }
}

static void RunFactorial()
{
  for (int i = 1; i < 15; i++)
  {
    try
    {
      WriteLine($"{i}! = {Factorial(i):N0}");
    }
    catch (System.OverflowException)
    {
      WriteLine($"{i}! is too big for a 32-bit integer.");
    }
  }
}
```

## Page 154 - Storing multiple values using an enum type
The table that represents a byte on this page should not have a zero column.

## Page 203 - Managing memory with reference and value types
In the second paragraph, the phrase "first-in, first-out" should be "last-in, first-out".

## Page 209 - Hiding members
In Step 1, I tell you to implement the `WriteToConsole` method, as shown in the following code:

```cs
WriteLine(format:
 "{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}",
 arg0: Name,
 arg1: DateOfBirth,
 arg2: HireDate)); // <- one too many close parenthesis
 ```
 Should be:
 ```cs
 WriteLine(format:
 "{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}",
 arg0: Name,
 arg1: DateOfBirth,
 arg2: HireDate);
 ```

## Page 217 - Inheriting exceptions
In Step 3, the variable named `e1` should be named `john`.

## Page 262 - Understanding the syntax of a regular expression
In the table of common symbols, the entries for `\w` and `\W` should have meanings of word characters and NON-word characters. The symbol for whitespace is `\s`, and for NON-whitespace is `\S`.

## Page 264 - Splitting a complex comma-separated string
In Step 2, I use a complex regular expression to split a comma-separated string but I neglected to include the link to the Stack Overflow discussion that explains how it works: [Regex to split a CSV](https://stackoverflow.com/questions/18144431/regex-to-split-a-csv)

## Page 275 - Using indexes and ranges
In Step 2, the expression to set the startIndex to get the last name can be simplified. Change:
```cs
string lastName = name.Substring(
  startIndex: name.Length - (name.Length - indexOfSpace - 1),
  length: name.Length - indexOfSpace - 1);
```
To:
```cs
string lastName = name.Substring(
  startIndex: indexOfSpace + 1,
  length: name.Length - indexOfSpace - 1);
```
## Page 281 - Reading assembly metadata
In Step 3, there is a missing variable named `assembly` in the printed book (it is correct in the GitHub repo file). 

Change:
```cs
Assembly = Assembly.GetEntryAssembly();
```
To:
```cs
Assembly assembly = Assembly.GetEntryAssembly();
```

## Page 309 - Compressing streams

In Step 2, I say, `GZipSteam`. It should say, `GZipStream`.

## Pages 338 to 340 - Encrypting symmetrically with AES

The code uses 2000 iterations for PBKDF2 and I said this is "double the recommended salt size and iteration count". I first wrote that code and statement in the fall of 2015 for the first edition and I have neglected to keep it updated. More than five years later, 2000 is not enough! 

To avoid updating the value every edition, what I will say in the sixth edition is that the best iteration count for PBKDF2 is whatever number takes about 100ms on the target machine. Now that anyone can buy a $699 Apple Mac mini with amazing performance, that recommendation could be closer to 100,000 iterations. And that value will only increase as time passes. 

As I said on page 334, "If security is important to you (and it should be!), then hire an experienced security expert for guidance rather than relying on advice found online." Or in a generalist programming book.

## Page 339 - Hashing with the commonly used SHA256
To make it easier to complete Exercise 10.3, I have split the `CheckPassword` method into two overloaded methods, as shown in the following code:
```cs
// check a user's password that is stored
// in the private static dictionary Users
public static bool CheckPassword(string username, string password)
{
  if (!Users.ContainsKey(username))
  {
    return false;
  }

  var user = Users[username];

  return CheckPassword(username, password, 
    user.Salt, user.SaltedHashedPassword);
}

// check a user's password using salt and hashed password
public static bool CheckPassword(string username, string password, 
  string salt, string hashedPassword)
{
  // re-generate the salted and hashed password 
  var saltedhashedPassword = SaltAndHashPassword(
    password, salt);

  return (saltedhashedPassword == hashedPassword);
}
```

## Page 363 - Creating the Northwind sample database for SQLite
- In Step 2, I say to download the SQL script. It is easier if you have created a local Git repository as explained in Chapter 1. Then you can simply copy the SQL script file from your local repository folder.
- In Step 4, if the `<` character is not supported on your operating system because you use a non-English language, try using
```
sqlite3 Northwind.db ".read Northwind.sql"
```
or 
```
sqlite3 Northwind.db -init Northwind.sql
```
and then press `Ctrl` + `D` to exit SQLite command mode.

## Page 375 - Filtering and sorting products

In Step 3, we run the console application but the `QueryingProducts` method throws an exception because the final release version of EF Core 3.0 dropped support for server-side sorting using SQLite Money type, as shown in the following output: 

```
Unhandled exception. System.InvalidOperationException: The LINQ expression 'DbSet<Product>
    .Where(p => p.Cost > __price_0)' could not be translated. Either rewrite the query in a form that can be translated, or switch to client evaluation explicitly by inserting a call to either AsEnumerable(), AsAsyncEnumerable(), ToList(), or ToListAsync().
```
There are multiple ways to "fix" this. The exception detail suggests adding an explicit call to the `AsEnumerable` method to force execution on the client-side (which requires us to also change the query variable type to `IOrderedEnumerable<Product>`), as shown in the following code:
```cs
IOrderedEnumerable<Product> prods = db.Products
  .AsEnumerable() ' force execution on client-side
  .Where(product => product.Cost > price)
  .OrderByDescending(product => product.Cost);
```

A more efficient "fix" would be to specify in the `Northwind` database context class that you created on page 372 that the `Product` entity class property named `Cost` (that is a nullable `decimal` type) can be converted to a type like `double` that *is* supported, as shown in the following code:

```cs
modelBuilder.Entity<Product>()
  .Property(product => product.Cost)
  .HasConversion<double>();
```

## Page 407 - Building an EF Core model
This is the same issue as on Page 375 above. To fix it, in Step 2, add an OnModelCreating method, as shown in the following code:
```cs
protected override void OnModelCreating(
  ModelBuilder modelBuilder)
{
  modelBuilder.Entity<Product>()
    .Property(product => product.UnitPrice)
    .HasConversion<double>();
}
```

## Page 412 - Joining and grouping sequences
In Step 1, the query does not specify a sort order. The old behavior sorted by category (as described in the book) but the current behavior sorts by product. To sort by category, add a call to `OrderBy` at the end of the query, as shown in the following code:

```cs
// join every product to its category to return 77 matches 
var queryJoin = db.Categories.Join(
  inner: db.Products,
  outerKeySelector: category => category.CategoryID, 
  innerKeySelector: product => product.CategoryID, 
  resultSelector: (c, p) =>
    new { c.CategoryName, p.ProductName, p.ProductID })
  .OrderBy(cp => cp.CategoryName);
```

## Page 423 - Creating your own LINQ extension methods
In Step 2, the logic for the `Mode` method is wrong. Since we sort by default in ascending order, the most frequent number will be last but in the book code we return the first item. We could fix this by calling `LastOrDefault`, but when debugging it is easiest if the data we are interested in appear at the top of the results, so the best way to fix this is to sort in descending order, as shown in the following code:
```cs
public static int? Mode(this IEnumerable<int?> sequence)
{
  var grouped = sequence.GroupBy(item => item);
  var orderedGroups = grouped.OrderByDescending(group => group.Count());
  return orderedGroups.FirstOrDefault().Key;
}
```
And:
```cs
public static decimal? Mode(this IEnumerable<decimal?> sequence)
{
  var grouped = sequence.GroupBy(item => item);
  var orderedGroups = grouped.OrderByDescending(group => group.Count());
  return orderedGroups.FirstOrDefault().Key;
}
```

## Page 454 - Working with async streams
The original code used `System.Threading.Thread.Sleep` method which blocks the thread. Using `Task.Delay` method instead allows thread to execute asynchronously.

```cs
async static IAsyncEnumerable<int> GetNumbers()
{
  var r = new Random();

  // simulate work
  await Task.Run(() => Task.Delay(r.Next(1500, 3000)));
  yield return r.Next(0, 101);

  await Task.Run(() => Task.Delay(r.Next(1500, 3000)));
  yield return r.Next(0, 101);

  await Task.Run(() => Task.Delay(r.Next(1500, 3000)));
  yield return r.Next(0, 101);
}
```

## Page 503 - Using Razor class libraries
In Step 7, if the `Areas` and `MyFeature` folders are missing, then that is caused by an errata in Step 4, where the command: 

```
dotnet new razorclasslib
```
Should be: 
```
dotnet new razorclasslib -s
```
or 
```
dotnet new razorclasslib --support-pages-and-views
```
Also, the [compact folders](https://github.com/microsoft/vscode-docs/blob/vnext/release-notes/v1_41.md#compact-folders-in-explorer) feature introduced in Visual Studio Code 1.41 in November 2019 might confuse you. The compact folders feature means that nested folders like `/Areas/MyFeature/Pages/` are shown in a compact form if they do not contain files. If you would like to disable the compact folders feature, complete the following steps:
1. In Visual Studio Code on Mac, navigate to **Code** | **Preferences** | **Settings**, or press `Cmd` + `,`. On Windows, navigate to **File** | **Preferences** | **Settings**, or press `Ctrl` + `,`.
2. In the **Search settings** box, enter `compact`
3. Clear the **Explorer: Compact Folders** check box, as shown in the following screenshot:

![Disabling the compact folders feature](https://github.com/markjprice/cs8dotnetcore3/blob/master/disable-compact-folders.png)
4. Close the **Settings** editor.
## Page 540 - Validating the model
In Step 7, the class name should be `HomeModelBindingViewModel`, as shown in the following code:
```cs
var model = new HomeModelBindingViewModel
```

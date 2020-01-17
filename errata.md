# Errata
## Page 30 - Discovering your C# compiler versions
In Step 5, the command `csc -langversion:?` works on macOS but on Windows it returns the error `The name "csc" is not recognized as the name of a command, function, script file, or executable program. Check the spelling of the name, as well as the presence and correctness of the path.` To fix this issue, use the following link: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/command-line-building-with-csc-exe
## Page 63 - Getting key input from the user
The sentence:
"This method waits for the user to type some text, then as soon as the user presses Enter, whatever the user has typed is returned as a `string` value."
Should be:
"This method waits for the user to press a key or key combination and that is then returned as a `ConsoleKeyInfo` value."
## Page 503 - Using Razor class libraries
In Step 4, the command: `dotnet new razorclasslib` should be: `dotnet new razorclasslib -s` or `dotnet new razorclasslib --support-pages-and-views`

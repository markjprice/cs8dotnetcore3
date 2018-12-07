using static System.Console;
using System;

namespace Arguments
{
  class Program
  {
    static void Main(string[] args)
    {
      ForegroundColor = (ConsoleColor)Enum.Parse(
        typeof(ConsoleColor), args[0], true);

      BackgroundColor = (ConsoleColor)Enum.Parse(
        typeof(ConsoleColor), args[1], true);

      try
      {
        WindowWidth = int.Parse(args[2]);
        WindowHeight = int.Parse(args[3]);
      }
      catch (PlatformNotSupportedException)
      {
        WriteLine("The current platform does not support changing the size of a console window.");
      }

      WriteLine($"There are {args.Length} arguments.");
      foreach (string arg in args)
      {
        WriteLine(arg);
      }
    }
  }
}
using System;
using static System.Console;

namespace IterationStatements
{
  class Program
  {
    static void Main(string[] args)
    {
      // Looping with the while statement

      int x = 0;

      while (x < 10)
      {
        WriteLine(x); x++;
      }

      // Looping with the do statement

      string password = string.Empty;

      do
      {
        Write("Enter your password: ");
        password = ReadLine();
      }
      while (password != "Pa$$w0rd");

      WriteLine("Correct!");

      for (int y = 1; y <= 10; y++)
      {
        WriteLine(y);
      }

      string[] names = { "Adam", "Barry", "Charlie" };

      foreach (string name in names)
      {
        WriteLine($"{name} has {name.Length} characters.");
      }

    }
  }
}

using System;
using static System.Console;
using System.Text.RegularExpressions;

namespace WorkingWithRegularExpressions
{
  class Program
  {
    static void Main(string[] args)
    {
      // Checking for digits entered as text
      Write("Enter your age: ");
      string input = ReadLine();
      var ageChecker = new Regex(@"^\d+$");
      if (ageChecker.IsMatch(input))
      {
        WriteLine("Thank you!");
      }
      else
      {
        WriteLine($"This is not a valid age: {input}");
      }
    }
  }
}

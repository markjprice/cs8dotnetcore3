using System;
using static System.Console;

namespace Exercise03
{
  class Program
  {
    static void Main(string[] args)
    {
      Write("Enter a number: ");
      string input = ReadLine();

      int number = int.Parse(input);

      WriteLine($"{number:N0} in words is {number.ToWords()}.");
    }
  }
}
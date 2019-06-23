using System;
using static System.Console;

namespace BooleanOperators
{
  class Program
  {
    static void Main(string[] args)
    {
      bool a = true;
      bool b = false;

      WriteLine($"AND  | a     | b    ");
      WriteLine($"a    | {a & a,-5} | {a & b,-5} ");
      WriteLine($"b    | {b & a,-5} | {b & b,-5} ");

      WriteLine($"OR   | a     | b    ");
      WriteLine($"a    | {a | a,-5} | {a | b,-5} ");
      WriteLine($"b    | {b | a,-5} | {b | b,-5} ");

      WriteLine($"XOR  | a     | b    ");
      WriteLine($"a    | {a ^ a,-5} | {a ^ b,-5} ");
      WriteLine($"b    | {b ^ a,-5} | {b ^ b,-5} ");
    }
  }
}

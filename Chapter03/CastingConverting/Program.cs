using System;
using static System.Console;
using static System.Convert;

namespace CastingConverting
{
  class Program
  {
    static void Main(string[] args)
    {
      // Casting numbers implicitly

      int a = 10;
      double b = a; // an int can be safely cast into a double
      WriteLine(b);

      // Casting numbers explicitly

      double c = 9.8;
      //int d = c; // compiler gives an error for this line
      int d = (int)c; // explicitly cast into a double
      WriteLine(d); // d is 9 losing the .8 part

      long e = 10;
      int f = (int)e;
      WriteLine($"e is {e} and f is {f}");
      e = long.MaxValue;
      f = (int)e;
      WriteLine($"e is {e} and f is {f}");

      // Converting with the System.Convert type

      double g = 9.8;
      int h = ToInt32(g);
      WriteLine($"g is {g} and h is {h}");

      // Rounding numbers

      double i = 9.49;
      double j = 9.5;
      double k = 10.49;
      double l = 10.5;
      WriteLine($"i is {i}, ToInt(i) is {ToInt32(i)}");
      WriteLine($"j is {j}, ToInt(j) is {ToInt32(j)}");
      WriteLine($"k is {k}, ToInt(k) is {ToInt32(k)}");
      WriteLine($"l is {l}, ToInt(l) is {ToInt32(l)}");

      // Converting from any type to a string

      int number = 12;
      WriteLine(number.ToString());
      bool boolean = true;
      WriteLine(boolean.ToString());
      DateTime now = DateTime.Now;
      WriteLine(now.ToString());
      object me = new object();
      WriteLine(me.ToString());

      // Converting from a binary object to a string

      // allocate array of 128 bytes 
      byte[] binaryObject = new byte[128];

      // populate array with random bytes 
      (new Random()).NextBytes(binaryObject);

      WriteLine("Binary Object as bytes:");

      for (int index = 0; index < binaryObject.Length; index++)
      {
        Write($"{binaryObject[index]:X} ");
      }
      WriteLine();

      // convert to Base64 string and output as text
      string encoded = Convert.ToBase64String(binaryObject); WriteLine($"Binary Object as Base64: {encoded}");

      // Parsing from strings to numbers or dates and times

      int age = int.Parse("27");
      DateTime birthday = DateTime.Parse("4 July 1980");
      WriteLine($"I was born {age} years ago.");
      WriteLine($"My birthday is {birthday}.");
      WriteLine($"My birthday is {birthday:D}.");

      Write("How many eggs are there? ");
      int count;
      string input = Console.ReadLine();
      if (int.TryParse(input, out count))
      {
        WriteLine($"There are {count} eggs.");
      }
      else
      {
        WriteLine("I could not parse the input.");
      }
    }
  }
}

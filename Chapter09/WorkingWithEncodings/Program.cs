using System;
using System.Text;
using static System.Console;

namespace WorkingWithEncodings
{
  class Program
  {
    static void Main(string[] args)
    {
      WriteLine("Encodings");
      WriteLine("[1] ASCII");
      WriteLine("[2] UTF-7");
      WriteLine("[3] UTF-8");
      WriteLine("[4] UTF-16 (Unicode)");
      WriteLine("[5] UTF-32");
      WriteLine("[any other key] Default");

      // choose an encoding
      Write("Press a number to choose an encoding: ");
      ConsoleKey number = ReadKey(false).Key;
      WriteLine();
      WriteLine();

      Encoding encoder;
      switch (number)
      {
        case ConsoleKey.D1:
          encoder = Encoding.ASCII; break;
        case ConsoleKey.D2:
          encoder = Encoding.UTF7; break;
        case ConsoleKey.D3:
          encoder = Encoding.UTF8; break;
        case ConsoleKey.D4:
          encoder = Encoding.Unicode; break;
        case ConsoleKey.D5:
          encoder = Encoding.UTF32; break;
        default:
          encoder = Encoding.Default; break;
      }

      // define a string to encode
      string message = "A pint of milk is £1.99";

      // encode the string into a byte array 
      byte[] encoded = encoder.GetBytes(message);

      // check how many bytes the encoding needed 
      WriteLine("{0} uses {1:N0} bytes.",
        encoder.GetType().Name, encoded.Length);

      // enumerate each byte 
      WriteLine($"BYTE  HEX  CHAR");
      foreach (byte b in encoded)
      {
        WriteLine($"{b,4} {b.ToString("X"),4} {(char)b,5}");
      }

      // decode the byte array back into a string and display it 
      string decoded = encoder.GetString(encoded);
      WriteLine(decoded);
    }
  }
}

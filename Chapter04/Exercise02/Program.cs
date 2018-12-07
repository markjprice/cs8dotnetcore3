using static System.Console;

namespace Exercise02
{
  class Program
  {
    static int[] primeNumbers = new[] { 97, 89, 83, 79, 73, 71, 67, 61, 59, 53, 47, 43, 41, 37, 31, 29, 23, 19, 17, 13, 11, 7, 5, 3, 2 };

    static string PrimeFactors(int number)
    {
      string factors = string.Empty;

      foreach (int divisor in primeNumbers)
      {
        int remainder;
        do
        {
          remainder = number % divisor;
          if (remainder == 0)
          {
            number = number / divisor;
            if (number == 1)
            {
              factors += $"{divisor}";
            }
            else
            {
              factors += $"{divisor} x ";
            }
          }
        } while (remainder == 0);
      }
      return $"{factors}";
    }

    static void Main(string[] args)
    {
      Write("Enter a number between 1 and 1000: ");
      int number = int.Parse(ReadLine());
      WriteLine($"Prime factors of {number} are {PrimeFactors(number)}");
    }
  }
}

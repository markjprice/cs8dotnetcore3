using System;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncEnumerable
{
  class Program
  {
    static IAsyncEnumerable<int> GetNumbers()
    {
      var r = new Random();

      // simulate work
      System.Threading.Thread.Sleep(r.Next(1000, 2000));
      yield return r.Next(0, 101);

      System.Threading.Thread.Sleep(r.Next(1000, 2000));
      yield return r.Next(0, 101);

      System.Threading.Thread.Sleep(r.Next(1000, 2000));
      yield return r.Next(0, 101);
    }

    static async Task Main(string[] args)
    {
      await foreach (int number in GetNumbers())
      {
        WriteLine($"Number: {number}");
      }
    }
  }
}
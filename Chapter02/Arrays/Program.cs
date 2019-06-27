using System;

namespace Arrays
{
  class Program
  {
    static void Main(string[] args)
    {
      // declaring the size of the array
      string[] names = new string[4];

      // storing items at index positions
      names[0] = "Kate";
      names[1] = "Jack";
      names[2] = "Rebecca";
      names[3] = "Tom";

      // looping through the names
      for (int i = 0; i < names.Length; i++)
      {
        Console.WriteLine(names[i]); // read the item at this index
      }
    }
  }
}

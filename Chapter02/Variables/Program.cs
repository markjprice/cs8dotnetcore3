using System;
using static System.Console;

namespace Variables
{
  class Program
  {
    static void Main(string[] args)
    {
      object height = 1.88; // storing a double value in an object
      object name = "Amir"; // storing a string value in an object 

      WriteLine($"{name} is {height} metres tall.");

      //int length1 = name.Length; // gives compile error!
      int length2 = ((string)name).Length; // tell compiler it is a string

      WriteLine($"{name} has {length2} characters.");

      // storing a string in a dynamic object
      dynamic anotherName = "Ahmed";

      // this compiles but would throw an exception at run-time
      // if you later store a data type that does not have a
      // property named Length
      int length = anotherName.Length;

      // Declaring local variables

      var population = 66_000_000; // 66 million in UK 
      var weight = 1.88; // in kilograms
      var price = 4.99M; // in pounds sterling
      var fruit = "Apples"; // strings use double-quotes 
      var letter = 'Z'; // chars use single-quotes
      var happy = true; // Booleans have value of true or false

      WriteLine($"default(int) = {default(int)}"); 
      WriteLine($"default(bool) = {default(bool)}");
      WriteLine($"default(DateTime) = {default(DateTime)}");

      int thisCannotBeNull = 4;
      //thisCannotBeNull = null; // compile error!

      int? thisCouldBeNull = null;
      WriteLine(thisCouldBeNull); // null
      WriteLine(thisCouldBeNull.GetValueOrDefault()); // 0

      thisCouldBeNull = 7;
      WriteLine(thisCouldBeNull); // 7
      WriteLine(thisCouldBeNull.GetValueOrDefault()); // 7
    }
  }
}

using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      // Setting and outputting field values

      var p1 = new Person();
      p1.Name = "Bob Smith";
      p1.DateOfBirth = new DateTime(1965, 12, 22);

      WriteLine(string.Format(
        format: "{0} was born on {1:dddd, d MMMM yyyy}",
        arg0: p1.Name,
        arg1: p1.DateOfBirth));

      var p2 = new Person
      {
        Name = "Alice Jones",
        DateOfBirth = new DateTime(1998, 3, 7)
      };

      WriteLine(string.Format(
        format: "{0} was born on {1:dd MMM yy}",
        arg0: p2.Name,
        arg1: p2.DateOfBirth));

      // Storing a value using an enum type

      p1.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

      WriteLine(string.Format(
        format: "{0}'s favorite wonder is {1}. It's integer is {2}.",
        arg0: p1.Name,
        arg1: p1.FavouriteAncientWonder,
        arg2: (int)p1.FavouriteAncientWonder));

      // Storing multiple values using an enum type

      p1.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon
        | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

      // p1.BucketList = (WondersOfTheAncientWorld)18; 

      WriteLine($"{p1.Name}'s bucket list is {p1.BucketList}");

      // Storing multiple values using collections

      p1.Children.Add(new Person { Name = "Alfred" }); p1.Children.Add(new Person { Name = "Zoe" });

      WriteLine($"{p1.Name} has {p1.Children.Count} children:");

      for (int child = 0; child < p1.Children.Count; child++)
      {
        WriteLine($"  {p1.Children[child].Name}");
      }

      // Making a field static

      BankAccount.InterestRate = 0.012M; // store a shared value

      var ba1 = new BankAccount(); // create a bank account
      ba1.AccountName = "Mrs. Jones";
      ba1.Balance = 2400;

      WriteLine(string.Format(format: "{0} earned {1:C} interest.",
        arg0: ba1.AccountName,
        arg1: ba1.Balance * BankAccount.InterestRate));

      var ba2 = new BankAccount(); // create another bank account
      ba2.AccountName = "Ms. Gerrier";
      ba2.Balance = 98;

      WriteLine(string.Format(format: "{0} earned {1:C} interest.",
        arg0: ba2.AccountName,
        arg1: ba2.Balance * BankAccount.InterestRate));

      // Making a field constant

      WriteLine($"{p1.Name} is a {Person.Species}");

      // Making a field read-only

      WriteLine($"{p1.Name} was born on {p1.HomePlanet}");

      // Initializing fields with constructors

      var p3 = new Person();
      WriteLine(string.Format(
        format: "{0} was instantiated at {1:hh:mm:ss} on a {2:dddd}.",
        arg0: p3.Name,
        arg1: p3.Instantiated,
        arg2: p3.Instantiated));

      var p4 = new Person("Aziz");
      WriteLine(string.Format(
        format: "{0} was instantiated at {1:hh:mm:ss} on a {2:dddd}.",
        arg0: p4.Name,
        arg1: p4.Instantiated,
        arg2: p4.Instantiated));

      // Returning values from methods

      p1.WriteToConsole();
      WriteLine(p1.GetOrigin());

      // Combining multiple returned values using tuples

      (string, int) fruit = p1.GetFruit();
      WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

      // Naming the fields of a tuple

      var fruitNamed = p1.GetNamedFruit();
      WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

      // Inferring tuple names

      var thing1 = ("Neville", 4);
      WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

      var thing2 = (p1.Name, p1.Children.Count);
      WriteLine($"{thing2.Name} has {thing2.Count} children.");

      // Deconstructing tuples

      (string fruitName, int fruitNumber) = p1.GetFruit();
      WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

      // Defining and passing parameters to methods

      WriteLine(p1.SayHello());
      WriteLine(p1.SayHello("Emily"));

      // Passing optional parameters and naming arguments

      WriteLine(p1.OptionalParameters());

      WriteLine(p1.OptionalParameters("Jump!", 98.5));

      WriteLine(p1.OptionalParameters(number: 52.7, command: "Hide!"));

      WriteLine(p1.OptionalParameters("Poke!", active: false));

      // Controlling how parameters are passed

      int a = 10;
      int b = 20;
      int c = 30;

      WriteLine($"Before: a = {a}, b = {b}, c = {c}");

      p1.PassingParameters(a, ref b, out c);

      WriteLine($"After: a = {a}, b = {b}, c = {c}");

      int d = 10;
      int e = 20;

      WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");

      // simplified C# 7 syntax for the out parameter
      p1.PassingParameters(d, ref e, out int f);

      WriteLine($"After: d = {d}, e = {e}, f = {f}");

      // Defining read-only properties

      var sam = new Person
      {
        Name = "Sam",
        DateOfBirth = new DateTime(1972, 1, 27)
      };

      WriteLine(sam.Origin);
      WriteLine(sam.Greeting);
      WriteLine(sam.Age);

      // Defining settable properties

      sam.FavoriteIceCream = "Chocolate Fudge";
      WriteLine(
        $"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");

      sam.FavoritePrimaryColor = "Red";
      WriteLine(
        $"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

// Defining indexers

sam.Children.Add(new Person { Name = "Charlie" });
sam.Children.Add(new Person { Name = "Ella" });

WriteLine($"Sam's first child is {sam.Children[0].Name}");
WriteLine($"Sam's second child is {sam.Children[1].Name}");
WriteLine($"Sam's first child is {sam[0].Name}");
WriteLine($"Sam's second child is {sam[1].Name}");

    }
  }
}
using System;                     // DateTime
using System.Collections.Generic; // List<T>, HashSet<T> 
using System.Xml.Serialization;   // XmlSerializer
using System.IO;                  // FileStream
using Packt.Shared;               // Person 
using Newtonsoft.Json;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithSerialization
{
  class Program
  {
    static void Main(string[] args)
    {
      // create an object graph
      var people = new List<Person>
        {
        new Person(30000M) { FirstName = "Alice",
            LastName = "Smith", DateOfBirth = new DateTime(1974, 3, 14) },
        new Person(40000M) { FirstName = "Bob", LastName = "Jones",
            DateOfBirth = new DateTime(1969, 11, 23) },
        new Person(20000M) { FirstName = "Charlie", LastName = "Cox",
            DateOfBirth = new DateTime(1984, 5, 4),
            Children = new HashSet<Person>
            { new Person(0M) { FirstName = "Sally", LastName = "Cox",
            DateOfBirth = new DateTime(2000, 7, 12) } } }
        };

      // create a file to write to
      string path = Combine(CurrentDirectory, "people.xml");
      FileStream stream = File.Create(path);

      // create an object that will format as List of Persons as XML 
      var xs = new XmlSerializer(typeof(List<Person>));

      // serialize the object graph to the stream 
      xs.Serialize(stream, people);

      // you must close the stream to release the file lock 
      stream.Close();

      WriteLine("Written {0:N0} bytes of XML to {1}",
        new FileInfo(path).Length, path);
      WriteLine();

      // Display the serialized object graph 
      WriteLine(File.ReadAllText(path));

      // Deserializing with XML

      FileStream xmlLoad = File.Open(path, FileMode.Open);

      // deserialize and cast the object graph into a List of Person 
      var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);

      foreach (var item in loadedPeople)
      {
        WriteLine("{0} has {1} children.",
          item.LastName, item.Children.Count);
      }
      xmlLoad.Close();

      // create a file to write to
      string jsonPath = Combine(CurrentDirectory, "people.json");
      StreamWriter jsonStream = File.CreateText(jsonPath);

      // create an object that will format as JSON 
      var jss = new JsonSerializer();

      // serialize the object graph into a string 
      jss.Serialize(jsonStream, people); 
      jsonStream.Close(); // release the file lock

      WriteLine();
      WriteLine("Written {0:N0} bytes of JSON to: {1}",
        new FileInfo(jsonPath).Length, jsonPath);

      // Display the serialized object graph 
      WriteLine(File.ReadAllText(jsonPath));
    }
  }
}

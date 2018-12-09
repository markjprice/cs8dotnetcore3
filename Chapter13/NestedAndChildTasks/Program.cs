using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace NestedAndChildTasks
{
  class Program
  {
    static void Main(string[] args)
    {
      var outer = Task.Factory.StartNew(() =>
        {
          WriteLine("Outer task starting...");
          var inner = Task.Factory.StartNew(() =>
            {
              WriteLine("Inner task starting...");
              Thread.Sleep(2000);
              WriteLine("Inner task finished.");
            }, TaskCreationOptions.AttachedToParent);
        });
      outer.Wait();
      WriteLine("Outer task finished.");
    }
  }
}

using System.Collections.Generic; // IEnumerable<T>
using System.Linq; // ToArray()

using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel

using Packt.Shared; // Employee

namespace PacktFeatures.Pages
{
  public class EmployeesPageModel : PageModel
  {
    private Northwind db;

    public EmployeesPageModel(Northwind injectedContext)
    {
      db = injectedContext;
    }

    public IEnumerable<Employee> Employees { get; set; }

    public void OnGet()
    {
      Employees = db.Employees.ToArray();
    }
  }
}

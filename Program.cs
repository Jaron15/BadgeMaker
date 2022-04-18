using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {

    static void Main(string[] args)
    {
      List<Employee> employees = GetEmployees();
      PrintEmployees(employees);
    }
    
    static List<Employee> GetEmployees()
    {
    List<Employee> employees = new List<Employee>();
    // Collect user values until the value is an empty string
    while (true)
      {
      Console.WriteLine("Enter first name: (leave empty to exit): ");
      // Get a name from the console and assign it to a variable
      string firstName = Console.ReadLine();
      if (firstName == "")
      {
        break;
      }

      Console.Write("Enter last name: ");
      string lastName = Console.ReadLine();
      Console.Write("Enter ID: ");
      int id = Int32.Parse(Console.ReadLine());
      Console.Write("Enter photo URL: ");
      string photoUrl = Console.ReadLine();
      // Create a new Employee instance
      Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
      // Add currentEmployee, not a string
      employees.Add(currentEmployee);
      }
   return employees;
    }

    static void PrintEmployees(List<Employee> employees)
    {
      for (int i = 0; i < employees.Count; i++) 
      {
        string template = "{0,-10}\t{1,-20}\t{2}";
        Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
      }
    }
  }
}
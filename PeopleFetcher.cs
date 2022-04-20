using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker {
    class PeopleFetcher 
    {
    public static List<Employee> GetEmployees()
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

    public static List<Employee> GetFromAPI()
      {
        List<Employee> employees = new List<Employee>();
        using (WebClient client = new WebClient())
      {
          // Image example 
          string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
          JObject json = JObject.Parse(response);
          foreach (JToken token in json.SelectToken("results")) {
              // Parse JSON data
              Employee emp = new Employee
              (
                  token.SelectToken("name.first").ToString(), 
                  token.SelectToken("name.last").ToString(),
                  Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                  token.SelectToken("picture.large").ToString()
              );
              employees.Add(emp);
          }
      }
      return employees;
      }
    }
}
using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {

    static void Main(string[] args)
    {
      List<Employee> employees = new List<Employee>();

      while (true) {
      Console.WriteLine("Would you like to create badges with the data from the API? If so enter 'yes'. To create a custom badge enter 'no'");
      string response = Console.ReadLine();
      if (response == "yes") {
      employees = PeopleFetcher.GetFromAPI();
      }
      else if (response == "no") {
        employees = PeopleFetcher.GetEmployees();
      }
      else {
        Console.WriteLine("Please enter a valid response");
      }
      Util.MakeCSV(employees);
      Util.MakeBadges(employees);
      }
    }

  }
}
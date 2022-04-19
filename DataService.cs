using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingExample
{
    internal class DataService
    {
        private readonly IMemoryCache _memoryCache;
        private static readonly string EMPLOYEES = "employees";
        public DataService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public static List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new();
            employees.Add(new() { FirstName = "Horatio", LastName = "Adeoye" });
            employees.Add(new() { FirstName = "Harper", LastName = "Adeoye" });
            employees.Add(new() { FirstName = "Saori", LastName = "Adeoye" });
            return employees;
        }

        public List<EmployeeModel> GetEmployeesCached()
        {
            List<EmployeeModel> employees;
            employees = _memoryCache.Get<List<EmployeeModel>>(EMPLOYEES);
            if(employees is null)
            {
                employees = new();
                employees.Add(new() { FirstName = "Horatio", LastName = "Adeoye" });
                employees.Add(new() { FirstName = "Harper", LastName = "Adeoye" });
                employees.Add(new() { FirstName = "Saori", LastName = "Adeoye" });
                _memoryCache.Set(EMPLOYEES, employees, TimeSpan.FromMinutes(1)); // You only want the cache to live for one minute.
                Console.WriteLine("\nRetreiving from the database:");
            }
            else
                Console.WriteLine("\nRetreiving from the EMPLOYEES cache:");

            return employees;
        }
    }
}

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
            Thread.Sleep(1000);
            return employees;
        }

        public static async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            List<EmployeeModel> employees = new();
            employees.Add(new() { FirstName = "Horatio", LastName = "Adeoye" });
            employees.Add(new() { FirstName = "Harper", LastName = "Adeoye" });
            employees.Add(new() { FirstName = "Saori", LastName = "Adeoye" });
            await Task.Delay(1000);
            return employees;
        }

        public async Task<List<EmployeeModel>> GetEmployeesCached()
        {
            List<EmployeeModel> employees;
            employees = _memoryCache.Get<List<EmployeeModel>>("employees");
            if(employees is null)
            {
                employees = new();
                employees.Add(new() { FirstName = "Horatio", LastName = "Adeoye" });
                employees.Add(new() { FirstName = "Harper", LastName = "Adeoye" });
                employees.Add(new() { FirstName = "Saori", LastName = "Adeoye" });                
                await Task.Delay(1000);
                _memoryCache.Set("employees", employees, TimeSpan.FromMinutes(1)); // You only want the cache to live for one minute.
                Console.WriteLine("Retreived from the database.");
            }
            else
                Console.WriteLine("Retreived from the cache.");

            return employees;
        }
    }
}

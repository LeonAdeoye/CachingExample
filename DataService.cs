using Microsoft.Extensions.Caching.Memory;

namespace CachingExample
{
    internal class DataService
    {
        private readonly IMemoryCache _memoryCache;
        private static readonly string EMPLOYEES = "employees";
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); // If you wish to leverage reflection but it includes a prefix.
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("DataService");
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
                log.Info("Retreiving from the database:");

            }
            else
                log.Info("Retreiving from the EMPLOYEES cache:");

            return employees;
        }
    }
}

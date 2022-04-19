using Microsoft.Extensions.Caching.Memory;

namespace CachingExample
{
    internal class DisplayManager
    {
        private readonly DataService _dataSource;

        public DisplayManager(DataService dataService)
        {
            _dataSource = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }
        
        public static void Initialize()
        {           
            var employees = DataService.GetEmployees();
            employees.ForEach(employee => Console.WriteLine(employee));
        }

        public void InitializeCached()
        {
            var employees = _dataSource.GetEmployeesCached();
            employees.ForEach(employee => Console.WriteLine(employee));
        }
    }
}

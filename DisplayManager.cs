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

        public static async Task InitializeAsync()
        {
            var employees = await DataService.GetEmployeesAsync();   
            employees.ForEach(employee => Console.WriteLine(employee));
        }

        public async Task InitializeCached()
        {
            var employees = await _dataSource.GetEmployeesCached();
            employees.ForEach(employee => Console.WriteLine(employee));
        }
    }
}

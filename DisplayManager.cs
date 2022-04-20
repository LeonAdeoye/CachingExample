using Microsoft.Extensions.Caching.Memory;

namespace CachingExample
{
    internal class DisplayManager
    {
        private readonly DataService _dataSource;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("DisplayManager");

        public DisplayManager(DataService dataService)
        {
            _dataSource = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }
        
        public static void Initialize()
        {           
            var employees = DataService.GetEmployees();
            employees.ForEach(employee => log.Info(employee));
        }

        public void InitializeCached()
        {
            var employees = _dataSource.GetEmployeesCached();
            employees.ForEach(employee => log.Info(employee));
        }
    }
}

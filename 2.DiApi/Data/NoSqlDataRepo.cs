using DiApi.DataServices;

namespace DiApi.Data
{
    public class NoSqlDataRepo : IDataRepo
    {
        private readonly IServiceScopeFactory _scopeFactory;

        // // Way 1 - Begin - Structure Dependency Injection pattern 
        // private IDataService _dataService;

        // public NoSqlDataRepo(IDataService dataService)
        // {
        //     _dataService = dataService;
        // }
        // // End - Structure Dependency Injection pattern 

        // Way 2
        public NoSqlDataRepo(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }


        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--> Getting data from Non SQL data base...");
            // Way 2
            using (var scope = _scopeFactory.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetRequiredService<IDataService>();
                dataService.GetProductData("https://something.api");
            }
            // Way 1
            // _dataService.GetProductData("https://something.api");
            Console.ResetColor();

            return "No SQL Data From DB";
        }
    }
}
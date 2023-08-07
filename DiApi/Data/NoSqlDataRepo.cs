using DiApi.DataServices;

namespace DiApi.Data
{
    public class NoSqlDataRepo : IDataRepo
    {
        // Begin - Structure Dependency Injection pattern 
        private IDataService _dataService;

        public NoSqlDataRepo(IDataService dataService)
        {
            _dataService = dataService;
        }
        // End - Structure Dependency Injection pattern 

        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--> Getting data from Non SQL data base...");
            _dataService.GetProductData("https://something.api");
            Console.ResetColor();

            return "No SQL Data From DB";
        }
    }
}
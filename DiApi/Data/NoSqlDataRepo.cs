namespace DiApi.Data
{
    public class NoSqlDataRepo : IDataRepo
    {
        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--> Getting data from Non SQL data base...");
            Console.ResetColor();

            return "No SQL Data From DB";
        }
    }
}
namespace DiApi.Data
{
    public class NoSqlDataRepo
    {
        // public NoSqlDataRepo()
        // {
            
        // }

        public string GetData()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--> Getting data from Non SQL data base...");
            Console.ResetColor();

            return "No SQL Data From DB";
        }
    }
}
namespace DiApi.Data
{
    public class SqlDataRepo : IDataRepo
    {
        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--> Getting data from sQL data base...");
            Console.ResetColor();

            return ("");
        }
    }
}
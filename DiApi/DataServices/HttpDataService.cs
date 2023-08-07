namespace DiApi.DataServices
{
    public class HttpDataService : IDataService
    {
        public string GetProductData(string url)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ---> Getting product Data");
            Console.ResetColor();
            return "Some product data";
        }
    }
}
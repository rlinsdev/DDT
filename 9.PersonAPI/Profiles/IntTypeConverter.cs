using AutoMapper;

namespace PersonAPI.Profiles
{
    public class IntTypeConverter : ITypeConverter<string, int> // : Implementing a interface
    {
        public int Convert(string source, int destination, ResolutionContext context)
        {
            var convertedInt = 0;

            try
            {
                convertedInt = System.Convert.ToInt32(source);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Whoops! Error to converting {ex.Message}");
            }
            return convertedInt;
        }
    }
}
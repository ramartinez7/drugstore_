namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Do());
            
        }

        static string Do()
        {
            int? a = null;
            switch (a)
            {
                case 1:
                    return "uno";
                case null:
                    goto default;
                default:
                    return "unknown";
            }
        }
    }
}

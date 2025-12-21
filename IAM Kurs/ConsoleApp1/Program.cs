using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)

        {
            bool boolfromStr = bool.Parse("true");
            int intfromStr = int.Parse("100");
            double dblFromStr = double.Parse("1.234");

            string strVal = dblFromStr.ToString();
            Console.WriteLine($"Data type : {strVal.GetType}");
            double dbNum = 12.345;
            Console.WriteLine($"Integer : {(int)dbNum}");
            int intNum = 10;
            long longNum = intNum;

        }
    }
}

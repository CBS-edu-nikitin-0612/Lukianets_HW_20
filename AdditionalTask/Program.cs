using System;

namespace AdditionalTask
{
    public delegate double MyDelegate(int x, int y, int z);
    internal class Program
    {
        //public static double AverageOf3(int x, int y, int z)
        static void Main(string[] args)
        {
            MyDelegate myDelegate = delegate (int x, int y, int z)
            {
                return Math.Round((double)(x + y + z) / 3, 2);
            };
            double result = myDelegate(1, 2, 8);
            Console.WriteLine(result);
        }
    }
}

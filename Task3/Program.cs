using System;

namespace Task3
{
    public delegate int RandomValue();
    public delegate double DellegateArray(RandomValue[] delArray);

    internal class Program
    {
        public static int GetRandom1()
        {
            Random rnd = new Random();
            int rndNumberm = rnd.Next(0, 10);
            Console.WriteLine($"Number {rndNumberm}");
            return rndNumberm;
        }

        public static int GetRandom2()
        {
            Random rnd = new Random();
            int rndNumberm = rnd.Next(11, 99);
            Console.WriteLine($"Number {rndNumberm}");
            return rndNumberm;
        }

        static void Main(string[] args)
        {
            RandomValue rv1 = GetRandom1;
            //rv1 += GetRandom2;
            RandomValue rv2 = GetRandom2;

            // массив делегатов
            RandomValue[] delegatsArray = new RandomValue[2] { rv1, rv2 };

            DellegateArray arr = delegate (RandomValue[] delArray)
            {
                int sum = 0;
                foreach (RandomValue randomValue in delArray)
                {
                    sum += randomValue();
                    //var list = randomValue.GetInvocationList();
                    //for (int i = 0; i < list.Length; i++)
                    //{
                    //    sum += list[i]();
                    //}
                }
                return (double)sum / delArray.Length;
            };

            double result = arr(delegatsArray);
            Console.WriteLine(result);
        }
    }
}

using System;
using Lab3_2;

namespace lab3z2
{
    class Program
    {
        static void Main(string[] args)
        {
           // Random random = new Random();
           // int id = random.Next(10, 1000);
            int id = 1;
            Casino casino = new Casino();
            casino.CreateAccount(id,1000);
            var mt = DateTimeOffset.UtcNow.ToUnixTimeSeconds(); // початковий елемент (СІД)
            //Console.WriteLine(mt);
            long newSeed = 0;
            long result = casino.Start_game(id); // посилаю запит на отримання справжнього числа


            List<long> resultList = new List<long>();

            for (int i = -100; i < 100; i++)
            {
                newSeed = mt + i;
                RandomMersenne randomMersenne = new RandomMersenne((uint)newSeed);
                for (int j = 0; j < 626; j++)
                {
                    resultList.Add(randomMersenne.Random());
                }
            }
            int index = resultList.IndexOf(result);  // знаходжу це число в послідовності
            long Next_result = resultList[index + 1]; // наступне число - передбачено
            Console.WriteLine("resultat:   " + casino.Return_Namber(Next_result, id)); // перевірка на збіг
            Console.WriteLine("money:   " + casino.Return_Money(id)); // виграш
            Console.ReadKey();
        }
    }
}
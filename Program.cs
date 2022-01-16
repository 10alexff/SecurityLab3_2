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

        }
    }
}
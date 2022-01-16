using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_2
{
    public class Casino 
    {
        // принімать запит - створення користува
        // початок гри - відправляє число - очікує наступне
        // приймає число - перевірка - результат - зміна суми
        private static List<Client_model> clients = new List<Client_model>();
        private int IDclient;
        private double money;
        private long currentNamber;
        private int start = 0;

        List<long> resultList = new List<long>();
        public void CreateAccount(int id, double money) 
        {
            Client_model client_Model = new Client_model();
            client_Model.id = id; client_Model.money = money;
            IDclient = id; this.money = money;
            clients.Add(client_Model);
        }

        public long Start_game(int id) 
        {
            long namber = new long();

            var newSeed = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            RandomMersenne m = new RandomMersenne((uint)newSeed);
            for (int j = 0; j < 626; j++)
            {
                resultList.Add(m.Random());
            }

            Random random = new Random();
            int count = random.Next(1, 625);

            namber = resultList[count];
            // знаходимо число через MersennerTwister
            currentNamber = resultList[count + 1];
            start = 1;
            return namber;
        }

        public int Return_Namber(long namber, int id) 
        {
            if (start == 1)
            {
                if (namber == currentNamber)
                {
                    money += 1000;
                    return 1;
                }
                else
                {
                    money -= 100;
                    return 0;
                }
            }
            else { return -1; }

        }
        public double Return_Money(int id) 
        {
            return money;
        }
    }
}

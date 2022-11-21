using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool gameIsFinished = false;
            var game = new Game();
            int player = 0;
            Console.WriteLine("tennis match!!!!\nenter who makes the point (1,2)");
            while (!gameIsFinished)
            {
                do
                {
                    player = Convert.ToInt32(Console.ReadLine());
                } while (player > 2 || player < 1);
                
                var score = game.PlayGame(player);

                Console.WriteLine(score.Text);

                gameIsFinished = score.GameIsFinished;
            }
            Console.ReadLine();
        }
    }
}

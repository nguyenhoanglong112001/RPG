using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseGame
{
    public class GameHelper
    {
        public static void CharacterInfomation(Charater hero)
        {
            Console.WriteLine("Hero Information: ");
            Console.WriteLine("Hero Name: " + hero.name);
            Console.WriteLine("Health: " + hero.health);
            Console.WriteLine("Attack Damage: " + hero.attack);
            Console.WriteLine("Speed: " + hero.attackSpeed);
            Console.WriteLine("Crit: " + hero.crit);
            Console.WriteLine("Amor: " + hero.amor);
        }

        public static int GetRandom(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
    }
}
 

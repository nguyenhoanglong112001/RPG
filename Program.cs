using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TurnBaseGame
{
    internal class Program
    {
        public static Charater[] charater = new Charater[2];
        public static Charater Player = new Charater();
        public static Charater Com = new Charater();
        static void Main(string[] args)
        {
            do
            {
                int key = ShowGameUI();
                switch (key)
                {
                    case 1:
                        {
                            CreateHero(charater);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Danh sach hero: ");
                            ShowAllHero(charater);
                            Console.WriteLine("Nhap hero ban muon xem thong tin");
                            int heroSelete = int.Parse(Console.ReadLine());
                            Showhero(charater, heroSelete);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Chose your hero: ");
                            ShowAllHero(charater);
                            Console.WriteLine("Selecte your hero: ");
                            int Choice = int.Parse(Console.ReadLine());
                            HeroSelect(charater,ref Player,ref Com, Choice);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Player.Fight(Com);
                            break;
                        }
                    case 5:
                        {
                            Exit();
                            break;
                        }
                }
            }
            while(true);
            Console.ReadKey();
        }

        public static int ShowGameUI()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("Welcome to please choice function: ");
            Console.WriteLine("1. Create your hero and enemy");
            Console.WriteLine("2. Show your hero and enemy information");
            Console.WriteLine("3. Select your hero");
            Console.WriteLine("4. Start game");
            Console.WriteLine("5. Exit");

            int key = int.Parse(Console.ReadLine());
            return key;
        }

        public static void CreateHero(Charater[] heros)
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Enter hero(enemy) name: ");
            string heroname = Console.ReadLine();
            Charater Charater = new Charater(heroname);
            Charater.health = GameHelper.GetRandom(1000,5001);
            Charater.attack = GameHelper.GetRandom(50,201);
            Charater.attackSpeed = GameHelper.GetRandom(50, 101);
            Charater.crit = GameHelper.GetRandom(0,101);
            Charater.amor = GameHelper.GetRandom(25, 151);

            AddToArray(heros, Charater);
            GameHelper.CharacterInfomation(Charater);
        }


        public static void AddToArray(Charater[] heros, Charater hero)
        {
            for (int i = 0; i < heros.Length; i++)
            {
                if (heros[i] == null)
                {
                    heros[i] = hero;
                    break;
                }
            }
        }
        public static void ShowAllHero(Charater[] hero)
        {
            Console.Clear();
            for (int i=0;i<hero.Length;i++)
            {
                if (hero[i] != null)
                {
                    Console.WriteLine($"{i + 1}. {hero[i].name}");
                }
            }
        }

        public static void Showhero(Charater[] hero, int heroSelete)
        {
            for (int i=0;i<hero.Length;i++)
            {
                if (hero[i] != null)
                {
                    if (i==heroSelete)
                    {
                        GameHelper.CharacterInfomation(hero[i]);
                        break;
                    }
                }
            }
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void HeroSelect(Charater[] heros,ref Charater Player,ref Charater Com, int Choice)
        {
            for (int i = 0; i < heros.Length; i++)
            {
                if (i == Choice)
                {
                    Player = heros[i];
                    Console.WriteLine("Information for your hero");
                    GameHelper.CharacterInfomation(Player);
                    break;
                }
            }
            Console.WriteLine("=======================");
            int Comchoice;
            do
            {
                Comchoice = GameHelper.GetRandom(0, heros.Length);
                for (int i = 0; i < heros.Length; i++)
                {
                    if (Comchoice == i)
                    {

                        Com = heros[i];
                        break;
                    }
                }
            }
            while (Comchoice == Choice);
            Console.WriteLine("Information of enemy's hero: ");
            GameHelper.CharacterInfomation(Com);
        }
    }
}

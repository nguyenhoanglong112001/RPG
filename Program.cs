using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace TurnBaseGame
{
    internal class Program
    {
        public static Sword sword = new Sword("Legend Sword");
        public static Amor amor = new Amor("Dragon Amor");
        public static Staff staff = new Staff("Wizzal staff");
        public static Bow bow = new Bow("Fire bow ");
        public static Item[] items = new Item[] {sword,amor,staff,bow};
        static void Main(string[] args)
        {
            Player Player = new Player("Hero");
            GameHelper.CharacterInfomation(Player);
            Thread.Sleep(100);
            Enemy Com = new Enemy("Monster");
            GameHelper.CharacterInfomation(Com);
            Charater[] charater = new Charater[] { Player, Com };
            while (true)
            {
                int key = ShowGameUI();
                switch (key)
                {
                    case 1:
                        {
                            Console.WriteLine("Danh sach hero: ");
                            ShowAllHero(charater);
                            Console.WriteLine("Nhap hero ban muon xem thong tin");
                            int heroSelete = int.Parse(Console.ReadLine());
                            Showhero(charater, heroSelete);
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            Fight(Com,Player);
                            break;
                        }
                    case 3:
                        {
                            GetItem(items, Player);
                            Thread.Sleep(100);
                            GetItem(items, Com);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Choose character to remove item: ");
                            int indexRemove = int.Parse(Console.ReadLine());
                            RemoveItem(charater, indexRemove);
                            break;
                        }
                    case 5:
                        {
                            Exit();
                            break;
                        }
                }
            }
            Console.ReadKey();
        }

        public static int ShowGameUI()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("Welcome to please choice function: ");
            Console.WriteLine("1. Show your hero and enemy information");
            Console.WriteLine("2. Start game");
            Console.WriteLine("3. Get random item");
            Console.WriteLine("4. Remove Item");
            Console.WriteLine("5. Exit");

            int key = int.Parse(Console.ReadLine());
            return key;
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

        public static void Fight(Charater Enemy, Charater Player)
        {
            float orginhealth = Player.health;
            float enemyOrginHealt = Enemy.health;
            Console.WriteLine($"{Player.name} vs {Enemy.name}");
            int turn = 1;
            Charater currentturn = Player.attackSpeed > Enemy.attackSpeed ? Player : Enemy;

            while(Player.Alive && Enemy.Alive)
            {
                Console.WriteLine($"Turn {turn}: ");
                Charater target = currentturn == Player ? Enemy : Player;
                if (GameHelper.GetRandom(0,101) <= target.crit)
                {
                    currentturn.CritAttack(target);
                }
                else
                {
                    currentturn.Attack(target);
                }
                if (currentturn.health <0 )
                {
                    currentturn.health = 0;
                }
                if (target.health < 0 ) 
                {
                    target.health = 0;
                }
                Console.WriteLine($"{currentturn.name} deal {currentturn.attack} to {target.name}");
                Console.WriteLine($"{target.name} ------ {target.health}");
                Console.WriteLine($"{currentturn.name} ------ {currentturn.health}");

                currentturn = target;
                turn++;
                Thread.Sleep(1000);
            }


            Charater winCharacter = Player.Alive ? Player : Enemy;
            string battleResult = winCharacter is Player ? "Player" : "Enemy";
            Console.WriteLine($"{battleResult} is victory");
            GameHelper.CharacterInfomation(winCharacter);

            Player.health = orginhealth;
            Enemy.health = enemyOrginHealt;
        }

        public static void GetItem(Item[] items, Charater charater)
        {
            int ItemIndex = GameHelper.GetRandom(0,items.Length);
            items[ItemIndex].Use(items[ItemIndex].itemName);
            items[ItemIndex].Function(charater);
            charater.itemeUse = items[ItemIndex];
        }

        public static void RemoveItem(Charater[] character, int indexremove)
        {
            for (int i=0;i<character.Length; i++)
            {
                if (i == indexremove)
                {
                    character[i].itemeUse = null ;
                    break;
                }
            }

        }
    }
}

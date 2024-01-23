using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TurnBaseGame
{
    public class Charater
    {
        public string name;
        public float health;
        public float attack;
        public float attackSpeed;
        public float amor;
        public float crit;

        public float HealthPoint
        {
            get { return health; }
            set { health = value; }
        }

        public float AttackDamage
        {
            get
            {
                return attack;
            }
            set { attack = value; }
        }

        public float AttackSpeed
        {
            get
            {
                return attackSpeed;
            }
            set
            {
                attackSpeed = value;    
            }
        }
        public Charater() 
        {
        }

        public Charater(string heroName)
        {
            this.name = heroName;
        }

        public float DameReduction()
        {
            return 100 / (100 + this.amor);
        }
        public float CritAttack(Charater opponent)
        {
            opponent.health = opponent.health - this.attack*2*DameReduction();
            return opponent.health;
        }

        public float Attack(Charater opponent)
        {
            opponent.health = opponent.health - this.attack*DameReduction();
            return opponent.health;
        }
        public void Fight(Charater Enemy)
        {
            float orginhealth = this.health;
            float enemyOrginHealt = Enemy.health;
            Console.WriteLine($"{this.name} vs {Enemy.name}");
            int turn = 1;
            do
            {
                if (turn % 2 == 1)
                {
                    Console.WriteLine("Turn" + turn + ":");
                    if (this.attackSpeed > Enemy.attackSpeed)
                    {
                        if (GameHelper.GetRandom(0,101) <= this.crit)
                        {
                            this.CritAttack(Enemy);
                            Console.WriteLine("You deal " + this.attack*2*DameReduction() + " to enemy");
                        }
                        else
                        {
                            this.Attack(Enemy);
                            Console.WriteLine("You deal " + this.attack*DameReduction() + " to enemy");
                        }

                        if (Enemy.health < 0)
                        {
                            Enemy.health = 0;
                        }
  
                        Console.WriteLine("Enemy has " + Enemy.health + " remaining");
                    }
                    else if (this.attackSpeed < Enemy.attackSpeed)
                    {
                        if (GameHelper.GetRandom(0, 101) <= this.crit)
                        {
                            Enemy.CritAttack(this);
                            Console.WriteLine("Enemy deal " + Enemy.attack*2*DameReduction() + " to your hero");
                        }
                        else
                        {
                            Enemy.Attack(this);
                            Console.WriteLine("Enemy deal " + Enemy.attack*DameReduction() + " to your hero");
                        }

                        if (this.health < 0)
                        {
                            this.health = 0;
                        }

                        Console.WriteLine("Your hero has " + this.health + " remaining");
                    }
                }
                else
                {
                    Console.WriteLine("Turn" + turn + ":");
                    if (this.attackSpeed < Enemy.attackSpeed)
                    {
                        if (GameHelper.GetRandom(0, 101) <= this.crit)
                        {
                            this.CritAttack(Enemy);
                            Console.WriteLine("You deal " + this.attack * 2*DameReduction() + " to enemy");
                        }
                        else
                        {
                            this.Attack(Enemy);
                            Console.WriteLine("You deal " + this.attack * DameReduction() + " to enemy");
                        }

                        if (Enemy.health < 0)
                        {
                            Enemy.health = 0;
                        }

                        Console.WriteLine("Enemy has " + Enemy.health + " remaining");
                    }
                    else if (this.attackSpeed > Enemy.attackSpeed)
                    {
                        if (GameHelper.GetRandom(0, 101) <= this.crit)
                        {
                            Enemy.CritAttack(this);
                            Console.WriteLine("Enemy deal " + Enemy.attack * 2 * DameReduction() + " to your hero");
                        }
                        else
                        {
                            Enemy.Attack(this);
                            Console.WriteLine("Enemy deal " + Enemy.attack * DameReduction() + " to your hero");
                        }

                        if (this.health < 0)
                        {
                            this.health = 0;
                        }

                        Console.WriteLine("Your hero has " + this.health  + " remaining");
                    }
                }
                Thread.Sleep(1000);
                turn++;
            } while (this.health > 0 && Enemy.health > 0);

            if (this.health <= 0)
            {
                Console.WriteLine("Enemy victory");
                GameHelper.CharacterInfomation(Enemy);
            }
            else if (Enemy.health <= 0)
            {
                Console.WriteLine("Player victory");
                GameHelper.CharacterInfomation(this);
            }

            this.health = orginhealth;
            Enemy.health = enemyOrginHealt;
        }
    }
}

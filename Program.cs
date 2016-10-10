using System;

namespace Terminal_RPG
{
    public class Enemy
    {
        public string name;
        public double health {get; set;}
        public int strength {get; set;}
        public int intelligence {get; set;}
        public int dexterity {get; set;}
        public bool dead {get; set;}

        public Enemy(string n)
        {
            name = n;
            health = 100;
            strength = 10;
            intelligence = 10;
            dexterity = 10;
            dead = false;
        }
    }

    public class Orc : Enemy
    {
        public int strength = 17;
        public int intelligence = 7;
        public Orc(string n) : base(n)
        {
            Console.WriteLine("New Orc: " + name);
        }
        public void FlameThrower(Ally player)
        {
            int damage = strength * 2;
            player.health -= damage;
            Console.WriteLine(name + " casts FlameThrower & deals " + damage + " damage to " + player.name + "! " + player.name + " drops to " + player.health + " HP!");
            
            if(player.health <= 0)
            {
                Console.WriteLine("RIP " + player.name);
                dead = true;
            }
        }
        public void Pillage(Ally player)
        {
            int damage = strength + intelligence;
            player.health -= damage;
            intelligence += 1;
            Console.WriteLine(name + " pillages the Allies! " + player.name + " takes " + damage + " damage and " + name + " gains " + intelligence + " intelligence!");
        
            if(player.health <= 0)
            {
                Console.WriteLine("RIP " + player.name);
                dead = true;
            }
        }
    }

    public class Ally
    {
        public string name;
        public double health {get; set;}
        public int strength {get; set;}
        public int intelligence {get; set;}
        public int dexterity {get; set;}
        public bool dead {get; set;}

        public Ally(string n)
        {
            name = n;
            health = 100;
            strength = 10;
            intelligence = 10;
            dexterity = 10;
            dead = false;
        }

        public class Elf : Ally
        {
            public int intelligence = 15;
            public int dexterity = 15;
            public Elf(string n) : base(n)
            {
                 Console.WriteLine("New Elf: " + name);
            }
            public void Heal(Ally player)
            {
                if(player.health <= 90)
                {
                    double heal = player.health / 10;
                    player.health += heal;
                    Console.WriteLine(name + " heals " + player.name + " for " + heal + " HP! " + player.name + " has " + player.health + " HP!");
                }
                else if(player.health >= 91 && player.health < 95)
                {
                    double heal = player.health / 20;
                    player.health += heal;
                    Console.WriteLine(name + " heals " + player.name + " for " + heal + " HP! " + player.name + " has " + player.health + " HP!");                
                }
                else if(player.health > 95 && player.health < 100)
                {
                    double heal = 1;
                    player.health += heal;
                    Console.WriteLine(name + " heals " + player.name + " for " + heal + " HP! " + player.name + " has " + player.health + " HP!");               
                }
                else if(player.health == 100)
                {
                    double heal = 0;
                    player.health += heal;
                    Console.WriteLine(player.name + " is already at full HP!");    
                }
             }
             public void Spy(Enemy player)
             {
                int intel = intelligence - 5;
                player.dexterity -= intel;
                dexterity += intel;
                Console.WriteLine(name + " spies on the enemy. " + name + " gains " + intel + " dexterity from " + player.name + "!");
                
             }
             public void IceArrow(Enemy player)
             {
                int damage = dexterity * 2;
                player.health -= damage;
                Console.WriteLine(name + " casts IceArrow on " + player.name + " & deals " + damage + " damage! " + player.name + " drops to " + player.health + " HP!");
                if(player.health <= 0)
                {
                    Console.WriteLine("RIP " + player.name);
                    dead = true;
                }
             }
          }
       
    public class Program
    {
        public static void Main(string[] args)
        {
            Elf elfA = new Elf("Legolas");
            Elf elfB = new Elf("Arwen");
            Orc orcA = new Orc("Snaggletooth");
            Orc orcB = new Orc("Throttle");
            orcA.FlameThrower(elfA); 
            elfB.Heal(elfA);  
            elfA.Spy(orcA);  
            elfB.Spy(orcB);
            elfB.IceArrow(orcB); 
            elfB.IceArrow(orcB); 
            orcB.Pillage(elfB);

        }
    }
}
}


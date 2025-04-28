using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Monster : Creature, IDamageable
    {
        List<Monster> monsters = new List<Monster>();
        Random random = new Random();
        //Statistics stats = new Statistics();
        /// <summary>
        /// Parameters taken into account for the monster
        /// </summary>
        /// <param name="monsterName">The name of the current monster</param>
        /// <param name="monsterHealth">The health of the current monster</param>
        /// <param name="monsterWeapon">The weeapon the current monster is holding</param>
        /// <param name="monsterDamage">The damage the current enemy's weapon deals</param>
        public Monster(string monsterName, int monsterHealth, string monsterWeapon, int monsterDamage) : base(monsterName, monsterHealth, monsterWeapon, monsterDamage)
        { }

        /// <summary>
        /// Display all enemy instances in the list with all parameters
        /// </summary>
        public void DisplayMonster()
        {
            Console.Write($"{monsters.Count} monsters in the Dungeon.");
            foreach (var m in monsters)
            {
                m.Output();
            }
        }
        /// <summary>
        /// Outputs the damage the player takes from the enemy in the particular room in the game.
        /// </summary>
        /// <param name="damage">Damage the player deals upon the enemy</param>
        /// <param name="entityName">The name of the player</param>
        /// <param name="entityWeapon">The weapon of the player</param>
        public override void TakeDamage(int damage, string entityName, string entityWeapon)
        {
            var playerDamage = random.Next(0, damage);
            Console.WriteLine($"\n{entityName} attacked {Name} for {playerDamage} with their {entityWeapon}.");
            Health -= playerDamage;
            Console.WriteLine($"\n{Name}: {Health} Health Remaining");
        }
    }

    class Goblin : Monster
    {
        /// <summary>
        /// Parameters taken into account for the goblin
        /// </summary>
        /// <param name="name">Goblin's Name</param>
        /// <param name="health">Goblin's health</param>
        /// <param name="weapon">Goblin's weapon name</param>
        /// <param name="monsterDamage">Goblin's weapon damage</param>
        public Goblin(string name, int health, string weapon, int monsterDamage) : base(name, health, weapon, monsterDamage)
        { }
        /// <summary>
        /// Outputs the goblin's name, health, weapon and damage
        /// </summary>
        public override void Output()
        {
            Console.WriteLine($"\n{Name}, {Health} Health, {Weapon}, Average Damage: {Damage}");
        }
    }
    class Boss : Goblin
    {
        /// <summary>
        /// Parameters taken into account for the boss
        /// </summary>
        /// <param name="name">Boss' name</param>
        /// <param name="health">Boss' health</param>
        /// <param name="weapon">Boss' weapon name</param>
        /// <param name="monsterDamage">Boss' weapon damage</param>
        public Boss(string name, int health, string weapon, int monsterDamage) : base(name, health, weapon, monsterDamage)
        { }
        /// <summary>
        /// Outputs the Boss' name, health, weapon and damage
        /// </summary>
        public override void Output()
        {
            Console.WriteLine($"\n\n{Name}, {Health} Health, {Weapon}, Average Damage: {Damage}");
        }
    }
}

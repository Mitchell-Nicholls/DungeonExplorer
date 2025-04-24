using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    abstract class Creature : IDamageable
    {
        /// <summary>
        /// Creature class is the base class for all creatures in the game.
        /// </summary>
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public string Weapon { get; protected set; }
        public bool IsAlive { get => Health > 0; }
        public bool IsDead { get => Health <= 0; }
        /// <summary>
        /// Creature constructor initializes the creature's name, health, weapon, and damage.
        /// </summary>
        /// <param name="name">Name of the creature</param>
        /// <param name="health">Health of the creature</param>
        /// <param name="weapon">Weapon name of the creature</param>
        /// <param name="damage">Damage of the creature's weapon</param>
        public Creature(string name, int health, string weapon, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Weapon = weapon;
        }

        public virtual void Output()
        { }
        /// <summary>
        /// Outputs the creature's information (Player or Monster)
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}\tHealth: {Health}\tWeapon: {Weapon}\tDamage: {Damage}");
        }
        /// <summary>
        /// Virtual method for taking damage. This method is overridden in derived classes monster and player.
        /// </summary>
        /// <param name="damage">Entity Max Damage amount</param>
        /// <param name="entityName">Entity Name</param>
        /// <param name="entityWeapon">Entity Weapon. Must be the correlating weapon for the entity chosen</param>
        public virtual void TakeDamage(int damage, string entityName, string entityWeapon)
        { }
    }
}

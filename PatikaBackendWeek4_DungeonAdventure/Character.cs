using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class Character : ICharacter
    {
        public string Name { get; }

        public int HP { get; set; }

        public int MaxHP { get; protected set; }

        public int MP { get; set; }

        public int MaxMP { get; protected set; }

        public int Level { get; protected set; }

        protected Random Random { get; } = new Random();

        protected Character(string name, int maxHp, int maxMp, int level)
        {
            Name = name;
            MaxHP = maxHp;
            MaxMP = maxMp;
            Level = level;
        }

        public virtual void Attack(ICharacter target)
        {
            int damage = Random.Next(Level, Level * 2);
            ConsoleHelper.WriteLineColored($"[SALDIRI] {Name}, {target.Name}' e {damage} hasar veriyor!", ConsoleColor.Yellow);
            target.TakeDamage(damage);
        }

        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
            ConsoleHelper.WriteLineColored($"[HASAR] {Name} {damage} hasar alıyor! Kalan HP: {HP}", ConsoleColor.Red);
        }
    }
}

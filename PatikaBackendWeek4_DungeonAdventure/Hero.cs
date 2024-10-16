using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class Hero : Character
    {
        public Hero(string name, int maxHp, int maxMp, int level) : base(name, maxHp, maxMp, level)
        {
        }
        public Hero(string name) : base(name, 100, 50, 1)
        {
            Skills.Add(new FireballSkill());
            Skills.Add(new HealingSkill());
        }
        public List<Item> Inventory { get; } = new List<Item>();

        public int Experience { get; private set; }
        public void AddItemToInvertory(Item item)
        {
            Inventory.Add(item);
            ConsoleHelper.WriteLineColored($"[ESYA] {Name} yeni bir {item.Name} buldu!", ConsoleColor.Green);
        }
        public void UseItem(Item item)
        {
            if (Inventory.Contains(item))
            {
                item.Use(this);
                Inventory.Remove(item);
            }
            else
            {
                ConsoleHelper.WriteLineColored($"[HATA] Hay aksi! {Name}'in envanterinde {item.Name} yok.", ConsoleColor.DarkRed);
            }
        }
        public void GainExperience(int exp)
        {
            Experience += exp;
            ConsoleHelper.WriteLineColored($"[DENEYIM] {Name} {exp} deneyim puani kazandi. Bilgelik akiyor sanki :)", ConsoleColor.Green);

            if (Experience >= 100 * Level)
            {
                LevelUp();
            }
        }
        public void LevelUp()
        {
            Level++;
            MaxHP += 20;
            MaxMP += 10;

            HP = MaxHP;
            MP = MaxMP;

            Experience -= 100 * (Level - 1);

            ConsoleHelper.WriteLineColored($"[SEVIYE ATLADI] {Name} seviye atladi!", ConsoleColor.Magenta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class HealthPotion : Item
    {
        public HealthPotion() : base("Can Iksiri")
        {
        }

        public override void Use(Character character)
        {
            int healAmount = 30;
            character.HP = Math.Min(character.MaxHP, character.HP + healAmount);
            ConsoleHelper.WriteLineColored($"[IYILESME] {character.Name} can iksirini kafasina dikti. " +
                $"Vücuduna ssicak bir his yayildi ve {healAmount} HP yenilendi.", ConsoleColor.Green);
        }
    }
}

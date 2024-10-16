using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class ManaPotion : Item
    {
        public ManaPotion() : base("Mana Iksiri")
        {
        }

        public override void Use(Character character)
        {
            int manaAmount = 20;
            character.MP = Math.Min(character.MaxMP, character.MP + manaAmount);
            ConsoleHelper.WriteLineColored($"[MANA] {character.Name} mana iksirini icti ve beyni elektriklenmis gibi hissetti! {manaAmount} MP yenilendi", 
                ConsoleColor.Blue);
        }
    }
}

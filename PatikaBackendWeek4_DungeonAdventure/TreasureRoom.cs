using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class TreasureRoom : Room
    {
        private Item _treasure;
        public TreasureRoom(string name, Item treasure) : base(name)
        {
            _treasure = treasure;
        }

        protected override void PerformAction(Hero hero)
        {
            ConsoleHelper.WriteLineColored($"[HAZINE] Gözleriniz parladi! {Name}'de {_treasure.Name} adinda bir hazine sandigi buldunuz.", ConsoleColor.Yellow);
            hero.AddItemToInvertory(_treasure);
        }
    }
}

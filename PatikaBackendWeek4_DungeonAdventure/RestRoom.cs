using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class RestRoom : Room
    {
        public RestRoom(string name) : base(name)
        {
        }

        protected override void PerformAction(Hero hero)
        {
            ConsoleHelper.WriteLineColored($"[DINLENME] {Name}, huzurlu bir oda. Burada biraz kestirseniz iyi olacak.", ConsoleColor.Green);

            hero.HP = hero.MaxHP;
            hero.MP = hero.MaxMP;

            ConsoleHelper.WriteLineColored($"[IYILESME] kisa bir sekerleme yaptiniz. HP ve MPniz tamamen yenilendi.", ConsoleColor.Green);
        }
    }
}

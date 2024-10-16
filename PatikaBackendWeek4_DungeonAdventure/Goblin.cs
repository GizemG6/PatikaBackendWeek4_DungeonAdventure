using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class Goblin : Enemy
    {
        public Goblin(string name) : base(name, 30, 10, 1)
        {
            Skills.Add(new SneackAttackSkill());
        }

        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteLineColored($"{Name} sinsi bir saldiri yapiyor", ConsoleColor.Green);
            Skills[0].Use(this, target);
        }
    }
}

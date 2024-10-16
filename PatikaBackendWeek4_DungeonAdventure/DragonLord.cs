using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class DragonLord : Enemy
    {
        public DragonLord(string name) : base(name, 500, 200, 10)
        {
            Skills.Add(new DragonBreathSkill());
        }

        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteLineColored($"{Name} korkunc ejderha nefesini puskurtuyor!", ConsoleColor.DarkRed);
            Skills[0].Use(this, target);
        }
    }
}

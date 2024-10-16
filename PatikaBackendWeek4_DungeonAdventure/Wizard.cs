using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class Wizard : Enemy
    {
        public Wizard(string name) : base(name, 50, 100, 5)
        {
            Skills.Add(new FireballSkill());
        }

        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteColored($"{Name} güclü bir ates topu firlatiyor!", ConsoleColor.Magenta);
            Skills[0].Use(this, target);
        }
    }
}

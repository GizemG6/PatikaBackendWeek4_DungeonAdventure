using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class SneackAttackSkill : Skill
    {
        public SneackAttackSkill() : base("Sinsi Saldiri", 5)
        {
        }

        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 2 + new Random().Next(1, 6);
        }
    }
}

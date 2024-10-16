using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class FireballSkill : Skill
    {
        public FireballSkill() : base("Ateş Topu", 5)
        {

        }

        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 3;
        }
    }
}

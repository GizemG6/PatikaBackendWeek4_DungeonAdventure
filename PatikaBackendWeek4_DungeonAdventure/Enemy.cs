using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public abstract class Enemy : Character
    {
        protected Enemy(string name, int maxHp, int maxMp, int level, int hp, int mp) : base(name, maxHp, maxMp, level, hp, mp)
        {
        }
        public abstract void SpecialMove(Character character);
    }
}

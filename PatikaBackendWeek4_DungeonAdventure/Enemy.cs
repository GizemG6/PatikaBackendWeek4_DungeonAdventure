using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public abstract class Enemy : Character
    {
        protected Enemy(string name, int hp, int mp, int level) : base(name, hp, mp, level)
        {
        }
        public abstract void SpecialMove(Character character);
    }
}

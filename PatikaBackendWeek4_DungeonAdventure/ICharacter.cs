using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public interface ICharacter
    {
        string Name { get; }
        int HP { get; set; }
        int MaxHp { get; }
        int MP { get; set; }
        int MaxMP { get; }
        int Level { get; }
        void Attack(ICharacter target);
        void TakeDamage(int damage);
    }
}

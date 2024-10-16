using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class HealingSkill : Skill
    {
        public HealingSkill() : base("Iyileştirme", 8)
        {
        }

        public override int Use(Character user, ICharacter target)
        {
            int healAmount = user.Level * 2;
            user.HP = Math.Min(user.MaxHP, user.HP + healAmount);

            ConsoleHelper.WriteLineColored($"[IYILESME] {user.Name} büyülü bir ışıkla sarıldı ve {healAmount} HP iyilesti.", ConsoleColor.Green);

            return 0;
        }
    }
}

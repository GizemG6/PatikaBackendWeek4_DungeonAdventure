using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class BattleRoom : Room
    {
        private Enemy _enemy;

        public event Func<Hero, Enemy, bool> OnBattle;
        public BattleRoom(string name, Enemy enemy) : base(name)
        {
            _enemy = enemy;
        }

        protected override void PerformAction(Hero hero)
        {
            ConsoleHelper.WriteLineColored($"[SAVAS] {Name}'da bir kapiyi actiniz ve...Eyvah bir {_enemy.Name} belirdi!", ConsoleColor.Red);

            bool battleResult = OnBattle?.Invoke(hero, _enemy) ?? false;

            if (battleResult)
            {
                ConsoleHelper.WriteLineColored($"[ZAFER] {_enemy.Name}'i yendiniz. Büyük bir zafer", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteLineColored($"[YENILGI] {_enemy.Name} karsisinda yenildiniz :(", ConsoleColor.Red);
            }
        }
    }
}

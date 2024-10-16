using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaBackendWeek4_DungeonAdventure
{
    public class Game
    {
        private Hero _hero;
        private List<Room> _rooms;
        private DragonLord _dragonLord;

        public Game()
        {
            InitializeGame();
        }
        private void InitializeGame()
        {
            _hero = new Hero("Cesur Maceraci");
            _rooms = new List<Room>
            {
                CreateBattleRoom("Karanlik Koridor", new Goblin("Sinsi Goblib")),
                new TreasureRoom("Eski hazine odasi", new HealthPotion()),
                new RestRoom("Huzurlu Bahce"),
                CreateBattleRoom("Ates Cukuru", new Troll("Koca Troll")),
                new TreasureRoom("Gizli Kasa", new ManaPotion()),
                new RestRoom("Sifali Pinar"),
                CreateBattleRoom("Büyücünün Kulesi", new Wizard("Kötü Büyücü"))
            };

            _dragonLord = new DragonLord("Kizil Ejderha");
        }

        private BattleRoom CreateBattleRoom(string name, Enemy enemy)
        {
            var battleRoom = new BattleRoom(name, enemy);
            battleRoom.OnBattle += Battle;

            return battleRoom;
        }

        public void Start()
        {
            ConsoleHelper.WriteLineColored("=== Zindan Macerasina Hosgeldiniz ===", ConsoleColor.Magenta);
            ConsoleHelper.WriteLineColored($"Siz {_hero.Name}, zindandan kaçmaya çalisan cesur bir kahramansiniz", ConsoleColor.Cyan);

            foreach (var room in _rooms)
            {
                if (_hero.HP <= 0)
                {
                    ConsoleHelper.WriteLineColored("[OYUN BITTI] Maalesef yenildiniz :( Belki bir sonraki sefere!", ConsoleColor.Red);
                    return;
                }

                room.Enter(_hero);
                DisplayHeroStatus();
            }

            if (_hero.HP > 0)
            {
                FinalBossBattle();
            }
        }

        private bool Battle(Hero hero, Enemy enemy)
        {
            while (hero.HP > 0 && enemy.HP > 0)
            {
                PerformTurn(hero, enemy);
                if (enemy.HP > 0)
                    PerformTurn(enemy, hero);
            }

            if (enemy.HP <= 0)
            {
                ConsoleHelper.WriteLineColored($"[ZAFER] {enemy.Name} yendiniz. Büyük bir zafer kazandiniz", ConsoleColor.Green);
                hero.GainExperience(enemy.Level * 20);
                return true;
            }

            return false;
        }

        private void PerformTurn(ICharacter attacker, ICharacter defender)
        {
            ConsoleHelper.WriteLineColored($"\\n[SIRA] {attacker.Name} in sirasi:", ConsoleColor.Yellow);

            ConsoleHelper.WriteLineColored($"HP {attacker.HP}/{attacker.MaxHP}, MP {attacker.MP}/{attacker.MaxMP}", ConsoleColor.Cyan);

            if (attacker is Hero hero)
            {
                PerformHeroTurn(hero, defender);
            }
            else if (attacker is Enemy enemy)
            {
                PerformEnemy(enemy, defender);
            }
        }

        private void PerformHeroTurn(Hero hero, ICharacter enemy)
        {
            ConsoleHelper.WriteLineColored("Ne yapmak istersiniz?", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored("1. Saldir", ConsoleColor.White);
            ConsoleHelper.WriteLineColored("2. Beceri Kullan", ConsoleColor.White);
            ConsoleHelper.WriteLineColored("3. Esya Kullan", ConsoleColor.White);

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    hero.Attack(enemy);
                    break;
                case "2":
                    ChooseAndUseSkill(hero, enemy);
                    break;
                case "3":
                    ChooseAndUseItem(hero);
                    break;
                default:
                    ConsoleHelper.WriteLineColored("[HATA] geçersiz secim yaptiniz!!! Heyecandan ne yapacaginizi şaşirdiniz ve saldirdiniz",
                        ConsoleColor.Red);
                    hero.Attack(enemy);
                    break;
            }
        }

        private void PerformEnemy(Enemy enemy, ICharacter hero)
        {
            enemy.SpecialMove(hero as Character);
        }

        private void ChooseAndUseSkill(Hero hero, ICharacter enemy)
        {
            ConsoleHelper.WriteLineColored("Hangi beceriyi kullanmak istersiniz?", ConsoleColor.Yellow);

            for (int i = 0; i < hero.Skills.Count; i++)
            {
                ConsoleHelper.WriteLineColored($"{i + 1}. {hero.Skills[i].Name} (MP maliyeti: {hero.Skills[i].MPCost})", ConsoleColor.White);
            }

            if (int.TryParse(Console.ReadLine(), out int skillChoice) && skillChoice > 0 && skillChoice <= hero.Skills.Count)
            {
                hero.UseSkill(hero.Skills[skillChoice - 1], enemy);
            }
            else
            {
                ConsoleHelper.WriteLineColored("[HATA] geçersiz beceri secimi. Varsayilan olarak saldiriyorsunuz", ConsoleColor.DarkRed);
                hero.Attack(enemy);
            }
        }

        private void ChooseAndUseItem(Hero hero)
        {
            if (!hero.Inventory.Any())
            {
                ConsoleHelper.WriteLineColored("[HATA] Eyvah! Cantaniz bomboş. Keske biraz alisveris yapsaydiniz :(", ConsoleColor.DarkRed);
                return;
            }

            ConsoleHelper.WriteLineColored("Hangi esyayi kullanmak istiyorsunuz?", ConsoleColor.Yellow);
            for (int i = 0; i < hero.Inventory.Count; i++)
            {
                ConsoleHelper.WriteLineColored($"{i + 1}. {hero.Inventory[i].Name}", ConsoleColor.White);
            }

            if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= hero.Inventory.Count)
            {
                Item choosenItem = hero.Inventory[itemChoice - 1];
                hero.UseItem(choosenItem);
            }
            else
            {
                ConsoleHelper.WriteLineColored("[HATA] Esya secerken hata yaptiniz!", ConsoleColor.DarkRed);
            }
        }

        private void DisplayHeroStatus()
        {
            ConsoleHelper.WriteLineColored("\\n ----Kahraman Durumu----", ConsoleColor.Cyan);
            ConsoleHelper.WriteLineColored($"Seviye: {_hero.Level}", ConsoleColor.White);
            ConsoleHelper.WriteLineColored($"HP: {_hero.HP}/{_hero.MaxHp}", ConsoleColor.Red);
            ConsoleHelper.WriteLineColored($"MP: {_hero.MP}/{_hero.MaxMP}", ConsoleColor.Blue);
            ConsoleHelper.WriteLineColored($"Deneyim: {_hero.Experience}", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored($"Envanter: {string.Join(",", _hero.Inventory.Select(i => i.Name))}", ConsoleColor.Green);
        }

        private void FinalBossBattle()
        {
            ConsoleHelper.WriteLineColored($"[SON BOSS] Son odaya ulastiniz. {_dragonLord.Name} size dogru geliyor!", ConsoleColor.Green);

            bool victorious = Battle(_hero, _dragonLord);

            if (victorious)
            {
                ConsoleHelper.WriteColored($"[ZAFER] Tebrikler! {_dragonLord.Name} yendiniz ve zindandan kactiniz! Siz gercek bir kahramansiniz!",
                    ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteColored($"[OYUN BITTI], {_dragonLord.Name} tarafindan yenildiniz! Ama iyi bir mücadeleydi!",
                    ConsoleColor.Red);
            }
        }
    }
}

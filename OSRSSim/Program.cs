using System;
using System.Collections.Generic;



namespace Csh_Exip
{
    class OSRSCombatSimulator
    {
        private static bool app_is_open = true;
        public static List<Players> players = new List<Players> { };


        static void Main(string[] args)
        {
            AddPlayers();
            string chose = "";
            while (app_is_open)
            {
                Console.WriteLine("\n1. Add characters?\n2. Start fight?\n3. Save player?\n4. Load player?\nexit\n");
                chose = Console.ReadLine();
                switch (chose)
                {
                    case "1.":
                        Console.WriteLine("Coming soon");
                        break;
                    case "2.":
                        SelectFightersAndFight();
                        break;
                    case "3.":
                        Data_store.SavePlayer();
                        break;
                    case "4.":
                        Data_store.LoadPlayer();
                        break;
                    case "exit":
                        AppClose();
                        break;
                    default:
                        Console.WriteLine("Wrong selection");
                        break;
                }
            }
        }

        private static void SelectFightersAndFight()
        {
            Console.WriteLine("Enter first fighter: ");
            Players fighter_1 = SelectFighter(Console.ReadLine());
            if (fighter_1 == null) return;
            Console.WriteLine("Enter second fighter: ");
            Players fighter_2 = SelectFighter(Console.ReadLine());
            if (fighter_2 == null) return;
            //cant fight other round because hp doesnt reset...
            Fight.StartFight(fighter_1, fighter_2);
        }

        private static void AddPlayers() {
            /*Console.Write("Set player name:");
            int name = Console.Read();
            Console.Write("Set player health_level:");
            int hp_lvl;*/
            players.Add(
                new Players
                (
                    name: "Player_1",
                    hp_lvl: 100,
                    str_lvl: 99,
                    atk_lvl: 99,
                    def_lvl: 30
                )
            );
            players.Add(
               new Players
               (
                   name: "Player_2",
                   hp_lvl: 100,
                   str_lvl: 30,
                   atk_lvl: 99,
                   def_lvl: 99
               )
            );
        }
        public static int FindPlayer(string name)
        {
            for (int i = 0; i < players.Count; i++)
            {

                if (name == players[i].name) return i;
            }
            return -1;
        }
        private static Players SelectFighter(string name)
        {
            int i = FindPlayer(name);
            if (0 <= i)
            {
                return players[i];
            }
            else
            {
                Console.WriteLine("Player not found.");
                return null;
            }
        }

        
        private static void AppClose(){
            app_is_open = false;
        }
    }
}
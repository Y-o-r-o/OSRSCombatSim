using System;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace OSRSComSim.Models
{
    public class Players
    {

        public string name { get; set; }
        public int hp_lvl { get; set; }
        public int def_lvl { get; set; }
        public int str_lvl { get; set; }
        public int atk_lvl { get; set; }


        public Combat combat = new Combat();
        public Players() :this ("No_name", 10, 1, 1, 1)  { }
        public Players(string name = "No_name", int hp_lvl = 10, int def_lvl = 1, int str_lvl = 1, int atk_lvl = 1)
        {
            this.name = name;
            this.def_lvl = def_lvl;
            this.hp_lvl = hp_lvl;
            this.str_lvl = str_lvl;
            this.atk_lvl = atk_lvl;
            combat.set_combat(str_lvl,atk_lvl,def_lvl);
            /*Console.WriteLine($"{combat.atk_max}\n");
            Console.WriteLine($"{combat.atk_roll}\n");
            Console.WriteLine($"{combat.def_roll}\n");*/
        }

    }
}

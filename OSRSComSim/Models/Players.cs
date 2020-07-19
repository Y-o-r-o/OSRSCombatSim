using System;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace OSRSComSim.Models
{
    public class Players: ObservableObject
    {


        public string Name { get; set; }
        public int Hp_lvl { get; set; }
        public int Def_lvl { get; set; }
        public int Str_lvl { get; set; }
        public int Atk_lvl { get; set; }





        public Combat combat = new Combat();
        public Players() : this("No_name", 10, 1, 1, 1) { }
        public Players(string name = "No_name", int hp_lvl = 10, int def_lvl = 1, int str_lvl = 1, int atk_lvl = 1)
        {
            this.Name = name;
            this.Def_lvl = def_lvl;
            this.Hp_lvl = hp_lvl;
            this.Str_lvl = str_lvl;
            this.Atk_lvl = atk_lvl;
                    
            combat.set_combat(str_lvl, atk_lvl, def_lvl);
        }

       




    }
}

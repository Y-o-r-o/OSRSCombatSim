using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.Models
{
    class Equipment: ObservableObject
    {
        //png ...
        //lvl ...

        public string  Name { get; set; } = "";
        public bool Member { get; set; } = false;
        public int     StabAtk  { get; set; } = 0;
        public int     SlashAtk { get; set; } = 0;
        public int     CrushAtk { get; set; } = 0;
        public int     MagicAtk { get; set; } = 0;
        public int     RangedAtk{ get; set; } = 0;
        public int     StabDef  { get; set; } = 0;
        public int     SlashDef { get; set; } = 0;
        public int     CrushDef { get; set; } = 0;
        public int     MagicDef { get; set; } = 0;
        public int     RangedDef{ get; set; } = 0;
        public int     MeleStr  { get; set; } = 0;
        public int     RangedStr{ get; set; } = 0;
        public int     MagicStr { get; set; } = 0;
        public int     Prayer   { get; set; } = 0;
        public double Weigth { get; set; } = 0;

        Equipment()
        {
            
        }

    }
}

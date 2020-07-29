using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.Models
{
    public class Equipment: ObservableObject
    {
        private string _png = "";
        //lvl ...

        public string  Name     { get; set; } = "";
        public bool    Member   { get; set; } = false;
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
        public double  Weigth   { get; set; } = 0;
        public int     Speed    { get; set; } = 0;
        public string Png
        {
            get { return _png; }
            set
            {
                _png = value;
                OnPropertyChanged("Png");
            }
        }
        public Equipment()
        {
            
        }
        private string _debug = "null";
        public string Debug
        {
            get { return _debug; }
            set
            {
                _debug = value;
                OnPropertyChanged("Debug");

            }

        }


        public void setData(string data, string equipment_type)
        {
            string[] values = data.Split(',');
            Name = values[0];
            if (values[1].Contains("Free-to-play")) Member = false;
            else Member = true;
            StabAtk = Int32.Parse(values[2]);
            SlashAtk = Int32.Parse(values[3]);
            CrushAtk = Int32.Parse(values[4]);
            MagicAtk = Int32.Parse(values[5]);
            RangedAtk = Int32.Parse(values[6]);
            StabDef = Int32.Parse(values[7]);
            SlashDef = Int32.Parse(values[8]);
            CrushDef = Int32.Parse(values[9]);
            MagicDef = Int32.Parse(values[10]);
            RangedDef = Int32.Parse(values[11]);
            MeleStr = Int32.Parse(values[12]);
            RangedStr = Int32.Parse(values[13]);
            
            MagicStr = Int32.Parse(values[14]);
            Prayer = Int32.Parse(values[15]);
            Weigth = Double.Parse(values[16]);
            Speed = Int32.Parse(values[17]);

            Png = "../Resources/Items/png/"+equipment_type +"/" + Name.Replace(" ", "_") + ".png";
            Debug = Png;

        }

    }
}

namespace OSRSComSim.Models
{
    public class Equipment : ObservableObject
    {
        private string _png = "";
        //lvl ...
        public string Name { get; set; } = "";
        public bool Member { get; set; } = false;
        public int StabAtk { get; set; } = 0;
        public int SlashAtk { get; set; } = 0;
        public int CrushAtk { get; set; } = 0;
        public int MagicAtk { get; set; } = 0;
        public int RangedAtk { get; set; } = 0;
        public int StabDef { get; set; } = 0;
        public int SlashDef { get; set; } = 0;
        public int CrushDef { get; set; } = 0;
        public int MagicDef { get; set; } = 0;
        public int RangedDef { get; set; } = 0;
        public int MeleStr { get; set; } = 0;
        public int RangedStr { get; set; } = 0;
        public int MagicStr { get; set; } = 0;
        public int Prayer { get; set; } = 0;
        public double Weigth { get; set; } = 0;
        public int Speed { get; set; } = 0;
        public string Png
        {
            get { return _png; }
            set
            {
                _png = value;
                OnPropertyChanged("Png");
            }
        }

        public Equipment (): this(null) { }
        public Equipment(string equipment_type)
        {
            switch (equipment_type)
            {
                case "Head":
                    Png = "../Resources/App/Equipment/Head_slot.png";
                    break;
                case "Neck":
                    Png = "../Resources/App/Equipment/Neck_slot.png";
                    break;
                case "Cape":
                    Png = "../Resources/App/Equipment/Cape_slot.png";
                    break;
                case "Ammo":
                    Png = "../Resources/App/Equipment/Ammo_slot.png";
                    break;
                case "Weapon":
                    Png = "../Resources/App/Equipment/Weapon_slot.png";
                    Name = "Unarmed";
                    Speed = 4;
                    break;
                case "Body":
                    Png = "../Resources/App/Equipment/Body_slot.png";
                    break;
                case "Shield":
                    Png = "../Resources/App/Equipment/Shield_slot.png";
                    break;
                case "Legs":
                    Png = "../Resources/App/Equipment/Legs_slot.png";
                    break;
                case "Feet":
                    Png = "../Resources/App/Equipment/Feet_slot.png";
                    break;
                case "Hands":
                    Png = "../Resources/App/Equipment/Hands_slot.png";
                    break;
                case "Ring":
                    Png = "../Resources/App/Equipment/Ring_slot.png";
                    break;
                default:
                    break;
            }
        }


    }
}

using System;

namespace OSRSComSim.Models.Items
{
    public class EquipmentModel : ItemModel
    {
        //lvl ...
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
        public int Speed { get; set; } = 0;
        public int Prayer { get; set; } = 0;

        public EquipmentModel(): this(null, "") { }
        public EquipmentModel(string equipment_type, string equipment_data = "")
        {
            ItemType = "Equipment";
            if (equipment_data.Length == 0)
                constructDefaultEqp(equipment_type);
            else constructEqp(equipment_data);
        }

        private void constructDefaultEqp(string equipment_type)
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

        public void constructEqp(string equipment_data)
        {
            string[] values = equipment_data.Split(',');
            ItemType = values[0];
            Name = values[1];
            //Member = values[2];
            Weigth = Double.Parse(values[3]);
            StabAtk = Int32.Parse(values[4]);
            SlashAtk = Int32.Parse(values[5]);
            CrushAtk = Int32.Parse(values[6]);
            MagicAtk = Int32.Parse(values[7]);
            RangedAtk = Int32.Parse(values[8]);
            StabDef = Int32.Parse(values[9]);
            SlashDef = Int32.Parse(values[10]);
            CrushDef = Int32.Parse(values[11]);
            MagicDef = Int32.Parse(values[12]);
            RangedDef = Int32.Parse(values[13]);
            MeleStr = Int32.Parse(values[14]);
            RangedStr = Int32.Parse(values[15]);
            MagicStr = Int32.Parse(values[16]);
            Prayer = Int32.Parse(values[17]);
            Speed = Int32.Parse(values[18]);
            Png = constructPng(ItemType, values[1]);
        }

    
    }
}

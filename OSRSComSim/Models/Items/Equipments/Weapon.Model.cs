using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.Models.Items.Equipments
{
    public class WeaponModel : EquipmentModel
    {
        public bool is_two_handed = false;

        public string WeaponType { get; set; } = null;

        public WeaponModel() : this("") { }
        public WeaponModel(string weapon_data = "")
        {
            ItemType = "Weapon";
            if (weapon_data.Length == 0)
                constructDefaultWeapon();
            else constructWeapon(weapon_data);
        }

        public void constructDefaultWeapon()
        {
            Name = "Unarmed";
            Speed = 4;
            WeaponType = "Unarmed";
            Png = "../Resources/App/Equipment/Weapon_slot.png";
        }

        public void constructWeapon(string weapon_data)
        {
            string[] values = weapon_data.Split(',');
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
            WeaponType = values[19];
            is_two_handed = Boolean.Parse(values[20]);
        }

    
    
    }
}

/*
            //if (values[1].Contains("Free-to-play")) Member = false;   !!!!!!!!!!!!!!!!!!!
            //else Member = true;                                       !!!!!!!!!!!!!!!!!!!
 */







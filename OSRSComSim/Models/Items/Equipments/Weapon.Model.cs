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
        private string _weapon_type = null;

        public bool is_two_handed = false;

        public string WeaponType
        {
            get { return _weapon_type; }
            set
            {
                _weapon_type = value;
                OnPropertyChanged("WeaponType");
            }
        }

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
            Name = values[0];
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
            Png = constructPng("Weapon", values[0]);
            WeaponType = values[18];
            is_two_handed = Boolean.Parse(values[19]);
        }

    
    
    }
}

/*
            //if (values[1].Contains("Free-to-play")) Member = false;   !!!!!!!!!!!!!!!!!!!
            //else Member = true;                                       !!!!!!!!!!!!!!!!!!!
 */







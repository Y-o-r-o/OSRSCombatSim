using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.Models.Items.Equipments
{
    public class Weapon: Equipment
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

        public Weapon() : this(null) { }
        public Weapon(string weapon_type)
        {
            Name = "Unarmed";
            Speed = 4;
            WeaponType = "Unarmed";
            Png = "../Resources/App/Equipment/Weapon_slot.png";
        }

    }
}

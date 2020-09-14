using OSRSComSim.Models.Items;
using OSRSComSim.Models.Items.Equipments;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OSRSComSim.Models
{
    [CollectionDataContract(ItemName = "Item")]
    [XmlInclude(typeof(FoodModel)), XmlInclude(typeof(PotionModel)), XmlInclude(typeof(RunesModel))]
    public class EquipedModel: ObservableObject
    {
        private const int inventory_capativity = 28;

        public EquipmentModel _head;
        public EquipmentModel _neck;
        public EquipmentModel _cape;
        public EquipmentModel _ammo;
        public WeaponModel _weapon;
        public EquipmentModel _body;
        public EquipmentModel _shield;
        public EquipmentModel _legs;
        public EquipmentModel _feet;
        public EquipmentModel _hands;
        public EquipmentModel _ring;
        private ObservableCollection<object> _item;


        public EquipmentModel Head 
        {
            get { return _head; }
            set
            {
                _head = value;
                OnPropertyChanged("Head");
            }
        }
        public EquipmentModel Neck
        {
            get { return _neck; }
            set
            {
                _neck = value;
                OnPropertyChanged("Neck");
            }
        }
        public EquipmentModel Cape
        {
            get { return _cape; }
            set
            {
                _cape = value;
                OnPropertyChanged("Cape");
            }
        }
        public EquipmentModel Ammo
        {
            get { return _ammo; }
            set
            {
                _ammo = value;
                OnPropertyChanged("Ammo");
            }
        }
        public WeaponModel Weapon
        {
            get { return _weapon; }
            set
            {
                _weapon = value;
                OnPropertyChanged("Weapon");
            }
        }
        public EquipmentModel Body
        {
            get { return _body; }
            set
            {
                _body = value;
                OnPropertyChanged("Body");
            }
        }
        public EquipmentModel Shield
        {
            get { return _shield; }
            set
            {
                _shield = value;
                OnPropertyChanged("Shield");
            }
        }
        public EquipmentModel Legs
        {
            get { return _legs; }
            set
            {
                _legs = value;
                OnPropertyChanged("Legs");
            }
        }
        public EquipmentModel Feet
        {
            get { return _feet; }
            set
            {
                _feet = value;
                OnPropertyChanged("Feet");
            }
        }
        public EquipmentModel Hands
        {
            get { return _hands; }
            set
            {
                _hands = value;
                OnPropertyChanged("Hands");
            }
        }
        public EquipmentModel Ring
        {
            get { return _ring; }
            set
            {
                _ring = value;
                OnPropertyChanged("Ring");
            }
        }
        public ObservableCollection<object> InventoryItem
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged("InventoryItem");
            }
        }


        private EquipedModel() { } 
        public EquipedModel(bool unused_value = false) //this unnuse value is for serializer, to not use this constructor. because if it uses, it always adds to InventoryItem new childrens. 
        {
            Head = new EquipmentModel("Head");
            Neck = new EquipmentModel("Neck");
            Cape = new EquipmentModel("Cape");
            Ammo = new EquipmentModel("Ammo");
            Weapon = new WeaponModel();
            Body = new EquipmentModel("Body");
            Shield = new EquipmentModel("Shield");
            Legs = new EquipmentModel("Legs");
            Feet = new EquipmentModel("Feet");
            Hands = new EquipmentModel("Hands");
            Ring = new EquipmentModel("Ring");
            InventoryItem = new ObservableCollection<object>();
            for (int i = 0; i < inventory_capativity; i++)
            {
                if(InventoryItem.Count <= 28) InventoryItem.Add(new ItemModel());
            }
        }

        //Class needs redesign from here
        public int getTotalStabAtk()
        {
            return Head.StabAtk + Neck.StabAtk + Cape.StabAtk + Ammo.StabAtk + Weapon.StabAtk + Body.StabAtk + Shield.StabAtk + Legs.StabAtk + Feet.StabAtk + Hands.StabAtk + Ring.StabAtk;
        }
        public int getTotalSlashAtk()
        {
            return Head.SlashAtk + Neck.SlashAtk + Cape.SlashAtk + Ammo.SlashAtk + Weapon.SlashAtk + Body.SlashAtk + Shield.SlashAtk + Legs.SlashAtk + Feet.SlashAtk + Hands.SlashAtk + Ring.SlashAtk;
        }
        public int getTotalCrushAtk()
        {
            return Head.CrushAtk + Neck.CrushAtk + Cape.CrushAtk + Ammo.CrushAtk + Weapon.CrushAtk + Body.CrushAtk + Shield.CrushAtk + Legs.CrushAtk + Feet.CrushAtk + Hands.CrushAtk + Ring.CrushAtk;
        }
        public int getTotalMagicAtk()
        {
            return Head.MagicAtk + Neck.MagicAtk + Cape.MagicAtk + Ammo.MagicAtk + Weapon.MagicAtk + Body.MagicAtk + Shield.MagicAtk + Legs.MagicAtk + Feet.MagicAtk + Hands.MagicAtk + Ring.MagicAtk;
        }
        public int getTotalRangedAtk()
        {
            return Head.RangedAtk + Neck.RangedAtk + Cape.RangedAtk + Ammo.RangedAtk + Weapon.RangedAtk + Body.RangedAtk + Shield.RangedAtk + Legs.RangedAtk + Feet.RangedAtk + Hands.RangedAtk + Ring.RangedAtk;
        }
        public int getTotalStabDef()
        {
            return Head.StabDef + Neck.StabDef + Cape.StabDef + Ammo.StabDef + Weapon.StabDef + Body.StabDef + Shield.StabDef + Legs.StabDef + Feet.StabDef + Hands.StabDef + Ring.StabDef;
        }
        public int getTotalSlashDef()
        {
            return Head.SlashDef + Neck.SlashDef + Cape.SlashDef + Ammo.SlashDef + Weapon.SlashDef + Body.SlashDef + Shield.SlashDef + Legs.SlashDef + Feet.SlashDef + Hands.SlashDef + Ring.SlashDef;
        }
        public int getTotalCrushDef()
        {
            return Head.CrushDef + Neck.CrushDef + Cape.CrushDef + Ammo.CrushDef + Weapon.CrushDef + Body.CrushDef + Shield.CrushDef + Legs.CrushDef + Feet.CrushDef + Hands.CrushDef + Ring.CrushDef;
        }
        public int getTotalMagicDef()
        {
            return Head.MagicDef + Neck.MagicDef + Cape.MagicDef + Ammo.MagicDef + Weapon.MagicDef + Body.MagicDef + Shield.MagicDef + Legs.MagicDef + Feet.MagicDef + Hands.MagicDef + Ring.MagicDef;
        }
        public int getTotalRangedDef()
        {
            return Head.RangedDef + Neck.RangedDef + Cape.RangedDef + Ammo.RangedDef + Weapon.RangedDef + Body.RangedDef + Shield.RangedDef + Legs.RangedDef + Feet.RangedDef + Hands.RangedDef + Ring.RangedDef;
        }
        public int getTotalMeleStr()
        {
            return Head.MeleStr + Neck.MeleStr + Cape.MeleStr + Ammo.MeleStr + Weapon.MeleStr + Body.MeleStr + Shield.MeleStr + Legs.MeleStr + Feet.MeleStr + Hands.MeleStr + Ring.MeleStr;
        }
        public int getTotalRangedStr()
        {
            return Head.RangedStr + Neck.RangedStr + Cape.RangedStr + Ammo.RangedStr + Weapon.RangedStr + Body.RangedStr + Shield.RangedStr + Legs.RangedStr + Feet.RangedStr + Hands.RangedStr + Ring.RangedStr;
        }
        public int getTotalMagicStr()
        {
            return Head.MagicStr + Neck.MagicStr + Cape.MagicStr + Ammo.MagicStr + Weapon.MagicStr + Body.MagicStr + Shield.MagicStr + Legs.MagicStr + Feet.MagicStr + Hands.MagicStr + Ring.MagicStr;
        }
        public int getTotalPrayer()
        {
            return Head.Prayer + Neck.Prayer + Cape.Prayer + Ammo.Prayer + Weapon.Prayer + Body.Prayer + Shield.Prayer + Legs.Prayer + Feet.Prayer + Hands.Prayer + Ring.Prayer;
        }
        public double getTotalWeigth()
        {
            return Head.Weigth + Neck.Weigth + Cape.Weigth + Ammo.Weigth + Weapon.Weigth + Body.Weigth + Shield.Weigth + Legs.Weigth + Feet.Weigth + Hands.Weigth + Ring.Weigth;
        }
        public int getTotalSpeed()
        {
            return Head.Speed + Neck.Speed + Cape.Speed + Ammo.Speed + Weapon.Speed + Body.Speed + Shield.Speed + Legs.Speed + Feet.Speed + Hands.Speed + Ring.Speed;
        }

        //equipment functions

        public static void mountEquipment(EquipedModel equiped, object equipment)
        {
            switch ((equipment as EquipmentModel).ItemType)
            {
                case "Head":
                    equiped.Head = equipment as EquipmentModel;
                    break;
                case "Neck":
                    equiped.Neck = equipment as EquipmentModel;
                    break;
                case "Cape":
                    equiped.Cape = equipment as EquipmentModel;
                    break;
                case "Ammo":
                    equiped.Ammo = equipment as EquipmentModel;
                    break;
                case "Body":
                    equiped.Body = equipment as EquipmentModel;
                    break;
                case "Shield":
                    equiped.Shield = equipment as EquipmentModel;
                    break;
                case "Legs":
                    equiped.Legs = equipment as EquipmentModel;
                    break;
                case "Feet":
                    equiped.Feet = equipment as EquipmentModel;
                    break;
                case "Hands":
                    equiped.Hands = equipment as EquipmentModel;
                    break;
                case "Ring":
                    equiped.Ring = equipment as EquipmentModel;
                    break;
                case "Weapon":
                    equiped.Weapon = equipment as WeaponModel;
                    break;
            }
        }

        public static EquipmentModel GetEquipment(EquipedModel equiped, string equipment_type)
        {
            switch (equipment_type)
            {
                case "Head":
                    return equiped.Head;
                case "Neck":
                    return equiped.Neck;
                case "Cape":
                    return equiped.Cape;
                case "Ammo":
                    return equiped.Ammo;
                case "Body":
                    return equiped.Body;
                case "Shield":
                    return equiped.Shield;
                case "Legs":
                    return equiped.Legs;
                case "Feet":
                    return equiped.Feet;
                case "Hands":
                    return equiped.Hands;
                case "Ring":
                    return equiped.Ring;
                case "Weapon":
                    return equiped.Weapon;
                default:
                    return null;
            }
        }

    }
}

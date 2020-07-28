using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.Models
{
    public class Equiped
    {
        public Equipment Head { get; set; }
        public Equipment Neck { get; set; }
        public Equipment Cape { get; set; }
        public Equipment Ammo { get; set; }
        public Equipment Sword { get; set; }
        public Equipment Body { get; set; }
        public Equipment Shield { get; set; }
        public Equipment Legs { get; set; }
        public Equipment Feet { get; set; }
        public Equipment Hands { get; set; }
        public Equipment Ring { get; set; }




        public Equiped()
        {
            Head = new Equipment();
            Neck = new Equipment();
            Cape = new Equipment();
            Ammo = new Equipment();
            Sword = new Equipment();
            Body = new Equipment();
            Shield = new Equipment();
            Legs = new Equipment();
            Feet = new Equipment();
            Hands = new Equipment();
            Ring = new Equipment();
            setupEquipmentDefautSlotImg();
        }

        private void setupEquipmentDefautSlotImg()
        {
            Head.Png = "../Resources/App/Equipment/Head_slot.png";
            Neck.Png = "../Resources/App/Equipment/Neck_slot.png";
            Cape.Png = "../Resources/App/Equipment/Cape_slot.png";
            Ammo.Png = "../Resources/App/Equipment/Ammo_slot.png";
            Sword.Png = "../Resources/App/Equipment/Weapon_slot.png";
            Body.Png = "../Resources/App/Equipment/Body_slot.png";
            Shield.Png = "../Resources/App/Equipment/Shield_slot.png";
            Legs.Png = "../Resources/App/Equipment/Legs_slot.png";
            Feet.Png = "../Resources/App/Equipment/Feet_slot.png";
            Hands.Png = "../Resources/App/Equipment/Hands_slot.png";
            Ring.Png = "../Resources/App/Equipment/Ring_slot.png";
        }


        public int getTotalStabAtk()
        {
            return Head.StabAtk + Neck.StabAtk + Cape.StabAtk + Ammo.StabAtk + Sword.StabAtk + Body.StabAtk + Shield.StabAtk + Legs.StabAtk + Feet.StabAtk + Hands.StabAtk + Ring.StabAtk;
        }
        public int getTotalSlashAtk()
        {
            return Head.SlashAtk + Neck.SlashAtk + Cape.SlashAtk + Ammo.SlashAtk + Sword.SlashAtk + Body.SlashAtk + Shield.SlashAtk + Legs.SlashAtk + Feet.SlashAtk + Hands.SlashAtk + Ring.SlashAtk;
        }
        public int getTotalCrushAtk()
        {
            return Head.CrushAtk + Neck.CrushAtk + Cape.CrushAtk + Ammo.CrushAtk + Sword.CrushAtk + Body.CrushAtk + Shield.CrushAtk + Legs.CrushAtk + Feet.CrushAtk + Hands.CrushAtk + Ring.CrushAtk;
        }
        public int getTotalMagicAtk()
        {
            return Head.MagicAtk + Neck.MagicAtk + Cape.MagicAtk + Ammo.MagicAtk + Sword.MagicAtk + Body.MagicAtk + Shield.MagicAtk + Legs.MagicAtk + Feet.MagicAtk + Hands.MagicAtk + Ring.MagicAtk;
        }
        public int getTotalRangedAtk()
        {
            return Head.RangedAtk + Neck.RangedAtk + Cape.RangedAtk + Ammo.RangedAtk + Sword.RangedAtk + Body.RangedAtk + Shield.RangedAtk + Legs.RangedAtk + Feet.RangedAtk + Hands.RangedAtk + Ring.RangedAtk;
        }
        public int getTotalStabDef()
        {
            return Head.StabDef + Neck.StabDef + Cape.StabDef + Ammo.StabDef + Sword.StabDef + Body.StabDef + Shield.StabDef + Legs.StabDef + Feet.StabDef + Hands.StabDef + Ring.StabDef;
        }
        public int getTotalSlashDef()
        {
            return Head.SlashDef + Neck.SlashDef + Cape.SlashDef + Ammo.SlashDef + Sword.SlashDef + Body.SlashDef + Shield.SlashDef + Legs.SlashDef + Feet.SlashDef + Hands.SlashDef + Ring.SlashDef;
        }
        public int getTotalCrushDef()
        {
            return Head.CrushDef + Neck.CrushDef + Cape.CrushDef + Ammo.CrushDef + Sword.CrushDef + Body.CrushDef + Shield.CrushDef + Legs.CrushDef + Feet.CrushDef + Hands.CrushDef + Ring.CrushDef;
        }
        public int getTotalMagicDef()
        {
            return Head.MagicDef + Neck.MagicDef + Cape.MagicDef + Ammo.MagicDef + Sword.MagicDef + Body.MagicDef + Shield.MagicDef + Legs.MagicDef + Feet.MagicDef + Hands.MagicDef + Ring.MagicDef;
        }
        public int getTotalRangedDef()
        {
            return Head.RangedDef + Neck.RangedDef + Cape.RangedDef + Ammo.RangedDef + Sword.RangedDef + Body.RangedDef + Shield.RangedDef + Legs.RangedDef + Feet.RangedDef + Hands.RangedDef + Ring.RangedDef;
        }
        public int getTotalMeleStr()
        {
            return Head.MeleStr + Neck.MeleStr + Cape.MeleStr + Ammo.MeleStr + Sword.MeleStr + Body.MeleStr + Shield.MeleStr + Legs.MeleStr + Feet.MeleStr + Hands.MeleStr + Ring.MeleStr;
        }
        public int getTotalRangedStr()
        {
            return Head.RangedStr + Neck.RangedStr + Cape.RangedStr + Ammo.RangedStr + Sword.RangedStr + Body.RangedStr + Shield.RangedStr + Legs.RangedStr + Feet.RangedStr + Hands.RangedStr + Ring.RangedStr;
        }
        public int getTotalMagicStr()
        {
            return Head.MagicStr + Neck.MagicStr + Cape.MagicStr + Ammo.MagicStr + Sword.MagicStr + Body.MagicStr + Shield.MagicStr + Legs.MagicStr + Feet.MagicStr + Hands.MagicStr + Ring.MagicStr;
        }
        public int getTotalPrayer()
        {
            return Head.Prayer + Neck.Prayer + Cape.Prayer + Ammo.Prayer + Sword.Prayer + Body.Prayer + Shield.Prayer + Legs.Prayer + Feet.Prayer + Hands.Prayer + Ring.Prayer;
        }
        public double getTotalWeigth()
        {
            return Head.Weigth + Neck.Weigth + Cape.Weigth + Ammo.Weigth + Sword.Weigth + Body.Weigth + Shield.Weigth + Legs.Weigth + Feet.Weigth + Hands.Weigth + Ring.Weigth;
        }

    }
}

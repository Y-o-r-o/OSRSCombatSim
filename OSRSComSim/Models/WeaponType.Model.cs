using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.Models
{
    static public class WeaponTypeModel
    {
        static public int NumberOfOptions { get; set; }

        static public string Option1 { get; set; } = null;
        static public string Option2 { get; set; } = null;
        static public string Option3 { get; set; } = null;
        static public string Option4 { get; set; } = null;
        static public string Option5 { get; set; } = null;

        static public string Option1Style { get; set; } = null;
        static public string Option2Style { get; set; } = null;
        static public string Option3Style { get; set; } = null;
        static public string Option4Style { get; set; } = null;
        static public string Option5Style { get; set; } = null;


        static public void setOptions(CombatModel FighterCombat, string weapontype)
        {
            switch (weapontype)
            {
                case "Axes":
                    optionsAxes();
                    break;
                case "Blunt weapons":
                    optionsBluntWeapons();
                    break;
                case "Bulwarks":
                    optionsBulwarks();
                    break;
                case "Claws":
                    optionsClaws();
                    break;
                case "Polearms":
                    optionsPolearms();
                    break;
                case "Pickaxes":
                    optionsPickaxes();
                    break;
                case "Scythes":
                    optionsScythes();
                    break;
                case "Slashing swords":
                    optionsSlashingSwords();
                    break;
                case "Spears":
                    optionsSpears();
                    break;
                case "Spiked weapons":
                    optionsSpikedWeapons();
                    break;
                case "Stabbing swords":
                    optionsStabbingSwords();
                    break;
                case "Two-handed swords":
                    optionsTwoHandedSwords();
                    break;
                case "Whips":
                    optionsWhips();
                    break;
                case "Bows":
                    optionsBows();
                    break;
                case "Chinchompas":
                    optionsChinchompas();
                    break;
                case "Crossbows":
                    optionsCrossbows();
                    break;
                case "Thrown weapons":
                    optionsThrownWeapons();
                    break;
                case "Staves":
                    optionsStaves();
                    break;
                case "Bladed staves":
                    optionsBladedStaves();
                    break;
                case "Powered staves":
                    optionsPoweredStaves();
                    break;
                case "Banners":
                    optionsBanners();
                    break;
                case "Blasters":
                    optionsBlasters();
                    break;
                case "Guns":
                    optionsGuns();
                    break;
                case "Polestaves":
                    optionsPolestaves();
                    break;
                case "Salamanders":
                    optionsSalamanders();
                    break;
                case "Unarmed":
                    optionsUnarmed();
                    break;
            }
            setCombat(FighterCombat, Option1, Option1Style);
        }
        static public void setCombat(CombatModel FighterCombat, string combat_style, string attack_type)
        {
            FighterCombat.CurretOptions = new CombatCurretOptionModel(combat_style, attack_type);
        }
        static private void optionsAxes() 
        {
            Option1 = "Chop";
            Option2 = "Hack";
            Option3 = "Smash";
            Option4 = "SlashBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Aggresive";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsBluntWeapons()
        {
            Option1 = "Pound";
            Option2 = "Pummel";
            Option3 = "CrushBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Defensive";
            NumberOfOptions = 3;
        }
        static private void optionsBulwarks()
        {
            Option1 = "Pummel";
            Option2 = "Block";
            Option1Style = "Accurate";
            Option2Style = "None"; //!
            NumberOfOptions = 2;
        }
        static private void optionsClaws()
        {
            Option1 = "Chop";
            Option2 = "Slash";
            Option3 = "Lunge";
            Option4 = "SlashBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Controlled";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsPolearms()
        {
            Option1 = "StabJab";
            Option2 = "Swipe";
            Option3 = "StabFend";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Defensive";
            NumberOfOptions = 3;
        }
        static private void optionsPickaxes()
        {
            Option1 = "Spike";
            Option2 = "Impale";
            Option3 = "Smash";
            Option4 = "StabBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Aggresive";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsScythes()
        {
            Option1 = "Reap";
            Option2 = "Chop";
            Option3 = "CrushJab";
            Option4 = "SlashBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Aggresive";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsSlashingSwords()
        {
            Option1 = "Chop";
            Option2 = "Slash";
            Option3 = "Lunge";
            Option4 = "Block";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Controlled";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsSpears()
        {
            Option1 = "Lunge";
            Option2 = "Swipe";
            Option3 = "Pound";
            Option4 = "StabBlock";
            Option1Style = "Controlled";
            Option2Style = "Controlled";
            Option3Style = "Controlled";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsSpikedWeapons()
        {
            Option1 = "Pound";
            Option2 = "Pummel";
            Option3 = "Spike";
            Option4 = "CrushBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Controlled";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsStabbingSwords()
        {
            Option1 = "Stab";
            Option2 = "Lunge";
            Option3 = "Slash";
            Option4 = "StabBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Aggresive";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsTwoHandedSwords()
        {
            Option1 = "Chop";
            Option2 = "Slash";
            Option3 = "Smash";
            Option4 = "SlashBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Aggresive";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsWhips()
        {
            Option1 = "Flick";
            Option2 = "Lash";
            Option3 = "Deflect";
            Option1Style = "Accurate";
            Option2Style = "Controlled";
            Option3Style = "Defensive";
            NumberOfOptions = 3;
        }
        static private void optionsBows()
        {
            Option1 = "RangedAccurate";
            Option2 = "Rapid";
            Option3 = "RangedLongrange";
            Option1Style = "Accurate";
            Option2Style = "Rapid";
            Option3Style = "Longrange";
            NumberOfOptions = 3;
        }
        static private void optionsChinchompas()
        {
            Option1 = "Short fuse";
            Option2 = "Medium fuse";
            Option3 = "Long fuse";
            Option1Style = "Accurate";
            Option2Style = "Rapid";
            Option3Style = "Longrange";
            NumberOfOptions = 3;
        }
        static private void optionsCrossbows()
        {
            Option1 = "RangedAccurate";
            Option2 = "Rapid";
            Option3 = "RangedLongrange";
            Option1Style = "Accurate";
            Option2Style = "Rapid";
            Option3Style = "Longrange";
            NumberOfOptions = 3;
        }
        static private void optionsThrownWeapons()
        {
            Option1 = "RangedAccurate";
            Option2 = "Rapid";
            Option3 = "RangedLongrange";
            Option1Style = "Accurate";
            Option2Style = "Rapid";
            Option3Style = "Longrange";
            NumberOfOptions = 3;
        }
        static private void optionsStaves()
        {
            Option1 = "Bash";
            Option2 = "Pound";
            Option3 = "Focus";
            Option4 = "Spell";
            Option5 = "Spell (Defensive)";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Defensive";
            Option4Style = "Magic";
            Option5Style = "Magic";
            NumberOfOptions = 5;
        }
        static private void optionsBladedStaves()
        {
            Option1 = "StabJab";
            Option2 = "Swipe";
            Option3 = "CrushFend";
            Option4 = "Spell";
            Option5 = "Spell (Defensive)";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Defensive";
            Option4Style = "Magic";
            Option5Style = "Magic";
            NumberOfOptions = 5;
        }
        static private void optionsPoweredStaves()
        {
            Option1 = "MagicAccurate";
            Option2 = "MagicAccurate";
            Option3 = "MagicLongrange";
            Option1Style = "Accurate";
            Option2Style = "Accurate";
            Option3Style = "Longrange";
            NumberOfOptions = 3;
        }
        static private void optionsBanners()
        {
            Option1 = "Lunge";
            Option2 = "Swipe";
            Option3 = "Pound";
            Option4 = "StabBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Aggresive";
            Option4Style = "Defensive";
            NumberOfOptions = 4;
        }
        static private void optionsBlasters()
        {
            Option1 = "Explosive";
            Option2 = "Flamer";
            Option1Style = "Gun";
            Option2Style = "Gun";
            NumberOfOptions = 2;
        }
        static private void optionsGuns()
        {
            Option1 = "Aim and Fire";
            Option2 = "Kick";
            Option1Style = "Guns";
            Option2Style = "Aggresive";
            NumberOfOptions = 2;
        }
        static private void optionsPolestaves()
        {
            Option1 = "Bash";
            Option2 = "Pound";
            Option3 = "CrushBlock";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style =  "Defensive";
            NumberOfOptions = 3;
        }
        static private void optionsSalamanders()
        {
            Option1 = "Scorch";
            Option2 = "Flare";
            Option3 = "Blaze";
            Option1Style = "Slash";
            Option2Style = "Accurate";
            Option3Style = "Magic";
            NumberOfOptions = 3;
        }
        static private void optionsUnarmed()
        {
            Option1 = "Punch";
            Option2 = "Kick";
            Option3 = "Block";
            Option1Style = "Accurate";
            Option2Style = "Aggresive";
            Option3Style = "Defensive";
            NumberOfOptions = 3;
        }
    }
}

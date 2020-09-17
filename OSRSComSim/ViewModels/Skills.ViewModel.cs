using OSRSComSim.Models;
using OSRSComSim.Views;
using System;

namespace OSRSComSim.ViewModels
{
    public class SkillsViewModel: ObservableObject
    {
        private string _btn_visibility;

        public object View { get; set; }
        public SkillsModel PlayerSkills { get; set; }
        
        public string BtnVisibility
        {
            get
            {
                return _btn_visibility;
            }
            set
            {
                _btn_visibility = value;
                OnPropertyChanged("BtnVisibility");
            }
        }

        public SkillsViewModel() : this(null, "Edit") { }
        public SkillsViewModel(SkillsModel skills, string skills_mode)
        {
            PlayerSkills = skills;
            if (skills_mode == "Edit" || skills_mode == "Create")
                BtnVisibility = "Visible"; 
            else BtnVisibility = "Hidden";

            View = new SkillsView(this);
        }

        public void resetPlayerSkills()
        {
           PlayerSkills = new SkillsModel();
        }
        public void setRandomPlayerSkills()
        {
            Random rnd = new Random();
            PlayerSkills.Hp_lvl = rnd.Next(10, 100);
            PlayerSkills.Def_lvl = rnd.Next(1, 100);
            PlayerSkills.Str_lvl = rnd.Next(1, 100);
            PlayerSkills.Atk_lvl = rnd.Next(1, 100);
            PlayerSkills.Magic_lvl = rnd.Next(1, 100);
            PlayerSkills.Ranged_lvl = rnd.Next(1, 100);
            PlayerSkills.Prayer_lvl = rnd.Next(1, 100);
        }
        public void editPlayerSkills(string name, int value)
        {
            switch (name)
            {
                case "HP":
                    PlayerSkills.Hp_lvl += value;
                    break;
                case "Def":
                    PlayerSkills.Def_lvl+= value;
                    break;
                case "Str":
                    PlayerSkills.Str_lvl+= value;
                    break;
                case "Atk":
                    PlayerSkills.Atk_lvl += value;
                    break;
                case "Magic":
                    PlayerSkills.Magic_lvl += value;
                    break;
                case "Ranged":
                    PlayerSkills.Ranged_lvl += value;
                    break;
                case "Prayer":
                    PlayerSkills.Prayer_lvl += value;
                    break;
                default:
                    //throw ex
                    break;
            }
        }

    }
}

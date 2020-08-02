using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    public class SkillsViewModel: ObservableObject
    {
        private string _btn_visibility;
        private Skills _playerskills;

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
        public Skills PlayerSkills
        {
            get { return _playerskills;  }
            set
            {
                _playerskills = value;
                OnPropertyChanged("PlayerSkills");
            }
        }


        public SkillsViewModel(Skills skills, bool can_modify_skills = false)
        {
            PlayerSkills = skills;
            if (can_modify_skills)
                BtnVisibility = "Visible";
            else BtnVisibility = "Hidden";

        }

        public void resetPlayerSkills()
        {
           PlayerSkills = new Skills();
        }
        public void setRandomPlayerSkills()
        {
            Random rnd = new Random();
            PlayerSkills.Hp_lvl = rnd.Next(10, 100);
            PlayerSkills.Def_lvl = rnd.Next(1, 100);
            PlayerSkills.Str_lvl = rnd.Next(1, 100);
            PlayerSkills.Atk_lvl = rnd.Next(1, 100);
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
                    PlayerSkills.Atk_lvl+= value;
                    break;
                default:
                    //throw ex
                    break;
            }
        }

    }
}

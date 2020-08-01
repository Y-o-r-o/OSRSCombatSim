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
        private Skills _playerskills;

        public Skills PlayerSkills
        {
            get { return _playerskills;  }
            set
            {
                _playerskills = value;
                OnPropertyChanged("PlayerSkills");
            }
        }

        public SkillsViewModel(Skills skills)
        {
            PlayerSkills = skills;
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
                case "PlusHP":
                    PlayerSkills.Hp_lvl+=value;
                    break;
                case "PlusDef":
                    PlayerSkills.Def_lvl+=value;
                    break;
                case "PlusStr":
                    PlayerSkills.Str_lvl+= value;
                    break;
                case "PlusAtk":
                    PlayerSkills.Atk_lvl+= value;
                    break;
                default:
                    //throw ex
                    break;
            }
        }

    }
}

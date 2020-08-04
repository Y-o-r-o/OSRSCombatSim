using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{


    public class BattleViewModel: ObservableObject
    {
        private bool _thread_is_started;
        private string _buttonfightcontent;
        private FighterViewModel _fighter1;
        private FighterViewModel _fighter2;

        private Thread th1;
        private Thread th2;

        public FighterViewModel Fighter1 
        {
            get { return _fighter1; }
            set
            {
                _fighter1 = value;
                OnPropertyChanged("Fighter1");
            }
        }
        public FighterViewModel Fighter2
        {
            get { return _fighter2; }
            set
            {
                _fighter2 = value;
                OnPropertyChanged("Fighter2");
            }
        }
        public bool ThreadIsStarted
        {
            get
            {
                return _thread_is_started;
            }
            set 
            {
                _thread_is_started = value;
                if (value == false) ButtonFightContent = "Fight";
                else ButtonFightContent = "Reset";
            }
        }
        public string ButtonFightContent
        {
            get { return _buttonfightcontent; }
            set
            {
                _buttonfightcontent = value;
                OnPropertyChanged("ButtonFightContent");
            }

        }

        public BattleViewModel()
        {
            Fighter1 = new FighterViewModel();
            Fighter2 = new FighterViewModel();
            _buttonfightcontent = "Fight";//
            ThreadIsStarted = false;
        }

        public void start_stopFight()
        {
            if (ThreadIsStarted || !playersIsNotDead()) Reset();
            else
            {

                th1 = FighterStartFight(Fighter1, Fighter2);
                th2 = FighterStartFight(Fighter2, Fighter1, 1000);

                ThreadIsStarted = true;
            }
        }

        private Thread FighterStartFight(FighterViewModel attacker, FighterViewModel deffender, int sleep = 0)
        {
            var t = new Thread(() => Fight(attacker, deffender, sleep));
            t.Start();
            return t;
        }

        private void Fight(FighterViewModel attacker, FighterViewModel deffender, int sleep)
        {
            Thread.Sleep(sleep);
            string attack_res = "";
            while (playersIsNotDead())
            {
                attack_res = attacker.getAttackRessult(deffender);
                deffender.takeDamage(attack_res);
                
                Thread.Sleep(1400); //atk speed - 1000;
            }
            ThreadIsStarted = false;
        }

        private bool playersIsNotDead()
        {
            return !(Fighter1.isDead() || Fighter2.isDead());
        }

        public void Reset()
        {
            if (ThreadIsStarted)
            {
                th1.Abort();
                th2.Abort();
                ThreadIsStarted = false;
            }
            Fighter1.Reset();
            Fighter2.Reset();
        }
    }
}

using OSRSComSim.Models;
using OSRSComSim.Views;
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
        private FighterView _fighter1;
        private FighterView _fighter2;

        private Thread th1;
        private Thread th2;

        public FighterView Fighter1 
        {
            get { return _fighter1; }
            set
            {
                _fighter1 = value;
                OnPropertyChanged("Fighter1");
            }
        }
        public FighterView Fighter2
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
            Fighter1 = new FighterView();
            Fighter2 = new FighterView();
            _buttonfightcontent = "Fight";//
            ThreadIsStarted = false;
        }

        public void start_stopFight()
        {
            if (ThreadIsStarted || !playersIsNotDead()) Reset();
            else
            {

                th1 = FighterStartFight(Fighter1.view_model, Fighter2.view_model);
                th2 = FighterStartFight(Fighter2.view_model, Fighter1.view_model, 1000);

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
                attacker.rest();
            }
            ThreadIsStarted = false;
        }

        private bool playersIsNotDead()
        {
            return !(Fighter1.view_model.isDead() || Fighter2.view_model.isDead());
        }

        public void Reset()
        {
            if (ThreadIsStarted)
            {
                th1.Abort();
                th2.Abort();
                ThreadIsStarted = false;
            }
            Fighter1.view_model.Reset();
            Fighter2.view_model.Reset();
        }
    }
}

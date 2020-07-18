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
    public class MainWindowViewModel : ObservableObject
    {
        private Thread th1;
        private Thread th2;
        private bool thread_is_started;

        private object _viewcontent;

        private Players _fighter1;
        private Players _fighter2;

        public object ViewContent
        {
            get
            {
                return _viewcontent;
            }
            set
            {
                _viewcontent = value;
                OnPropertyChanged("ViewContent");
            }
        }
      
        public Players Fighter1
        {
            get { return _fighter1; }
            set
            {
                _fighter1 = value;
                OnPropertyChanged("Fighter1");
            }
        }
        public Players Fighter2
        {
            get { return _fighter2; }
            set
            {
                _fighter2 = value;
                OnPropertyChanged("Fighter2");
            }
        }


        public MainWindowViewModel()
        {
            thread_is_started = false;
        }


        public void viewLoadScreen(string fighter_num)
        {
            if(Fighter1 != null && Fighter2 != null)reset();
            ViewContent = new LoadScreenView(this, fighter_num);
        }

        public void stopView()
        {
            ViewContent = null;
        }
        public void StartFight()
        {
            reset();
            th2 = FighterStartFight(Fighter2, Fighter1);
            Thread.Sleep(1000);
            th1 = FighterStartFight(Fighter1, Fighter2);
            thread_is_started = true; 
        }

        public Thread FighterStartFight(Players attacker, Players deffender)
        {
            var t = new Thread(() => Fight(attacker, deffender));
            t.Start();
            return t;
        }

        public void Fight(Players attacker, Players deffender)
        {
            string attack = "";
            while (true)
            {   
                
                attack = attacker.combat.Attack(deffender.combat.def_roll);
                
                if (attack != "def")
                {
                    deffender.LastAtkStatColor = "Red";
                    deffender.LastAtkStatContext = attack.ToString();

                    deffender.HealthTaken += (int)Math.Round((double.Parse(attack) / deffender.Hp_lvl) * 100);
                }
                else
                {
                    deffender.LastAtkStatColor = "Blue";
                    deffender.LastAtkStatContext = "0";
                }
                Thread.Sleep(1000);
                deffender.LastAtkStatColor = "Transparent";
                deffender.LastAtkStatContext = "";
                Thread.Sleep(1400);
                if (attacker.HealthTaken >= 100 || deffender.HealthTaken >= 100) break;
            }
            thread_is_started = false;
        }

        public void reset()
        {
            if (thread_is_started)
            {
                th1.Abort();
                th2.Abort();
                thread_is_started = false;
            }
            Fighter1.Reset();
            Fighter2.Reset();
        }
    }
}

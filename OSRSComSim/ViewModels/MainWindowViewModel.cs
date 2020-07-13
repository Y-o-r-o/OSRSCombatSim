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
        private Thread th_fight;
        private bool thread_is_started;

        private object _viewcontent;

        private Players _fighter1;
        private Players _fighter2;

        private string _fight_log;

        private int _health_taken1;
        private int _health_taken2;
        private string _fighter1name;
        private string _fighter2name;


        public string Fighter1Name
        {
            get { return _fighter1name; }
            set
            {
                _fighter1name = value;
                OnPropertyChanged("Fighter1Name");
            }
        }
        public string Fighter2Name
        {
            get { return _fighter2name; }
            set
            {
                _fighter2name = value;
                OnPropertyChanged("Fighter2Name");
            }
        }
        public int HealthTaken1
        {
            get
            {
                return _health_taken1;
            }
            set
            {
                if (value >= 0)
                {
                    if (value >= 100)
                    {
                        _health_taken1 = 100;
                    }
                    else _health_taken1 = value;
                    OnPropertyChanged("HealthTaken1");
                }

            }
        }
        public int HealthTaken2
        {
            get
            {
                return _health_taken2;
            }
            set
            {
                if (value >= 0)
                {
                    if (value >= 100)
                    {
                        _health_taken2 = 100;
                    }
                    else _health_taken2 = value;
                    OnPropertyChanged("HealthTaken2");
                }

            }
        }
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
                Fighter1Name = ((Players)value).name;
                OnPropertyChanged("Fighter1");
            }
        }
        public Players Fighter2
        {
            get { return _fighter2; }
            set
            {
                _fighter2 = value;
                Fighter2Name = ((Players)value).name;
                OnPropertyChanged("Fighter1");
            }
        }
        public string FightLog
        {
            get { return _fight_log; }
            set
            {
                _fight_log = value;
                OnPropertyChanged("FightLog");
            }
        }



        public MainWindowViewModel()
        {
            _fighter1name = "No player selected";
            _fighter2name = "No player selected";
            _fight_log = "....";
            _health_taken1 = 0;
            _health_taken2 = 0;
            thread_is_started = false;
        }


        public void viewLoadScreen(string fighter_num)
        {
            reset();
            ViewContent = new LoadScreenView(this, fighter_num);
        }

        public void stopView()
        {
            ViewContent = null;
        }
        public void StartFight()
        {
            reset();
            th_fight = new Thread(new ThreadStart(Fight));
            th_fight.Start();
            thread_is_started = true;
        }



        public void Fight()
        {
            while (true)
            {
                int atk_f1 = Fighter1.combat.Attack(Fighter2.combat.def_roll);
                int atk_f2 = Fighter2.combat.Attack(Fighter1.combat.def_roll);
                Thread.Sleep(10);
                HealthTaken2 += (int)Math.Round(((double)atk_f1 / Fighter2.hp_lvl) * 100);
                Thread.Sleep(10);
                HealthTaken1 += (int)Math.Round(((double)atk_f2 / Fighter1.hp_lvl) * 100);
                if (HealthTaken2 == 100 || HealthTaken1 == 100) break;
            }
            thread_is_started = false;
        }

        public void reset()
        {
            if (thread_is_started)
            {
                th_fight.Abort();
                thread_is_started = false;
            }
            HealthTaken1 = 0;
            HealthTaken2 = 0;
        }
    }
}

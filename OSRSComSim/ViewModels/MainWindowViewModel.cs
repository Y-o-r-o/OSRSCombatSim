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

        private int _health_taken1;
        private int _health_taken2;

        private string _lastatkstat1color;
        private string _lastatkstat2color;

        private string _lastatkstat1context;
        private string _lastatkstat2context;

        public string LastAtkStat1Color 
        {
            get 
            { return _lastatkstat1color; }
            set 
            {
                _lastatkstat1color = value;
                OnPropertyChanged("LastAtkStat1Color");
            }
        }
        public string LastAtkStat2Color
        {
            get
            { return _lastatkstat2color; }
            set
            {
                _lastatkstat2color = value;
                OnPropertyChanged("LastAtkStat2Color");
            }
        }
        
        public string LastAtkStat1Context
        {
            get
            { return _lastatkstat1context; }
            set
            {
                _lastatkstat1context = value;
                OnPropertyChanged("LastAtkStat1Context");
            }
        }
        public string LastAtkStat2Context
        {
            get
            { return _lastatkstat2context; }
            set
            {
                _lastatkstat2context = value;
                OnPropertyChanged("LastAtkStat2Context");
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
            _health_taken1 = 0;
            _health_taken2 = 0;
            LastAtkStat1Color = "Transparent";
            LastAtkStat2Color = "Transparent";
            LastAtkStat1Context = "";
            LastAtkStat2Context = "";
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
            string atk_f1;
            string atk_f2;
            while (true)
            {   
                
                atk_f1 = Fighter1.combat.Attack(Fighter2.combat.def_roll);
                atk_f2 = Fighter2.combat.Attack(Fighter1.combat.def_roll);
                
                
                if (atk_f1 != "def")
                {
                    LastAtkStat2Color = "Red";
                    LastAtkStat2Context = atk_f1.ToString();

                    HealthTaken2 += (int)Math.Round((double.Parse(atk_f1) / Fighter2.hp_lvl) * 100);
                }
                else
                {
                    LastAtkStat2Color = "Blue";
                    LastAtkStat2Context = "0";
                }
                Thread.Sleep(1000);
                LastAtkStat2Color = "Transparent";
                LastAtkStat2Context = "";
                Thread.Sleep(1400);
                
                
                if (atk_f2 != "def")
                {
                    LastAtkStat1Color = "Red";
                    LastAtkStat1Context = atk_f2.ToString();
                    HealthTaken1 += (int)Math.Round((double.Parse(atk_f2) / Fighter1.hp_lvl) * 100);
                }
                else
                {
                    LastAtkStat1Color = "Blue";
                    LastAtkStat1Context = "0";
                }
                Thread.Sleep(1000);
                LastAtkStat1Color = "Transparent";
                LastAtkStat1Context = "";
                Thread.Sleep(1400);


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
            LastAtkStat1Color = "Transparent";
            LastAtkStat1Context = "";
            LastAtkStat2Color = "Transparent";
            LastAtkStat2Context = "";
            HealthTaken1 = 0;
            HealthTaken2 = 0;
        }
    }
}

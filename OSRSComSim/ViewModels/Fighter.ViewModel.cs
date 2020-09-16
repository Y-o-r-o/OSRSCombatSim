﻿using OSRSComSim.Models;
using OSRSComSim.Views;
using System;
using System.Threading;

namespace OSRSComSim.ViewModels
{
    public class FighterViewModel : ObservableObject
    {
        const int gameticks = 600;
        private const int status_show_time = 1000;

        Thread th_show_stats;

        private ControlPanelViewModel _controlpanel;
        private int _health_taken;
        private PlayerModel _fighter;
        private CombatModel _fighter_combat;
        private string _name;
        private string _last_atk_stat_context;
        private string _last_atk_stat_color;
        
        public object View { get; set; }
        public ControlPanelViewModel ControlPanel
        {
            get { return _controlpanel; }
            set
            {
                _controlpanel = value;
                OnPropertyChanged("ControlPanel");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public PlayerModel Fighter
        {
            get { return _fighter; }
            set
            {
                _fighter = value;
                OnPropertyChanged("Fighter");
            }
        }
        public CombatModel FighterCombat
        {
            get { return _fighter_combat; }
            set
            {
                _fighter_combat = value;
                OnPropertyChanged("FighterCombat");
            }
        }

        public string LastAtkStatColor
        {
            get { return _last_atk_stat_color; }
            set
            {
                _last_atk_stat_color = value;

                OnPropertyChanged("LastAtkStatColor");
            }
        }
        public string LastAtkStatContext
        {
            get { return _last_atk_stat_context; }
            set
            {
                _last_atk_stat_context = value;

                OnPropertyChanged("LastAtkStatContext");
            }
        }
        public int HealthTaken
        {
            get { return _health_taken; }
            set
            {
                if (value >= 100) _health_taken = 100;
                else _health_taken = value;
                OnPropertyChanged("HealthTaken");
            }
        }

        public FighterViewModel(): this (null) { }
        public FighterViewModel(PlayerModel selectedplayer = null)
        {
            if (selectedplayer == null) selectedplayer = new PlayerModel();
            ControlPanel = new ControlPanelViewModel(player: selectedplayer, cp_mode: "Interactive");
            Name = selectedplayer.Name;
            Fighter = selectedplayer;
            FighterCombat = selectedplayer.Combat;
            WeaponTypeModel.setOptions(selectedplayer.Combat, selectedplayer.Equiped.Weapon.WeaponType);
            setupFighter();

            View = new FighterView(this);
        }
        private void setupFighter()
        {
            LastAtkStatColor = "Transparent";
            LastAtkStatContext = "";
        }


        public string getAttackRessult(PlayerModel deffender)
        {
            int deffender_def_roll = CombatModel.Deffend(deffender, FighterCombat);
            return CombatModel.Attack(Fighter, deffender_def_roll);
        }
        private Thread startStatusShow(string context, string color)
        {
            var t = new Thread(() => statusShow(context, color));
            t.Start();
            return t;
        }
        private void statusShow(string context, string color)
        {
            LastAtkStatColor = color;
            LastAtkStatContext = context;
            Thread.Sleep(status_show_time);
            LastAtkStatColor = "Transparent";
            LastAtkStatContext = "";
        }

        public void rest()
        {
            Thread.Sleep((Fighter.Equiped.getTotalSpeed() - FighterCombat.CurretOptions.StancBonusSpd) * gameticks);
        }
        public void takeDamage(string attack_res)
        {
            if (attack_res == "def")
            {
                th_show_stats = startStatusShow("0", "Blue");
            }
            else if (attack_res == "Message")
            {
                th_show_stats = startStatusShow("Debug: you cant attack", "Transparent");
            }
            else
            {
                HealthTaken += (int)Math.Round((double.Parse(attack_res) / Fighter.Skills.Hp_lvl) * 100);
                th_show_stats = startStatusShow(attack_res.ToString(), "Red");
            }
        }
        public bool isDead()
        {
            return HealthTaken == 100;
        }
        public void Reset()
        {
            HealthTaken = 0;
            LastAtkStatColor = "Transparent";
            LastAtkStatContext = "";
        }

    }
}

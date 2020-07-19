using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{


    public class BattleViewModel
    {
        private bool thread_is_started;


        private Thread th1;
        private Thread th2;

        public FighterViewModel Fighter1 { get; set; }
        public FighterViewModel Fighter2 { get; set; }

        public BattleViewModel()
        {
            Fighter1 = new FighterViewModel();
            Fighter2 = new FighterViewModel();
            thread_is_started = false;
        }

        public void StartFight()
        {
            Reset();
            th2 = FighterStartFight(Fighter2, Fighter1);
            Thread.Sleep(1000);
            th1 = FighterStartFight(Fighter1, Fighter2);
            thread_is_started = true;
        }

        private Thread FighterStartFight(FighterViewModel attacker, FighterViewModel deffender)
        {
            var t = new Thread(() => Fight(attacker, deffender));
            t.Start();
            return t;
        }

        private void Fight(FighterViewModel attacker, FighterViewModel deffender)
        {
            string attack_res = "";
            while (!(attacker.isDead() || deffender.isDead()))
            {
                attack_res = attacker.getAttackRessult(deffender);
                deffender.takeDamage(attack_res);
                
                Thread.Sleep(1400); //atk speed - 1000;
            }
            thread_is_started = false;
        }


        public void Reset()
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

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

        public void start_stopFight()
        {
            if (thread_is_started || !playersIsNotDead()) Reset();
            else
            {

                th1 = FighterStartFight(Fighter1, Fighter2);

                th2 = FighterStartFight(Fighter2, Fighter1, 1000);
                thread_is_started = true;
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
            thread_is_started = false;
        }

        private bool playersIsNotDead()
        {
            return !(Fighter1.isDead() || Fighter2.isDead());
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

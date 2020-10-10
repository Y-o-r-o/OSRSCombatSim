using System.Threading;

namespace OSRSComSim.ViewModels
{


    public class BattleViewModel: ObservableObject
    {
        private Thread th1;
        private Thread th2;

        public FighterViewModel Fighter1 { get; set; }
        public FighterViewModel Fighter2 { get; set; }
        public bool ThreadIsStarted { get; set; }
        public string ButtonFightContent { get; set; }

        public BattleViewModel()
        {
            Fighter1 = new FighterViewModel();
            Fighter2 = new FighterViewModel();
            ButtonFightContent = "Fight";//
            ThreadIsStarted = false;
        }

        public void start_stopFight()
        {
            if (ThreadIsStarted || !playersIsNotDead())
            {
                ButtonFightContent = "Fight";
                Reset();
            }
            else
            {
                ButtonFightContent = "Reset";

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
                attack_res = attacker.getAttackRessult(deffender.Fighter);
                deffender.takeDamage(attack_res);
                attacker.rest();
            }
            ThreadIsStarted = false;
        }

        private bool playersIsNotDead()
        {
            return !(Fighter1.isDead() || Fighter2.isDead());
        }

        public void Reset()
        {
            if (th1 != null || th2 != null)
            {
                if (th1.IsAlive || th2.IsAlive)
                {
                    th1.Abort();
                    th2.Abort();
                    ThreadIsStarted = false;
                }
            }
            Fighter1.Reset();
            Fighter2.Reset();
        }
    }
}

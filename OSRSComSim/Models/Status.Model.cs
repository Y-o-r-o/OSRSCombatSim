using OSRSComSim.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.Models
{
    public class StatusModel : ObservableObject
    {
        private int _health_left;
        private int _hit_points_left;


        public int TotalHitPoints {get; set;}
        public int HealthLeft
        {
            get { return _health_left; }
            set
            {
                _health_left = value;
                if (_health_left < 0) _health_left = 0;

                OnPropertyChanged("HealthLeft");
                OnPropertyChanged("HealthTaken");
            }
        }
        public int HealthTaken
        {
            get { return -1 * (HealthLeft - 100); }
        }
        public int HitPointsLeft
        {
            get { return _hit_points_left; }
            set
            {
                _hit_points_left = value;
                if (_hit_points_left < 0) _hit_points_left = 0;
                else if (_hit_points_left > TotalHitPoints) _hit_points_left = TotalHitPoints;
                OnPropertyChanged("HitPointsLeft");
            }
        }

        public StatusModel() : this(10, 1) { }
        public StatusModel(int hp_lvl = 10, int prayer_lvl = 1)
        {
            TotalHitPoints = hp_lvl;
            HitPointsLeft = hp_lvl;
            HealthLeft = 100;
        }

        //Status functions

        public static void takeDmage(StatusModel status, int dmage)
        {
            status.HitPointsLeft -= dmage;
            status.HealthLeft -= (int)Math.Round(((double)dmage / (double)status.TotalHitPoints) * 100);
        }

        public static void heal(StatusModel status, int hp_to_heal)
        {
            status.HitPointsLeft += hp_to_heal;
            status.HealthLeft += (int)Math.Round(((double)hp_to_heal / (double)status.TotalHitPoints) * 100);
        }

        public static void reset_status(StatusModel status)
        {
            status.HitPointsLeft = status.TotalHitPoints;
            status.HealthLeft = 100;
        }

    }
}

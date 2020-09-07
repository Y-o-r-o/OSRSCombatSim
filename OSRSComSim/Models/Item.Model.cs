using OSRSComSim.ViewModels;
using System;
using System.Windows.Controls;


namespace OSRSComSim.Models
{
    public class ItemModel : ObservableObject
    {
        private string _png = "";
        
        public bool Member { get; set; } = false;
        public string Name { get; set; } = "";
        public double Weigth { get; set; } = 0;
        public string ItemType { get; set; } = "";
        public string Png
        {
            get { return _png; }
            set
            {
                _png = value;
                OnPropertyChanged("Png");
            }
        }
        

        public ItemModel()
        {
            Png = "../Resources/404.png";
        }


    }
}
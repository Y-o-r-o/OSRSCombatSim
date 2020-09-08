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

        protected string constructPng(string item_type, string png_name)
        {
            string png_location = "../../Resources/Items/png/" + item_type + "/" + png_name.Replace(" ", "_") + ".png";
            if (Data_store.CheckIfFileExists(png_location))
            {
                return png_location;
            }
            else return "../../Resources/404.png";
        }

    }
}
using System;

namespace OSRSComSim.Models.Items
{
    public class FoodModel : ItemModel
    {
        private int _hp_heals = 0;

        public int HPHeals
        {
            get { return _hp_heals; }
            set
            {
                _hp_heals = value;
                OnPropertyChanged("HPHeals");
            }
        }

        public FoodModel(): this("") { }
        public FoodModel(string item_data)
        {
            ItemType = "Food";
            if (item_data.Length != 0)
                constructFood(item_data);

        }

        public void constructFood(string item_data)
        {
            string[] values = item_data.Split(',');
            ItemType = values[0];
            Name = values[1];
            //Member = values[2];
            Weigth = Double.Parse(values[3]);
            HPHeals = Int32.Parse(values[4]);
            Png = constructPng(ItemType, values[1]);
        }
    }
}

using System;

namespace OSRSComSim.Models.Items
{
    public class PotionModel : ItemModel
    {
        public PotionModel() : this("") { }
        public PotionModel(string item_data)
        {
            ItemType = "Potion"; 
            if (item_data.Length != 0)
                constructPotion(item_data);
        }

        public void constructPotion(string item_data)
        {
            string[] values = item_data.Split(',');
            ItemType = values[0];
            Name = values[1];
            //Member = values[2];
            Weigth = Double.Parse(values[3]);
            Png = constructPng(ItemType, values[1]);
        }
    }
}

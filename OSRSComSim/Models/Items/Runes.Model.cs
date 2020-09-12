using System;

namespace OSRSComSim.Models.Items
{
    public class RunesModel : ItemModel
    {
        public RunesModel(): this("") { }
        public RunesModel(string item_data)
        {
            ItemType = "Runes";
            if (item_data.Length != 0)
                constructRunes(item_data);
        }

        public void constructRunes(string item_data)
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

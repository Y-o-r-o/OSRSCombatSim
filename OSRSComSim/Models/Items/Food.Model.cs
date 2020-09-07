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

        public FoodModel()
        {
            ItemType = "Food";
        }

    }
}

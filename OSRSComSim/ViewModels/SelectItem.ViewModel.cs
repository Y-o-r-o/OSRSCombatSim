using OSRSComSim.Models;
using System.Collections.Generic;
using System.Linq;


namespace OSRSComSim.ViewModels
{
    public class SelectItemViewModel: ObservableObject
    {
        public string[] _lines;
        private EquipedModel player_equiped;

        public object View { get; set; }

        public string ItemsToSelect { get; set; }
        public string SelectedItemSlotName { get; set; }

        public IEnumerable<string> ReadCSV
        {
            get
            {
                if (SelectedItemSlotName != "")
                    return _lines.Select(line =>
                    {
                        return line.Split(',').Skip(1).FirstOrDefault();
                    });
                else return null;
            }
        }

        public SelectItemViewModel() : this(null, "", "", true) { }
        public SelectItemViewModel(EquipedModel player_equiped = null, string selected_slot = "", string items_to_select = "", bool view = true)
        {
            this.player_equiped = player_equiped;

            SelectedItemSlotName = selected_slot;
            ItemsToSelect = items_to_select;

            _lines = getCSV();


            if(view) View = new SelectItemView(this);
        }
        
        private string getItemData(string equipment_name)
        {
            int i = 0;
            foreach (string eqp in _lines)
            {
                i++;
                if (eqp.Contains(equipment_name))
                {
                    return eqp;
                }
            }
            return "";
        }
        private string[] getCSV()
        {
            string[] lines = new string[0];
            if (ItemsToSelect.Contains("Head")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Head.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Neck")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Neck.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Cape")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Cape.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Ammo")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Ammo.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Weapon")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Weapon.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Body")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Body.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Shield")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Shield.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Legs")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Legs.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Feet")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Feet.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Hands")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Hands.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Ring")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Ring.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Food")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Food.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Potions")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Potions.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Runes")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Runes.Split('\n'))).ToArray();
            }
            return lines;
        }
        private string[] skipFirstAndLastLines(string[] lines)
        {
            lines = lines.Skip(1).ToArray();
            lines = lines.Take(lines.Count() - 1).ToArray();
            return lines;
        }
        public void select(string equipment_name) //exmp: inv_item_0 ... 27
        {
            string item_data = getItemData(equipment_name);
            EquipedModel.mountItem(player_equiped, SelectedItemSlotName,item_data);
        }
    }
}

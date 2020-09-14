﻿using OSRSComSim.ViewModels;
using System;
using System.Windows.Controls;


namespace OSRSComSim.Models
{
    public class ItemModel : ObservableObject
    {
        private string _png = "";
        
        public string ItemType { get; set; } = "";
        public string Name { get; set; } = "";
        public bool Member { get; set; } = false;
        public double Weigth { get; set; } = 0;
        
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


        //item functions
        public static string getItemType(ItemModel item)
        {
            if (itemIsEquipment(item)) return "Equipment";
            else return item.ItemType;
        }
        public static bool itemIsEquipment(ItemModel item)
        {
            switch (item.ItemType)
            {
                case "Weapon": return true;
                case "Head": return true;
                case "Neck": return true;
                case "Cape": return true;
                case "Ammo": return true;
                case "Body": return true;
                case "Shield": return true;
                case "Legs": return true;
                case "Feet": return true;
                case "Hands": return true;
                case "Ring": return true;
                default: return false;
            }
        }
        public static bool equipmentIsWeapon(ItemModel item)
        {
            if (item.ItemType.Equals("Weapon")) return true;
            else return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

using OSRSComSim.Models;
using System.Collections.ObjectModel;

namespace OSRSComSim
{
    static class Data_store
    {
        static private string path = "no_path";
        static private XmlSerializer serializer = null;

        static Data_store()
        {
            CreatePath();
            serializer = new XmlSerializer(typeof(Players));
        }



        private static void CreatePath()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RSCombatSimulator\";
            System.IO.Directory.CreateDirectory(path);
        }

        public static void LoadPlayers(ObservableCollection<Players> players)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var file in dir.GetFiles("SavedPlayer_*.xml"))
            {
                using (FileStream fs = File.OpenRead(file.FullName))
                {
                    players.Add((Players)serializer.Deserialize(fs));
                    fs.Close();
                }
            }
        }
        
        public static void DeletePlayer(string name)
        {
            if(File.Exists(path + "SavedPlayer_" + name + ".xml"))
            {
                File.Delete(path + "SavedPlayer_" + name + ".xml");
            }
        }



        public static void SavePlayer(Players player)
        {
            using (Stream fs = new FileStream(path + "SavedPlayer_" + player.name + ".xml",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(fs, player);
                fs.Close();
            }
            //Console.WriteLine("Saved!");
        }
        
        public static bool CheckIfPlayerExists(string name)
        {
            return File.Exists(path + "SavedPlayer_" + name + ".xml");
        }

        /*
        private static bool CheckIfPlayerSaveFileExists(string path)
        {
            if (File.Exists(path)) return true;
            else return false;
        }

        public static int FindPlayer(List<Players> players, string name)
        {
            for (int i = 0; i < players.Count; i++)
            {

                if (name == players[i].name) return i;
            }
            return -1;
        }*/
    }
}

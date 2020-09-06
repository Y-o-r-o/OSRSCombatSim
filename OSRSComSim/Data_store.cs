using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

using OSRSComSim.Models;
using System.Collections.ObjectModel;
using System.CodeDom;

namespace OSRSComSim
{
    static class Data_store
    {
        static private string path = "no_path";
        static private XmlSerializer serializer = null;

        static Data_store()
        {
            CreatePath();
            serializer = new XmlSerializer(typeof(PlayerModel));
        }


        
        private static void CreatePath()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RSCombatSimulator\";
            System.IO.Directory.CreateDirectory(path);
        }

        public static void LoadPlayers(ObservableCollection<PlayerModel> players)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var file in dir.GetFiles("SavedPlayer_*.xml"))
            {
                using (FileStream fs = File.OpenRead(file.FullName))
                {
                    players.Add((PlayerModel)serializer.Deserialize(fs));
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



        public static void SavePlayer(PlayerModel player)
        {
            using (Stream fs = new FileStream(path + "SavedPlayer_" + player.Name + ".xml",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(fs, player);
                fs.Close();
            }
        }
        
        public static bool CheckIfPlayerExists(string name)
        {
            return File.Exists(path + "SavedPlayer_" + name + ".xml");
        }

        public static bool CheckIfFileExists(string location)
        {
            string temp_location = location.Replace("/", @"\");
            return File.Exists(@temp_location);
        }

    }
}

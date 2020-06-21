using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Csh_Exip
{
    static class Data_store
    {
        static private string path = "no_path";
        static private XmlSerializer serializer = null;

        static Data_store()
        {
            path = GetPath();
            serializer = new XmlSerializer(typeof(Players));
        }

        public static void SavePlayer()
        {
            Console.Write("Enter player name that you want to save: ");
            string name = Console.ReadLine();
            int i = OSRSCombatSimulator.FindPlayer(name);
            if (0 <= i)
            {
                using (Stream fs = new FileStream(path + name + ".xml",
                    FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    serializer.Serialize(fs, OSRSCombatSimulator.players[i]);
                    fs.Close();
                }
                Console.WriteLine("Saved!");
            }
            else Console.WriteLine("There is no player with this name");
        }

        public static void LoadPlayer()
        {
            Console.Write("Enter player name that you want to load: ");
            string name = Console.ReadLine();
            if (CheckIfPlayerSaveFileExists(path + name + ".xml"))
            {
                using (FileStream fs = File.OpenRead(path + name + ".xml"))
                {
                    OSRSCombatSimulator.players.Add((Players)serializer.Deserialize(fs));
                    fs.Close();
                }
                Console.WriteLine("Loaded!");
            }
            Console.WriteLine("Player save file not found...");
        }

        private static bool CheckIfPlayerSaveFileExists(string path)
        {
            if (File.Exists(path)) return true;
            else return false;
        }

        private static string GetPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RSCombatSimulator\SavedPlayer_";
        }
    }
}

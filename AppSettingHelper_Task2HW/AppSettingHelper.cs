using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AppSettingHelper_Task2HW
{
    static class AppSettingHelper
    {
        public static void WriteSettings(string path,Settings settings)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write((int)settings.BackgroundColor);
                writer.Write((int)settings.ForegroundColor);
                writer.Write(settings.Height);
                writer.Write(settings.Width);
                writer.Write(settings.Title);
            }
        }
        public static Settings ReadSettings(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                Settings settings = new Settings();
                settings.BackgroundColor=(ConsoleColor)reader.ReadInt32();
                settings.ForegroundColor=(ConsoleColor)reader.ReadInt32();
                settings.Height=reader.ReadInt32();
                settings.Width=reader.ReadInt32();
                settings.Title=reader.ReadString();
                return settings;
            }
        }
    }
}

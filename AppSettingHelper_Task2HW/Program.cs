using System;

namespace AppSettingHelper_Task2HW
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings = new Settings(ConsoleColor.Red, ConsoleColor.Black, 200, 100, "Settings");
            Settings settings2;
            AppSettingHelper.WriteSettings("settings.yml",settings);
            settings2 = AppSettingHelper.ReadSettings("settings.yml");
            Console.WriteLine(settings2);
            settings2.Apply();
        }
    }
}

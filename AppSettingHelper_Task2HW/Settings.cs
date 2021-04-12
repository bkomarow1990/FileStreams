using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSettingHelper_Task2HW
{
        class Settings
        {
            public ConsoleColor BackgroundColor { get; set; }
            public ConsoleColor ForegroundColor { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public string Title { get; set; }
            public Settings(ConsoleColor bc, ConsoleColor fc, int height, int width, string title)
            {
                BackgroundColor = bc;
                ForegroundColor = fc;
                Height = height;
                Width = width;
                Title = title;

            }
            public Settings()
            {

            }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
        public void Apply() {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;
            Console.BufferHeight = Height;
            Console.BufferWidth= Width;
            Console.WindowHeight = Height;
            Console.WindowWidth= Width;
            Console.Title = Title;
        }
        public override string ToString()
        {
            return $"BackgroundColor: {BackgroundColor.ToString()}, TextColor: {ForegroundColor.ToString()}, Height: {Height}, Width: {Width}"; 
        }
    }
}

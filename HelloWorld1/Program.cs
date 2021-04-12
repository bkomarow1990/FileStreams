using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld1
{
    static class FS
    {
        public static void WriteString(string str, string fname)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            byte len = (byte)bytes.Length;
            using (FileStream fs = new FileStream(fname, FileMode.Create))
            {
                fs.WriteByte(len);
                fs.Write(bytes,0 ,str.Length);
            }
        }
        public static string ReadString(string fname)
        {
            using (FileStream fs = new FileStream(fname, FileMode.Open))
            {
                byte len = (byte)fs.ReadByte();
                byte[] bytes = new byte[len];
                fs.Read(bytes,0, (int)fs.Length);
                return Encoding.UTF8.GetString(bytes);

            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string txt = "Джон Рембо";
            FS.WriteString(txt, "Boris.dat");
            Console.WriteLine(FS.ReadString("Boris.dat")); 
        }
    }
}

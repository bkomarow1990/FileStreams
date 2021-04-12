using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Classwork
{
    class Program
    {
        static class StudentWorker
        {
            public static Student ReadStudent(string path) {
                Student student = new Student();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                { 
                    byte len = (byte)fs.ReadByte();
                    byte[] bytes = new byte[len];
                    fs.Read(bytes, 0, len);
                    student.Name=Encoding.UTF8.GetString(bytes);
                    bytes = new byte[sizeof(int)]; // 
                    fs.Read(bytes,0, sizeof(int));// read from file 4 bytes(converted int)
                    student.Course = BitConverter.ToInt32(bytes,0); // byte[] ----> int
                    List<int> marks = new List<int>();
                    while (fs.Position != fs.Length) {
                        fs.Read(bytes, 0, sizeof(int));
                        int mark = BitConverter.ToInt32(bytes,0);
                        //Console.WriteLine(mark);
                        marks.Add(mark);
                    }
                    student.Marks = marks;
                    return student;
                    
                }
            }    
            public static void WriteStudent(string path, Student student)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(student.Name);
                byte len = (byte)bytes.Length;
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    fs.WriteByte(len);
                    fs.Write(bytes, 0, student.Name.Length);
                    bytes = BitConverter.GetBytes(student.Course);
                    fs.Write(bytes, 0, sizeof(int));
                    foreach (int item in student.Marks)
                    {
                        bytes = BitConverter.GetBytes(item);
                        fs.Write(bytes, 0, sizeof(int));
                    }
                }
            }
        }
        class Student
        {
            public void AddMarks(params int[] marks)
            {
                foreach (int item in marks)
                {
                    Marks.Add(item);
                }
            }
            public string Name { get; set; }
            public int Course { get; set; }
            public List<int> Marks = new List<int>();
            public Student(string name="NoName", int course=0)
            {
                Name = name;
                Course = course;
            }
            public override string ToString()
            {
                return $"Name: {Name}, Course: {Course}, Marks: {String.Join(" ", Marks)}";
            }
        }
        static void Main(string[] args)
        {
            StudentWorker.ReadStudent("students.txt");
            Student Valera = new Student("Valeriy", 3);
            Valera.AddMarks(12, 8, 10, 11, 9, 12, 11);
            StudentWorker.WriteStudent("students.txt",Valera);
            
            Student st2= StudentWorker.ReadStudent("students.txt");
            Console.WriteLine(st2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConAppStudentData2
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
    internal class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            LoadData();
            Console.WriteLine("*****************************");
            Console.WriteLine("\n Students Data before Sorting:");
            Console.WriteLine("*****************************");
            Display(students);
          
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name,
           StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("*****************************");
            Console.WriteLine("\nStudent Data After Sorting \n");
            Console.WriteLine("*****************************");
            DisplaySortedData();
            Console.Write("\nEnter a student's name to search: ");
            string searchName = Console.ReadLine();
            SearchByName(searchName);
            Console.ReadKey();
        }
        static void LoadData()
        {
            try
            {
                string filePath = "D:\\ConAppStudentData2\\student.txt";

                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');
                        if (data.Length == 2)
                        {
                            string name = data[0].Trim();
                            string studentClass = data[1].Trim();
                            students.Add(new Student { Name = name, Class = studentClass });
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found: student.txt");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in loading data from the file!!!! " + ex.Message);
            }
        }
        static void Display(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, \t\t\t\tClass: {student.Class}");
            }
        }
        static void DisplaySortedData()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, \t\t\t\tClass: {student.Class}");
            }
        }
        static void SearchByName(string searchName)
        {
            bool found = false;
            foreach (var student in students)
            {
                if (student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nStudent Found: Name: {student.Name}, Class: {student.Class}");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("\nStudent not found!!!");
            }
        }
    }
}
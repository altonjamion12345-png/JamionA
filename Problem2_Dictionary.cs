using System;
using System.Collections.Generic;

class Problem2
{
    struct Student
    {
        public string Number, Name, Program;
        public int Year;
    }

    static void Main()
    {
        Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();
        string choice = "";

        while (choice != "4")
        {
            Console.WriteLine("\n=== STUDENT LOOKUP USING DICTIONARY ===");
            Console.WriteLine("1. Add Student\n2. Search Student\n3. Display All Students\n4. Exit");
            Console.Write("Enter choice: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Student s = new Student();
                Console.Write("Enter Student Number: ");
                s.Number = Console.ReadLine();
                if (studentDictionary.ContainsKey(s.Number))
                {
                    Console.WriteLine("Student Number already exists!");
                    continue;
                }
                Console.Write("Enter Name: ");
                s.Name = Console.ReadLine();
                Console.Write("Enter Program: ");
                s.Program = Console.ReadLine();
                do
                {
                    Console.Write("Enter Year Level (1-4): ");
                    int.TryParse(Console.ReadLine(), out s.Year);
                } while (s.Year < 1 || s.Year > 4);

                studentDictionary.Add(s.Number, s);   // key = Student Number
                Console.WriteLine("Student added successfully!");
            }
            else if (choice == "2")
            {
                Console.Write("Enter Student Number to search: ");
                string number = Console.ReadLine();
                if (studentDictionary.ContainsKey(number))
                {
                    Console.WriteLine("Student Found!");
                    Print(studentDictionary[number]);
                }
                else Console.WriteLine("Student not found.");
            }
            else if (choice == "3")
            {
                foreach (Student s in studentDictionary.Values)
                    Print(s);
                if (studentDictionary.Count == 0) Console.WriteLine("No records.");
            }
        }
        Console.WriteLine("Program exited.");
    }

    static void Print(Student s)
    {
        Console.WriteLine($"\nStudent Number: {s.Number}\nName: {s.Name}\nProgram: {s.Program}\nYear Level: {s.Year}");
    }
}

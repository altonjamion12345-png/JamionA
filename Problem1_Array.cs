using System;

class Problem1
{
    struct Student
    {
        public string Number, Name, Program;
        public int Year;
    }

    static void Main()
    {
        Student[] students = new Student[10];
        int count = 0;
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("\n=== STUDENT RECORD MANAGEMENT ===");
            Console.WriteLine("1. Add Student\n2. Display All Students\n3. Search Student");
            Console.WriteLine("4. Update Student\n5. Delete Student\n6. Exit");
            Console.Write("Enter choice: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                if (count == 10) { Console.WriteLine("Array is full!"); continue; }

                Student s = new Student();
                Console.Write("Enter Student Number: ");
                s.Number = Console.ReadLine();
                if (Find(students, count, s.Number) != -1)
                {
                    Console.WriteLine("Student Number already exists!");
                    continue;
                }
                ReadDetails(ref s);
                students[count] = s;
                count++;
                Console.WriteLine("Student added successfully!");
            }
            else if (choice == "2")
            {
                for (int i = 0; i < count; i++)
                    Print(students[i]);
                if (count == 0) Console.WriteLine("No records.");
            }
            else if (choice == "3")
            {
                Console.Write("Enter Student Number: ");
                int i = Find(students, count, Console.ReadLine());
                if (i == -1) Console.WriteLine("Student not found.");
                else Print(students[i]);
            }
            else if (choice == "4")
            {
                Console.Write("Enter Student Number: ");
                int i = Find(students, count, Console.ReadLine());
                if (i == -1) Console.WriteLine("Student not found.");
                else
                {
                    ReadDetails(ref students[i]);
                    Console.WriteLine("Student updated successfully!");
                }
            }
            else if (choice == "5")
            {
                Console.Write("Enter Student Number: ");
                int i = Find(students, count, Console.ReadLine());
                if (i == -1) Console.WriteLine("Student not found.");
                else
                {
                    for (int j = i; j < count - 1; j++)   // shift left
                        students[j] = students[j + 1];
                    count--;
                    Console.WriteLine("Student deleted successfully!");
                }
            }
        }
        Console.WriteLine("Program exited.");
    }

    // returns the index of the student, or -1 if not found
    static int Find(Student[] students, int count, string number)
    {
        for (int i = 0; i < count; i++)
            if (students[i].Number == number) return i;
        return -1;
    }

    static void ReadDetails(ref Student s)
    {
        Console.Write("Enter Name: ");
        s.Name = Console.ReadLine();
        Console.Write("Enter Program: ");
        s.Program = Console.ReadLine();
        do
        {
            Console.Write("Enter Year Level (1-4): ");
            int.TryParse(Console.ReadLine(), out s.Year);
        } while (s.Year < 1 || s.Year > 4);
    }

    static void Print(Student s)
    {
        Console.WriteLine($"\nStudent Number: {s.Number}\nName: {s.Name}\nProgram: {s.Program}\nYear Level: {s.Year}");
    }
}

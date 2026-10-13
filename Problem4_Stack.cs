using System;
using System.Collections.Generic;

class Problem4
{
    struct Student
    {
        public string Number, Name, Program;
        public int Year;
    }

    struct Operation
    {
        public string Action, StudentNumber, StudentName;
    }

    static Stack<Operation> operationHistory = new Stack<Operation>();

    static void Main()
    {
        Student[] students = new Student[10];
        int count = 0;
        string choice = "";

        while (choice != "9")
        {
            Console.WriteLine("\n=== STUDENT RECORDS + OPERATION HISTORY ===");
            Console.WriteLine("1. Add Student\n2. Display All Students\n3. Search Student");
            Console.WriteLine("4. Update Student\n5. Delete Student");
            Console.WriteLine("6. View Operation History\n7. View Last Operation\n8. Remove Last Operation\n9. Exit");
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
                Record("Added", s);
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
                    Record("Updated", students[i]);
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
                    Record("Deleted", students[i]);       // record before it is overwritten
                    for (int j = i; j < count - 1; j++)
                        students[j] = students[j + 1];
                    count--;
                    Console.WriteLine("Student deleted successfully!");
                }
            }
            else if (choice == "6")
            {
                if (operationHistory.Count == 0) { Console.WriteLine("No recorded operations."); continue; }

                Console.WriteLine("OPERATION HISTORY");
                Operation[] ops = operationHistory.ToArray();   // newest first
                Array.Reverse(ops);                             // oldest first
                for (int i = 0; i < ops.Length; i++)
                    Console.WriteLine($"{i + 1}. {ops[i].Action} {ops[i].StudentName}");
            }
            else if (choice == "7")
            {
                if (operationHistory.Count == 0) { Console.WriteLine("No recorded operations."); continue; }

                Operation last = operationHistory.Peek();       // look, don't remove
                Console.WriteLine($"Last Operation: {last.Action} {last.StudentName}");
            }
            else if (choice == "8")
            {
                if (operationHistory.Count == 0) { Console.WriteLine("No recorded operations."); continue; }

                operationHistory.Pop();                         // remove the top
                Console.WriteLine("Last operation removed successfully!");
            }
        }
        Console.WriteLine("Program exited.");
    }

    static void Record(string action, Student s)
    {
        Operation op = new Operation();
        op.Action = action;
        op.StudentNumber = s.Number;
        op.StudentName = s.Name;
        operationHistory.Push(op);
    }

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

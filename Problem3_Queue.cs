using System;
using System.Collections.Generic;

class Problem3
{
    struct StudentRequest
    {
        public string StudentNumber, StudentName, RequestType;
    }

    static void Main()
    {
        Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();
        string choice = "";

        while (choice != "4")
        {
            Console.WriteLine("\n=== STUDENT REQUEST QUEUE ===");
            Console.WriteLine("1. Add Request\n2. View Pending Requests\n3. Process Request\n4. Exit");
            Console.Write("Enter choice: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                StudentRequest r = new StudentRequest();
                Console.Write("Enter Student Number: ");
                r.StudentNumber = Console.ReadLine();
                Console.Write("Enter Student Name: ");
                r.StudentName = Console.ReadLine();
                Console.Write("Enter Request Type: ");
                r.RequestType = Console.ReadLine();

                requestQueue.Enqueue(r);              // add to the back
                Console.WriteLine("Request added successfully!");
            }
            else if (choice == "2")
            {
                if (requestQueue.Count == 0) { Console.WriteLine("No pending requests."); continue; }

                Console.WriteLine("REQUEST QUEUE");
                int n = 1;
                foreach (StudentRequest r in requestQueue)   // front to back
                {
                    Console.WriteLine($"{n}. {r.StudentName} - {r.RequestType}");
                    n++;
                }
            }
            else if (choice == "3")
            {
                if (requestQueue.Count == 0) { Console.WriteLine("No pending requests."); continue; }

                StudentRequest r = requestQueue.Dequeue();   // remove from the front
                Console.WriteLine($"Processing Request: {r.StudentName} - {r.RequestType}");
                Console.WriteLine("Request processed successfully!");
            }
        }
        Console.WriteLine("Program exited.");
    }
}

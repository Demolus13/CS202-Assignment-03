// Activity 4: Object-Oriented Programming

using System;

namespace StudentApp
{
    class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double Marks { get; set; }

        // Constructor to initialize student details.
        public Student(string name, int id, double marks)
        {
            // BREAKPOINT: Verify that properties are copied correctly.
            Name = name;
            ID = id;
            Marks = marks;
        }

        // Copy Constructor
        public Student(Student other)
        {
            Name = other.Name;
            ID = other.ID;
            Marks = other.Marks;
        }

        // Method to determine grade based on Marks.
        public string GetGrade()
        {
            if (Marks >= 90)
                return "A";
            else if (Marks >= 80)
                return "B";
            else if (Marks >= 70)
                return "C";
            else if (Marks >= 60)
                return "D";
            else
                return "F";
        }
    }

    class StudentIITGN : Student
    {
        public string Hostel { get; set; }

        // Constructor for StudentIITGN including new property.
        public StudentIITGN(string name, int id, double marks, string hostel)
            : base(name, id, marks)
        {
            Hostel = hostel;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // BREAKPOINT: Check instantiation of Student and output of GetGrade().
            Student s = new Student("Alice", 101, 85);
            Console.WriteLine($"Student: {s.Name}, Grade: {s.GetGrade()}");

            // BREAKPOINT: Verify creation and output of StudentIITGN details.
            StudentIITGN sIITGN = new StudentIITGN("Bob", 102, 78, "Hostel-1");
            Console.WriteLine($"Student: {sIITGN.Name}, Grade: {sIITGN.GetGrade()}, Hostel: {sIITGN.Hostel}");
        }
    }
}
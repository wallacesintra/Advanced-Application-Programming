using System;
using System.Collections.Generic;

namespace ResultSystem;


class Student
    {
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public Dictionary<string, string> Grades { get; set; }

        public Student(string studentID, string name, string course)
        {
            StudentID = studentID;
            Name = name;
            Course = course;
            Grades = new Dictionary<string, string>();
        }

        public void AddGrade(string courseName, string grade)
        {
            Grades[courseName] = grade;
        }
    }

class ResultSlip
    {
        private Student Student;

        public ResultSlip(Student student)
        {
            Student = student;
        }

        public void GenerateSlip()
        {
            Console.WriteLine($"Student ID: {Student.StudentID}");
            Console.WriteLine($"Name: {Student.Name}");
            Console.WriteLine($"Course: {Student.Course}");
            Console.WriteLine("Grades:");
            foreach (var grade in Student.Grades)
            {
                Console.WriteLine($"{grade.Key}: {grade.Value}");
            }
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("20/03944", "Wallace Wahong'o", "Bachelor of Science in Software Development");
            student1.AddGrade("Advanced Application Programming", "A");
            student1.AddGrade("Machine Learning", "B+");
            student1.AddGrade("Data Science", "B");
            student1.AddGrade("Web Development", "A-");
            student1.AddGrade("Mobile Application Programming", "A");
            student1.AddGrade("Data Structures and Algorithms", "A-");


            ResultSlip slip1 = new ResultSlip(student1);
            slip1.GenerateSlip();
        }
    }


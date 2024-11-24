using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyHocSinh
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tạo danh sách học sinh
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Anh", Age = 15 },
                new Student { Id = 2, Name = "Bao", Age = 14 },
                new Student { Id = 3, Name = "Chi", Age = 16 },
                new Student { Id = 4, Name = "Dang", Age = 18 },
                new Student { Id = 5, Name = "Anh", Age = 17 },
                new Student { Id = 5, Name = "Khiem", Age = 21 },
                new Student { Id = 5, Name = "Nam", Age = 20 },
                new Student { Id = 5, Name = "Khoi", Age = 18 }
            };

            // a. In danh sach
            Console.WriteLine("DANH SACH HOC SINH:");
            students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

            // b. Tim va in danh sach hoc sinh tu 15 tuoi den 18 tuoi
            var ageRangeStudents = students.Where(s => s.Age >= 15 && s.Age <= 18);
            Console.WriteLine("\nHoc sinh tu 15 tuoi den 18 tuoi: ");
            foreach (var s in ageRangeStudents)
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}");

            // c. Tim hoc sinh co ten bat dau bang chu cai 'A'
            var nameStartsWithA = students.Where(s => s.Name.StartsWith("A"));
            Console.WriteLine("\nHoc sinh co ten bat dau bang chu cai 'A': ");
            foreach (var s in nameStartsWithA)
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}");

            // d. Tong tuoi cua tat ca hoc sinh
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"\nTong tuoi tat ca hoc sinh: {totalAge}");

            // e. Tim hoc sinh co tuoi lon nhat
            int maxAge = students.Max(s => s.Age);
            var oldestStudents = students.Where(s => s.Age == maxAge);
            Console.WriteLine("\nHoc sinh co tuoi lon nhat:");
            foreach (var s in oldestStudents)
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}");

            // f. Sap xep danh sach theo tuoi tang dan
            var sortedStudents = students.OrderBy(s => s.Age).ToList();
            Console.WriteLine("\nDanh sach hoc sinh theo tuoi tang dan:");
            sortedStudents.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));
        }
    }
}


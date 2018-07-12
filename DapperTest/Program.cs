using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperTest.Models;
using MicroOrm.Pocos.SqlGenerator;

namespace DapperTest
{
    class Program
    {
        static IUnitOfWork unitOfWork;

        static void Main(string[] args)
        {
            unitOfWork = new UnitOfWork(Database.Connection);
            DisplayStudents();
            Ages();
            Above50();
            FindStudents();
            Console.ReadKey();
        }

        static void DisplayStudents()
        {
            var students = unitOfWork.Students.Get();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id}   {student.Name}");
            }
        }

        static void FindStudents()
        {
            var students = unitOfWork.Students.Find(new { Name = "kit" });
           
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine("...");
        }

        static void Ages()
        {
            var ages = unitOfWork.Students.GetStudentAge();

            foreach (var age in ages)
            {
                Console.WriteLine(age);
            }
            Console.WriteLine("...");
        }

        static void Above50()
        {
            var names = unitOfWork.Students.GetStudentAgeAbove50();

            foreach (var name in names)
            {
                Console.WriteLine($"{name}");
            }
            Console.WriteLine("...");
        }

        static void Insert()
        {
           
            var student = new Students
            {
                Name = "bvbgfhfg",
                Age = 55,
                Address = "gg",
                YearLevel = 3,
                Course = "bsit",
                School = "d"
            };

            int affectedRows = unitOfWork.Students.Add(student);
            
            Console.WriteLine(affectedRows);

            
        }

        static void InsertBulk()
        {
            var students = new List<Students>()
            {
                new Students {
                    Name = "cccccc",
                    Age = 55,
                    Address = "gg",
                    YearLevel = 3,
                    Course = "bsit",
                    School = "d"
                },
                new Students {
                    Name = "mmmm",
                    Age = 55,
                    Address = "gg",
                    YearLevel = 3,
                    Course = "bsit",
                    School = "d"
                }
            };

            int affectedRows = unitOfWork.Students.AddRange(students);
            Console.WriteLine(affectedRows);

        }

        static void Remove()
        {

            var students = unitOfWork.Students.Find(new { Id = 8 });

            foreach (var student in students)
            {
                unitOfWork.Students.Remove(student);
            } 
            
        }

    }
}

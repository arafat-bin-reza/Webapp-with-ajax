using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
using WebApp.BLL.BLL;

namespace MyEF
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager _studentManager = new StudentManager();
            //DepartmentManager _departmentManager = new DepartmentManager();


            //Console.WriteLine("\t\tDepartment");
            //foreach (var department in _departmentManager.GetAll())
            //{
            //    Console.WriteLine("\nDepartment Name:\t" + department.Name + "\n\t\t\t\tStudents");
            //    if (department.Students != null && department.Students.Any())
            //    {

            //        foreach (var student in department.Students)
            //        {
            //            Console.WriteLine("Student RollNo:\t" + student.RollNo + "\tName:\t" + student.Name + "\tAge:\t" + student.Age);
            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("\t\tNo Student Found!!!");
            //    }
            //}


            //Department department = new Department()
            //{
            //    Name = "ENG",
            //    Students = new List<Student>()
            //    {
            //        new Student()
            //        {
            //                RollNo = "009",
            //                Name =  "Fajle",
            //                Address = "Mirpur",
            //                Age = 40
            //        },
            //        new Student()
            //        {
            //            RollNo = "010",
            //            Name =  "Arafat",
            //            Address = "Mirpur",
            //            Age = 16
            //        }
            //    }
            //};

            //Student student = new Student()
            //{
            //    RollNo = "011",
            //    Name = "Yusuf",
            //    Address = "Mirpur",
            //    Age = 24
            //};

            //department.Students.Add(student);

            //_departmentManager.Add(department);            //Department department = new Department()
            //{
            //    Name = "ENG",
            //    Students = new List<Student>()
            //    {
            //        new Student()
            //        {
            //                RollNo = "009",
            //                Name =  "Fajle",
            //                Address = "Mirpur",
            //                Age = 40
            //        },
            //        new Student()
            //        {
            //            RollNo = "010",
            //            Name =  "Arafat",
            //            Address = "Mirpur",
            //            Age = 16
            //        }
            //    }
            //};

            //Student student = new Student()
            //{
            //    RollNo = "011",
            //    Name = "Yusuf",
            //    Address = "Mirpur",
            //    Age = 24
            //};

            //department.Students.Add(student);

            //_departmentManager.Add(department);



            ////Add
            //if (_studentManager.Add(student))
            //{
            //    Console.WriteLine("Saved");
            //}
            //else
            //{
            //    Console.WriteLine("Not Saved");
            //}

            //Delete
            //if (_studentManager.Delete(1))
            //{
            //    Console.WriteLine("Deleted");
            //}
            //else
            //{
            //    Console.WriteLine("Not Deleted");
            //}

            //Update
            //student.Id = 2;
            //student.Name = "Md Yusuf";
            ////student.RollNo = "003";
            //student.Address = "Mohakhali";
            //student.Age = 30;


            //if (_studentManager.Update(student))
            //{
            //    Console.WriteLine("Updated");
            //}
            //else
            //{
            //    Console.WriteLine("Not Updated");
            //}


            Console.WriteLine("-----------------------------------------------------------");
            int i = 1;
            Console.WriteLine("Sl\t Name \t\t Roll No \t Address \t Age \t\tDepartment");
            foreach (var std in _studentManager.GetAll())
            {

                Console.WriteLine(i + "\t" + std.Name + "\t\t" + std.RollNo + " \t\t " + std.Address + " \t\t " + std.Age + "\t\t" + std.DepartmentId);
                i++;
            }

            Console.WriteLine("----------------------------LINQ-----------------------");
            i = 1;

            
            var students = _studentManager.GetAll();
            //SELECT * FROM Student WHERE Age> 20 AND Age <30
            var result = from s in students
                            where s.Age > 20 && s.Age<30
                            select s;

            Console.WriteLine("Sl\t Name \t\t Roll No \t Address \t Age \t\tDepartment");
            foreach (var std in result)
            {

                Console.WriteLine(i + "\t" + std.Name + "\t\t" + std.RollNo + " \t\t " + std.Address + " \t\t " + std.Age + "\t\t" + std.DepartmentId);
                i++;
            }

            Console.ReadKey();
        }
    }
}

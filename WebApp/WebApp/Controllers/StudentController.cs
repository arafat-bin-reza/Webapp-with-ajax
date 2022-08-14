using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  WebApp.Model.Model;
using WebApp.BLL.BLL;
using WebApp.Models;
using AutoMapper;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager = new StudentManager();
        DepartmentManager _departmentManager = new DepartmentManager();
        //public string Add(string rollNo, string name, string address, int? age, int? departmentId)

        [HttpGet]
        public ActionResult Add()
        {
           StudentViewModel studentViewModel = new StudentViewModel();
           studentViewModel.Students = _studentManager.GetAll();

           studentViewModel.DepartmentSelectListItems = _departmentManager
                                    .GetAll()
                                    .Select(c=> new SelectListItem()
                                    {
                                        Value = c.Id.ToString(), Text = c.Name
                                    }).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel studentViewModel)
        {
            string message = "";

            //Student student = new Student();
            //student.RollNo = studentViewModel.RollNo;
            //student.Name = studentViewModel.Name;
            //student.Address = studentViewModel.Address;
            //student.Age = studentViewModel.Age;
            //student.DepartmentId = studentViewModel.DepartmentId;
            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<Student>(studentViewModel);

                if (_studentManager.Add(student))
                {
                    message = "Saved";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View(studentViewModel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll();

            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(studentViewModel);
          
        }

        [HttpPost]
        public ActionResult Search(StudentViewModel studentViewModel)
        {
            var students = _studentManager.GetAll();

            if (studentViewModel.RollNo != null)
            {
                students = students.Where(c => c.RollNo.Contains(studentViewModel.RollNo)).ToList();
            }
            if (studentViewModel.Name != null)
            {
                students = students.Where(c => c.Name.ToLower().Contains(studentViewModel.Name.ToLower())).ToList();
            }

            studentViewModel.Students = students;
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(studentViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = _studentManager.GetById(id);

            StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);

            studentViewModel.Students = _studentManager.GetAll();

            studentViewModel.DepartmentSelectListItems = _departmentManager
                                     .GetAll()
                                     .Select(c => new SelectListItem()
                                     {
                                         Value = c.Id.ToString(),
                                         Text = c.Name
                                     }).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            string message = "";

            //Student student = new Student();
            //student.RollNo = studentViewModel.RollNo;
            //student.Name = studentViewModel.Name;
            //student.Address = studentViewModel.Address;
            //student.Age = studentViewModel.Age;
            //student.DepartmentId = studentViewModel.DepartmentId;
            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<Student>(studentViewModel);

                if (_studentManager.Update(student))
                {
                    message = "Updated";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View(studentViewModel);
        }

        public ActionResult StudentDetails()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            

            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            ViewBag.Department = studentViewModel.DepartmentSelectListItems;
            return View();
        }

        public JsonResult GetStudentByDepartmentId(int departmentId)
        {
            var studentlist = _studentManager.GetAll().Where(c => c.DepartmentId == departmentId).ToList();
            var  students = from s in studentlist select (new {s.Id,s.Name});

            return Json(students, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentRollNoById(int studentId)
        {
            var studentlist = _studentManager.GetAll().Where(c => c.Id == studentId).ToList();
            var rollNo = from s in studentlist select(s.RollNo);

            return Json(rollNo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsRollNoExist(string rollNo)
        {
            var studentlist = _studentManager.GetAll().Where(c => c.RollNo == rollNo).ToList();

            bool isExists = false;
            if (studentlist.Count() > 0)
                isExists = true;

            //var students = from s in studentlist select (new { s.RollNo });

            return Json(isExists, JsonRequestBehavior.AllowGet);
        }
        //StudentDetails
        public ActionResult GetStudentById(int id)
        {
            //var student = _studentManager.GetById(id);
            //StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll().Where(c => c.Id == id).ToList();
            return PartialView("Student/_StudentDetails", studentViewModel);
        }

    }
}
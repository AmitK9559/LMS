using Library.DBContext;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Library.Controllers
{
    public class CMSDashboardController : Controller
    {
        private ResultDB _context;

        public CMSDashboardController(ResultDB context)
        {
            _context = context;
        }
        public IActionResult Dashboard()
        {
            try
            {

                var S = _context.Student.ToList();
                List<Student> st = new List<Student>();
                foreach (var record in S)
                {
                    st.Add(new Student
                    {
                        FirstName = record.FirstName,
                        LastName = record.LastName,

                    });
                }
                return View(st);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult StudentRecord()
        {
            try
            {

                var S = _context.Student.ToList();
                List<Student> st = new List<Student>();
                foreach (var record in S)
                {
                    st.Add(new Student
                    {
                        StudentId = record.StudentId,
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        FatherName = record.FatherName,
                        MobileNo = record.MobileNo,
                        AlterNateMobileNo = record.AlterNateMobileNo,
                        Address = record.Address,
                        LibraryTime = record.LibraryTime,
                        EmailID = record.EmailID,
                        CreatedOn = record.CreatedOn,
                        IsActive = record.IsActive,
                    });
                }
                return View(st);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult _AddStudent(Int64 ID)
        {
            Student model = new Student();
            if (ID > 0)
            {
                model = _context.Student.Find(ID);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult _AddStudent(Student model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var std = new Student()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        FatherName = model.FatherName,
                        MobileNo = model.MobileNo,
                        AlterNateMobileNo = model.AlterNateMobileNo,
                        Address = model.Address,
                        LibraryTime = model.LibraryTime,
                        EmailID = model.EmailID,
                        CreatedOn = DateTime.Now,
                        CreatedBy = Convert.ToInt16(HttpContext.Session.GetString("ID").ToString()),
                        IsActive = true,
                        StudentId = model.StudentId

                    };
                    if (model.StudentId > 0)
                    {
                        _context.Student.Update(std);
                    }
                    else
                    {
                        _context.Student.Add(std);
                    }

                    _context.SaveChanges();
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("StudentRecord");
        }

        public IActionResult Delete(Int64 ID)
        {
            Student model = new Student();
            if (ID > 0)
            {
                model = _context.Student.Find(ID);
                if (model.IsActive == false)
                    model.IsActive = true;
                else
                    model.IsActive = false;
                _context.Student.Update(model);
                _context.SaveChanges();
                return RedirectToAction("StudentRecord");
            }
            return View(model);
        }

        public IActionResult Details(Int64 ID)
        {
            Student model = new Student();
            if (ID > 0)
            {
                model = _context.Student.Find(ID);
            }
            return PartialView("StudentDetails", model);
        }
    }
}

using Asp.net_MVC_Crud_using_Entity_Framework_DB_First.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.net_MVC_Crud_using_Entity_Framework_DB_First.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        mvcdb1Entities1 dbobj = new mvcdb1Entities1();
        public ActionResult Student(tbl_Student obj)
        {
         
                return View(obj);
            
            
        }

        [HttpPost]
        public ActionResult AddStudent(tbl_Student model)
        {
            //receiver
            if (ModelState.IsValid)
            {
                tbl_Student obj = new tbl_Student();
                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                if (model.Id == 0)
                {
                    dbobj.tbl_Student.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(obj).State = EntityState.Modified;
                    dbobj.SaveChanges();
                }


            }
            ModelState.Clear();


            return View("Student");
        }
        public ActionResult StudentList() {

            var res = dbobj.tbl_Student.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.tbl_Student.Where(x=>x.Id==id).First();
            dbobj.tbl_Student.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.tbl_Student.ToList();
            return View("StudentList", list);
        }

    }
}
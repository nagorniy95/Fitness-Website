using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using sportSiteMvc.Models;
/*
namespace sportSiteMvc.Controllers
{
    public class ExcersisesController : Controller
    {
        private MuscleGroupsContext db = new MuscleGroupsContext();
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //================================================================================= Read

        public ActionResult List()
        {

            string query = "select * from Excersises";
            // Обьявить переменную
            IEnumerable<MuscleGroup> excersises;
            excersises = db.MuscleGroups.SqlQuery(query);

            return View(excersises);
        }
        //================================================================================= Create

        public ActionResult New()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(string excersiseTitle_New, string excersisePhoto_New, string excersiseContent_New)
        {
            string query = "insert into Excersises (excersiseTitle,  excersisePhoto, excersiseContent)" +
                " values (@title, @photo, @content)";
            SqlParameter[] myparams = new SqlParameter[3];
            myparams[0] = new SqlParameter("@title", excersiseTitle_New);
            myparams[1] = new SqlParameter("@photo", excersisePhoto_New);
            myparams[2] = new SqlParameter("@content", excersiseContent_New);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //================================================================================= Edit

        public ActionResult Edit(int? id)
        {
            if ((id == null) || (db.Excersises.Find(id) == null))
            {
                return HttpNotFound();
            }
            string query = "select * from Excersises where exersiseId=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Excersise mytag = db.Excersises.SqlQuery(query, param).FirstOrDefault();
            return View(mytag);
        }


        [HttpPost]
        public ActionResult Edit(int? exersiseId, string excersiseTitle, string excersisePhoto, string excersiseContent)
        {
            if (exersiseId == null) || (db.MuscleGroups.Find(exersiseId) == null))
            {
                return HttpNotFound();
            }
            string query = "update Excersises set excersiseTitle=@title, excersisePhoto=@photo, excersiseContent=Content" +
                " where exersiseId=@id";
            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter("@title", excersiseTitle);
            myparams[1] = new SqlParameter("@photo", excersisePhoto);
            myparams[2] = new SqlParameter("@content", excersiseContent);
            myparams[3] = new SqlParameter("@id", exersiseId);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("Show/" + exersiseId);
        }
        //================================================================================= Delete

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.MuscleGroups.Find(id) == null))
            {
                return HttpNotFound();

            }
            string query = "delete from MuscleGroups where MuscleGroupId=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return View("List");
        }

        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.MuscleGroups.Find(id) == null))
            {
                return HttpNotFound();

            }
            string query = "select * from MuscleGroups where MuscleGroupId=@id";
            SqlParameter param = new SqlParameter("@id", id);

            MuscleGroup MuscleGroupstoshow = db.MuscleGroups.Find(id);

            return View(MuscleGroupstoshow);

        }


    }
}
*/
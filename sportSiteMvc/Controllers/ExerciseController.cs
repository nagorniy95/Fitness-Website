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

namespace sportSiteMvc.Controllers
{
    public class ExerciseController : Controller
    {

        MuscleGroupsContext db = new MuscleGroupsContext();
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        //================================================================================= Read

        public ActionResult List()
        {

            string query = "select * from Exercises";
            // Обьявить переменную
            IEnumerable<Exercise> exercises;
            exercises = db.Exercises.SqlQuery(query);

            return View(exercises);
        }
        //================================================================================= Create

        public ActionResult Create()
        {
            return List();
        }

        [HttpPost]
        public ActionResult Create(string ExerciseTitle, string ExercisePhoto, string ExerciseContent)
        {
            string query = "insert into Exercises (ExerciseTitle, ExercisePhoto, ExerciseContent)" +
                " values (@title, @photo, @content)";
            SqlParameter[] myparams = new SqlParameter[3];
            myparams[0] = new SqlParameter("@title", ExerciseTitle);
            myparams[1] = new SqlParameter("@photo", ExercisePhoto);
            myparams[2] = new SqlParameter("@content", ExerciseContent);

            Debug.WriteLine(query);
            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        
        //================================================================================= Edit

        public ActionResult Edit(int? id)
        {
            if ((id == null) || (db.Exercises.Find(id) == null))
            {
                return HttpNotFound();
            }
            string query = "select * from Exercises where ExerciseId=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Exercise mytag = db.Exercises.SqlQuery(query, param).FirstOrDefault();
            return View(mytag);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string ExerciseTitle, string ExercisePhoto, string ExerciseContent)
        {
            if ((id == null) || (db.Exercises.Find(id) == null))
            {
                return HttpNotFound();
            }
            string query = "update Exercises set ExerciseTitle=@title, ExercisePhoto=@photo, ExerciseContent=@content" +
                " where ExerciseId=@id";
            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter("@title", ExerciseTitle);
            myparams[1] = new SqlParameter("@photo", ExercisePhoto);
            myparams[2] = new SqlParameter("@content", ExerciseContent);
            myparams[3] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
       
        //================================================================================= Delete

        public ActionResult Delete(int? id)
        {

            if ((id == null) || (db.Exercises.Find(id) == null))
            {
                return HttpNotFound();

            }
            string query = "delete from Exercises where ExerciseId=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return RedirectToAction("List");

        }
  
        //================================================================================= Details
        public ActionResult Details(int? id)
        {
            if ((id == null) || (db.Exercises.Find(id) == null))
            {
                return HttpNotFound();

            }
            string query = "select * from Exercises whereExerciseId=@id";
            SqlParameter param = new SqlParameter("@id", id);

            Exercise Exercisestoshow = db.Exercises.Find(id);

            return View(Exercisestoshow);
        }
    }

    
}
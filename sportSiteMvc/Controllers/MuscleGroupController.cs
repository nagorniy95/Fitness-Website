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
    public class MuscleGroupController : Controller
    {
        MuscleGroupsContext db = new MuscleGroupsContext();
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        //================================================================================= Read

        public ActionResult List()
        {

            string query = "select * from MuscleGroups";
            // Обьявить переменную
            IEnumerable<MuscleGroup> muscleGroups;
            muscleGroups = db.MuscleGroups.SqlQuery(query);

            return View(muscleGroups);
        }
        //================================================================================= Create

        public ActionResult New()
        {

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string MuscleGroupName, string MuscleGroupDesc)
        {
            string query = "insert into MuscleGroups (MuscleGroupName, MuscleGroupDesc)" +
                " values (@name, @desc)";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@name", MuscleGroupName);
            myparams[1] = new SqlParameter("@desc", MuscleGroupDesc);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //================================================================================= Edit

        public ActionResult Edit(int? id)
        {
            if ((id == null) || (db.MuscleGroups.Find(id) == null))
            {
                return HttpNotFound();
            }
            string query = "select * from MuscleGroups where MuscleGroupID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            MuscleGroup mytag = db.MuscleGroups.SqlQuery(query, param).FirstOrDefault();
            return View(mytag);
        }


        [HttpPost]
        public ActionResult Edit(int? id, string MuscleGroupName, string MuscleGroupDesc)
        {
            if ((id == null) || (db.MuscleGroups.Find(id) == null))
            {
                return HttpNotFound();
            }
            string query = "update MuscleGroups set MuscleGroupName=@name, MuscleGroupDesc=@desc" +
                " where MuscleGroupID=@id";
            SqlParameter[] myparams = new SqlParameter[3];
            myparams[0] = new SqlParameter("@name", MuscleGroupName);
            myparams[1] = new SqlParameter("@desc", MuscleGroupDesc);
            myparams[2] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //================================================================================= Delete

        
        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.MuscleGroups.Find(id) == null))
            {
                return HttpNotFound();

            }
            string query = "delete from MuscleGroups where MuscleGroupID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return RedirectToAction("List");
            
        }
        //================================================================================= Details

        public ActionResult Details(int? id)
        {
            if ((id == null) || (db.MuscleGroups.Find(id) == null))
            {
                return HttpNotFound();

            }
            string query = "select * from MuscleGroups where MuscleGroupID=@id";
            SqlParameter param = new SqlParameter("@id", id);

            MuscleGroup MuscleGroupstoshow = db.MuscleGroups.Find(id);

            return View(MuscleGroupstoshow);

        }


    }
}
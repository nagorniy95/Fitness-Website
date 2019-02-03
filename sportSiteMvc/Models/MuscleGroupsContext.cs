using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

//This is a Model. What we're doing is defining classes
//That will define our database and tables.

namespace sportSiteMvc.Models
{
    //SubClass of DbContext
    public class MuscleGroupsContext : DbContext
    {

        public MuscleGroupsContext()
        {

        }

        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Excersise> Excersises { get; set; }

    }
}
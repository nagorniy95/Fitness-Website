using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace sportSiteMvc.Models
{
    public class MuscleGroup
    {
        [Key]
        public int MuscleGroupID { get; set; }

        [Required, StringLength(255), Display(Name = "Muscle Group Name")]
        public string MuscleGroupName { get; set; }

        [Required, StringLength(255), Display(Name = "Description")]
        public string MuscleGroupDesc { get; set; }

        //public virtual ICollection<Excersise> Excersises { get; set; }

        public virtual Exercise exercise { get; set; }



    }
}
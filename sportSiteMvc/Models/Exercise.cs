using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace sportSiteMvc.Models
{
    public class Exercise
    {
        [Key, ScaffoldColumn(false)]
        public int ExerciseId { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string ExerciseTitle { get; set; }

        [StringLength(255), Display(Name = "Photo")]
        public string ExercisePhoto { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Content")]
        public string ExerciseContent { get; set; }

        //One excersise to many muscel groups
        public virtual ICollection<MuscleGroup> MuscleGroups { get; set; }

    }
}
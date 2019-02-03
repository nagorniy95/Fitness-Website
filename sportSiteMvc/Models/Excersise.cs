using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace sportSiteMvc.Models
{
    public class Excersise
    {
        [Key, ScaffoldColumn(false)]
        public int exerseseId { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string excersiseTitle { get; set; }

        [StringLength(255), Display(Name = "Photo")]
        public string excersisePhoto { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Content")]
        public string excersiseContent { get; set; }

        //One excersise to many muscel groups
        public virtual ICollection<MuscleGroup> MuscleGroups { get; set; }

    }
}
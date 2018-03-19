namespace PCTUNAWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkFlow")]
    public partial class WorkFlow
    {
        public int ID { get; set; }

        public int? RecipeID { get; set; }

        public int? NextRecipeID { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual Recipe Recipe1 { get; set; }
    }
}

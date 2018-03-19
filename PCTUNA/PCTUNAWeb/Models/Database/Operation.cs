namespace PCTUNAWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Operation")]
    public partial class Operation
    {
        public int ID { get; set; }

        public int? EmployeeID { get; set; }

        public int? LotID { get; set; }

        public int? RecipeID { get; set; }

        public DateTime? StartTime { get; set; }

        [Column(TypeName = "date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? StartDate { get; set; }

        public DateTime? EndTime { get; set; }

        [Column(TypeName = "date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EndDate { get; set; }

        public double? Input { get; set; }

        public double? Output { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Lot Lot { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}

namespace PCTUNAWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ControlValue")]
    public partial class ControlValue
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        public int? ProcessID { get; set; }

        public int? DailyPlan { get; set; }

        public virtual Process Process { get; set; }

        public virtual Product Product { get; set; }
    }
}

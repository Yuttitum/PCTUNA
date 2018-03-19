namespace PCTUNAWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmpRFID")]
    public partial class EmpRFID
    {
        [Key]
        [StringLength(50)]
        public string RFID { get; set; }

        public int? EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

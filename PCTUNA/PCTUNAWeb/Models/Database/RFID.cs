namespace PCTUNAWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RFID")]
    public partial class RFID
    {
        [Key]
        [Column("RFID")]
        [StringLength(50)]
        public string RFID1 { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}

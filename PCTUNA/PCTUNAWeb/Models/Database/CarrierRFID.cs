namespace PCTUNAWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarrierRFID")]
    public partial class CarrierRFID
    {
        [Key]
        [StringLength(50)]
        public string RFID { get; set; }

        public int? CarrierID { get; set; }

        public virtual Carrier Carrier { get; set; }
    }
}

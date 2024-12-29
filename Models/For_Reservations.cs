namespace GovEgy_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class For_Reservations
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Service_Type { get; set; }


        [DataType(DataType.Date)]

        [Column(TypeName = "date")]
        public DateTime? Date_Of_Arrival { get; set; }


        [DataType(DataType.Date)]

        [Column(TypeName = "date")]
        public DateTime? Departure_Date { get; set; }

        public string Passport { get; set; }

        public string Details { get; set; }

        public int? S_Id { get; set; }

        public virtual ServiceType ServiceType { get; set; }
    }
}

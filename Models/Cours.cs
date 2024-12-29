namespace GovEgy_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Courses")]
    public partial class Cours
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string C_Name { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        [StringLength(50)]
        public string Discount { get; set; }

        public int? C_Number { get; set; }

        [StringLength(50)]
        public string C_Mode { get; set; }

        public string Discription { get; set; }

        public string C_Image { get; set; }

        public string C_File { get; set; }

        public int? D_Id { get; set; }

        public virtual Department Department { get; set; }
    }
}

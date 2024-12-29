using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GovEgy_2.Models
{
    public partial class GovEgyDB2 : DbContext
    {
        public GovEgyDB2()
            : base("name=GovEgyDB2")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactService> ContactServices { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<For_Reservations> For_Reservations { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<ServiceType_2> ServiceType_2 { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

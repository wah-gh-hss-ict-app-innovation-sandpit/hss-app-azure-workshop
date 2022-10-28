using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereIsPatient.DB.Models;

namespace WhereIsPatient.DB
{
    public class WhereIsPatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Admission> Admissions { get; set; }

        public WhereIsPatientContext(DbContextOptions<WhereIsPatientContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Replace with your connection string");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patient", e => e.IsTemporal());
            modelBuilder.Entity<Admission>().ToTable("Admission", e => e.IsTemporal());
        }
    }
}

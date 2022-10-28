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
        DbSet<Patient> Patients { get; set; }
        DbSet<Admission> Admissions { get; set; }

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

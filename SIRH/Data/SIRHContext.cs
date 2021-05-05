using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIRH.Models;

namespace SIRH.Data
{
    public class SIRHContext : DbContext
    {
        public SIRHContext (DbContextOptions<SIRHContext> options)
            : base(options)
        {
        }

        public DbSet<SIRH.Models.CandidateDiploma> CandidateDiploma { get; set; }

        public DbSet<SIRH.Models.ContratType> ContratType { get; set; }

        public DbSet<SIRH.Models.Country> Country { get; set; }

        public DbSet<SIRH.Models.Diploma> Diploma { get; set; }

        public DbSet<SIRH.Models.Domain> Domain { get; set; }

        public DbSet<SIRH.Models.Experience> Experience { get; set; }

        public DbSet<SIRH.Models.User> User { get; set; }

        public DbSet<SIRH.Models.JobOffer> JobOffer { get; set; }

        public DbSet<SIRH.Models.CandidateExperience> CandidateExperience { get; set; }

        public DbSet<SIRH.Models.DrivingLicence> DrivingLicence { get; set; }

        public DbSet<SIRH.Models.SalaryWish> SalaryWish { get; set; }

        public DbSet<SIRH.Models.Other> Other { get; set; }

        public DbSet<SIRH.Models.Language> Language { get; set; }

        public DbSet<SIRH.Models.LanguageLevel> LanguageLevel { get; set; }

        public DbSet<SIRH.Models.CandidateLanguage> CandidateLanguage { get; set; }

        public DbSet<SIRH.Models.Candidate> Candidate { get; set; }

        public DbSet<SIRH.Models.Candidature> Candidature { get; set; }

        public DbSet<SIRH.Models.Status> Status { get; set; }

        public DbSet<SIRH.Models.EducationLevel> EducationLevel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Email })
                .IsUnique(true);
            modelBuilder.Entity<JobOffer>()
                .HasIndex(jo => new { jo.Reference })
                .IsUnique(true);
        }

        public DbSet<SIRH.Models.CandidatureSpont> CandidatureSpont { get; set; }
    }
}

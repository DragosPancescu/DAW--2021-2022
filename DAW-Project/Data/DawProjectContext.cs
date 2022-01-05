using DAW_Project.Models;
using DAW_Project.Models.AssociativeTables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Data
{
    public class DawProjectContext: DbContext
    {
        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserTeam> UserTeam { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamProject> TeamProject { get; set; }
        public DbSet<ProjectVersion> ProjectVersion { get; set; }
        public DbSet<BugReport> BugReports { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<PossibleCause> PossibleCauses { get; set; }

        public DawProjectContext(DbContextOptions<DawProjectContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relations

            // User - Team (M-M)
            modelBuilder.Entity<UserTeam>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.User)
                    .WithMany(x => x.UserTeams)
                    .HasForeignKey(x => x.UserId);

                entity.HasOne(x => x.Team)
                    .WithMany(x => x.UserTeams)
                    .HasForeignKey(x => x.TeamId);
            });

            // Team - Project (M-M)
            modelBuilder.Entity<TeamProject>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Team)
                    .WithMany(x => x.TeamProjects)
                    .HasForeignKey(x => x.TeamId);

                entity.HasOne(x => x.Project)
                    .WithMany(x => x.TeamProjects)
                    .HasForeignKey(x => x.ProjectId);
            });

            // Project - ProjectVersion (1-M)
            modelBuilder.Entity<ProjectVersion>(entity =>
            {
                entity.HasOne(x => x.Project)
                    .WithMany(x => x.ProjectVersions)
                    .HasForeignKey(x => x.ProjectId);
            });

            // ProjectVersion - BugReport (1-M)
            modelBuilder.Entity<BugReport>(entity =>
            {
                entity.HasOne(x => x.ProjectVersion)
                    .WithMany(x => x.BugReports)
                    .HasForeignKey(x => x.VersionId);
            });

            // BugReport - Attachment (1-M)
            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasOne(x => x.BugReport)
                    .WithMany(x => x.Attachments)
                    .HasForeignKey(x => x.ReportId);
            });

            // BugReport - PossibleCause (1-1)
            modelBuilder.Entity<PossibleCause>(entity =>
            {
                entity.HasOne(x => x.BugReport)
                    .WithOne(x => x.PossibleCause)
                    .HasForeignKey<PossibleCause>(x => x.ReportId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

using CerificateApp.Entites.Models;
using DCCS.Web.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Web.Entities
{
    public class DCCSContext : DbContext
    {
        public DCCSContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateType> CertificateType { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<UploadFile> UploadFile { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Comment> Comment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>()
               .HasIndex(c => c.Id)
               .IsUnique();

            modelBuilder.Entity<CertificateType>()
               .HasIndex(c => c.Id)
               .IsUnique();

            modelBuilder.Entity<Supplier>()
               .HasIndex(c => c.Id)
               .IsUnique();

            modelBuilder.Entity<UploadFile>()
               .HasIndex(c => c.DocumentId)
               .IsUnique();

            modelBuilder.Entity<User>()
               .HasIndex(c => c.Id)
               .IsUnique();

            modelBuilder.Entity<Comment>()
               .HasIndex(c => c.Id)
               .IsUnique();

            //modelBuilder.Entity<Certificate>()
            //.HasOne(a => a.Supplier)
            //.WithOne(a => a.Certificate)
            //.HasForeignKey<Supplier>(c => c.Certificate);

            //modelBuilder.Entity<Certificate>()
            //.HasOne(a => a.UploadFile)
            //.WithOne(a => a.Certificate)
            //.HasForeignKey<UploadFile>(c => c.Certificate);

            //modelBuilder.Entity<User>()
            //            .HasOne(c => c.Certificate)
            //            .WithMany(c => c.Participant)
            //            .HasForeignKey(p => p.Certificate);

            modelBuilder.Entity<Certificate>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<CertificateType>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Supplier>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<UploadFile>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Comment>().HasQueryFilter(p => !p.IsDeleted);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
        {
            return base.Remove(entity);
        }
    }
}

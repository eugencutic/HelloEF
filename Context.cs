using EfConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApp2
{
    public class Context : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Robot> Robots { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Robots)
                .WithRequired(x => x.User);

            modelBuilder.Entity<Robot>()
                .HasMany(x => x.Sessions)
                .WithRequired(x => x.Robot);
        }
    }
}

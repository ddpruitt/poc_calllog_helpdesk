using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoC.CallLogMvc.Web02.Data.Models;

namespace PoC.CallLogMvc.Web02.Data
{
    public class HelpDeskDbContext : DbContext
    {
        public HelpDeskDbContext(DbContextOptions<HelpDeskDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CallLog>().ToTable("CallLogs")
                .HasOne(cl=>cl.CallStatus)
                .WithMany(cs=>cs.CallLogs);

            modelBuilder.Entity<CallStatus>()
                .ToTable("CallStatus")
                .HasData(
                    new CallStatus { Id = 0, Name = "New" },
                    new CallStatus { Id = 1, Name = "Working" },
                    new CallStatus { Id = 2, Name = "Closed" },
                    new CallStatus { Id = 3, Name = "Rejected" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CallLog> CallLog { get; set; }
        public DbSet<CallStatus> CallStatus { get; set; }
    }
}

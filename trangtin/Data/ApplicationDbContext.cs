using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using trangtin.Models;

namespace trangtin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<trangtin.Models.chuyenmuc> chuyenmuc { get; set; }
        public DbSet<trangtin.Models.chude> chude { get; set; }
        public DbSet<trangtin.Models.bantin> bantin { get; set; }
    }
}

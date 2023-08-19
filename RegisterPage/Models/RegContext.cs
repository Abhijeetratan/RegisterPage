using Microsoft.EntityFrameworkCore;
using System;

namespace RegisterPage.Models
{
    public class RegContext:DbContext
    {
        public RegContext(DbContextOptions<RegContext> options) : base(options) { }



        //DbSet
        public DbSet<Reg> regs { get; set; }

    }
}


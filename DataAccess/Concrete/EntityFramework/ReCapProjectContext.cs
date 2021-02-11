﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProjectContext:DbContext
    {
        // context: db tablolarını ile proje classlarını bağlamak
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapProjectDb;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }       //dbdeki benim nesnem hangi tabloya karşılık gelecek
        public DbSet<Color> Colours { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
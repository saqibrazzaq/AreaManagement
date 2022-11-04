﻿using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        // Tables
        public DbSet<Country>? Countries { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<State>? States { get; set; }
        public DbSet<Area>? Areas { get; set; }
    }
}

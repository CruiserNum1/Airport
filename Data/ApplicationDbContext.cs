using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AirportWork.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AirportWork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Airport> Airports {get;set;}
        public DbSet<Route> Routes {get;set;}
        public DbSet<AirportInRoute> AirportinRoutes {get;set;}
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Foody.DataAccessLayer.Context
{
    public class FoodyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6EJT1VO\\SQLEXPRESS;Database=FoodyDb;Trusted_Connection=True;Encrypt=False;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<AboutItem> AboutItems { get; set; }

    }
}

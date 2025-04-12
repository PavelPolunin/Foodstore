using Foodstore.Models;
using FoodstoreApp1_2025.Controllers;
using FoodstoreApp1_2025.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace FoodStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
             DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Manufacturers> Manufacturers { get; set; }
    }
}

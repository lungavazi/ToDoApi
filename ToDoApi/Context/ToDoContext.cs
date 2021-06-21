using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Entities;
using ToDoApi.Models.Enums;

namespace ToDoApi.Context
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        //database seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
                .HasData(
                new ToDo()
                {
                    Id = 1,
                    Date = DateTime.Now.Date.ToString(),
                    Description = "Need to buy groccery",
                    Title = "Other",
                    Priority = 4,
                    DateCreated = DateTime.Now.Date.ToString()
                },
                new ToDo()
                {
                    Id = 2,
                    Date = DateTime.Now.Date.ToString(),
                    Description = "Do monthly Budget",
                    Title = "Budget",
                    Priority = 2,
                    DateCreated = DateTime.Now.Date.ToString()
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}


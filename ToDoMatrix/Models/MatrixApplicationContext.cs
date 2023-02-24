using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoMatrix.Models
{
    public class MatrixApplicationContext : DbContext
    {
        public MatrixApplicationContext(DbContextOptions<MatrixApplicationContext> options) : base(options)
        {
            //leave blank
        }

        public DbSet<TaskModel> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
                );

            mb.Entity<TaskModel>().HasData(
                new TaskModel
                {
                    TaskId = 1,
                    Task = "Wash the dog",
                    Urgent = "Q1",
                    Completed = false,

                    CategoryId = 1
                },
                new TaskModel
                {
                    TaskId = 2,
                    Task = "IS 413 Assignment",
                    Urgent = "Q2",
                    Completed = false,

                    CategoryId = 2
                },
                new TaskModel
                {
                    TaskId = 3,
                    Task = "Big Presentation",
                    Urgent = "Q3",
                    Completed = false,

                    CategoryId = 3
                },
                new TaskModel
                {
                    TaskId = 4,
                    Task = "Sacrament Meeting Talk",
                    Urgent = "Q4",
                    Completed = false,

                    CategoryId = 4
                }

                );
        }

            
    }
}


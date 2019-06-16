using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public static class ModelBuilderExtensions
    {
        public static void SeedTodo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
               new TodoItem
               {
                   Key = Guid.NewGuid().ToString(),
                   Name = "Initial Value"
               });
        }
    }
}

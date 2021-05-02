using Microsoft.EntityFrameworkCore;
using Project2.Models;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace Project2
{
    public class ContextDB:DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WPF_Project
{
    class ApplicationContext : DbContext
    {
            public ApplicationContext() : base("DbConnectionString") { } // base("DbConnectionString") Имя для подклучения к базы данных
            public DbSet<User> Users { get; set; } //Использование переменных в базе данных
    }
}

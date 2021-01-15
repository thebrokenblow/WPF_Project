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
        public DbSet<User> Users { get; set; } //Использование базы данных
        public ApplicationContext() : base("DefaultConnection") { } //Имя для подклучения к базы данных
    }
}

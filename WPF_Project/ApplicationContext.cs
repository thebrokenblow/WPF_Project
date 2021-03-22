using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;

namespace WPF_Project
{
    class ApplicationContext : DbContext
    {
            public ApplicationContext() : base("DbConnectionString") { } //base("DbConnectionString") определяет контекст данных, 
                                                                         //используемый для взаимодействия с базой данных.
        public DbSet<Users> Users { get; set; } //Представляет набор сущностей, хранящихся в базе данных (таблица Users)
        public DbSet<Сountry> Country { get; set; } //Представляет набор сущностей, хранящихся в базе данных (таблица Country)
        public DbSet<City> City { get; set; } //Представляет набор сущностей, хранящихся в базе данных (таблица City)
        public DbSet<Hotel> Hotel { get; set; } //Представляет набор сущностей, хранящихся в базе данных (таблица Hotel)
    }
}

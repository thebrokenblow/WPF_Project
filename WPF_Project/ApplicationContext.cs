using System.Data.Entity;

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
        public DbSet<TypeOfRoom> TypeOfRoom { get; set; } //Представляет набор сущностей, хранящихся в базе данных (таблица Hotel)
    }
}

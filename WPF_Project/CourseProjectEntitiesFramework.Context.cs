﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelsEntitiesFramework : DbContext
    {
        private static HotelsEntitiesFramework _context;
        public HotelsEntitiesFramework()
            : base("name=HotelsEntitiesFramework")
        {
        }
        public static HotelsEntitiesFramework GetContext()
        {
            if (_context == null)
                _context = new HotelsEntitiesFramework();
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<ListOfRooms> ListOfRooms { get; set; }
        public virtual DbSet<photosOfHotels> photosOfHotels { get; set; }
        public virtual DbSet<PhotosOfRooms> PhotosOfRooms { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeOfRoom> TypeOfRoom { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Сountry> Сountry { get; set; }
    }
}

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
    
    public partial class CourseProjectEntitiesDataBase : DbContext
    {
        public static CourseProjectEntitiesDataBase context;
        public CourseProjectEntitiesDataBase()
            : base("name=CourseProjectEntitiesDataBase")
        {
        }
        public static CourseProjectEntitiesDataBase GetContext()
        {
            if (context == null)
                context = new CourseProjectEntitiesDataBase();
            return context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<ListOfChanges> ListOfChanges { get; set; }
        public virtual DbSet<ListOfRooms> ListOfRooms { get; set; }
        public virtual DbSet<photosOfHotels> photosOfHotels { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeOfRoom> TypeOfRoom { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Сountry> Сountry { get; set; }
    }
}
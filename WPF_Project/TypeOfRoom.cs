//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TypeOfRoom
    {
        public int id { get; set; }
        public string roomName { get; set; }
        public decimal pricePerDay { get; set; }
        public int idOfRooms { get; set; }
        public string roomDescription { get; set; }
    
        public virtual ListOfRooms ListOfRooms { get; set; }
    }
}

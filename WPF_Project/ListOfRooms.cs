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
    
    public partial class ListOfRooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListOfRooms()
        {
            this.Reservation = new HashSet<Reservation>();
            this.TypeOfRoom = new HashSet<TypeOfRoom>();
        }
    
        public int id { get; set; }
        public int idOfHotel { get; set; }
        public int idOfPhotosRooms { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        public virtual PhotosOfRooms PhotosOfRooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeOfRoom> TypeOfRoom { get; set; }
    }
}

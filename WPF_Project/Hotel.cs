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
    
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            this.ListOfRooms = new HashSet<ListOfRooms>();
            this.photosOfHotels = new HashSet<photosOfHotels>();
        }
    
        public int id { get; set; }
        public string nameOfHotel { get; set; }
        public int idOfCity { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string hotelDescription { get; set; }
        public int countOfStars { get; set; }
        public byte[] ImagePreview { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListOfRooms> ListOfRooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<photosOfHotels> photosOfHotels { get; set; }
    }
}

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
    
    public partial class PhotosOfHotels
    {
        public int id { get; set; }
        public int idOfHotel { get; set; }
        public byte[] photo { get; set; }
    
        public virtual Hotel Hotel { get; set; }

        internal static object GetContext()
        {
            throw new NotImplementedException();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reservuary.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Podpisanty
    {
        public int ID { get; set; }
        public Nullable<int> IDFilial { get; set; }
        public string Doljnost { get; set; }
        public string FIO { get; set; }
        public string Nazn { get; set; }
    
        public virtual location location { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfServisCenter
{
    using System;
    using System.Collections.Generic;
    
    public partial class Клиент
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Клиент()
        {
            this.Заказ = new HashSet<Заказ>();
            this.СписокОказанияУслуг = new HashSet<СписокОказанияУслуг>();
        }
    
        public int Код { get; set; }
        public string Фио { get; set; }
        public string Телефон { get; set; }
        public string Адрес { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заказ> Заказ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<СписокОказанияУслуг> СписокОказанияУслуг { get; set; }
    }
}

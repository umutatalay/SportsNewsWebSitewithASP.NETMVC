//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USportsNews.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Haber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Haber()
        {
            this.Tbl_Admin = new HashSet<Tbl_Admin>();
        }
    
        public int HaberID { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public string HaberBaslik { get; set; }
        public string HaberOzet { get; set; }
        public string HaberIcerik { get; set; }
        public string HaberGorsel { get; set; }
        public Nullable<int> YazarID { get; set; }
        public Nullable<System.DateTime> HaberTarih { get; set; }
        public string Slider { get; set; }
        public string Etiket { get; set; }
    
        public virtual Tbl_Kategori Tbl_Kategori { get; set; }
        public virtual Tbl_Yazar Tbl_Yazar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Admin> Tbl_Admin { get; set; }
    }
}

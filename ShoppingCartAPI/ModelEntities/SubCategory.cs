//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingCartAPI.ModelEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubCategory
    {
        public int SubCategoryId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public string SubCategoryName { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Category Category1 { get; set; }
        public virtual Category Category2 { get; set; }
        public virtual Category Category3 { get; set; }
        public virtual Category Category4 { get; set; }
        public virtual Category Category5 { get; set; }
        public virtual Category Category6 { get; set; }
        public virtual Category Category7 { get; set; }
        public virtual Category Category8 { get; set; }
        public virtual Category Category9 { get; set; }
        public virtual Category Category10 { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingCart.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Image
    {
        public int ImageId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string ImageUrl { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Product Product1 { get; set; }
        public virtual Product Product2 { get; set; }
        public virtual Product Product3 { get; set; }
        public virtual Product Product4 { get; set; }
        public virtual Product Product5 { get; set; }
        public virtual Product Product6 { get; set; }
        public virtual Product Product7 { get; set; }
        public virtual Product Product8 { get; set; }
        public virtual Product Product9 { get; set; }
        public virtual Product Product10 { get; set; }
    }
}

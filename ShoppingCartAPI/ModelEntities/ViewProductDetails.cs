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
    
    public partial class ViewProductDetails
    {
        public int ProductId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string CategoryName { get; set; }
        public bool Category_IsActive { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrdersSystem.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int OrderedCount { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
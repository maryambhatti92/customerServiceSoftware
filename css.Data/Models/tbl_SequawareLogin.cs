//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace css.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_SequawareLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Nullable<int> Company_ID { get; set; }
        public string role { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string ForgotPasswordCode { get; set; }
        public Nullable<int> languageID { get; set; }
    }
}

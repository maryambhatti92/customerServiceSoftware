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
    
    public partial class tbl_customer_request
    {
        public int Request_id { get; set; }
        public string ref_num { get; set; }
        public int issue { get; set; }
        public string customer_file { get; set; }
        public int customer_id { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> date_added { get; set; }
        public Nullable<System.DateTime> Last_Modified { get; set; }
        public string Individual_FootNote { get; set; }
        public string FurtherInformatipn { get; set; }
        public string error_description { get; set; }
        public string worker { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
        public Nullable<int> Company_ID { get; set; }
        public string CreatedBy { get; set; }
    }
}

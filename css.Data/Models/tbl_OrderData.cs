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
    
    public partial class tbl_OrderData
    {
        public int Order_id { get; set; }
        public Nullable<int> Request_id { get; set; }
        public Nullable<int> Email_Sent { get; set; }
        public Nullable<System.DateTime> Email_date { get; set; }
        public string Confirmation { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string CustomerNumber_FrmSheet { get; set; }
        public string CustomerNumber_Org { get; set; }
        public string OrginalOrderNumber { get; set; }
        public string Waranty { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string product { get; set; }
        public Nullable<double> Orignal_Quantity { get; set; }
    }
}
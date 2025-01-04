using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Shared.ViewModels
{
   public class ServiceInfoVM
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
        public Nullable<int> Order_id { get; set; }
        public Nullable<int> Request_id1 { get; set; }
        public Nullable<int> Email_Sent { get; set; }
        public Nullable<System.DateTime> Email_date { get; set; }
        public string Confirmation { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string CustomerNumber_FrmSheet { get; set; }
        public string CustomerNumber_Org { get; set; }
        public string OrginalOrderNumber { get; set; }
        public string Waranty { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<double> Orignal_Quantity { get; set; }
        public Nullable<int> InspectionID { get; set; }
        public Nullable<int> RequestId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> Department { get; set; }
        public string Operator { get; set; }
        public string Complaint { get; set; }
        public Nullable<int> ServiceTask { get; set; }
        public Nullable<int> Diagnosis { get; set; }
        public Nullable<int> Reason { get; set; }
        public string Description { get; set; }
        public string createRp { get; set; }
        public string ReportDone { get; set; }
        public string Create8DReport { get; set; }
        public string report8DDone { get; set; }
        public Nullable<int> Email_Sent1 { get; set; }
        public Nullable<System.DateTime> Email_date1 { get; set; }
        public Nullable<int> Customer_id1 { get; set; }
        public string cname { get; set; }
        public string address { get; set; }
        public string Country { get; set; }
        public string street { get; set; }
        public string Zipcode { get; set; }
        public string company { get; set; }
        public string CustomerRefNo { get; set; }

        public List<tbl_contact_person> contactpersons { get; set; }


    }
}

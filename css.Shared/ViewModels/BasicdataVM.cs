using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Shared.ViewModels
{
   public partial class BasicdataVM
    {
        public int Customer_id { get; set; }
        public string cname { get; set; }
        public string address { get; set; }
        public string street { get; set; }
        public Nullable<int> zipcode_id { get; set; }
        public Nullable<int> country_id { get; set; }
        public string company { get; set; }
        public string CustomerRefNo { get; set; }
        public Nullable<int> Request_id { get; set; }
        public Nullable<int> ref_num { get; set; }       
        public int issue { get; set; }
        public string customer_file { get; set; }
        public Nullable<int> customer_id { get; set; } 
        public Nullable<int> priority { get; set; }
        public Nullable<int>  status { get; set; }
        public string  date_added { get; set; }
        public string error_description { get; set; }
        public string worker { get; set; }
        public Nullable<int> zipCode_id { get; set; }
        public string  zipcode { get; set; }
        public Nullable<int> count_id { get; set; }
        public string country { get; set; }

        public List<tbl_contact_person> contactpersons { get; set; }

    }
}

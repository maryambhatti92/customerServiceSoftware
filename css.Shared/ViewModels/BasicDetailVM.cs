using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace css.Shared.ViewModels
{
   public class BasicDetailVM
    {
        public int Customer_id { get; set; }               
        public string street { get; set; }      
        public string company { get; set; }
        public string CustomerRefNo { get; set; }
        public Nullable<int> Request_id { get; set; }        
        public int issue { get; set; }                        
        public string error_description { get; set; }                
        public string zipcode { get; set; }        
        public string country { get; set; }

        public int Contact_id { get; set; }
        public string Contact_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string furtherInfo { get; set; }
    }
}

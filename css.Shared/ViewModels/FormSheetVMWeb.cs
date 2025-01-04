
using css.Data.Models;


namespace css.Shared.ViewModels
{
    public class FormSheetVMWeb
    {
        //customer
        public string cname { get; set; }        
        public string Country { get; set; }
        public string street { get; set; }
        public string Zipcode { get; set; }
        public string company { get; set; }
        public string CustomerRefNo { get; set; }

        //contact
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        //problem
        public int Issue { get; set; }
        public string ref_num { get; set; }
        public string FurtherInformatin { get; set; }
        public string reason { get; set; }
        public int companyID { get; set; }
        public string CreatedBy { get; set; }







    }
}

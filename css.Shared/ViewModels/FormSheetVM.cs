
using css.Data.Models;


namespace css.Shared.ViewModels
{
    public class FormSheetVM
    {
        public tbl_customer Customer { get; set; }        
        public tbl_contact_person Person1 { get; set; }
        public tbl_contact_person Person2 { get; set; }
        public tbl_customer_request Request { get; set; }

    }
}

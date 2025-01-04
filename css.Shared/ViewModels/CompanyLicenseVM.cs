using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace css.Shared.ViewModels
{
    public class CompanyLicenseVM
    {
        public string OldLicense { get; set; }
        public string OldLicenseDate { get; set; }
        public bool ToArchive { get; set; }
        public string License { get; set; }
        public string LicenseDate { get; set; }
        public int CompanyID { get; set; }
     

    }
}

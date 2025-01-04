using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;
using css.Repository.Interfaces;
using System.Data.Entity;

namespace css.Repository.Repositories
{
    class EmailRepository : Repository<Tbl_EmailContents> , IEmailRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public EmailRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public Tbl_EmailContents GetEmailwithCode(string code, int companyID, int LanguageID)
        {
            try
            {
                var y = cssDbContext.Tbl_EmailContents.Where(x => x.Email_Code.Contains(code) && x.Company_ID ==  companyID && x.LanguageID == LanguageID).FirstOrDefault();                
                return y;
            }
            catch (Exception ex)
            {
                string errrror = ex.Message.ToString();
                throw;
            }    
                                          
        }

        
    }
}

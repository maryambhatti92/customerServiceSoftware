using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Repository.Interfaces
{
    public interface IEmailRepository : IRepository<Tbl_EmailContents>
    {
        Tbl_EmailContents GetEmailwithCode(string code, int compnayID, int LanguageID);       
    }
}

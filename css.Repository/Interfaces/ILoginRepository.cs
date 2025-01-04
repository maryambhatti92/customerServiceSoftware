using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Repository.Interfaces
{
    public interface ILoginRepository : IRepository<tbl_SequawareLogin>
    {
        tbl_SequawareLogin GetLogin(tbl_SequawareLogin login);
        tbl_SequawareLogin GetLoginViaUserandCompany(tbl_SequawareLogin login);
        tbl_SequawareLogin GetDataforForgetPassword(tbl_SequawareLogin login);
        tbl_SequawareLogin GetDataViaResetCode(string login);
        IEnumerable<tbl_SequawareLogin> GetLoginViaCompany (int CompanyID);
    }
}

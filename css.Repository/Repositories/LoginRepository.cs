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
    class LoginRepository : Repository<tbl_SequawareLogin>, ILoginRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public LoginRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public tbl_SequawareLogin GetLogin(tbl_SequawareLogin login)
        {
            try
            {
                var y = cssDbContext.tbl_SequawareLogin.Where(x => x.UserName.Contains(login.UserName) && x.Password.Contains(login.Password) && x.Company_ID == login.Company_ID && x.isActive == true).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                string errrror = ex.Message.ToString();
                throw;
            }

        }

        public tbl_SequawareLogin GetLoginViaUserandCompany(tbl_SequawareLogin login)
        {
            try
            {
                var y = cssDbContext.tbl_SequawareLogin.Where(x => x.UserName.Contains(login.UserName) && x.Company_ID == login.Company_ID && x.isActive == true).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                string errrror = ex.Message.ToString();
                throw;
            }

        }

        public tbl_SequawareLogin GetDataforForgetPassword(tbl_SequawareLogin login)
        {
            try
            {
                var y = cssDbContext.tbl_SequawareLogin.Where(x => x.UserName.Contains(login.UserName)).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                string errrror = ex.Message.ToString();
                throw;
            }

        }

        public tbl_SequawareLogin GetDataViaResetCode(string code)
        {
            try
            {
                var y = cssDbContext.tbl_SequawareLogin.Where(x => x.ForgotPasswordCode.Contains(code)).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                string errrror = ex.Message.ToString();
                throw;
            }

        }

        public  IEnumerable<tbl_SequawareLogin> GetLoginViaCompany(int CompanyID)
        {
            try
            {
                var y = cssDbContext.tbl_SequawareLogin.Where(x => x.Company_ID == CompanyID && x.isActive == true).ToList();
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

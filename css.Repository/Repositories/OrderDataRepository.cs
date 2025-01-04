using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;
using css.Repository.Interfaces;
using System.Data.Entity;
using System.Data;

namespace css.Repository.Repositories
{
   public class OrderDataRepository : Repository<tbl_OrderData>, IOrderDataRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public OrderDataRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public tbl_OrderData GetOrderViaRequest(int requestId)
        {
            return cssDbContext.tbl_OrderData.Where(x => x.Request_id== requestId).FirstOrDefault();
        }
    }
}

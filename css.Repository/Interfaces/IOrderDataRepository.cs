using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;


namespace css.Repository.Interfaces
{ 
    public interface IOrderDataRepository : IRepository<tbl_OrderData>
    {
        tbl_OrderData GetOrderViaRequest(int requestId);
    }
}

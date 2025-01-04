using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Shared.ViewModels
{
   public class SolutionVM
    {
        public tbl_Solution solution { get; set; }

        public IEnumerable<tbl_SolutionOptions> options { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 
namespace CustomerPayments.Data.Repositories.Generic
{
    public class RepositoryActionResult
    {
        public RepositoryActionStatus Status { get; private set; }

        public RepositoryActionResult(RepositoryActionStatus status)
        {
            Status = status;
        }
    }
}

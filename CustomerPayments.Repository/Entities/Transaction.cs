using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CustomerPayments.Repository.Entities
{
    [Table("CUSTOMER_TRANSACTIONS")]
    public partial class Transaction
    {
        public int Id { get; set; }
        public int AccountFrom_Id { get; set; }
        public int AccountTo_Id { get; set; }
        public int CustomerFrom_Id { get; set; }
        public int CustomerTo_Id { get; set; }

        [Timestamp]
        public DateTime DateSubmitted { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}

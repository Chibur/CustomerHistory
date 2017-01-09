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
    [Table("CUSTOMER_ACCOUNTS")]
    public partial class Account
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Timestamp]
        public DateTime DateCreated { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }

        [StringLength(10)]
        [Required]
        public string AccountType { get; set; }
    }
}

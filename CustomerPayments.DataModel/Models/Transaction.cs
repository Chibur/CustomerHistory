using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.DataModel
{
    [Table("Transactions")]
    public class Transaction
    {
        public int Id { get; set; }

        [Timestamp]
        public byte[] DateSubmitted { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [StringLength(200)]
        [Required]
        public string Discription { get; set; }

        [StringLength(30)]
        [Required]
        public string BeneficiaryAccount { get; set; }

        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomerPayments.Domain.Interfaces;

namespace CustomerPayments.Domain.Entities
{
    [Table("Transactions")]
    public class Transaction: IModificationHistory, IEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [StringLength(200)]
        [Required]
        public string Discription { get; set; }

        [StringLength(30)]
        [Required]
        public string BeneficiaryAccount { get; set; }

        [StringLength(30)]
        [Required]
        public string SenderAccount { get; set; }

        public int? AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}

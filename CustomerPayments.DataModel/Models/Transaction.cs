using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.DataModel.Interfaces;

namespace CustomerPayments.DataModel
{
    [Table("Transactions")]
    public class Transaction: IModificationHistory
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

        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDirty { get; set; }

    }
}

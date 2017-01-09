using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.DataModel
{
    [Table("Accounts")]
    public class Account
    {
        public Account()
        {
            Transacions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        [StringLength(30)]
        public string AccountNumber { get; set; }
        [Timestamp]
        public byte[] DateCreated { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
        [Required]
        public AccountType AccountType { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public ICollection<Transaction> Transacions { get; set; }
    }
}

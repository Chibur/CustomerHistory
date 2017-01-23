using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Enums;
using CustomerPayments.Domain.Interfaces;

namespace CustomerPayments.Domain.Entities
{
    [Table("Accounts")]
    public class Account: IModificationHistory
    {
        public Account()
        {
            Transacions = new List<Transaction>();
        }

        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string AccountNumber { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
        
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public List<Transaction> Transacions { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Interfaces;

namespace CustomerPayments.Domain.Entities
{
    [Table("Customers")]
    public class Customer: IModificationHistory, IEntity
    {
        public Customer()
        {
            Accounts = new List<Account>();
            Transactions = new List<Transaction>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }

        public List<Account> Accounts { get; set; }
        public List<Transaction> Transactions { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

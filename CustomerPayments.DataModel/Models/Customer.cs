using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.DataModel
{
    [Table("Customers")]
    public class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
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

        [Timestamp]
        public byte[] LastModified { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } // could be handy
    }
}

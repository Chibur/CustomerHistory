using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Custom;
using CustomerPayments.Domain.Interfaces;

namespace CustomerPayments.Domain.Entities
{
    [Table("Customers")]
    public class Customer: IModificationHistory, IEntity
    {
        public Customer()
        {
            Accounts = new List<Account>();
        }

        public virtual int Id { get; set; }

        [StringLength(50)]
        [Required]
        public virtual string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public virtual string LastName { get; set; }

        [StringLength(20)]
        public virtual string PhoneNumber { get; set; }

        [StringLength(50)]
        public virtual string EmailAddress { get; set; }

        [Column(TypeName = "date")]
        public virtual DateTime Birthdate { get; set; }

        public virtual List<Account> Accounts { get; set; }

        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }
        public virtual bool IsDirty { get; set; }
    }
}

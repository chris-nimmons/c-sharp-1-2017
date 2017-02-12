using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public Guid Signature { get; set; }
        public string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address_1 { get; set; }
        public virtual string Address_2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Do_Not_Email { get; set; }
        public Customer()
        {

        }

        public void UpdateEmail(string email)
        {
            if (email != Email)
            {
                Email = email;
            }
        }
    }
}
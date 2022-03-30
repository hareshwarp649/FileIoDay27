using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationAddress
{
    internal class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

       
        public string Address { get; set; }

       
        public string City { get; set; }

       
        public string State { get; set; }


        public string ZipCode { get; set; }

      

        public string PhoneNumber { get; set; }

        

        public string Email { get; set; }

        

        public Contact(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNumber, string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.ZipCode = ZipCode;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
        }

      

        public override string ToString()
        {
            return FirstName + "\t" + LastName + "\t" + Address + "\t" + City + "\t" + State + "\t" + ZipCode + "\t" + PhoneNumber + "\t" + Email;
        }
    }
}

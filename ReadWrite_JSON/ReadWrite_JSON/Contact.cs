using System;
using System.Collections.Generic;
using System.Text;

namespace ReadWrite_JSON
{
    public class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public double zip { get; set; }
        public double phoneNumber { get; set; }
        public string email { get; set; }
        public Contact(string firstName, string lastName, string address, string city, string state, double zip, double phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Contact))
            {
                return false;
            }
            return (this.firstName == ((Contact)obj).firstName)
                && (this.lastName == ((Contact)obj).lastName);
        }
        public override int GetHashCode()
        {
            return firstName.GetHashCode() ^ lastName.GetHashCode();
        }
    }
}

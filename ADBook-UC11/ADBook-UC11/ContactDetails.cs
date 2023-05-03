using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{    
    public class ContactDetails
    {
        // contact PRoperties mentioned in the Use-Case
        public string firstName;
        public string secondName;
        public string address;
        public string city;
        public string state;
        public long zip;
        public long phoneNumber;
        public string emailId;
      
        public ContactDetails(string firstName, string secName, string address, string city, string state, long zip, long phoneNumber, string emailId)
        {
            this.firstName = firstName.ToLower();
            this.secondName = secName.ToLower();
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.emailId = emailId;
        }
    }
}
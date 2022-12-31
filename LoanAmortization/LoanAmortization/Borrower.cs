using System;

namespace LoanAmortization
{
    public class Borrower
    {
        public String fullName;
        public String address;
        public String address2;
        public String city;
        public String state;
        public String zipcode;

        public Borrower()
        {
        }

        public Borrower(string fullName, string address, string address2, string city, string state, string zipcode)
        {
            this.fullName = fullName;
            this.address = address;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
        }

        public string FullName { get => fullName; set => fullName = value; }
        public string Address { get => address; set => address = value; }
        public string Address2 { get => address2; set => address2 = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
    }
}

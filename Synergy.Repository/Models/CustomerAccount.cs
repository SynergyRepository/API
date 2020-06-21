using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Repository.Models
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int CountryId { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string DailingCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public bool isEmailVerified { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RefererCode { get; set; }
    }
}

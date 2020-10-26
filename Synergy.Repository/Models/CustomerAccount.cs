using System;

namespace Synergy.Repository.Models
{
    public class CustomerAccount : BaseAccountModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string DailingCode { get; set; }
        public string PhoneNumber { get; set; }
        
        public bool isEmailVerified { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public int NationalityId { get; set; }
        public string HowDoyouKnow { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public string RefererCode { get; set; }
        public Country Country { get; set; }
    }

    public class BaseAccountModel
    {
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public string Role { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}

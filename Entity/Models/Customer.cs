using System;
namespace Entity.Models
{
    public class Customer: GeneralModel
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}

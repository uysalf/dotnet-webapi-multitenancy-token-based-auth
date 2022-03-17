using System;
using System.Collections.Generic;

namespace WebUI.Models
{

    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }

    public class CustomerListModel
    {
        public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
    }
    
    
}

using System;
using Microsoft.AspNetCore.Identity;
namespace Entity.Models
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

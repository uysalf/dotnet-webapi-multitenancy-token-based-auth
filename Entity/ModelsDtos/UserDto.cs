using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.ModelsDtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string SelectedRoles { get; set; }
    }

    public class RoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}

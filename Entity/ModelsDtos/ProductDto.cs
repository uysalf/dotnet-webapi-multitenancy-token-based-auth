using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.ModelsDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [StringLength(40, ErrorMessage = "Name cannot be longer than 40 characters.")]
        public string Name { get; set; }
        public Decimal? Price { get; set; }
        public string Description { get; set; }
        public string LastUpdateUser { get; set; }

    }
}

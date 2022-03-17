using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //  [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public Decimal? Price { get; set; }
        public string Description { get; set; }
    }
    public class ProductListModel
    {
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}

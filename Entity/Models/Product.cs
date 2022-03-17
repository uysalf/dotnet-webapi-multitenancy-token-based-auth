using System;
namespace Entity.Models
{
    public class Product: GeneralModel
    {
        public string Name { get; set; }
        public Decimal? Price { get; set; }
        public string Description { get; set; }
        public string StockCode { get; set; }

    }
}

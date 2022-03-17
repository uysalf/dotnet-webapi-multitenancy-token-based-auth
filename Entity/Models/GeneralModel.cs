using System;
namespace Entity.Models
{
    public class GeneralModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreateUser { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public string LastUpdateUser { get; set; }

    } 
}

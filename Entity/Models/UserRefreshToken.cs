using System;
namespace Entity.Models
{
    public class UserRefreshToken : GeneralModel
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}

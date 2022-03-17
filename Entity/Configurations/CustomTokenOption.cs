using System;
using System.Collections.Generic;

namespace Entity.Configurations
{
    /// <summary>
    /// Bu class appsettigs.json'a göre oluşturuldu.
    /// options pattern'e göre startup.cs'den configure ettik.
    /// IOptions<CustomTokenOption> options ile oluşturup options.Value ile getirilir.
    /// </summary>
    public class CustomTokenOption
    {
        public List<String> Audience { get; set; }
        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }

        public string SecurityKey { get; set; }
    }
}

# dotnet-webapi-multitenancy-token-based-auth


*******************************************************
Ön Not:
Bu projeyi entity framework 5.. ile geliştirdiğim için öncelikle bilgisayarınızda kurulu entity framework versiyonunu aşağıdaki şekilde edebilirsin. 
*******  dotnet ef --version. *******
versiyonun 5.. ise;

Migration klasörü WebApi içinde olduğu için terminalde solution içindeki "WebApi" ye gidip, burada sırası ile çalıştırması gereken iki scrpit var

dotnet ef database update --context FirstDbContext

bu tamamlandıktan sonra


dotnet ef database update --context SecondDbContext

bu işlemlerden sonra sqlServerında iki tane Database oluşacaktır. 
*******************************************************










Video Anlatım: https://www.youtube.com/watch?v=Hyc9cIqBxJM
 
Bu uygulama Multi Tenant yapısı ile geliştirildi. Kullanıcılar birden fazla veribanına aynı uygulama üzerinden erişim gerçekleştirebilecek. Bu erişimi de sadece yetkisi olduğu kısımlarda gerçekleştirebilecek.​

Web API tarafında AspNetCore.Identity login olurken, bu kullanıcı için Token Authentication ile token oluşturuyoruz.

Web UI tarafında ise oluşan bu token'ı,  UI tarafında Cookie'de saklayıp, UI tarafında da login olmasını sağlıyoruz.


Bu uygulama örneğinde iki tane veritabanımız var.​
Ilk db'de IdentityASP.NET tabloları, Product ve refresh token bilgilerinin tutulduğu tablomuz mevcut.​
İkinci db'de ise Customer tablosu mevcut.​

Bu uygulamanın WebApi tarafında Unit of Work ile Generic Repository Tasarım deseni kullanıldı. Projenin 4 katmanı bulunmaktadır.​

Entity: Apilerde kullandığımız modellerimiz bu katmanda yer alacak.​

Data: EntitiyFramework işlemlerini burada gerçekleştiriyoruz. DbContext, UnitofWork ve Repository sınıflarımız burada yer alıyor.​

Business: Data katmanıdan çektiğimiz verileri Api katmanına ileten katman burasıdır. İşlemlerde ilgili kodlamalar yapılacak.​ Token bu katmanda oluşturuluyor.

WebApi: Web Api servislerimiz burada yer alacak.​

WebUI: WebApi servislerini kullanan ön yüz uygulaması​




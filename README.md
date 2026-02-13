 
##  Mimari ve Teknik Yaklaşım

###   Backend (.NET 10)
Projenin backend tarafı, sürdürülebilirlik ve test edilebilirlik prensipleri üzerine inşa edilmiştir:

* **Onion Architecture:** Bağımlılıklar içe doğru kurgulanarak (Domain > Application > Infrastructure > API) iş mantığı dış etkenlerden izole edilmiştir.
* **CQRS & MediatR:** Okuma ve yazma işlemleri ayrıştırılarak kod karmaşası önlenmiştir.
* **Redis Cache (Cache-aside Pattern):** Ürün listeleri ve detayları Redis üzerinde önbelleğe alınarak veritabanı yükü azaltılmıştır.
* **Cache Invalidation:** `Create`, `Update` ve `Delete` komutları sonrası ilgili önbellek anahtarları otomatik olarak temizlenerek veri tutarlılığı (consistency) sağlanmıştır.
* **Serilog:** Uygulama logları hem konsol hem de günlük dosya sisteminde yapısal olarak tutulmaktadır.



###   Frontend (Next.js 14+)
Kullanıcı arayüzü, en güncel Next.js özellikleri kullanılarak SEO ve performans odaklı geliştirilmiştir:

* **App Router:** Modern dosya tabanlı yönlendirme sistemi.
* **Redux Toolkit (RTK):** Sepet (Cart) yönetimi, merkezi bir store üzerinden global state olarak yönetilmektedir.
* **next-intl (i18n):** TR/EN dil desteği kurgulanmış, dinamik route yapıları (locale-based) oluşturulmuştur.
* **Image Optimization:** `next/image` bileşeni ile görsellerin otomatik boyutlandırılması ve lazy-load edilmesi sağlanmıştır.
* **Middleware:** JWT tabanlı oturum kontrolü sunucu tarafında (Server-side) yönetilerek güvenli rotalar oluşturulmuştur.

---

##   Kurulum ve Çalıştırma

### 1. Gereksinimler
* PostgreSQL
* Redis (veya Windows için Memurai)
* Node.js (v18+)

### 2. Backend Ayarları
`appsettings.json` dosyasındaki bağlantı dizelerini güncelledikten sonra:
```bash
cd ProductFlow.OnionTest.Server.API
dotnet restore
dotnet run
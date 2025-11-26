# e-İmar Projesi Backend

Bu proje, e-İmar süreçlerini yönetmek için geliştirilmiş bir .NET 8.0 backend uygulamasıdır. Temiz Mimari (Clean Architecture) prensipleri kullanılarak tasarlanmıştır ve esnek, sürdürülelebilir ve test edilebilir bir yapı sunar.

## Proje Mimarisi

Proje, 4 ana katmandan oluşmaktadır:

-   **`Domain`**: Projenin iş kurallarını ve temel varlıklarını (entities) içerir. Diğer katmanlardan bağımsızdır.
-   **`Application`**: Uygulamanın ana iş mantığını, servis arayüzlerini (interfaces) ve veri transfer nesnelerini (DTOs/ViewModels) barındırır.
-   **`Infrastructure`**: Veritabanı erişimi (Entity Framework Core), dış servislerle iletişim gibi teknik detayları içerir.
-   **`Api`**: Dış dünyaya açılan kapıdır. RESTful API endpoint'lerini barındırır ve kullanıcıdan gelen istekleri karşılar.

## Kurulum ve Çalıştırma

Bu projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin.

### Ön Koşullar

1.  **.NET 8.0 SDK:** Makinenizde .NET 8.0 SDK'nın kurulu olduğundan emin olun.
2.  **MySQL Veritabanı:** Çalışan bir MySQL sunucusuna erişiminiz olmalı.
3.  **dotnet-ef aracı:** Entity Framework Core "migration" komutlarını çalıştırabilmek için bu aracın .NET 8.0 uyumlu versiyonunun yüklü olması gerekir. Yüklemek için:
    ```bash
    dotnet tool install --global dotnet-ef --version 8.0.4
    ```

### Adım 1: Veritabanı Bağlantısını Yapılandırma

`eImar/eImar.Api/appsettings.json` dosyasını açın ve `ConnectionStrings` bölümünü kendi MySQL veritabanı bilgilerinize göre güncelleyin. `{YOUR_PASSWORD}` kısmını kendi şifrenizle değiştirin.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=eimar_db;User=root;Password={YOUR_PASSWORD};"
}
```

### Adım 2: Veritabanı "Migration" Oluşturma ve Uygulama

Bu proje, veritabanı şemasını kod üzerinden (Code-First) yönetir. Aşağıdaki komutlarla veritabanını oluşturabilirsiniz. Projenin ana dizininde (`eImar/` klasörünün olduğu yerde) bir terminal açın ve çalıştırın:

1.  **Migration Dosyasını Oluşturma:**
    *Bu komut, projedeki `Domain` katmanında tanımlı entity'lere bakarak veritabanı tablolarını oluşturacak SQL script'lerini içeren bir "migration" dosyası yaratır.*
    ```bash
    dotnet ef migrations add InitialCreate --project eImar/eImar.Infrastructure/eImar.Infrastructure.csproj --startup-project eImar/eImar.Api/eImar.Api.csproj
    ```

2.  **Migration'ı Veritabanına Uygulama:**
    *Bu komut, bir önceki adımda oluşturulan "migration" dosyasını çalıştırarak veritabanınızda ilgili tabloları ve başlangıç verilerini (seed data) oluşturur.*
    ```bash
    dotnet ef database update --project eImar/eImar.Infrastructure/eImar.Infrastructure.csproj --startup-project eImar/eImar.Api/eImar.Api.csproj
    ```
    Bu komut başarıyla tamamlandığında, `eimar_db` veritabanınız ve içinde tüm tablolarınız hazır olacaktır.

### Adım 3: Uygulamayı Çalıştırma

Aşağıdaki komutla API projesini başlatın:

```bash
dotnet run --project eImar/eImar.Api/eImar.Api.csproj
```

Uygulama başarıyla başladığında, terminalde `http://localhost:5000` ve `https://localhost:5001` (veya benzeri) adreslerinde çalıştığını göreceksiniz.

## API'yi Test Etme (Swagger Arayüzü)

Uygulama çalışırken, bir tarayıcı açın ve aşağıdaki adrese gidin:

**`http://localhost:5000/swagger`**

Bu arayüz, projedeki tüm API endpoint'lerini listeler. Buradan endpoint'leri test edebilir, istek gönderebilir ve dönen yanıtları inceleyebilirsiniz. Özellikle `Workflows` kontrolcüsü altındaki endpoint'ler, projenin temel iş akışı mantığını test etmek için kullanılabilir.

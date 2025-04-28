# 📚 PhoneBookApp - Mikroservis Telefon Rehberi Uygulaması

Bu proje, iş mülakatı kapsamında geliştirilmiş bir mikroservis mimarili **Telefon Rehberi** uygulamasıdır.  
.NET 8/9, PostgreSQL, Kafka, Docker Compose kullanılarak geliştirilmiştir.  
Servisler birbirleriyle **REST API** ve **Kafka üzerinden** haberleşmektedir.

---

## 🛠️ Kullanılan Teknolojiler

- .NET 9.0
- ASP.NET Core Web API
- PostgreSQL (Entity Framework Core)
- Kafka (Asenkron mesajlaşma)
- Docker & Docker Compose
- CQRS + MediatR
- Unit of Work Pattern
- Repository Pattern
- FluentValidation
- AutoMapper
- xUnit + Moq + FluentAssertions (Unit Testler)

---

## 📂 Proje Yapısı

```bash
PhoneBookApp/
├── src/
│   ├── Services/
│   │   ├── ContactService/         # Kişi yönetimi servisleri
│   │   ├── ReportService/           # Rapor yönetimi servisleri
│   │   ├── ReportService.Worker/    # Kafka Consumer - Rapor hazırlayıcı Worker servisi
│   ├── Shared/
│       ├── BaseResponses/           # Ortak Response yapıları
│       ├── Events/                  # Kafka event modelleri
├── tests/
│   ├── ContactService.Test/         # Contact Service unit/integration testleri
│   ├── ReportService.Test/          # Report Service unit/integration testleri
├── docker-compose-kafka.yml         # Kafka ve Zookeeper için Docker Compose dosyası
└── README.md                        # Proje açıklamaları

⚙️ Projeyi Kurulum Talimatları
1️⃣ Gerekli Kurulumlar
.NET SDK 9.0

PostgreSQL 14+

Docker Desktop (Kafka çalıştırmak için)

Docker yoksa Kafka kurulumu manuel yapılmalıdır.

2️⃣ Veritabanı Kurulumu
PostgreSQL kurulumu yapıldıktan sonra:

Bir adet ContactDB

Bir adet ReportDB veritabanı oluşturulmalıdır.

Bağlantı bilgileri appsettings.json dosyalarında ayarlanmıştır:

json
Kopyala
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ContactDB;Username=postgres;Password=admin1234"
}
Sonrasında Migrations uygulayın:

Terminal açın ve sırayla şu komutları çalıştırın:

bash
Kopyala
cd src/Services/ContactService/ContactService.Infrastructure
dotnet ef database update

cd ../../../ReportService/ReportService.Infrastructure
dotnet ef database update
✅ Veritabanı tabloları otomatik oluşacaktır.

3️⃣ Kafka ve Zookeeper Ortamının Ayağa Kaldırılması
Projede Kafka iletişimi için Docker Compose kullanılmıştır.
Kafka ve Zookeeper'ı çalıştırmak için:

bash
Kopyala
docker-compose -f docker-compose-kafka.yml up -d
Zookeeper ➔ Port: 2181

Kafka ➔ Port: 9092

docker ps komutuyla container'lar ayakta mı kontrol edebilirsiniz.

4️⃣ Projeleri Çalıştırmak
Sırasıyla aşağıdaki projeleri çalıştırın:


Proje	Açıklama
ContactService.Api	Swagger arayüzü ile Person ve Contact yönetimi
ReportService.Api	Swagger arayüzü ile Rapor talep yönetimi
ReportService.Worker	Arkaplanda Kafka'dan mesajları tüketir, raporları hazırlar
5️⃣ API Dökümantasyonu
Swagger üzerinden API'ları test edebilirsiniz:

ContactService ➔ http://localhost:5000/swagger

ReportService ➔ http://localhost:5001/swagger

✅ CRUD işlemleri ✅ Rapor talebi ✅ Rapor sonuçlarını izleme

🛠️ Testleri Çalıştırmak
Test projeleri:

bash
Kopyala
cd tests/ContactService.Test
dotnet test

cd ../ReportService.Test
dotnet test
✅ Service Testleri
✅ Handler Testleri
✅ xUnit, FluentAssertions ve Moq kullanılmıştır.

🔥 Projede Kullanılan Tasarım Kalıpları (Design Patterns)
CQRS (Command Query Responsibility Segregation)

Mediator Pattern (MediatR ile handler iletişimi)

Repository Pattern (Generic, Selectable, Writable vs.)

Unit of Work Pattern

Template Method Pattern (Validation işlemleri)

Clean Architecture Prensipleri

Layered Architecture

Event-Driven Architecture (Kafka Producer/Consumer)

🚨 Önemli Notlar
Kafka Producer ContactService tarafında üretilmektedir.

Kafka Consumer ReportService.Worker tarafında çalışmaktadır.

Worker Service hem Windows Service gibi hem de Console App gibi çalışabilir (.UseWindowsService()).

FluentValidation kullanılarak tüm DTO'lara validasyon yapılmıştır.

Docker ortamı kurulmazsa Kafka ile iletişim sağlanamaz.

PostgreSQL üzerinde ContactDB ve ReportDB veritabanları oluşturulmalıdır.

API Gateway, Authentication gibi eklemeler proje kapsamı dışında bırakılmıştır.

📝 Kurulum Özet Adımları
PostgreSQL kurulmalı ➔ ContactDB ve ReportDB oluşturulmalıdır.

dotnet ef database update ile migration uygulanmalıdır.

docker-compose -f docker-compose-kafka.yml up -d komutu ile Kafka ve zookeeper ayağa kaldırılmalıdır.

ContactService.Api ve ReportService.Api projeleri başlatılmalıdır.

ReportService.Worker'ı başlatılmalıdır.

Swagger ile API testleri yapılmalıdır.

Unit test projelerini çalıştırılmalıdır.

👨‍💻 Geliştirici Bilgisi
Geliştirici: Mikdat Meriç

Bu proje mülakat test projesi kapsamında mikroservis mimarisi, event-driven yapı, clean code ve profesyonel yazılım geliştirme prensipleri kullanılarak hazırlanmıştır.

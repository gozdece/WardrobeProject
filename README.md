# WardrobeProject

Proje toplam 4 ana katmandan oluşmaktadır. 

1. Core Katmanı
2. Repository Katmanı
3. Service Katmanı
4. Presentation Katmanı


## CORE KATMANI
Core katmanına veri katmanı(data layer) da denebilir. 
Bu katmanda database ile ilişkilendirilecek modeller, kullanıcı ile iletişimde olacak data transfer objectler (dto), aynı zamanda diğer iki üst katman olan Repository ve Service katmanında kullanılacak yapıların arayüzleri bulunmaktadır. 
Core katmanında bulunan repository ve service arayüzleri, üst katmanların doğrudan entityler ile bağlantı kurmasının önüne geçecektir.
``Not: Bu katman hiçbir projeyi referans almamaktadır.

## REPOSİTORY KATMANI
Her türlü database işlemleri bu katmanda yapılmaktadır. 
AppDbContext sınıfı ile bir DbContext oluşturulmuş olup, Core katmanındaki modellerin database tablosundaki karşılıkları verilmiştir. 
Configuration sınıfları ile database tablolarının konfigrasyon ayarları yapılmıştır.
Seed sınıflarında ise proje ilk ayağa kalkıp migration ile database tablosu oluşturuldugunda örnek datalar oluşturulmuştur.
UnitOfWork sınıfı ise veritabanı ile yapılacak olan tüm işlemleri, tek bir kanal aracılığı ile gerçekleştirmeye imkan sunmaktadır. 
Repository sınıflarında ise Core katmanında bulunan Repository arayüzlerinin somutları oluşturulmuştur.
``Not: Bu katman yalnızca Core katmanını referans almaktadır.

## SERVİCE KATMANI
Service katmanının temel görevi iş yüklerini bulundurmasıdır. 
Bu katmanda Repository katmanından projeye çekilmiş olan veriler işlenmektedir. Ayrıca kullanıcıdan gelen veriler de öncelikle bu katmanda işlenir ve daha sonra repository katmanına gider. 
Kullanıcıdan gelen dtoları mapleme işlemi bu katmanda yapılır. 
Validasyon sınıfları da burada yer alır. Kıullanıcıdan alınacak dtoların belirli koşullarla alınması istendiğinde bu katmana validasyonlar yazılır. (Fluent Validation)
``Not: Bu katman yalnızca Repository katmanını referans almaktadır. Yalnız Repository katmanını referans olarak almasına rağmen, repository katmanı da core katmanını referans aldığı için core katmanına da dolaylı olarak ulaşabilmektedir. (Onion Architecture)

## PRESENTATION KATMANI
Bu katman kullanıcı ile etkileşimin yapıldığı katmandır. 
Bu projede kullanıcı ile etkileşime giren iki proje yapısı vardır, API ve Blazor.
``Not: Bu katman yalnızca Business katmanını referans almaktadır.

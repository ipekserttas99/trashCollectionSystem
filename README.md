# 🗑 Trash Collection System 🗑

## İsterler 🗃

  Bir şirket akıllı atık toplama sistemleri üzerinde çalışmaktadır.  Bir cöp toplama yada atik toplama aracını en optimum ve verimli şekilde kullanarak en kısa surede tum noktalara uğranması ve n adet  seferde (doldur boşalt işlemi)  tum konteynerleri toplamış olması beklenmektedir.
  Sistemde 2 adet SQL tablosu kullanılmıştır. Container ve Vehicle tablosu. Vehicle tablosu sahada aktif olarak kullanılan araçları tutarken, Container tablosu bu araçlardan  her birinin o gun içinde uğrayıp alması gereken konteynerlerin listesini yani konumlarını tutmaktadır.

1. Sistemdeki tum araçları listeleyen ve yeni bir araç ekleyen  end pointleri ekleyiniz. (VehicleController)
2. Arac bilgisini guncelleyen bir api ekleyiniz.
3. Sistemdeki aracı silecek bir delete apisi ekleyiniz. Bu api araca ait container bilgisini varsa onları da silecek şekilde çalışmalıdır.
4. Container ve Vehicle ilişkisi, container uzerindeki VehicleId uzerinden kurulmustur.
5. Entity Framework  + UnitOfWork    yada  Dapper + UnitOfWork    ikilisinden birisini Repository Pattern ile birlikte kullanabilirsiniz.  (Repository Pattern is must)
6. Sistemdeki tum container listeleyen ve  yeni bir container ekleyen apileri ekleyiniz. (ContainerController)
7. Container bilgisini güncelleyecek bir api ekleyiniz. Güncelleme sırasında container tablosundaki VehicleId nin güncellenmediğinden emin olunuz.
8. Container silecek bir api ekleyiniz.
9. VehicleId ile istek yapıldığında o araca ait tum konteynerlari listeleyen apiyi ekleyiniz.
10. Yeni bir api ekleyip 2 adet parametre aliniz. VehicleId ve N(küme sayısı). Araca ait containerlari eşit eleman olacak şekilde N kümeye ayırıp tum kumeleri tek response olarak hazirlayiniz.
11. Vehicle id ile çağırdığımız api bize tum konteyner bilgisini karmaşık bir sırada vermektedir. Araç bu noktalara en kısa surede ulaşmak için gruplama olmasını talep etmektedir. Kümeleme algoritmalarından birisini kullanarak her araç için tanimli 8 noktayı kendi arasında gruplayarak n adet rota oluşturan bir api yazınız.  N değeri  1<n<4 aralığında dinamik olacaktır.  Algoritmayı test etmek için veri yani container sayisini arttırabilirsiniz. Rotalama işlemi sonucunda n adet liste dönmesi beklenmektedir. Yeni bir controller ekleyerek optimizasyon işlemlerini gerçekleştiriniz.
12. Controller kisminda kullandiginiz modelleri Entity'e ceviriniz. CRUD islemlerini AutoMapper ile data model'e convert ederek gerceklestiriniz. Response tiplerin data model yerine entity olarak degistirip gerekli donusumleri yapiniz.
13. Vehicle controller da GetById methodu yoksa ekleyiniz. Bu methodu middleware seviyesinde blocklayacak bir gelistirme yapiniz. Bu method cagrildiginda 403 http response code ile cevap veriniz.

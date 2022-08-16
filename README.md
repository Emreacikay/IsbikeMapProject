# KariyerTechProject
Hocam Merhabalar, zorunlu stajım dolayısıyla hafta içi 5 gün çalışıyorum bayramdan itibaren. Dolayısı ile sadece haftasonları projeye vakit ayırabildim. yani toplam 4-5 gün anca bakabilmişimdir. Tabii ki bunlar bahane değil.

Öncelikle uygulamayı çalıştırmak için 2 startup ı birleştirmeniz lazım biliyorsunuzdur zaten. Uygulamamı .net core 6 ile geliştirmeye çalıştım token'ı farklı şekilde implement etmeyi denedim. Api çalışınca önce register olmanız gerekiyor ardından login olunca size bir token veriyor. Token ile swagger UI da yukarıdaki autherization tuşu ile auth oluyorsunuz. "bearer + Tokeniniz" şeklinde. 

Sizin token örneğini yaptığınız .net 5 projesi ile devam etme kararı almıştım öncelikle database scaffold ettim ve api controllerlarını ekledim. Ancak onda ise api'yi swagger ile test ettiğimde dataBase'den veri çekemedim. APİ yi tüketemediğim için diğer kısımlara geçemedim. 

Bu projemde Database first kullandım. MVC ile Api bağlantılarını kuracaktım ancak vakit kısıtlıydı. Bilerek migration almadım çünkü alınca genelde başka pc de çalışmıyor ancak connection string ve db context ekledim. Sadece MVC deki controllerlardan Api Controllerlarına istek atmak kaldı. Bir de create delete ekranlarını yetiştiremedim. Genel listeleme ekranını yapmış olmam gerekiyor ancak veri gelmediği için teyit edemedim.

Olurda database migration yaparsanız tablolar oluştuktan sonra isbike.json.txt dosyasındaki sql komutlarını direkt query olarak verince, yaklaşık 250 civarı tablo verisi gelmesi geliyor. 

Yapmak istediğim projeye gelirsek: Şuanda istanbul büyükşehir api'sinden aldığım isbike lokasyon,kapasite, id vs. gibi birçok JSON verilerini database first yöntemi ile önce database'de oluşturup ardından json tipteki verileri db ye sql ile import etmekti. Devamında api ile bu verileri düzenleme yetkisini giriş yapan kullanıcıya servis etmek istiyordum ( Bu kişi bir isbike yöneticisi olabilir örneğin).

Kullanıcı register olur (password ile confirm uyuşursa) -> register controller apideki public emailverifier metodunu, userDto ie çalıştırır-> onay maili gider -> onaylandıktan sonra database e düşer ve user login olabilir -> Login olan token alır ve CRUD işlemleri yapabilir.

Kullanıcı bu verileri bir tablo vasıtasıyla düzenleyebilecek ve ayrıca bütün isbike lokasyonlarını(marker işareti) ve lokasyona tıkladığında(popup mini ekran) detaylı bilgileri harita üzerinde görüntüleyebilecekti. Harita üzerinde görüntülenmesi için api'de lokasyon verileri önce json a ardından da geojson a çevrilerek response edilecek ardından MVC client da MAPLİBRE kütüphanesi ile haritada göstermeyi amaçlıyordum.

Bu bootcampe başlarken henüz yeni c# öğrenen birisi olarak önce solid ardından MVC ve APİ, db contextler tokenlar cookie ler razorlar view datalar middlewarelar derken kısıtlı zamanım olduğu için sizin deyişinizle yemeği kaşık kaşık hızlıca yemiş oldum. Aslında Her şeyin nasıl olması gerektiğini biliyorum ancak implemente etmekte zorlanıyorum. Bu bootcamp bana birçok şey kattı. .net backend olsun front-end olsun sektör hakkında yaptığınız terapi gibi konuşmalar olsun her şey çok iyiydi çok teşekkürler emekleriniz için. ilk .net projemdi çok daha iyi bir proje üretmek isterdim çok çalıştım ama olmadı. Tekrardan teşekkürler emekleriniz için.

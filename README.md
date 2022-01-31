# assessment
<h1 align="center">Hi 👋, I'm Fatih</h1>
<h3 align="center">I am a backend developer from Turkiye</h3>

<p align="left"> <img src="https://komarev.com/ghpvc/?username=fthylmz2229&label=Profile%20views&color=0e75b6&style=flat" alt="fthylmz2229" /> </p>

- 🔭 I’m currently working on [assessment](https://github.com/fthylmz2229/assessment)

- 👨‍💻 All of my projects are available at [https://github.com/fthylmz2229](https://github.com/fthylmz2229)

- 📝 I regularly write articles on [https://www.fatihyilmaz.com.tr](https://www.fatihyilmaz.com.tr)

- 📫 How to reach me **fatih@fatihyilmaz.com.tr**

<p align="left">
</p>

<h3 align="left">Languages and Tools:</h3>
<p align="left"> <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://www.docker.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/docker/docker-original-wordmark.svg" alt="docker" width="40" height="40"/> </a> <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://www.elastic.co" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/elastic/elastic-icon.svg" alt="elasticsearch" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> <a href="https://www.w3.org/html/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/html5/html5-original-wordmark.svg" alt="html5" width="40" height="40"/> </a> <a href="https://developer.mozilla.org/en-US/docs/Web/JavaScript" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/javascript/javascript-original.svg" alt="javascript" width="40" height="40"/> </a> <a href="https://www.elastic.co/kibana" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/elasticco_kibana/elasticco_kibana-icon.svg" alt="kibana" width="40" height="40"/> </a> <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a> <a href="https://www.mysql.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/mysql/mysql-original-wordmark.svg" alt="mysql" width="40" height="40"/> </a> <a href="https://www.oracle.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/oracle/oracle-original.svg" alt="oracle" width="40" height="40"/> </a> <a href="https://www.postgresql.org" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/postgresql/postgresql-original-wordmark.svg" alt="postgresql" width="40" height="40"/> </a> <a href="https://www.python.org" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/python/python-original.svg" alt="python" width="40" height="40"/> </a> <a href="https://reactjs.org/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/react/react-original-wordmark.svg" alt="react" width="40" height="40"/> </a> <a href="https://redis.io" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/redis/redis-original-wordmark.svg" alt="redis" width="40" height="40"/> </a> </p>

-----------------------------------------------

Proje için öncelikle PostgreSQL ve RabbitMQ ya ihtiyacımız var.
Bilgisayarınıza Docker kurulumu yaptıktan sonra docker-compose.yml dosyasını çalıştırdığınızda bu servisler ayağa kalkacaktır.
Varsayılan ayarlarla kurulduğunda uygulama çalışırken herhangi bir sorun olmayacaktır.

Uygulama 2 adet db kullanmaktadır.
Contact ve Report db leri.
Bu db ler code first yaklaşımı ile hazırlanmıştır.
2 db yi de migration ile oluşturabilirsiniz.

Oluşturduktan sonra;
 - Contact db de IletisimBilgiTipi tablosuna 1 - Telefon Numarası, 2 - E-mail Adresi, 3 - Konum bilgilerini ekleyin.
 - Report db de RaporDurum tablosuna 1 - Hazırlanıyor, 2 - Tamamlandı bilgilerini ekleyin.
 
 Solution da 2 adet API uygulaması mevcuttur.
 
 contact.api;
 - Kişi,
 - Kişiye Ait İletişim Bilgileri
 - İletişim Bilgi Tipleri tablolarını içermektedir.

• Rehberde kişi oluşturma
• Rehberde kişi kaldırma
• Rehberdeki kişiye iletişim bilgisi ekleme
• Rehberdeki kişiden iletişim bilgisi kaldırma
• Rehberdeki kişilerin listelenmesi
• Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin
getirilmesi
• Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor
talebi

taleplerine cevap vermektedir.

report.api;
 - Rapor,
 - RaporDurum tablolarını içermektedir.

• Sistemin oluşturduğu raporların listelenmesi
• Sistemin oluşturduğu bir raporun detay bilgilerinin getirilmesi

taleplerine cevap vermektedir.

report.api bünyesinde RabbitMQ ile hazırlanmış Background Service içermektedir.
Bu servis RabbitMQ ye iletilen rapor oluşturma isteklerini dinler ve Exel rapor oluşturur.
Sonrasında ise Rapor tablosundaki kaydı günceller.

Mimari:
![Screenshot](Assessment_Example_Architecture.png)


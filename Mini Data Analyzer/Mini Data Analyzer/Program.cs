using Bogus;
using Bogus.DataSets;
using Mini_Data_Analyzer.Models;

// Bogus kütüpahensiyle sahte veri üretiyoruz, cinisyet belirlendikten sonra o cinsiyete göre isimler oluşturuyoruz.Türkçe veriler kullanıyoruz
var userFaker = new Faker<User>("tr")
    .RuleFor(u => u.Gender, f => f.PickRandom<Name.Gender>())
    .RuleFor(u => u.Name, (f, u) => f.Name.FullName(u.Gender))
    .RuleFor(u => u.City, f => f.Address.City())
    .RuleFor(u => u.Age, f => f.Random.Int(18, 65))
    .Generate(15);

// userFaker ile oluşturulan sahte verileri users adlı bir listeye atıyoruz.
List<User> users = userFaker;
Console.WriteLine("   Veriler: ");
Console.WriteLine();

foreach(var veri in users)
{
    Console.WriteLine($" İsim Soyisim: {veri.Name} - Şehir: {veri.City} - Yaş: {veri.Age} - Cinsiyet: {(veri.Gender == Name.Gender.Male ? "Erkek" : "Kadın")}");
}
Console.WriteLine();
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine();

Console.WriteLine("  Yaşa Göre Gruplama:");
Console.WriteLine();

// Oluşturduğumuz users listesindeki verileri yaşlarına göre gruplama yapıyoruz.
var yasGruplari = users.GroupBy(u => u.Age);
foreach(var yas in yasGruplari)
{
    Console.WriteLine($" Yaş: {yas.Key} - Kullanıcı Sayısı: {yas.Count()}");

}

Console.WriteLine();
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine();

Console.WriteLine("  Şehre Göre Kullanıcı Sayısı:");
Console.WriteLine();

// Oluşturduğumuz users listesindeki verileri şehirlerine göre gruplama yapıyoruz.
var sehirGruplari = users.GroupBy(u=> u.City);
foreach(var sehir in sehirGruplari)
{
    Console.WriteLine($" Şehir: {sehir.Key} - Kullanıcı Sayısı: {sehir.Count()} ");
}

Console.WriteLine();
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine();

Console.WriteLine("  Cinsiyete Göre Ortalama Yaş:");
Console.WriteLine();

//// Oluşturduğumuz users listesindeki verileri cinsiyetlerine göre gruplama yapıyoruz.
var cinsiyetGruplari = users.GroupBy(u => u.Gender);
foreach(var cinsiyet  in cinsiyetGruplari)
{
    // Gruplandırıdığımız cinsiyet grubundaki kullanıcıların yaşlarını alıp ortalamasını hesaplıyoruz.
    double ortalama = cinsiyet.Average(u => u.Age);
    Console.WriteLine($" Cinsiyet: {(cinsiyet.Key == Name.Gender.Male ? "Erkek" : "Kadın")} - Ortalama Yaş: {ortalama:F1}");

}

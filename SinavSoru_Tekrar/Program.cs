

namespace SinavSoru_Tekrar
{
    internal class Program
    {
        static int kosulanSaat, kosulanDakika, adimOlcusu, kosulanMesafe;
        static void Main(string[] args)
        {
            do
            {
                adimOlcusu = AdimOlcusuAl();
                int dakikadaKosulanAdimSayisi = DakikadaKosulanAdimSayisi();
                KosulanSaatveDakikaBilgisiAl();
                KosulanSaatveDakikaSifirHatasi(kosulanSaat, kosulanDakika);
                kosulanMesafe = KosulanMesafeHesapla(kosulanSaat, kosulanDakika, adimOlcusu, dakikadaKosulanAdimSayisi);
                KosulanMesafeyiYazdır(kosulanMesafe);
            }
            while (KullanıcıdanBoolDegerAl("Tekrar hesaplamak istiyor musunuz?"));
        }
        private static bool KullanıcıdanBoolDegerAl(string sorulacakSoru)
        {
            Console.WriteLine(sorulacakSoru);
            string cevap = Console.ReadLine().ToLower();
            switch (cevap)
            {
                case "e":
                case "evet":
                    Console.Clear();
                    return true;
                case "h":
                case "hayır":
                    return false;
                default:
                    Console.WriteLine("Cevabınız anlaşılmadı.");
                    return KullanıcıdanBoolDegerAl(sorulacakSoru);
            }
        }
        private static void KosulanMesafeyiYazdır(int kosulanMesafe)
        {
            Console.WriteLine(new string('*', 100));
            Console.WriteLine($"Koşulan mesafe = {kosulanMesafe}m'dir.");
        }
        private static int KosulanMesafeHesapla(int adimOlcusu, int kosulanDakika, int kosulanSaat, int dakikadaKosulanAdimSayisi)
        {
            int dakikadaGidilenMesafe = adimOlcusu * dakikadaKosulanAdimSayisi;
            int sonuc = dakikadaGidilenMesafe * (kosulanDakika + (kosulanSaat * 60));
            int metreCinsinden = sonuc / 100;
            return metreCinsinden;
        }

        private static void KosulanSaatveDakikaSifirHatasi(int kosulanSaat, int kosulanDakika)
        {
            if (kosulanSaat == 0 && kosulanDakika == 0)
            {
                Console.WriteLine("Girilen saat ve dakika aynı anda sıfır olamaz.");
            }
        }

        private static int DakikadaKosulanAdimSayisi()
        {
            int min = 10, max = 100;
            try
            {
                int kosulanAdimSayisi = IntVeriOku("Bir dakikada kaç adım koşarsınız: ", min, max, out bool sonuc);
                if (!sonuc)
                {
                    return DakikadaKosulanAdimSayisi();
                }
                else
                {
                    return kosulanAdimSayisi;
                }
            }
            catch (Exception)
            {
                YanlisVeriHatasi();
                return DakikadaKosulanAdimSayisi();
            }
        }

        private static void KosulanSaatveDakikaBilgisiAl()
        {
            kosulanSaat = KosulanSaatBilgisiAl();
            kosulanDakika = KosulanDakikaBilgisiAl();
        }

        private static int KosulanDakikaBilgisiAl()
        {
            int min = 0, max = 59;
            try
            {
                int kosulanDakika = IntVeriOku("Kaç dakika koştunuz(0-59 arasında olmalı): ", min, max, out bool sonuc);
                if (!sonuc)
                {
                    return KosulanDakikaBilgisiAl();
                }
                else
                {
                    return kosulanSaat;
                }
            }
            catch (Exception)
            {
                YanlisVeriHatasi();
                return KosulanDakikaBilgisiAl();
            }
        }

        private static int KosulanSaatBilgisiAl()
        {
            int min = 0, max = 12;
            try
            {
                int kosulanSaat = IntVeriOku("Kaç saat koştunuz(0-12 arasında olmalı): ", min, max, out bool sonuc);
                if (!sonuc)
                {
                    return KosulanSaatBilgisiAl();
                }
                else
                {
                    return kosulanSaat;
                }
            }
            catch (Exception)
            {
                YanlisVeriHatasi();
                return KosulanSaatBilgisiAl();
            }
        }

        private static int AdimOlcusuAl()
        {
            int min = 10, max = 100;
            try
            {
                int adimOlcusu = IntVeriOku("Adım ölçünüzü cm olarak giriniz: ", min, max, out bool sonuc);
                if (!sonuc)
                {
                    return AdimOlcusuAl();
                }
                else
                {
                    return adimOlcusu;
                }
            }
            catch (Exception)
            {
                YanlisVeriHatasi();
                return AdimOlcusuAl();
            }
        }

        private static void YanlisVeriHatasi()
        {
            Console.WriteLine("Girilen veri belirli formatta değildir.");
        }

        private static int IntVeriOku(string sorulacakSoru, int min, int max, out bool kontrol)
        {
            try
            {
                kontrol = true;
                Console.WriteLine(sorulacakSoru);
                int sonuc = int.Parse(Console.ReadLine());
                if (sonuc < min || sonuc > max)
                {
                    AralikHataMesaji(min, max);
                    kontrol = false;
                }
                return sonuc;
            }
            catch (Exception ex)
            {
                YanlisVeriHatasi();
                Console.WriteLine(ex.Message);
                return IntVeriOku(sorulacakSoru, min, max, out kontrol);
            }
        }

        private static void AralikHataMesaji(int min, int max)
        {
            Console.WriteLine($"Girdiğiniz veriler minimum {min}, maksimum {max} aralığında olmalıdır.");
        }
    }
}

using System;
using System.Linq;

namespace HesapMakinesi
{
    class Program
    {
        static void Main(string[] args)
        {
            Giris();

            do
            {
                string Talep = TalebiAl();
                double sonuc = HesabiYap(Talep);
                EkranaBastir(sonuc, 0);
            } while (BaskaIslemYapmakIstıyorMu());
            Cikis();

        }

        private static double HesabiYap(string hesaplanacakDeger)
        {
            //string[] bolunmus= hesaplancakDeger.Split('+', '-', '*', '/');
            char[] bolunmus = hesaplanacakDeger.ToCharArray();
            int[] degerler = { };
            char[] islemler = { };
            string rakam = "";
            foreach (char item in bolunmus)
            {

                switch (item)
                {
                    // Rakamlar
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '0':
                        rakam += item.ToString();
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        int deger = Convert.ToInt32(rakam);
                        Array.Resize(ref degerler, degerler.Count() + 1);
                        degerler[degerler.Count() - 1] = deger;
                        rakam = "";
                        Array.Resize(ref islemler, islemler.Length + 1);
                        islemler[islemler.Length - 1] = item;
                        break;
                    default:
                        throw new Exception("Hatalı Giriş" + item.ToString());

                }
            }
            Array.Resize(ref degerler, degerler.Count() + 1);
            degerler[degerler.Count() - 1] = Convert.ToInt32(rakam);
            int toplam = degerler[0];
            for (int i = 1; i < degerler.Length; i++)
            {
                switch (islemler[i - 1])
                {
                    case '+':
                        toplam += degerler[i];
                        break;
                    case '-':
                        toplam -= degerler[i];
                        break;
                    case '*':
                        toplam *= degerler[i];
                        break;
                    case '/':
                        toplam /= degerler[i];
                        break;

                }

                //toplam = degerler[i];
            }
            return toplam;
        }

        private static bool BaskaIslemYapmakIstıyorMu()
        {

            Console.WriteLine("Başka işlem yapmak istiyor musun?");
            string cevap = Console.ReadLine();
            switch (cevap)
            {
                case "e":
                case "E":
                case "Evet":
                case "evet":
                    return true;
                case "h":
                case "H":
                case "Hayır":
                case "hayır":
                    return false;
                default:
                    throw new Exception("Hatalı giriş yaptınız.");
            }

        }

        public static string TalebiAl()
        {
            Console.WriteLine("Toplama işlemi için (+) Çıkarma işlemi için (-) basınız");
            string cevap;
            try
            {
                cevap = Console.ReadLine();
                CevaplariKontrolEt(cevap);
                return cevap;

            }
            catch (Exception hata)
            {

                Console.WriteLine("Hata Mesajı");
                Console.WriteLine(hata.Message);
                return TalebiAl();
            }

        }

        private static void CevaplariKontrolEt(string veri)
        {
            //+ girdimi
            //- girdimi
            //er    /e,r
            //++    /+,+
            //123+54+65+95-96  //1,2,3,+,5,4,+6,5,+,9,5,-,9,6
            // veriyi char dizi olarak dönüştür
            char[] karakterler = veri.ToCharArray();
            foreach (char item in karakterler)
            {
                switch (item)
                {
                    // Rakamlar
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '0':
                        break;
                    // İşlemler
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        break;
                    // Noktalama işaretleri

                    // Hatalı Girişler
                    default:
                        throw new Exception("Uygun olmayan bir karakter girdiniz.");
                }

            }
        }

        public static void EkranaBastir(double ekranaBastirilacakSonuc, int IslemSayisi)
        {
            Console.WriteLine("Sonuç: " + ekranaBastirilacakSonuc.ToString());
            return;
        }

        private static void Cikis()
        {
            Console.Read();
            Environment.Exit(0);
        }

        private static void Giris()
        {
            Console.WriteLine("Hesap Makinesine Hoş Geldiniz");
        }


    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace allatok
{
    class Allat
    {
        private string nev;
        private int szuletesiEv;
        private int szepsegPont, viselkedesPont;
        private int osszPont;
        private static int aktualisEv;
        private static int korHatar;


        public Allat(string nev, int szuletesiEv)
        {
            this.nev = nev;
            this.szuletesiEv = szuletesiEv;
        }
        public int Kor()
        {
            return aktualisEv - szuletesiEv;
        }
        public void Pontozzak(int szepsegPont, int viselkedesPont)
        {
            this.szepsegPont = szepsegPont;
            this.viselkedesPont = viselkedesPont;
            if (Kor() <= korHatar)
            {
                osszPont = viselkedesPont * Kor() + szepsegPont * (korHatar - Kor());
            }
            else
            {
                osszPont = 0;
            }
        }
        public override string ToString()
        {
            return nev + " Pontszáma: " + osszPont + " pont";
        }
        public string Nev
        {
            get { return nev; }
        }
        public int SzuletesiEv
        {
            get { return szuletesiEv; }
        }
        public int SzepsegPont
        {
            get { return szepsegPont; }
        }
        public int ViselkedesPont
        {
            get { return viselkedesPont; }
        }
        public int OsszPont
        {
            get { return osszPont; }
        }
        public static int AktualisEv
        {
            get { return aktualisEv; }
            set { aktualisEv = value; }
        }
        public static int KorHatar
        {
            get { return korHatar; }
            set { korHatar = value; }
        }
    }
    private static void AllatVerseny()
    {
        Allat allat;

        string nev;
        int szulEv;
        int igazolas;
        int szepseg, viselkedes;
        int veletlenPontHatar = 10;
        int rajtszam = 0;

        Random rand = new Random();

        int osszesVersenyzo = 0;
        int osszesPont = 0;
        int legtobbPont = 0;
        Console.WriteLine("Kezdődik a verseny");
        char tovabb = 'i';
        while (tovabb == 'i')
        {
            Console.Write("Az állat neve: ");
            nev = Console.ReadLine();
            Console.Write("születési éve: ");
            while (!int.TryParse(Console.ReadLine(), out szulEv)
            || szulEv <= 0
            || szulEv > Allat.AktualisEv)
            {
                Console.Write("Hibás adat írja újra!");
            }
            Console.Write("Oltási igazolás száma: ");
            igazolas = int.Parse(Console.ReadLine());


            rajtszam++;

            szepseg = rand.Next(veletlenPontHatar + 1);
            viselkedes = rand.Next(veletlenPontHatar + 1);


            allat = new Allat(nev, szulEv);

            allat.Pontozzak(szepseg, viselkedes);
            Console.WriteLine(allat);

            osszesVersenyzo++;
            osszesPont += allat.OsszPont;
            if (legtobbPont < allat.OsszPont)
            {
                legtobbPont = allat.OsszPont;
            }
            Console.Write("Van még állat? (i/n) ");

            tovabb = char.Parse(Console.ReadLine());
        }
        Console.WriteLine("\nÖsszesen " + osszesVersenyzo + " versenyző volt," +
            " \nösszpontszámuk: " + osszesPont + " pont," + "\nlegnagyobb pontszám: " + legtobbPont + "\nÁtlag pontszám: " + osszesPont / osszesVersenyzo);

    }

internal class Program
 {


    static void Main(string[] args)
    {
        int aktualisEv = 2024;
        int korhatar = 10;

        Allat.AktualisEv = aktualisEv;
        Allat.KorHatar = korhatar;

        Allat.AllatVerseny();

        Console.ReadKey();
    }
}



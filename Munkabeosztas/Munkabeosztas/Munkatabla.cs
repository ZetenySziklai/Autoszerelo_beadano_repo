using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Munkabeosztas
{

    internal class Munkatabla
    {
        static List<Munkabeosztas> lista = new List<Munkabeosztas>();

        static void Main(string[] args)
        {
            fajlbe();
        }
        //c1
        private static void fajlbe()
        {
            StreamReader f = new StreamReader("adatok.txt");
            f.ReadLine();
            while (!f.EndOfStream)
            {
                Munkabeosztas s = new Munkabeosztas(f.ReadLine());
                lista.Add(s);
            }
            f.Close();
        }
        //c2
        private static List<Munkabeosztas> munkalekeres()
        {
            List<Munkabeosztas> munkasok = new List<Munkabeosztas>();
            string munka = Console.ReadLine();

            for (int i = 0; i < lista.Count; i++)
            {
                if(lista[i].munkakor == munka)
                {
                    munkasok.Add(lista[i]);
                }
            }
            return munkasok;
        }
        //c3
        private static List<string> munkakor()
        {
            List<int> orak = new List<int>();
            List<string> szerelokorak = new List<string>();
            List<Munkabeosztas> munkalek = munkalekeres();

          
            for (int i = 0; i < munkalek.Count; i++)
            {
                for (int j = 0; j < munkalek[i].munka_ido.Count; j++)

                {
                    if (lista[i].munka_ido[j] == true)
                    {
                        orak.Add(i + 1);
                    }
                }
                szerelokorak.Add(munkalek[i].szerelo_nev + " " + orak);
            }

            return szerelokorak;
        }
        
       
        //c4
        private static List<Munkabeosztas> lekeres()
        {
            var rendezes = lista.OrderBy(x => x.szerelo_nev).ToList();
            return rendezes;
        }

        //c5
        private static void foglalas()
        {
            int ora_kezdete = Convert.ToInt32(Console.ReadLine());
            int ora_vege = Convert.ToInt32(Console.ReadLine());
            bool igazh = true;
            List<Munkabeosztas> munkasok = new List<Munkabeosztas>();
            munkasok = munkalekeres();
            for (int i = 0; i < munkasok.Count; i++)
            {
                for (int j = 0; j < lista[i].munka_ido.Count; j++)
                {
                    igazh = eldontes(ora_kezdete, ora_vege, i, j);

                }
            }

            if (igazh == true)
            {
                Console.WriteLine("van szabadhely");
            }
            else
            {
                Console.WriteLine("nincs szabadhely");
            }

        }
        private static bool eldontes(int ora_kezdete, int ora_vege,int i,int j)
        {
            for (int k = ora_kezdete; k <= ora_vege; k++)
            {
                if (lista[i].munka_ido[j] == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            return true;
        }
        //c6
        private static List<string> osszesora()
        {
            string szerelonev = Console.ReadLine();
            List<string> adat = new List<string>();
            List<int> orak = new List<int>();
            for(int i = 0;i < lista.Count; i++)
            {
                if(szerelonev == lista[i].szerelo_nev)
                {
                    for (int j = 0; j < lista[i].munka_ido.Count; j++)
                    {
                        if (lista[i].munka_ido[j] == true)
                        {
                            orak.Add(i);
                        }
                    }
                    
                    adat.Add(szerelonev+" " + orak);
                }

                else if(szerelonev == "")
                {
                    for (int j = 0; j < lista[i].munka_ido.Count; j++)
                    {
                        if (lista[i].munka_ido[j] == true)
                        {
                            orak.Add(i);
                        }
                       
                    }
                    adat.Add(szerelonev + " " + orak);
                }
            }
            return adat;
        }
    }
}

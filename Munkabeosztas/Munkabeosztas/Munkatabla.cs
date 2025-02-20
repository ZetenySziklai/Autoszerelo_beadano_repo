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

        private static List<int> munkakor()
        {
            List<int> orak = new List<int>();
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0;  j < lista[i].munka_ido.Count; j++)
                {
                    if (lista[i].munka_ido[j] == true)
                    {
                        orak.Add(i+1);
                    }
                }
            }
            return orak;

        }

        private static List<Munkabeosztas> lekeres()
        {
            var rendezes = lista.OrderBy(x => x.szerelo_nev).ToList();
            return rendezes;
        }

        private static List<Munkabeosztas> foglalas()
        {
            int ora_kezdete = Convert.ToInt32(Console.ReadLine());
            int ora_vege = Convert.ToInt32(Console.ReadLine());
            List<Munkabeosztas> munkasok = new List<Munkabeosztas>();
            munkasok = munkalekeres();

        }
    }
}

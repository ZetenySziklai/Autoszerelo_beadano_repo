using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munkabeosztas
{
    internal class Munkabeosztas
    {
        public string munkakor {get; set;}
        public string szerelo_nev;
        public List<bool> munka_ido;
        public string munka_nap;

        

        public Munkabeosztas(string sor)
        {
            string[] adatok = sor.Split(';');
            munkakor = adatok[2];
            szerelo_nev = adatok[0];
            munka_nap = adatok[1];
            munka_ido = new List<bool>();

            string[] tomb = adatok[3].Split(',');
            for (int i = 0; i < tomb.Length; i++)
            {
                if (Convert.ToInt32(tomb[i]) == 1){ munka_ido.Add(false);}
                else { munka_ido.Add(true);}
            }
        }
    }
}

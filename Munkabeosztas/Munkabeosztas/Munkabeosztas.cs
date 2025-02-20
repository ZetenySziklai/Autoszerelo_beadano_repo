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
        public List<bool> munka_ido { get; set; } 
        public string munka_nap;

        

        public Munkabeosztas(string sor)
        {
            string[] adatok = sor.Split(',');
            munkakor = adatok[2];
            szerelo_nev = adatok[1];
            munka_nap = adatok[0];
            for (int i = 4; i < adatok.Length; i++)
            {
                if (Convert.ToInt32(adatok[i]) == 1){ munka_ido.Add(false);}
                else { munka_ido.Add(true);}
            }
        }
    }
}

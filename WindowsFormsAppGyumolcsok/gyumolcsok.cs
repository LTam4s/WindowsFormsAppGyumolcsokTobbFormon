using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppGyumolcsok
{
    internal class gyumolcsok
    {
        int id;
        string nev;
        int egysegar;
        int mennyiseg;

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public int Egysegar { get => egysegar; set => egysegar = value; }
        public int Mennyiseg { get => mennyiseg; set => mennyiseg = value; }

        public gyumolcsok(int id, string nev, int egysegar, int mennyiseg)
        {
            Id = id;
            Nev = nev;
            Egysegar = egysegar;
            Mennyiseg = mennyiseg;
        }
        public override string ToString()
        {
            return nev + " | " + Egysegar + "Ft | " + Mennyiseg + "db";
        }
    }
}

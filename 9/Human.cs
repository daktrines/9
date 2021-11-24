using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _9
{
    struct Human
    {
        public int N; //поля
        public string FIO;
        public string Pol;
        public int Year;
        public string Country;
        public string Nacion;

        public Human(int n, string fio, string pol, int year, string country, string nacion)
        {
            N = n;
            FIO = fio;
            Pol = pol;
            Year = year;
            Country = country;
            Nacion = nacion;
        }

    }
}

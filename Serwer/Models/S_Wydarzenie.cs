using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_Wydarzenie
    {
        public int id { get; set; }
        public float wysokosc { get; set; }
        public float szerokosc { get; set; }
        public string login_organizatora { get; set; }
        public DateTime data_poczatku { get; set; }
        public DateTime data_konca { get; set; }
        public  char dostepnosc{ get; set; }

        public S_Wydarzenie(Wydarzenie w)
        {
            this.id = w.id;
            this.wysokosc = w.wysokosc;
            this.szerokosc = w.szerokosc;
            this.login_organizatora = w.login_organizatora;
            this.data_poczatku = w.data_poczatku;
            this.data_konca = w.data_konca;
            this.dostepnosc = w.dostepnosc;
        }

        internal static Wydarzenie ToWydarzenie(S_Wydarzenie value)
        {
            return new Wydarzenie
            {
                id = value.id,
                wysokosc = value.wysokosc,
                szerokosc = value.szerokosc,
                login_organizatora = value.login_organizatora,
                data_poczatku = value.data_poczatku,
                data_konca = value.data_konca,
                dostepnosc = value.dostepnosc

            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_Wydarzenie
    {
        public int id { get; set; }
        public float? wysokosc { get; set; }
        public float? szerokosc { get; set; }
        public string login_organizatora { get; set; }
        public string data_poczatku { get; set; }
        public string data_konca { get; set; }
        public  string nazwa_wydarzenia { get; set; }

        public S_Wydarzenie(Wydarzenie w)
        {
            this.id = w.id;
            this.wysokosc = w.wysokosc;
            this.szerokosc = w.szerokosc;
            this.login_organizatora = w.login_organizatora;


            this.data_poczatku = w.data_poczatku.ToString("dd/MM/yyyy");
            if(w.data_konca != null)
                this.data_konca = ((DateTime)w.data_konca).ToString("dd/MM/yyyy");
            this.nazwa_wydarzenia = w.nazwa_wydarzenia;
        }

        internal static Wydarzenie ToWydarzenie(S_Wydarzenie value)
        {
            return new Wydarzenie
            {
                id = value.id,
                wysokosc = value.wysokosc,
                szerokosc = value.szerokosc,
                login_organizatora = value.login_organizatora,
                data_poczatku = DateTime.Parse(value.data_poczatku),
                data_konca = DateTime.Parse(value.data_konca),
                nazwa_wydarzenia = value.nazwa_wydarzenia

            };
        }
    }
}
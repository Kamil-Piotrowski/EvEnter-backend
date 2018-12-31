using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_Uzytkownik
    {
        public string login { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int punkty { get; set; }
        public string data_urodzenia { get; set; }
        public string nr_telefonu { get; set; }
        public bool? zweryfikowane { get; set; }
        public string skrot_hasla { get; set; }
        public int? id { get; set; }

        public S_Uzytkownik(Uzytkownik u)
        {
            this.login = u.login;
            this.imie = u.imie;
            this.nazwisko = u.nazwisko;
            this.punkty = u.punkty;
            if(u.data_urodzenia != null)
            {
                DateTime d = (DateTime)u.data_urodzenia;
                this.data_urodzenia = d.ToString("MM.dd.yyyy");
            }
            
            this.nr_telefonu = u.nr_telefonu;
            this.zweryfikowane = u.zweryfikowane;
            this.skrot_hasla = u.skrot_hasla;
            this.id = u.id;

        }

        internal static Uzytkownik ToUzytkownik(S_Uzytkownik value)
        {
            return new Uzytkownik
            {
                login = value.login,
                imie = value.imie,
                nazwisko = value.nazwisko,
                punkty = value.punkty,
                data_urodzenia = DateTime.Parse(value.data_urodzenia),
                nr_telefonu = value.nr_telefonu,
                zweryfikowane = value.zweryfikowane,
                skrot_hasla = value.skrot_hasla,
                id = value.id

            };
        }
    }
}
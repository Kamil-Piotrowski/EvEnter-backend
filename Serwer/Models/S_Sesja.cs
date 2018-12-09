using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_Sesja
    {
        public int id_sesji { get; set; }
        public string login_uzytkownika { get; set; }
        public DateTime data_ostatniego_dostepu { get; set; }
        public int wygasa_po_min { get; set; }

        public S_Sesja(Sesja s)
        {
            this.id_sesji = s.id_sesji;
            this.login_uzytkownika = s.login_uzytkownika;
            this.data_ostatniego_dostepu = s.data_ostatniego_dostepu;
            this.wygasa_po_min = s.wygasa_po_min;
        }
        internal static Sesja To_Sesja(S_Sesja value)
        {
            return new Sesja
            {
                id_sesji = value.id_sesji,
                login_uzytkownika = value.login_uzytkownika,
                data_ostatniego_dostepu = value.data_ostatniego_dostepu,
                wygasa_po_min = value.wygasa_po_min
            };
        }
    }
}
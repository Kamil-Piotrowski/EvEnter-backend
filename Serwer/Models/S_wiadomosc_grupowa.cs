using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_wiadomosc_grupowa
    {
        public int id { get; set; }
        public int id_grupy { get; set; }
        public string login_nadawcy { get; set; }
        public DateTime data_wyslania { get; set; }
        public string tresc { get; set; }

        public S_wiadomosc_grupowa(wiadomosc_grupowa w)
        {
            this.id = w.id;
            this.id_grupy = w.id_grupy;
            this.login_nadawcy = w.login_nadawcy;
            this.data_wyslania = w.data_wyslania;
            this.tresc = w.tresc;

        }
        internal static wiadomosc_grupowa To_wiadomosc_grupowa(S_wiadomosc_grupowa value)
        {
            return new wiadomosc_grupowa
            {
                id = value.id,
                id_grupy = value.id_grupy,
                login_nadawcy = value.login_nadawcy,
                data_wyslania = value.data_wyslania,
                tresc = value.tresc
            };
        }
    }
}
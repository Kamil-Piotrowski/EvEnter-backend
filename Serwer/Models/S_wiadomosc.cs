using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_wiadomosc
    {
        public int id { get; set; }
        public string tresc { get; set; }
        public string login_nadawcy { get; set; }
        public string login_odbiorcy { get; set; }
        public DateTime data_wyslania { get; set; }
        public DateTime? data_odebrania { get; set; }

        public S_wiadomosc(wiadomosc w)
        {
            this.id = w.id;
            this.tresc = w.tresc;
            this.login_nadawcy = w.login_nadawcy;
            this.login_odbiorcy = w.login_odbiorcy;
            this.data_wyslania = w.data_wyslania;
            this.data_odebrania = w.data_odebrania;

        }
        internal static wiadomosc To_wiadomosc(S_wiadomosc value)
        {
            return new wiadomosc
            {
                id = value.id,
                tresc = value.tresc,
                login_nadawcy = value.login_nadawcy,
                login_odbiorcy = value.login_odbiorcy,
                data_wyslania = value.data_wyslania,
                data_odebrania = value.data_odebrania
            };
        }
    }
}
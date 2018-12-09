using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_znajomosc
    {
        public string login_zapraszajacego { get; set; }
        public string login_zaproszonego { get; set; }
        public DateTime? data_poczatku { get; set; }

        public S_znajomosc(znajomosc z)
        {
            this.login_zapraszajacego = z.login_zapraszajacego;
            this.login_zaproszonego = z.login_zaproszonego;
            this.data_poczatku = z.data_poczatku;

        }
        internal static znajomosc To_znajomosc(S_znajomosc value)
        {
            return new znajomosc
            {
                login_zapraszajacego = value.login_zapraszajacego,
                login_zaproszonego = value.login_zaproszonego,
                data_poczatku = value.data_poczatku
            };
        }
    }
}
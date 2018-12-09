using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_skarga
    {
        public int id { get; set; }
        public string login_powoda { get; set; }
        public string login_oskarzonego { get; set; }
        public DateTime data_dodania { get; set; }
        public DateTime? data_rozpatrzenia { get; set; }
        public string tresc_skargi { get; set; }
        public string tresc_odpowiedzi { get; set; }

        public S_skarga(skarga s)
        {
            this.id = s.id;
            this.login_powoda = s.login_powoda;
            this.login_oskarzonego = s.login_oskarzonego;
            this.data_dodania = s.data_dodania;
            this.data_rozpatrzenia = s.data_rozpatrzenia;
            this.tresc_skargi = s.tresc_skargi;
            this.tresc_odpowiedzi = s.tresc_odpowiedzi;

        }
        internal static skarga To_skarga(S_skarga value)
        {
            return new skarga
            {
                id = value.id,
                login_powoda = value.login_powoda,
                login_oskarzonego = value.login_oskarzonego,
                data_dodania = value.data_dodania,
                data_rozpatrzenia = value.data_rozpatrzenia,
                tresc_skargi = value.tresc_skargi,
                tresc_odpowiedzi = value.tresc_odpowiedzi
            };
        }
    }
}
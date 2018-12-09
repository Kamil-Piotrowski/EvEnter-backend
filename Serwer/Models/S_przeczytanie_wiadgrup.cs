using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_przeczytanie_wiadgrup
    {
        public int id_wiadomosci_grup { get; set; }
        public string login_odbiorcy { get; set; }
        public DateTime? data_przeczytania { get; set; }

        public S_przeczytanie_wiadgrup(przeczytanie_wiadgrup p)
        {
            this.id_wiadomosci_grup = p.id_wiadomosci_grup;
            this.login_odbiorcy = p.login_odbiorcy;
            this.data_przeczytania = p.data_przeczytania;

        }
        internal static przeczytanie_wiadgrup To_przeczytanie_wiadgrup(S_przeczytanie_wiadgrup value)
        {
            return new przeczytanie_wiadgrup
            {
                id_wiadomosci_grup = value.id_wiadomosci_grup,
                login_odbiorcy = value.login_odbiorcy,
                data_przeczytania = value.data_przeczytania
            };
        }
    }
}
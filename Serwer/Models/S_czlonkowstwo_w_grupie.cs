using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_czlonkowstwo_w_grupie
    {
        public int id_grupy { get; set; }
        public string login_czlonka { get; set; }
        public DateTime data_dolaczenia { get; set; }

        public S_czlonkowstwo_w_grupie(czlonkowstwo_w_grupie c)
        {
            this.id_grupy = c.id_grupy;
            this.login_czlonka = c.login_czlonka;
            this.data_dolaczenia = c.data_dolaczenia;
        }
        internal static czlonkowstwo_w_grupie To_czlonkostwo_w_grupie(S_czlonkowstwo_w_grupie value)
        {
            return new czlonkowstwo_w_grupie
            {
                id_grupy = value.id_grupy,
                login_czlonka = value.login_czlonka,
                data_dolaczenia = value.data_dolaczenia
            };
        }
    }
}
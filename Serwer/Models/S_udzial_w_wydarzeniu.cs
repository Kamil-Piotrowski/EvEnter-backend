using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class S_udzial_w_wydarzeniu
    {
        public string login_uczestnika { get; set; }
        public int id_wydarzenia { get; set; }
        public DateTime data_dolaczenia { get; set; }

        public S_udzial_w_wydarzeniu(udzial_w_wydarzeniu u)
        {
            this.login_uczestnika = u.login_uczestnika;
            this.id_wydarzenia = u.id_wydarzenia;
            this.data_dolaczenia = u.data_dolaczenia;
        }
        internal static udzial_w_wydarzeniu To_udzial_w_wydarzeniu(S_udzial_w_wydarzeniu value)
        {
            return new udzial_w_wydarzeniu
            {
                login_uczestnika = value.login_uczestnika,
                id_wydarzenia = value.id_wydarzenia,
                data_dolaczenia = value.data_dolaczenia
            };
        }
    }
}
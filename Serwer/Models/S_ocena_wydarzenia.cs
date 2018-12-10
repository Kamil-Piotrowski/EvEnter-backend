using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{

    /// <summary>
    /// Klasa odpowiadająca ocenie wystawianej przez użytkownika, odnośnie całego wydarzenia. Charakteryzuje się konkretną wartością, komentarzem
    /// oraz datą wystawienia oceny.
    /// </summary>
    public class S_ocena_wydarzenia
    {
        public int id { get; set; }
        public int id_wydarzenia { get; set; }
        public string login_oceniajacego { get; set; }
        public short ocena { get; set; }
        public string komentarz { get; set; }
        public DateTime data_dodania { get; set; }

        public S_ocena_wydarzenia(ocena_wydarzenia o)
        {
            this.id = o.id;
            this.id_wydarzenia = o.id_wydarzenia;
            this.login_oceniajacego = o.login_oceniajacego;
            this.ocena = o.ocena;
            this.komentarz = o.komentarz;
            this.data_dodania = o.data_dodania;

        }
        internal static ocena_wydarzenia To_ocena_wspoluczestnika(S_ocena_wydarzenia value)
        {
            return new ocena_wydarzenia
            {
                id = value.id,
                id_wydarzenia = value.id_wydarzenia,
                login_oceniajacego = value.login_oceniajacego,
                ocena = value.ocena,
                komentarz = value.komentarz,
                data_dodania = value.data_dodania
            };
        }
    }
}
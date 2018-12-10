using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    /// <summary>Klasa reprezentująca grupę. Do grupy mogą należeć użytkownicy.</summary>
    public class S_Grupa
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public string opis { get; set; }
        public bool tylko_admin_dodaje { get; set; }
        public string login_admina { get; set; }

        public S_Grupa(Grupa z)
        {
            this.id = z.id;
            this.nazwa = z.nazwa;
            this.opis = z.opis;
            this.tylko_admin_dodaje = z.tylko_admin_dodaje;
            this.login_admina = z.logina_admina;

        }
        internal static Grupa To_Grupa(S_Grupa value)
        {
            return new Grupa
            {
                id = value.id,
                nazwa = value.nazwa,
                opis = value.opis,
                tylko_admin_dodaje = value.tylko_admin_dodaje,
                logina_admina = value.login_admina
            };
        }
    }
}
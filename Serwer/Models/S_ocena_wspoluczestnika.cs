using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{

    /// <summary>
    ///   <para>Klasa odpowiadająca ocenie jednego użytkownika wystawianej przez drugiego użytkownika.</para>
    ///   <para>Charakteryzuje się konkretną wartością, datą dodania oceny, oraz konkretnym wydarzeniem, z okazji ktrego zostaa wystawiona.</para>
    /// </summary>
    public class S_ocena_wspoluczestnika
    {
        public int id { get; set; }
        public string login_oceniajacego { get; set; }
        public string login_ocenianego { get; set; }
        public DateTime data_dodania { get; set; }
        public short ocena { get; set; }
        public int id_wydarzenia { get; set; }

        public S_ocena_wspoluczestnika(ocena_wspoluczestnika o)
        {
            this.id = o.id;
            this.login_oceniajacego = o.login_oceniajacego;
            this.login_ocenianego = o.login_ocenianego;
            this.data_dodania = o.data_dodania;
            this.ocena = o.ocena;
            this.id_wydarzenia = o.id_wydarzenia;

        }
        internal static ocena_wspoluczestnika To_ocena_wspoluczestnika(S_ocena_wspoluczestnika value)
        {
            return new ocena_wspoluczestnika
            {
                id = value.id,
                login_oceniajacego = value.login_oceniajacego,
                login_ocenianego = value.login_ocenianego,
                data_dodania = value.data_dodania,
                ocena = value.ocena,
                id_wydarzenia = value.id_wydarzenia
            };
        }
    }
}
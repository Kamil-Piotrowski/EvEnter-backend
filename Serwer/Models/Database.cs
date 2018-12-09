using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.Models
{
    public class Database
    {
        private static DBDataContext instance;
        static public DBDataContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBDataContext();
                }
                return instance;
            }
        }
    }
}
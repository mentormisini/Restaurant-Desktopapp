using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stresta
{
    class connection
    {
        public static string dbconnect()
        {
            //return ("Server = sql130.main-hosting.eu; Database = u761703911_restaurant; uid = u761703911_restaurant; pwd = Restaurant@123.");
            return ("Server = localhost; Database = kvpt_osterdbm; uid = root; pwd = Kosova@123.");
        }
    }
}

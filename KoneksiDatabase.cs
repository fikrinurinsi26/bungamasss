using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace SIMRS
{
    public class KoneksiDatabase
    {
        private string koneksi =
            "Server=localhost;" +
            "Database=db_rumah_sakit;" +
            "Uid=root;" +
            "Pwd=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(koneksi);
        }
    }
}

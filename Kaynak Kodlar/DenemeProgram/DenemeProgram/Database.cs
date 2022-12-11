using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DenemeProgram
{
    class Database //Data Source=DESKTOP-VROS4GM\SQLEXPRESS;Initial Catalog=Randevu;Integrated Security=True
    {
        public SqlConnection baglanti = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=Randevu;Trusted_Connection=True;");
    }
}

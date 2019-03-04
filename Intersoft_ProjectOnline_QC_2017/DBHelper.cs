using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Intersoft_ProjectOnline_QC_2017
{
    public static class DBHelper
    {
        public static T GetValue<T>(this SqlDataReader sqlDataReader, string columnName)
        {
            var value = sqlDataReader[columnName];

            return value == DBNull.Value ? default(T) : (T)value;
        }
    }//class DbHelper
}//Namespace Intersoft_ProjectOnline_QC_2017

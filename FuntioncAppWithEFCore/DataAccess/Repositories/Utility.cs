using Empower.DataAccess.Entities.Eviti;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.DataAccess.Repositories
{
    public class Utility
    {

        public static string IsDBNull(SqlDataReader dataReader, string columnName)
        {
            if (dataReader[columnName] == DBNull.Value || dataReader[columnName].ToString() == "{}")
            {
                if (columnName.ToUpper().Contains("GUID") || dataReader[columnName].ToString() == "{}")
                {
                    return Guid.Empty.ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            else
            {

                return dataReader[columnName].ToString();
            }

        }

        public static DateTime IsDBNull(SqlDataReader dataReader, string columnName, string isdate)
        {
            if (dataReader[columnName] == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                return Convert.ToDateTime(dataReader[columnName]);
            }
        }

        public void Remove(evitiEligiblePatients entity)
        {
            throw new NotImplementedException();
        }
    }
}

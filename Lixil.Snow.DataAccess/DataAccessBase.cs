using Lixil.Snow.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lixil.Snow.DataAccess
{
    public class DataAccessBase
    {
        //protected int Update(string sql, IEnumerable<OracleParameter> parameters)
        //{
        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

        //    OracleCommand command = new OracleCommand(sql);
        //    command.Connection = connection;

        //    // パラメータ
        //    if (!parameters == null)
        //    {
        //        foreach (OracleParameter parameter in parameters)
        //            command.Parameters.Add(new OracleParameter(parameter.ParameterName, parameter.Value));
        //    }

        //    int result = 0;
        //    try
        //    {
        //        if (connection.State == ConnectionState.Closed)
        //            connection.Open();
        //        result = command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        connection.Close();
        //        return 0;
        //    }
        //    return result;
        //}

    }
}

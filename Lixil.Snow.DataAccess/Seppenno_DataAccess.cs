using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class Seppenno_DataAccess : SqlManager
	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public List<Object> GetDataByFile(string filePath)
		{
			using var db = SqlManager.GetConnection;
			var str = new StreamReader(filePath);
			string strSQL = str.ReadToEnd();
			var result = db.Query<Object>($"{strSQL}").ToList();
			str.Close();
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public int SetDataByFile(string filePath)
		{
			using var db = SqlManager.GetConnection;
			var str = new StreamReader(filePath);
			string strSQL = str.ReadToEnd();
			var result = db.Execute($"{strSQL}");
			str.Close();
			return result;
		}

	}
}

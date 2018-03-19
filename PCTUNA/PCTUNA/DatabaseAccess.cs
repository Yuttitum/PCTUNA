using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTUNA
{
    public class DatabaseAccess
    {
        public DataTable SelectData(DatabaseAccessObject databaseAccessObject, string cmdText, params System.Data.SqlClient.SqlParameter[] parameterArray)
        {
            string parameterText = "";
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(cmdText, databaseAccessObject.Connection))
            {
                cmd.Transaction = databaseAccessObject.Transaction;
                if (parameterArray.Length != 0)
                {
                    int parameterCount = 0;
                    foreach (System.Data.SqlClient.SqlParameter parameter in parameterArray)
                    {
                        cmd.Parameters.Add(parameter);
                        if (parameterCount != 0)
                        {
                            parameterText += ",";
                        }
                        parameterText += parameter.ParameterName + "(" + parameter.SqlDbType + ") = " + parameter.Value;
                        parameterCount += 1;
                    }
                }
                using (System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter())
                {
                    DataTable data = new DataTable();
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(data);
                    return data;
                }
            }
        }
        public int SelectExist(DatabaseAccessObject databaseAccessObject, string cmdText, params System.Data.SqlClient.SqlParameter[] parameterArray)
        {
            string parameterText = "";
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(cmdText, databaseAccessObject.Connection))
            {
                cmd.Transaction = databaseAccessObject.Transaction;
                if (parameterArray.Length != 0)
                {
                    int parameterCount = 0;
                    foreach (System.Data.SqlClient.SqlParameter parameter in parameterArray)
                    {
                        cmd.Parameters.Add(parameter);
                        if (parameterCount != 0)
                        {
                            parameterText += ",";
                        }
                        parameterText += parameter.ParameterName + "(" + parameter.SqlDbType + ") = " + parameter.Value;
                        parameterCount += 1;
                    }
                }
                using (System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter())
                {
                    DataTable data = new DataTable();
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(data);
                    return data.Rows.Count;
                }
            }
        }

        public int OperateData(DatabaseAccessObject databaseAccessObject, string cmdText, params System.Data.SqlClient.SqlParameter[] parameterArray)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(cmdText, databaseAccessObject.Connection))
            {
                string parameterText = "";
                cmd.Transaction = databaseAccessObject.Transaction;
                if (parameterArray.Length != 0)
                {
                    int parameterCount = 0;
                    foreach (System.Data.SqlClient.SqlParameter parameter in parameterArray)
                    {
                        cmd.Parameters.Add(parameter);
                        if (parameterCount != 0)
                        {
                            parameterText += ",";
                        }
                        parameterText += parameter.ParameterName + "(" + parameter.SqlDbType + ") = " + parameter.Value;
                        parameterCount += 1;
                    }
                }
                int affectedRow = cmd.ExecuteNonQuery();
                return affectedRow;
            }
        }
    }
}

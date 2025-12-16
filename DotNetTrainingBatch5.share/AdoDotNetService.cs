using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch5.shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;
        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DataTable Query(string query,params SqlParameterModel[] sqlParameterModels)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if(sqlParameterModels != null)
            {
                foreach (SqlParameterModel param in sqlParameterModels)
                {
                    cmd.Parameters.AddWithValue(param.Name, param.Value);
                }
               
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable(); 
            adapter.Fill(dt);
            return dt;
        }
        public int Execute(string query, params SqlParameterModel[] sqlParameterModels)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (sqlParameterModels != null)
            {
                foreach (SqlParameterModel param in sqlParameterModels)
                {
                    cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

            }
           var result = cmd.ExecuteNonQuery();
            return result;
        }
    }

    public class SqlParameterModel
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public SqlParameterModel()
        {
        }
        public SqlParameterModel(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}

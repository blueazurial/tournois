using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace DB
{
    public class Connection
    {
        private string ConnectionString { get; set; }
        private DbProviderFactory Factory { get; set; }

        public Connection(string connectionString, string InvariantName)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Il manque des informations à notre connection...");
            ConnectionString = connectionString;
            Factory = DbProviderFactories.GetFactory(InvariantName);
        }

        public object ExecuteScalar(Command query)
        {
            object result;
            using (DbConnection Server = this.setConnection())
            {
                using (DbCommand command = this.SetCommand(query, Server))
                {
                    Server.Open();
                    result  = command.ExecuteScalar();
                    Server.Close();
                }
            }            
            return result;
        }

        public IEnumerable<T> ExecuteReader<T>(Command query, Func<IDataReader,T> convert) where T : new()
        {
            using (DbConnection Server = this.setConnection())
            {
                using (DbCommand command = this.SetCommand(query, Server))
                {

                    Server.Open();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return convert(reader);
                        }
                    }
                    Server.Close();
                }
            }
        }

        public int ExecuteNonQuery(Command query)
        {
            int result = 0;
            using (DbConnection Server = this.setConnection())
            {
                using (DbCommand command = this.SetCommand(query,Server))
                {

                    Server.Open();
                    result = command.ExecuteNonQuery();
                    Server.Close();
                }
            }
            return result;
        }

        public DataTable GetDataTable (Command query)
        {
            DataTable dt = new DataTable();
            using (DbConnection Server = this.setConnection())
            {
                using (DbCommand command = this.SetCommand(query,Server))
                {
                    DbDataAdapter dataAdapt = Factory.CreateDataAdapter();
                    dataAdapt.Fill(dt);
                }
            }
            return dt;
        }

        private DbCommand SetCommand(Command query, DbConnection Server)
        {
            DbCommand command = Server.CreateCommand();

            command.CommandText = query.CommandText;
            command.CommandType = (query.IsStoredProcedure) ? CommandType.StoredProcedure : CommandType.Text;

            foreach (KeyValuePair<string, object> kvp in query.Parameters)
            {
                DbParameter DbP = command.CreateParameter();
                DbP.ParameterName = kvp.Key;
                DbP.Value = kvp.Value;
                command.Parameters.Add(DbP);
            }

            return command;
        }

        private DbConnection setConnection()
        {
            DbConnection connect = Factory.CreateConnection();
            connect.ConnectionString = this.ConnectionString;
            return connect;
        }
    }
}

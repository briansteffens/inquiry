using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace ColdPlace.Inquiry
{
    public abstract class Dal
    {
        protected ConnectionString ConnString { get; set; }
        public DbConnection Connection { get; set; }
        public DbTransaction Transaction { get; set; }

        public static Dal Create(ConnectionString connectionString)
        {
            switch (connectionString.ServerType)
            {
                case ServerType.MSSQL:
                    return new SqlDal(connectionString);

                case ServerType.MySQL:
                    return new MySqlDal(connectionString);

                case ServerType.Access:
                    return new AccessDal(connectionString);

                case ServerType.Oracle:
                    return new OracleDal(connectionString);

                default:
                    return null;
            }
        }

        public Dal()
        {
            ConnString = null;
            Connection = null;
        }

        public virtual string PopString(object raw)
        {
            if (raw == null || raw is DBNull)
                return "";
            else
                return raw.ToString();
        }

        public int Command(string query)
        {
            DbCommand cmd = null;
            try
            {
                cmd = Connection.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 100000;

                if (Transaction != null)
                    cmd.Transaction = Transaction;

                return cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                cmd = null;
            }
        }

        public DbDataReader Reader(string query)
        {
            DbCommand cmd = null;
            DbDataReader reader = null;
            try
            {
                cmd = Connection.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 100000;

                if (Transaction != null)
                    cmd.Transaction = Transaction;

                reader = cmd.ExecuteReader();
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                cmd = null;
            }

            return reader;
        }


        public DataTable ReadTable(string query, out int recordsAffected)
        {
            DbDataReader r = null;
            try
            {
                r = Reader(query);
                recordsAffected = r.RecordsAffected;

                DataTable schema = r.GetSchemaTable();
                if (schema == null)
                    return null;

                DataTable dt = new DataTable();

                foreach (DataRow schemaRow in schema.Rows)
                    dt.Columns.Add(schemaRow[0].ToString());

                while (r.HasRows && r.Read())
                {
                    DataRow dr = dt.NewRow();

                    for (int i = 0; i < r.FieldCount; i++)
                        dr[i] = PopString(r[i]);

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            finally
            {
                if (r != null) r.Dispose();
                r = null;
            }
        }


        public DataTable[] ReadTables(string query, out int recordsAffected)
        {
            List<DataTable> ret = new List<DataTable>();

            DbDataReader r = null;
            try
            {
                r = Reader(query);
                recordsAffected = r.RecordsAffected;

                while (true)
                {
                    DataTable schema = r.GetSchemaTable();
                    if (schema == null)
                        return null;

                    DataTable dt = new DataTable();

                    foreach (DataRow schemaRow in schema.Rows)
                        dt.Columns.Add(schemaRow[0].ToString());

                    while (r.HasRows && r.Read())
                    {
                        DataRow dr = dt.NewRow();
                        
                        for (int i = 0; i < r.FieldCount; i++)
                            dr[i] = PopString(r[i]);

                        dt.Rows.Add(dr);
                    }

                    ret.Add(dt);

                    if (!r.NextResult())
                        break;
                }
            }
            finally
            {
                if (r != null) r.Dispose();
                r = null;
            }

            return ret.ToArray();
        }



        public void Close()
        {
            if (Transaction != null) Transaction.Dispose();
            Transaction = null;

            if (Connection != null) Connection.Close();
            Connection = null;
        }


        public virtual void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public virtual void RollbackTransaction()
        {
            Transaction.Rollback();
            Transaction.Dispose();
            Transaction = null;
        }

        public virtual void CommitTransaction()
        {
            Transaction.Commit();
            Transaction.Dispose();
            Transaction = null;
        }


        public virtual List<Schema.Database> SchemaDatabases()
        {
            return new List<Schema.Database>();
        }

        public virtual List<Schema.Table> SchemaTables(string databaseName)
        {
            return new List<Schema.Table>();
        }

        public virtual List<Schema.Column> SchemaColumns(string databaseName, string tableName, string tableType)
        {
            return new List<Schema.Column>();
        }
    }

    public class SqlDal : Dal
    {
        public SqlDal(ConnectionString connectionString)
        {
            ConnString = connectionString;
            Connection = new SqlConnection(ConnString.String);
            Connection.Open();
        }

        public override List<Schema.Database> SchemaDatabases()
        {
            DataTable dt = Connection.GetSchema("Databases");

            List<Schema.Database> ret = new List<Schema.Database>();

            foreach (DataRow dr in dt.Rows)
            {
                string db = dr["database_name"].ToString();

                if (db == "master" || db == "tempdb" || db == "model" || db == "msdb")
                    continue;

                ret.Add(new Schema.Database()
                {
                    Name = db
                });
            }

            return ret;
        }

        public override List<Schema.Table> SchemaTables(string databaseName)
        {
            this.Command("use [" + databaseName + "];");

            List<Schema.Table> ret = new List<Schema.Table>();
            
            DataTable dt = Connection.GetSchema("Tables", new string[] { databaseName, null, null, "BASE TABLE"});
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(new Schema.Table()
                {
                    Name = dr["table_name"].ToString(),
                    Type = "Table"
                });
            }

            dt = Connection.GetSchema("Tables", new string[] { databaseName, null, null, "VIEW" });
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(new Schema.Table()
                {
                    Name = dr["table_name"].ToString(),
                    Type = "View"
                });
            }

            return ret;
        }

        public override List<Schema.Column> SchemaColumns(string databaseName, string tableName, string tableType)
        {
            this.Command("use [" + databaseName + "];");

            List<Schema.Column> ret = new List<Schema.Column>();

            DataTable dt = Connection.GetSchema("Columns", new string[] { databaseName, null, tableName });
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(new Schema.Column()
                {
                    Name = dr[3].ToString(),
                    Type = dr[7].ToString(),
                    Null = dr[6].ToString()
                });
            }

            return ret;
        }
    }

    public class MySqlDal : Dal
    {
        public MySqlDal(ConnectionString connectionString)
        {
            ConnString = connectionString;
            Connection = new MySqlConnection(ConnString.String);
            Connection.Open();
        }

        public override List<Schema.Database> SchemaDatabases()
        {
            DataTable dt = Connection.GetSchema("Databases");

            List<Schema.Database> ret = new List<Schema.Database>();

            foreach (DataRow dr in dt.Rows)
            {
                string db = dr[1].ToString();

                if (db == "information_schema" || db == "dbo" || db == "mysql")
                    continue;

                ret.Add(new Schema.Database()
                {
                    Name = db
                });
            }

            return ret;
        }

        public override List<Schema.Table> SchemaTables(string databaseName)
        {
            this.Command("use `" + databaseName + "`;");

            List<Schema.Table> ret = new List<Schema.Table>();

            DataTable dt = Connection.GetSchema("Tables", new string[] { null, databaseName, null, "BASE TABLE" });
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(new Schema.Table()
                {
                    Name = dr[2].ToString(),
                    Type = "Table"
                });
            }

            dt = Connection.GetSchema("Views", new string[] { null, databaseName, null, "VIEW" });
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(new Schema.Table()
                {
                    Name = dr[2].ToString(),
                    Type = "View"
                });
            }

            return ret;
        }

        public override List<Schema.Column> SchemaColumns(string databaseName, string tableName, string tableType)
        {
            this.Command("use `" + databaseName + "`;");

            List<Schema.Column> ret = new List<Schema.Column>();

            DataTable dt = Connection.GetSchema("Columns", new string[] { null, databaseName, tableName, null });
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(new Schema.Column()
                {
                    Name = dr[3].ToString(),
                    Type = dr[7].ToString(),
                    Null = dr[6].ToString()
                });
            }
            
            return ret;
        }
    }

    public class AccessDal : Dal
    {
        public AccessDal(ConnectionString connectionString)
        {
            ConnString = connectionString;
            Connection = new OleDbConnection(ConnString.String);
            Connection.Open();
        }

        public override List<Schema.Database> SchemaDatabases()
        {
            List<Schema.Database> ret = new List<Schema.Database>();

            ret.Add(new Schema.Database()
            {
                Name = ConnString.FriendlyName
            });

            return ret;
        }

        public override List<Schema.Table> SchemaTables(string databaseName)
        {
            List<Schema.Table> ret = new List<Schema.Table>();

            DataTable dt = Connection.GetSchema("Tables", new string[] { null, null, null, "TABLE" });
            foreach (DataRow dr in dt.Rows)
            {
                Schema.Table table = new Schema.Table()
                {
                    Name = dr[2].ToString(),
                    Type = "Table"
                };

                if (table.Name == "Paste Errors")
                    continue;

                ret.Add(table);
            }

            dt = Connection.GetSchema("Tables", new string[] { null, null, null, "VIEW" });
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(new Schema.Table()
                {
                    Name = dr[2].ToString(),
                    Type = "View"
                });
            }

            return ret;
        }

        public override List<Schema.Column> SchemaColumns(string databaseName, string tableName, string tableType)
        {
            List<Schema.Column> ret = new List<Schema.Column>();

            DataTable dt = Connection.GetSchema("Columns", new string[] { null, null, tableName });
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(new Schema.Column()
                {
                    Name = dr[3].ToString(),
                    Type = dr[11].ToString(),
                    Null = dr[10].ToString()
                });
            }

            return ret;
        }
    }

    public class OracleDal : Dal
    {
        public OracleDal(ConnectionString connectionString)
        {
            ConnString = connectionString;
            Connection = new OracleConnection(ConnString.String);
            Connection.Open();
        }
    }

    public class Schema
    {
        public class Database
        {
            public string Name { get; set; }
        }
        public class Table
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }
        public class Column
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Null { get; set; }
        }
    }
}

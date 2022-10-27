using System.Data;
using Microsoft.Data.SqlClient;
namespace CalorieShare.Data;

public interface IDatabase
{
    void Connect();
    DataTable Query(string sql, params object[] parameterPairs);
}

public class Database : IDatabase
{
    private string constring = "Server=localhost,50505;Database=CalorieShare;User Id=sa;Password=Vmware##;Encrypt=False;TrustServerCertificate=True";
    private IDbConnection? connection;
    public Database(string constring)
    {
        this.constring = constring;
    }

    public Database()
    {
        this.connection = new SqlConnection(constring);

    }

    public void Connect()
    {
        bool isClosed = this.connection.State.Equals(ConnectionState.Closed);
        if (isClosed) connection.Open();
    }


    //pair example: "@imInAQuery", valueForImInAQuery
    public DataTable Query(string sql, params object[] parameterPairs)
    {
        if (this.connection is null) throw new System.Exception("Database connection not open");

        this.Connect();

        return _Query(CommandType.Text, sql, parameterPairs);
    }

    public void NonQuery(string sql, params object[] parameterPairs)
    {
        this.Connect();

        using (IDbCommand cmd = this.connection.CreateCommand())
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            for (int i = 0; i < parameterPairs.Length; i++)
            {
                object name = parameterPairs[i];
                object value = parameterPairs[++i];

                if (name is not string)
                {
                    throw new ArgumentException("ParameterName is not a string");
                }

                IDbDataParameter parameter = cmd.CreateParameter();
                parameter.ParameterName = name.ToString();
                parameter.Value = value;

                cmd.Parameters.Add(parameter);
            }

            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }

    private DataTable _Query(CommandType cmdType, string sql, params object[] parameterPairs)
    {
        if (parameterPairs.Length % 2 != 0)
        {
            throw new ArgumentException("Parameter list should be pairs of name and value");
        }

        using (IDbCommand cmd = this.connection.CreateCommand())
        {
            cmd.CommandType = cmdType;
            cmd.CommandText = sql;

            for (int i = 0; i < parameterPairs.Length; i++)
            {
                object name = parameterPairs[i];
                object value = parameterPairs[++i];

                if (name is not string)
                {
                    throw new ArgumentException("ParameterName is not a string");
                }

                IDbDataParameter parameter = cmd.CreateParameter();
                parameter.ParameterName = name.ToString();
                parameter.Value = value;

                cmd.Parameters.Add(parameter);
            }

            using (IDataReader dr = cmd.ExecuteReader())
            {
                DataTable result = new DataTable();
                result.Load(dr);
                this.connection.Close();
                return result;
            }
        }
    }
}

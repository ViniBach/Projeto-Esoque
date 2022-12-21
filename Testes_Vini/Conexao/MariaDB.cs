//using MySql.Data.MySqlClient;

using MySqlConnector;
using System.Data;

namespace ConexãoDB;

public class ConectaMySQL
{
    private string connString = @"Server=localhost;Port=3306;Database=estoque; User Id=root";

    private MySqlConnection connection;
    private MySqlCommand cmd;
    private MySqlTransaction tr;

    public ConectaMySQL()
    {
        connection = new MySqlConnection(this.connString);
        this.tr = null;
    }
    public void BeginTransaction()
    {
        cmd.Transaction = this.tr;
    }
    public void SetTransaction()
    {
        cmd.Transaction = this.tr;
    }
    public void Commit()
    {
        this.tr.Commit();
    }
    public void RollBach()
    {
        this.tr.Rollback();
    }
    public void Open()
    {
        connection.Open();
    }
    public void Close()
    {
        connection.Close();
    }
    public bool IsOpen()
    {
        if (connection.State == ConnectionState.Open)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int ExecuteCMD()
    {
        return cmd.ExecuteNonQuery();
    }
    public void Parametro(string campo, Object value)
    {
        if (value == null) { value = DBNull.Value; }
        cmd.Parameters.AddWithValue(campo, value);
        cmd.Parameters[campo].Direction = ParameterDirection.Input;
    }
    public void OutParametro(string campo, Object value)
    {
        cmd.Parameters.AddWithValue(campo, value);
        cmd.Parameters[campo].Direction = ParameterDirection.InputOutput;
    }
    public Object GetParametroValor(string campo)
    {
        return cmd.Parameters[campo].Value;
    }
    public void ParametrosClear()
    {
        cmd.Parameters.Clear();
    }
    public void StoreProcedure(string nomeProduto)
    {
        cmd = new MySqlCommand(nomeProduto, this.connection);
        cmd.CommandType = CommandType.StoredProcedure;
    }
    public void CreatSQL(string sql)
    {
        cmd = new MySqlCommand(sql, this.connection);
        cmd.CommandType = CommandType.Text;
    }
    public MySqlDataReader ExecutSQL()
    {
        MySqlDataReader r = cmd.ExecuteReader();
        return r;
    }
    public MySqlDataAdapter CriaDatagrid()
    {
        return new MySqlDataAdapter(cmd);
    }
    public DataTable GetDataTable()
    {
        DataTable dt = new DataTable();
        MySqlDataAdapter obj = new MySqlDataAdapter(cmd);
        obj.Fill(dt);
        return dt;
    }
}

using ConexãoDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Funcionarios
    {
        public int Id { get; set; } 
        public string NomeFuncionario { get; set; }

        public override string ToString()
        {
            return NomeFuncionario;
        }
        public static List<Funcionarios> GetListAll()
        {
            List<Funcionarios> list = new List<Funcionarios>();

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {

                string stringSQL = " SELECT * FROM funcionarios " +                    
                    " order by nomefuncionario ";

                con.CreatSQL(stringSQL);
                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    Funcionarios prod = new Funcionarios()
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        NomeFuncionario = Convert.ToString(row["nomefuncionario"])
                    };                    
                    list.Add(prod);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            finally
            {
                if (con.IsOpen()) { con.Close(); }

            }
        }
    }
}

using ConexãoDB;
using MySqlConnector;
using System;
using System.ComponentModel;
using System.Data;

namespace Entidades
{
    public class Produtos
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
  

        public override string ToString()
        {
            return NomeProduto;
        }

        public static List<Produtos> GetListAll()
        {
            List<Produtos> list = new List<Produtos>();

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {

                string stringSQL = " SELECT * FROM produtos " +
                    " order by id desc";

                con.CreatSQL(stringSQL);
                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach(DataRow row in dt.Rows)
                {
                    Produtos prod = new Produtos()
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        NomeProduto = Convert.ToString(row["nomeproduto"])
                        
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
                if(con.IsOpen()) { con.Close(); }

            }
        }
        public static Produtos GetByNome(string nome)
        {

            Produtos prod = new Produtos();
            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {

                string stringSQL = " SELECT * FROM produtos " +
                    " where nomeproduto = @vid";

                con.CreatSQL(stringSQL);
                con.Parametro("@vid", nome);
                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    prod = new Produtos()
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        NomeProduto = Convert.ToString(row["nomeproduto"])

                    };

                }
                return prod;

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
        public void Save()
        {
            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {


                var queryStrings = " INSERT into produtos  " +
                                   " (nomeproduto) " +
                                   " VALUES  " +
                                   "(@vnomeproduto) ";

                con.CreatSQL(queryStrings);

                con.Parametro("@vnomeproduto", NomeProduto);              
                  


                con.ExecuteCMD();

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
        public static Produtos GetById(string id)
        {
            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {
                Produtos prod = new Produtos();

                var queryString = " SELECT * " +
                                  " FROM produtos " +
                                  " WHERE id = @vid; ";

                con.CreatSQL(queryString);
                con.Parametro("@vid", id);
                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    prod = new Produtos
                    {
                        Id = Convert.ToInt32(row["id"]),
                        NomeProduto = Convert.ToString(row["nomeproduto"])
                    };
                }
                return prod;
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
        public static Produtos ExisteVinculo(string id)
        {
            Produtos retorno = new Produtos();

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {

                Produtos prod = new Produtos();

                var queryString = " SELECT * " +
                                  " FROM vinculocomponentes " +
                                  " join compras on (vinculocomponentes.idcompra = compras.id)" +
                                  " join produtos on (compras.idproduto = produtos.id)" +
                                  " WHERE compras.idproduto = @vid; ";

                con.CreatSQL(queryString);
                con.Parametro("@vid", id);

                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    prod = new Produtos
                    {
                        Id = Convert.ToInt32(row["id"]),
                        //NomeProduto = Convert.ToString(row["NomeComponente"]),
                    };
                }

                return prod;

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
        public static bool VerificaNome(string id)
        {
            

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {

                Produtos prod = new Produtos();
                List<Produtos> list = new List<Produtos>();

                var queryString = " SELECT * " +
                                  " FROM Produtos " +                                  
                                  " WHERE id = @vid; ";

                con.CreatSQL(queryString);
                con.Parametro("@vid", id);

                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    prod = new Produtos
                    {
                        Id = Convert.ToInt32(row["id"]),
                        //NomeProduto = Convert.ToString(row["NomeComponente"]),
                    };
                    list.Add(prod);
                }
                if (list.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
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
        public void Delete(string id)
        {
            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {
                var queryStrings = " DELETE  from  produtos " +
                                   " WHERE id = @vid; ";

                con.CreatSQL(queryStrings);
                con.Parametro("@vid", id);

                con.ExecuteCMD();

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
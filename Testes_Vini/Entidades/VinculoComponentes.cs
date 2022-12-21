using ConexãoDB;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes_Vini.Entidades;

namespace Principal.Entidades
{
    public class VinculoComponentes
    {

        public int Id { get; set; }
        public DateTime Datacadastro { get; set; }
        public Funcionarios Funcionario { get; set; }
        public Compras Compra { get; set; }

        public string TipoMovimento;
        public string Motivo;

        public static List<VinculoComponentes> GetListAll()
        {
            List<VinculoComponentes> list = new List<VinculoComponentes>();
            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {
                string stringSQL = " SELECT * FROM vinculocomponentes " +
                  " join compras on (vinculocomponentes.idcompra = compras.id) " +
                  " join funcionarios on (vinculocomponentes.idfuncionario = funcionarios.id)" +
                  " join produtos on (compras.idproduto = produtos.id) " +
                  " order by vinculocomponentes.id ";

                con.CreatSQL(stringSQL);
                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    VinculoComponentes prod = new VinculoComponentes
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Datacadastro = Convert.ToDateTime(row["datacadastro"]),
                        Compra = new Compras
                        {
                            Id = Convert.ToInt32(row["id1"]),
                            CaminhoPdf = Convert.ToString(row["caminhopdf"]),
                            Chave = Convert.ToString(row["chave"]),
                            Quantidade = Convert.ToInt32(row["quantidade"]),
                            DataCadastro = Convert.ToDateTime(row["datacadastro"]),
                            Produto = new Produtos
                            {
                                Id = Convert.ToInt32(row["id3"]),
                                NomeProduto = Convert.ToString(row["nomeproduto"])
                            },


                            DataEmissao = Convert.ToDateTime(row["dataemissao"]),
                            NotaFiscal = Convert.ToString(row["nf"])
                        },
                        Funcionario = new Funcionarios
                        {
                            Id = Convert.ToInt32(row["id2"]),
                            NomeFuncionario = Convert.ToString(row["nomefuncionario"])
                        }

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
        public static VinculoComponentes GetById(int id)
        {
            VinculoComponentes prod = new VinculoComponentes();
            List<VinculoComponentes> list = new List<VinculoComponentes>();
            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {
                string stringSQL = " SELECT * FROM vinculocomponentes " +
                  " join compras on (vinculocomponentes.idcompra = compras.id) " +
                  " join funcionarios on (vinculocomponentes.idfuncionario = funcionarios.id)" +
                  " join produtos on (compras.idproduto = produtos.id) " +
                  " WHERE vinculocomponentes.ID = @vid ";

                con.CreatSQL(stringSQL);
                con.Parametro("@vid", id);
                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    prod = new VinculoComponentes
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Datacadastro = Convert.ToDateTime(row["datacadastro"]),
                        Compra = new Compras
                        {
                            Id = Convert.ToInt32(row["id1"]),
                            CaminhoPdf = Convert.ToString(row["caminhopdf"]),
                            Chave = Convert.ToString(row["chave"]),
                            Quantidade = Convert.ToInt32(row["quantidade"]),
                            DataCadastro = Convert.ToDateTime(row["datacadastro"]),
                            Produto = new Produtos
                            {
                                Id = Convert.ToInt32(row["id"]),
                                NomeProduto = Convert.ToString(row["nomeproduto"])
                            },


                            DataEmissao = Convert.ToDateTime(row["dataemissao"]),
                            NotaFiscal = Convert.ToString(row["nf"])
                        },
                        Funcionario = new Funcionarios
                        {
                            Id = Convert.ToInt32(row["id2"]),
                            NomeFuncionario = Convert.ToString(row["nomefuncionario"])
                        }

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
            List<Movimentos> list = new List<Movimentos>();

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {
                {   //Inserte na tabela Registromovimentos
                    string stringSQL = " INSERT INTO registromovimentos " +
                        "(idcompra, tipomovimento, motivo, idfuncionario, datacadastro)" +
                        " VALUES " +
                        " (@vidcompra, @vtipomovimento, @vmotivo, @vidfuncionario, @vdatacadastro) ";


                    con.CreatSQL(stringSQL);
                    con.Parametro("@vidcompra", Compra.Id);
                    con.Parametro("@vtipomovimento", TipoMovimento);
                    con.Parametro("@vmotivo", Motivo);
                    con.Parametro("@vidfuncionario", Funcionario.Id);
                    con.Parametro("@vdatacadastro", DateTime.Today);

                    con.ExecuteCMD();
                }
                {  //Inserte na tabela Vinculocomponentes
                    string stringSQLs = " INSERT INTO vinculocomponentes " +
                        "(idcompra, idfuncionario, datacadastro)" +
                        " VALUES " +
                        " (@vidcompra, @vidfuncionario, @vdatacadastro) ";


                    con.CreatSQL(stringSQLs);
                    con.Parametro("@vidcompra", Compra.Id);
                    con.Parametro("@vidfuncionario", Funcionario.Id);
                    con.Parametro("@vdatacadastro", DateTime.Today);


                    con.ExecuteCMD();
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
        public void Desvincular()
        {
            List<Movimentos> list = new List<Movimentos>();

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {
                {   //Inserte na tabela Registromovimentos
                    string stringSQL = " INSERT INTO registromovimentos " +
                        "(idcompra, tipomovimento, motivo, idfuncionario, datacadastro)" +
                        " VALUES " +
                        " (@vidcompra, @vtipomovimento, @vmotivo, @vidfuncionario, @vdatacadastro) ";


                    con.CreatSQL(stringSQL);
                    con.Parametro("@vidcompra", Compra.Id);
                    con.Parametro("@vtipomovimento", TipoMovimento);
                    con.Parametro("@vmotivo", Motivo);
                    con.Parametro("@vidfuncionario", Funcionario.Id);
                    con.Parametro("@vdatacadastro", DateTime.Today);

                    con.ExecuteCMD();
                }
                {  //Delete na tabela Vinculocomponentes

                    string stringSQLs = " DELETE FROM vinculocomponentes " +
                        "   WHERE vinculocomponentes.id = @vid "; 
                        


                    con.CreatSQL(stringSQLs);
                    con.Parametro("@vid",Id);
                 


                    con.ExecuteCMD();
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
        public void Descartar()
        {
            List<Movimentos> list = new List<Movimentos>();

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {
                {   //Inserte na tabela Registromovimentos
                    string stringSQL = " INSERT INTO registromovimentos " +
                        "(idcompra, tipomovimento, motivo, idfuncionario, datacadastro)" +
                        " VALUES " +
                        " (@vidcompra, @vtipomovimento, @vmotivo, @vidfuncionario, @vdatacadastro) ";


                    con.CreatSQL(stringSQL);
                    con.Parametro("@vidcompra", Compra.Id);
                    con.Parametro("@vtipomovimento", TipoMovimento);
                    con.Parametro("@vmotivo", Motivo);
                    con.Parametro("@vidfuncionario", Funcionario.Id);
                    con.Parametro("@vdatacadastro", DateTime.Today);

                    con.ExecuteCMD();
                }
                {  //Delete na tabela Vinculocomponentes

                    string stringSQL = " DELETE FROM vinculocomponentes " +
                        "   WHERE vinculocomponentes.id = @vid ";



                    con.CreatSQL(stringSQL);
                    con.Parametro("@vid", Id);



                    con.ExecuteCMD();
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
    }
}

using ConexãoDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Testes_Vini.Entidades;

namespace Entidades
{
    public class Garantias
    {
        public int Id { get; set; }
        public DateTime Incio { get; set; }
        public Compras Compra { get; set; }
        public int Quantidade { get; set; }
        public string Status { get; set; }
        public string Situacao { get; set; }
        public DateTime Termino { get; set; }
        public string Observacao { get; set; }

        public static List<Garantias> GetListAll()
        {
            List<Garantias> list = new List<Garantias>();

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {

                string stringSQL = " SELECT * FROM garantias " +
                    " join compras on (idcompra = compras.id) " +
                    " join produtos on (compras.idproduto = produtos.id) " +
                    " order by garantias.id ";

                con.CreatSQL(stringSQL);
                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    Garantias prod = new Garantias()
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        Incio = Convert.ToDateTime(row["data_inicio_chamado"]),
                        Termino = Convert.ToDateTime(row["data_termino_chamado"]),
                        Situacao = Convert.ToString(row["situacao"]),
                        Quantidade = Convert.ToInt32(row["quantidade"]),
                        Status = Convert.ToString(row["status"]),
                        Observacao = Convert.ToString(row["observacao"]),
                        Compra = new Compras
                        {
                            Id = Convert.ToInt32(row["id1"]),
                            CaminhoPdf = Convert.ToString(row["caminhopdf"]),
                            Quantidade = Convert.ToInt32(row["quantidade"]),
                            DataCadastro = Convert.ToDateTime(row["datacadastro"]),
                            Chave = Convert.ToString(row["chave"]),
                            NotaFiscal = Convert.ToString(row["nf"]),
                            DataEmissao = Convert.ToDateTime(row["dataemissao"]),
                            Produto = new Produtos
                            {
                                Id = Convert.ToInt32(row["id2"]),                                
                                NomeProduto = Convert.ToString(row["nomeproduto"])
                            }
                        },
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
        public static List<Garantias> GetById(int id)
        {
            List<Garantias> list = new List<Garantias>();

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {

                string stringSQL = " SELECT * FROM garantias " +
                    " join compras on (idcompra = compras.id) " +
                    " join produtos on (compras.idproduto = produtos.id) " +
                    " where garantias.id = @vid ";

                con.CreatSQL(stringSQL);
                con.Parametro("@vid", id);
                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    Garantias prod = new Garantias()
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        Incio = Convert.ToDateTime(row["data_inicio_chamado"]),
                        Termino = Convert.ToDateTime(row["data_termino_chamado"]),
                        Situacao = Convert.ToString(row["situacao"]),
                        Quantidade = Convert.ToInt32(row["quantidade"]),
                        Status = Convert.ToString(row["status"]),
                        Observacao = Convert.ToString(row["observacao"]),
                        Compra = new Compras
                        {
                            Id = Convert.ToInt32(row["id1"]),
                            CaminhoPdf = Convert.ToString(row["caminhopdf"]),
                            Quantidade = Convert.ToInt32(row["quantidade"]),
                            DataCadastro = Convert.ToDateTime(row["datacadastro"]),
                            Chave = Convert.ToString(row["chave"]),
                            NotaFiscal = Convert.ToString(row["nf"]),
                            DataEmissao = Convert.ToDateTime(row["dataemissao"]),
                            Produto = new Produtos
                            {
                                Id = Convert.ToInt32(row["id2"]),
                                NomeProduto = Convert.ToString(row["nomeproduto"])
                               
                                
                            }
                        },
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
        public void SaveOurUpdate(int codigo)
        {
            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {
                if(codigo == 1)
                {
                    var queryStrings = " INSERT into garantias  " +
                                  " (idcompra, data_inicio_chamado, data_termino_chamado, situacao, observacao, status, quantidade) " +
                                  " VALUES  " +
                                  " (@vidcompra, @vdata_inicio_chamado, @vdata_termino_chamado, @vsituacao, @vobservacao, @vstatus, @vquantidade) ";

                    con.CreatSQL(queryStrings);
                }

                if(codigo == 2)
                {
                    var queryStrings = " UPDATE  garantias  " +
                                    " SET    idcompra = @vidcompra,    " +
                                    "        data_inicio_chamado = @vdata_inicio_chamado, " +
                                    "        data_termino_chamado = @vdata_termino_chamado, " +
                                    "        situacao = @vsituacao,  " +
                                    "        observacao = @vobservacao,  " +
                                    "        status = @vstatus , " +
                                    "        quantidade = @vquantidade  " +
                                    " WHERE id = @vid; ";

                    con.CreatSQL(queryStrings);
                    con.Parametro("@vid", Id);
                }
              


                    con.Parametro("@vidcompra", Compra.Id);
                    con.Parametro("@vdata_inicio_chamado", Incio);
                    con.Parametro("@vdata_termino_chamado", Termino);
                    con.Parametro("@vsituacao", Situacao);
                    con.Parametro("@vobservacao", Observacao);
                    con.Parametro("@vstatus", Status);
                    con.Parametro("@vquantidade", Quantidade);

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

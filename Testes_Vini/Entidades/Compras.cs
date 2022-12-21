using ConexãoDB;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes_Vini.Entidades
{
    public class Compras
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public Produtos Produto { get; set; }
        public int Quantidade { get; set; }
        public string CaminhoPdf { get; set; }
        public string Chave { get; set; }
        public string NotaFiscal { get; set; }
        public DateTime DataEmissao { get; set; }
        public Garantias Garantia { get; set; }
        public int Disponivel { get; set; }

        public override string ToString()
        {
            return Produto.NomeProduto;
        }

        public static List<Compras> GetListAll()
        {
            List<Compras> list = new List<Compras>();

            ConectaMySQL con = new ConectaMySQL();
            con.Open();
            try
            {
                string stringSQL = " SELECT * FROM compras " +
                    " join produtos on (idproduto = produtos.id)" +
                    " left join garantias on (idgarantia = garantias.id)" +
                    " order by compras.id desc ";

                con.CreatSQL(stringSQL);
                con.ExecuteCMD();

                DataTable dt = con.GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    Compras prod = new Compras()
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        CaminhoPdf = Convert.ToString(row["caminhopdf"]),
                        Chave = Convert.ToString(row["chave"]),
                        Quantidade = Convert.ToInt32(row["quantidade"]),
                        DataCadastro = Convert.ToDateTime(row["datacadastro"]),
                        Garantia = new Garantias
                        {
                            Id = Convert.ToInt32(row["id1"])

                        },
                        Produto = new Produtos
                        {
                            Id = Convert.ToInt32(row["idproduto"]),
                            NomeProduto = Convert.ToString(row["nomeproduto"])


                        },
                        DataEmissao = Convert.ToDateTime(row["dataemissao"]),
                        NotaFiscal = Convert.ToString(row["nf"])
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
        public void Save()
        {
            ConectaMySQL con = new ConectaMySQL();
            con.Open();

            try
            {


                var queryStrings = " INSERT into compras  " +
                                   " (caminhopdf, idproduto, quantidade, datacadastro, chave, nf, dataemissao, idgarantia) " +
                                   " VALUES  " +
                                   "(@vcaminhopdf, @vidproduto, @vquantidade, @vdatacadastro, @vchave, @vnf, @vdataemissao, @vidgarantia) ";

                con.CreatSQL(queryStrings);

                con.Parametro("@vcaminhopdf", CaminhoPdf);
                con.Parametro("@vidproduto", Produto.Id);
                con.Parametro("@vquantidade", Quantidade);
                con.Parametro("@vdatacadastro", DataCadastro);
                con.Parametro("@vchave", Chave);
                con.Parametro("@vnf", NotaFiscal);
                con.Parametro("@vdataemissao", DataEmissao);
                if (Garantia != null) { con.Parametro("@vidgarantia", Garantia.Id); } else { con.Parametro("@vidgarantia", null); }


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

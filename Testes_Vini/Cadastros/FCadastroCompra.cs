

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Entidades;

using System.Runtime.CompilerServices;
using Testes_Vini.Entidades;
using EstoqueFRM.Utilitarios;
using ControlePerfect.Cadastros;

namespace ControlePerfect.Estoque
{
    public partial class FCadastroCompra : Form
    {
        List<Produtos> listprod;
        Produtos prod;
        Compras comp;
        Garantias garantia;

        public int n;
        public FCadastroCompra(Garantias n)
        {
            garantia = n;

            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Formulario_KeyPress);

        }

        private void FMovimento_Load(object sender, EventArgs e)
        {
            n = 1;

            AtualizaComboBox();
            LbData.Text = DateTime.Today.ToString("dd/MM/yyyy");

        }
        private void TxtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void Formulario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 27)
            {
                FecharPrograma();
            }
        }
        private void Formulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            else if (e.KeyData == Keys.F1) { }
            else if (e.KeyData == Keys.F2) { }
            else if (e.KeyData == Keys.F3) { }
            else if (e.KeyData == Keys.F4) { }
            else if (e.KeyData == Keys.F5) { }
            else if (e.KeyData == Keys.F6) { }
            else if (e.KeyData == Keys.F7) { }
            else if (e.KeyData == Keys.F8) { }
            else if (e.KeyData == Keys.F9) { }
            else if (e.KeyData == Keys.F10) { }
            else if (e.KeyData == Keys.F11) { }
            else if (e.KeyData == Keys.F12) { }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt))
            {
                return false;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void FecharPrograma()
        {
            if (DialogResult.Yes == MsgTela.MsgSimNao("Deseja realmente fechar o programa?", "Atenção"))
            {
                this.Close();
            }

        }
        private void AtualizaComboBox()
        {
            listprod = Produtos.GetListAll();
            CbProduto.DataSource = listprod;
            if (garantia == null)
            {

                listprod = null;
                CbProduto.DataSource = null;

                listprod = new List<Produtos>();
                listprod = Produtos.GetListAll();
                CbProduto.DataSource = listprod;
                CbProduto.SelectedIndex = -1;
            }
            else
            {
                int index = 0;

                for (int n = 0; n < listprod.Count; n++)
                {
                    if (listprod[n].NomeProduto == garantia.Compra.Produto.NomeProduto) { index = n; n = listprod.Count; }
                }

                CbProduto.Enabled = false;
                CbProduto.SelectedIndex = index;
                TxtQuantidade.Enabled = false;
                TxtQuantidade.Text = garantia.Quantidade.ToString();
                BtnNovoProduto.Enabled = false;
            }
        }

        private void BtnSalvarCaminho_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();

            //define as propriedades do controle OpenFileDialog
            ofd1.Multiselect = false;
            ofd1.Title = "Selecionar Arquivo";
            ofd1.InitialDirectory = @"C:\NFs";

            //filtra para exibir todos os arquivos
            ofd1.Filter = "All files (*.*)|*.*";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 1;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true;
            DialogResult dr = ofd1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                //atribui o nome do arquivo ao arquivo texto
                TxtCaminho.Text = ofd1.FileName;

            }
        }

        private void BtnNovoProduto_Click(object sender, EventArgs e)
        {
            prod = new Produtos();
            FCadastroProduto c1 = new FCadastroProduto();
            c1.ShowDialog();
            prod = c1.prod;

            if (prod != null) { CbProduto.SelectedItem = prod.NomeProduto; }
            AtualizaComboBox();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtNotaFiscal.Text == string.Empty) { TxtNotaFiscal.Text = " "; }
            if (TxtChave.Text == string.Empty) { TxtChave.Text = " "; }
            if (TxtCaminho.Text == string.Empty) { TxtCaminho.Text = " "; }

            if (TxtCaminho.Text != string.Empty && TxtQuantidade.Text != string.Empty && TxtChave.Text != string.Empty && TxtNotaFiscal.Text != string.Empty && CbProduto.SelectedItem != null)
            {
                string caminho = TxtCaminho.Text;
                caminho = caminho.Replace(" ", "%20");

                comp = new Compras();

                if (garantia != null) { comp.Garantia = garantia; }
                comp.Produto = Produtos.GetByNome(CbProduto.Text);
                comp.Quantidade = int.Parse(TxtQuantidade.Text);
                comp.NotaFiscal = TxtNotaFiscal.Text;
                comp.CaminhoPdf = caminho;
                comp.Chave = TxtChave.Text;
                comp.DataEmissao = DpEmissao.Value;
                comp.DataCadastro = DateTime.Today;

                comp.Save();
                this.Close();
                n = 0;


            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos para salvar");
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            Limpatela();
        }
        private void Limpatela()
        {
            CbProduto.SelectedIndex = -1;
            TxtQuantidade.Text = string.Empty;
            TxtChave.Text = string.Empty;
            TxtChave.Text = string.Empty;
            TxtNotaFiscal.Text = string.Empty;
            TxtCaminho.Text = string.Empty;
            DpEmissao.Value = DateTime.Today;
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCadastroCompra_Load(object sender, EventArgs e)
        {

        }
    }
}

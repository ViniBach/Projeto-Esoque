

using Entidades;
using EstoqueFRM.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlePerfect.Cadastros
{
    public partial class FCadastroProduto : Form
    {
        public Produtos prod;

        
        public FCadastroProduto()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Formulario_KeyPress);
        }

        private void FCadastroComponentes_Load(object sender, EventArgs e)
        {
            LimparTela();
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
                //TxtCaminho.Text = ofd1.FileName;

            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void LimparTela()
        {
            TxtComponente.Text = string.Empty;
          //  TxtCaminho.Text = string.Empty;
           
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if(TxtComponente.Text != string.Empty )
            {
                prod = new Produtos(); 
                prod.NomeProduto = TxtComponente.Text;
              //  prod.CaminhoImagem = TxtCaminho.Text;
                prod.Save();
                this.Close();
            }
        }

        private void FCadastroProduto_Load(object sender, EventArgs e)
        {

        }
    }
}

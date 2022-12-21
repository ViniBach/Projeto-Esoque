using ControlePerfect.Cadastros;
using ControlePerfect.Estoque;
using Entidades;
using EstoqueFRM.Utilitarios;
using Principal.Entidades;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ObjectiveC;
using Testes_Vini.CriaFerramentas;
using Testes_Vini.Entidades;

namespace Testes_Vini
{
    public partial class FPrincipal : Form
    {
        Button btn = new Button();

        DataGridView dgv = new DataGridView();

        TextBox txt = new TextBox();

        List<Compras> listcompras;
        List<VinculoComponentes> listvinculos;
        List<Garantias> listgarantias;
        List<Produtos> listprodutos;

        public FPrincipal()
        {
            InitializeComponent();
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            CarregaPanelInicio();
        }
        private List<Compras> GridDiponivel()
        {
            listcompras = Compras.GetListAll();
            listvinculos = VinculoComponentes.GetListAll();
            listgarantias = Garantias.GetListAll();

            Compras comp = new Compras();

            List<Compras> gridstoque = new List<Compras>();
            List<VinculoComponentes> vinc = new List<VinculoComponentes>();
            List<Garantias> garantias = new List<Garantias>();

            for (int i = 0; i < listcompras.Count; i++)
            {
                bool existeproduto = false;
                comp = listcompras[i];

                for (int n = 0; n < gridstoque.Count; n++)
                {
                    if (gridstoque[n].Produto.Id == comp.Produto.Id)
                    {
                        gridstoque[n].Disponivel = gridstoque[n].Disponivel + gridstoque[n].Quantidade;
                        gridstoque[n].Quantidade = gridstoque[n].Quantidade + comp.Quantidade;
                        existeproduto = true;
                    }
                }
                if (existeproduto == false)
                {
                    Compras c = new Compras();
                    c.Produto = comp.Produto;
                    c.Quantidade = comp.Quantidade;
                    c.Disponivel = comp.Quantidade;
                    for (int n = 0; n < listgarantias.Count; n++)
                    {
                        if (listgarantias[n].Compra.Produto.Id == comp.Produto.Id)
                        {
                            c.Disponivel = c.Disponivel - listgarantias[n].Quantidade;
                        }
                    }
                    for (int n = 0; n < listvinculos.Count; n++)
                    {
                        if (listvinculos[n].Compra.Produto.Id == comp.Produto.Id)
                        {
                            c.Disponivel = c.Disponivel - 1;
                        }
                    }
                    gridstoque.Add(c);
                }
            }

            return gridstoque;
        }
        private void TextBoxInicial_Leave(object sender, System.EventArgs e)
        {
            dgv.DataSource = null;
            dgv.DataSource = listcompras.Where(x => x.Produto.NomeProduto.ToUpper().Contains(txt.Text.ToUpper())).OrderBy(x => x.Produto.NomeProduto).ToList();
        }
        private void CriaPanelInicio()
        {


            int x = PanelPrincipal.Size.Width;
            int y = PanelPrincipal.Size.Height;

            {   //TextBox Pesquisar
                txt = new TextBox();
                txt = NovaFerramenta.CriaTextBox(txt, "TxtPesquisar", x - 152, 13, 140, 23, 1);
                txt.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
                PanelPrincipal.Controls.Add(txt);
                txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxInicial_Leave);

            }
            {   //DataGridView
                dgv = new DataGridView();
                dgv = NovaFerramenta.CriaDataGrid(dgv, "DgvEstoque", 12, 40, x - 23, y - 60, 7);
                dgv.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;

                PanelPrincipal.Controls.Add(dgv);
                dgv.DataSource = listcompras;
                DgrideEstoque();
            }
        }
        private void CriaPanelCadastros()
        {//teste
            {   //Reseta Dados
                listprodutos = null;
                listprodutos = Produtos.GetListAll();
                listcompras = null;
                listcompras = Compras.GetListAll();
                PintaMenus();
                PanelCadastros.BackColor = Color.CornflowerBlue;
                PanelPrincipal.Controls.Clear();


            }
                double x = PanelPrincipal.Size.Width + (0.00001);
                double y = PanelPrincipal.Size.Height + (0.00001);

            {   //DataGridView(Compras)

                double PorcentoX_Size = 0.616;
                double PorcentoY_Size = 0.853;

                double PorcentoX_Location = 0.01209;
                double PorcentoY_Location = 0.105;

                int sizeX = int.Parse((x * PorcentoX_Size).ToString().Substring(0, (x * PorcentoX_Size).ToString().IndexOf(",")));
                int sizeY = int.Parse((y * PorcentoY_Size).ToString().Substring(0, (y * PorcentoY_Size).ToString().IndexOf(",")));

                int locationX = int.Parse((x * PorcentoX_Location).ToString().Substring(0, (x * PorcentoX_Location).ToString().IndexOf(",")));
                int locationY = 55;

                dgv = new DataGridView();
                dgv = NovaFerramenta.CriaDataGrid(dgv, "DgvCompras", locationX, locationY, sizeX, sizeY, 7);
                PanelPrincipal.Controls.Add(dgv);
                // dgv.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
                listcompras = null; dgv.DataSource = null;
                listcompras = Compras.GetListAll();
                dgv.DataSource = listcompras;
                DgrideCompras();
            }
            {   //TextBox Pesquisar(Compras)
                double PorcentoX_Location = 0.527;
                double PorcentoX_Size = 0.10;

                int sizeX = int.Parse((x * PorcentoX_Size).ToString().Substring(0, (x * PorcentoX_Size).ToString().IndexOf(",")));

                int locationX = int.Parse((x * PorcentoX_Location).ToString().Substring(0, (x * PorcentoX_Location).ToString().IndexOf(",")));
                txt = new TextBox();
                txt = NovaFerramenta.CriaTextBox(txt, "TxtPesquisarC", locationX, 25, sizeX, 23, 3);
                PanelPrincipal.Controls.Add(txt);
            }
            {   //Button Novo(Compras)
                double PorcentoX_Location = 0.01209;
                double PorcentoX_Size = 0.0756;

                int sizeX = int.Parse((x * PorcentoX_Size).ToString().Substring(0, (x * PorcentoX_Size).ToString().IndexOf(",")));

                int locationX = int.Parse((x * PorcentoX_Location).ToString().Substring(0, (x * PorcentoX_Location).ToString().IndexOf(",")));

                btn = new Button();

                //btn = NovaFerramenta.CriaButton(btn, "BtnNovoC", 12, 26, 75, 23, 1, "Novo");
                btn = NovaFerramenta.CriaButton(btn, "BtnNovoC", locationX, 25, sizeX, 23, 1, "Novo");
                PanelPrincipal.Controls.Add(btn);
                btn.Click += new System.EventHandler(this.ButtonNovoCompras_Click);
            }
            {   //Button Editar(Compras)
                double PorcentoX_Location = 0.09375;
                double PorcentoX_Size = 0.0756;

                int sizeX = int.Parse((x * PorcentoX_Size).ToString().Substring(0, (x * PorcentoX_Size).ToString().IndexOf(",")));

                int locationX = int.Parse((x * PorcentoX_Location).ToString().Substring(0, (x * PorcentoX_Location).ToString().IndexOf(",")));

                btn = new Button();
                btn = NovaFerramenta.CriaButton(btn, "BtnEditarC", locationX, 25, sizeX, 23, 2, "Editar");
                PanelPrincipal.Controls.Add(btn);
                btn.Click += new System.EventHandler(this.ButtonEditarCompras_Click);
            }
            {   //Button Novo(Produtos)
                double PorcentoX_Location = 0.6794;
                double PorcentoX_Size = 0.0756;

                int sizeX = int.Parse((x * PorcentoX_Size).ToString().Substring(0, (x * PorcentoX_Size).ToString().IndexOf(",")));

                int locationX = int.Parse((x * PorcentoX_Location).ToString().Substring(0, (x * PorcentoX_Location).ToString().IndexOf(",")));

                btn = new Button();
                btn = NovaFerramenta.CriaButton(btn, "BtnNovoP", locationX, 25, sizeX, 23, 4, "Novo");
                PanelPrincipal.Controls.Add(btn);
                btn.Click += new System.EventHandler(this.ButtonNovoProdutos_Click);

            }
            {   //Button Editar(Produtos)
                double PorcentoX_Location = 0.76205;
                double PorcentoX_Size = 0.0756;

                int sizeX = int.Parse((x * PorcentoX_Size).ToString().Substring(0, (x * PorcentoX_Size).ToString().IndexOf(",")));

                int locationX = int.Parse((x * PorcentoX_Location).ToString().Substring(0, (x * PorcentoX_Location).ToString().IndexOf(",")));


                btn = new Button();
                btn = NovaFerramenta.CriaButton(btn, "BtnEditarP", locationX, 25, sizeX, 23, 5, "Editar");
                PanelPrincipal.Controls.Add(btn);
                btn.Click += new System.EventHandler(this.ButtonEditarProdutos_Click);
            }
            {   //TextBox Pesquisar(Produtos)
                double PorcentoX_Location = 0.8870;
                double PorcentoX_Size = 0.10;

                int sizeX = int.Parse((x * PorcentoX_Size).ToString().Substring(0, (x * PorcentoX_Size).ToString().IndexOf(",")));

                int locationX = int.Parse((x * PorcentoX_Location).ToString().Substring(0, (x * PorcentoX_Location).ToString().IndexOf(",")));

                txt = new TextBox();
                txt = NovaFerramenta.CriaTextBox(txt, "TxtPesquisarP", locationX, 25, sizeX, 23, 6);
                PanelPrincipal.Controls.Add(txt);
            }
            {   //DataGridView(Produtos)

                double PorcentoX_Size = 0.308;
                double PorcentoY_Size = 0.853;

                double PorcentoX_Location = 0.68;
                double PorcentoY_Location = 0.105;

                int sizeX = int.Parse((x * PorcentoX_Size).ToString().Substring(0, (x * PorcentoX_Size).ToString().IndexOf(",")));
                int sizeY = int.Parse((y * PorcentoY_Size).ToString().Substring(0, (y * PorcentoY_Size).ToString().IndexOf(",")));

                int locationX = int.Parse((x * PorcentoX_Location).ToString().Substring(0, (x * PorcentoX_Location).ToString().IndexOf(",")));
                int locationY = 55;

                dgv = new DataGridView();
                dgv = NovaFerramenta.CriaDataGrid(dgv, "DgvProdutos", locationX, locationY, sizeX, sizeY, 7);
                PanelPrincipal.Controls.Add(dgv);
                // dgv.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
                dgv.DataSource = listprodutos;
                DgrideProdutos();
            }

        }
        private void PintaMenus()
        {
            PanelCadastros.BackColor = Color.RoyalBlue;
            PanelInventario.BackColor = Color.RoyalBlue;
            PanelGarantias.BackColor = Color.RoyalBlue;
            PanelRelatorios.BackColor = Color.RoyalBlue;
            PanelInicio.BackColor = Color.RoyalBlue;
        }

        private void PanelCadastros_Click(object sender, EventArgs e)
        {
            CriaPanelCadastros();
        }

        private void PanelInicio_Click(object sender, EventArgs e)
        {
            CarregaPanelInicio();
        }

        private void CarregaPanelInicio()
        {
            PintaMenus();
            listcompras = null;
            listcompras = GridDiponivel();
            PanelInicio.BackColor = Color.CornflowerBlue;
            PanelPrincipal.Controls.Clear();
            CriaPanelInicio();
        }
        private void ButtonNovoCompras_Click(object sender, EventArgs e)
        {
            FCadastroCompra c1 = new FCadastroCompra(null);
            c1.ShowDialog();
            CriaPanelCadastros();
        }
        private void ButtonNovoProdutos_Click(object sender, EventArgs e)
        {
            FCadastroProduto c1 = new FCadastroProduto();
            c1.ShowDialog();
            CriaPanelCadastros();
        }
        private void ButtonEditarCompras_Click(object sender, EventArgs e)
        {
            MessageBox.Show("o");
        }
        private void ButtonEditarProdutos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("o");

        }
        private void DgrideEstoque()
        {
            bool eMultiSelect = false;
            string[] cabecalho = new string[] { "Id", "Data_Cadastro", "Produto", "Quantidade", "CaminhoPdf", "Chave", "NFe", "Data_Emissao", "Garantia", "Disponivel" };
            bool[] visivel = new bool[] { false, false, true, false, false, false, false, false, false, true };
            string[] alinhamento = new string[] { "left", "center", "left", "right", "left", "right", "right", "center", "left", "left" };
            string[] tamanho = new string[] { "fill", "120", "200", "fill", "fill", "fill", "fill", "fill", "fill", "fill" };
            string[] formato = new string[] { "", "", "", "", "", "", "", "", "", "" };

            MDataGrid.MostraDg(dgv, eMultiSelect, cabecalho, alinhamento, tamanho, formato, visivel);
        }
        private void DgrideCompras()
        {
            bool eMultiSelect = false;
            string[] cabecalho = new string[] { "Id", "Data_Cadastro", "Produto", "Quantidade", "CaminhoPdf", "Chave", "NFe", "Data_Emissao", "Garantia", "Disponivel" };
            bool[] visivel = new bool[] { false, true, true, true, false, false, true, false, false, true };
            string[] alinhamento = new string[] { "left", "center", "left", "right", "left", "right", "right", "center", "left", "right" };
            string[] tamanho = new string[] { "fill", "120", "200", "fill", "fill", "fill", "fill", "fill", "fill", "fill" };
            string[] formato = new string[] { "", "", "", "", "", "", "", "", "", "" };
            MDataGrid.MostraDg(dgv, eMultiSelect, cabecalho, alinhamento, tamanho, formato, visivel);
        }
        private void DgrideProdutos()
        {
            bool eMultiSelect = false;
            string[] cabecalho = new string[] { "Id", "Produto" };
            bool[] visivel = new bool[] { false, true };
            string[] alinhamento = new string[] { "left", "left" };
            string[] tamanho = new string[] { "fill", "fill" };
            string[] formato = new string[] { "", "" };
            MDataGrid.MostraDg(dgv, eMultiSelect, cabecalho, alinhamento, tamanho, formato, visivel);
        }


    }
}
namespace ControlePerfect.Estoque
{
    partial class FCadastroCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.CbProduto = new System.Windows.Forms.ComboBox();
            this.BtnSalvarCaminho = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtChave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtQuantidade = new System.Windows.Forms.TextBox();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.TxtCaminho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnNovoProduto = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbData = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNotaFiscal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DpEmissao = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 42;
            this.label4.Text = "Produto";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.BtnSalvar);
            this.panel2.Controls.Add(this.BtnLimpar);
            this.panel2.Controls.Add(this.BtnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 309);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 43);
            this.panel2.TabIndex = 35;
           
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Location = new System.Drawing.Point(229, 10);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(75, 23);
            this.BtnSalvar.TabIndex = 8;
            this.BtnSalvar.Text = "Salvar";
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Location = new System.Drawing.Point(148, 10);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(75, 23);
            this.BtnLimpar.TabIndex = 10;
            this.BtnLimpar.Text = "Limpar";
            this.BtnLimpar.UseVisualStyleBackColor = true;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(67, 10);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 9;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // CbProduto
            // 
            this.CbProduto.FormattingEnabled = true;
            this.CbProduto.Location = new System.Drawing.Point(23, 69);
            this.CbProduto.Name = "CbProduto";
            this.CbProduto.Size = new System.Drawing.Size(177, 23);
            this.CbProduto.TabIndex = 1;
            // 
            // BtnSalvarCaminho
            // 
            this.BtnSalvarCaminho.Location = new System.Drawing.Point(325, 250);
            this.BtnSalvarCaminho.Name = "BtnSalvarCaminho";
            this.BtnSalvarCaminho.Size = new System.Drawing.Size(33, 24);
            this.BtnSalvarCaminho.TabIndex = 7;
            this.BtnSalvarCaminho.Text = "...";
            this.BtnSalvarCaminho.UseVisualStyleBackColor = true;
            this.BtnSalvarCaminho.Click += new System.EventHandler(this.BtnSalvarCaminho_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 55;
            this.label1.Text = " Chave de Acesso";
            // 
            // TxtChave
            // 
            this.TxtChave.Location = new System.Drawing.Point(23, 129);
            this.TxtChave.Name = "TxtChave";
            this.TxtChave.Size = new System.Drawing.Size(296, 23);
            this.TxtChave.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 58;
            this.label2.Text = "Quantidade";
            // 
            // TxtQuantidade
            // 
            this.TxtQuantidade.Location = new System.Drawing.Point(240, 69);
            this.TxtQuantidade.Name = "TxtQuantidade";
            this.TxtQuantidade.Size = new System.Drawing.Size(79, 23);
            this.TxtQuantidade.TabIndex = 3;
            this.TxtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantidade_KeyPress);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // TxtCaminho
            // 
            this.TxtCaminho.Location = new System.Drawing.Point(23, 251);
            this.TxtCaminho.Name = "TxtCaminho";
            this.TxtCaminho.Size = new System.Drawing.Size(296, 23);
            this.TxtCaminho.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 62;
            this.label3.Text = "Selecione a Nota Fiscal";
            // 
            // BtnNovoProduto
            // 
            this.BtnNovoProduto.Location = new System.Drawing.Point(140, 41);
            this.BtnNovoProduto.Name = "BtnNovoProduto";
            this.BtnNovoProduto.Size = new System.Drawing.Size(60, 23);
            this.BtnNovoProduto.TabIndex = 2;
            this.BtnNovoProduto.Text = "Novo";
            this.BtnNovoProduto.UseVisualStyleBackColor = true;
            this.BtnNovoProduto.Click += new System.EventHandler(this.BtnNovoProduto_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.LbData);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(16, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 27);
            this.panel1.TabIndex = 64;
            // 
            // LbData
            // 
            this.LbData.AutoSize = true;
            this.LbData.Enabled = false;
            this.LbData.Location = new System.Drawing.Point(44, 4);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(0, 15);
            this.LbData.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(13, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Data :";
            // 
            // TxtNotaFiscal
            // 
            this.TxtNotaFiscal.Location = new System.Drawing.Point(23, 192);
            this.TxtNotaFiscal.Name = "TxtNotaFiscal";
            this.TxtNotaFiscal.Size = new System.Drawing.Size(177, 23);
            this.TxtNotaFiscal.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 65;
            this.label6.Text = "Nota Fiscal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 67;
            this.label7.Text = "Data de Emissão (NF)";
            // 
            // DpEmissao
            // 
            this.DpEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DpEmissao.Location = new System.Drawing.Point(219, 189);
            this.DpEmissao.Name = "DpEmissao";
            this.DpEmissao.Size = new System.Drawing.Size(100, 23);
            this.DpEmissao.TabIndex = 6;
            // 
            // FCadastroCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 352);
            this.Controls.Add(this.DpEmissao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtNotaFiscal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnNovoProduto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtCaminho);
            this.Controls.Add(this.TxtQuantidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtChave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSalvarCaminho);
            this.Controls.Add(this.CbProduto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(395, 391);
            this.MinimumSize = new System.Drawing.Size(395, 391);
            this.Name = "FCadastroCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FMovimento";
            this.Load += new System.EventHandler(this.FMovimento_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label4;
        private Panel panel2;
        private Button BtnSalvar;
        private Button BtnLimpar;
        private Button BtnCancelar;
        private ComboBox CbProduto;
        private Button BtnSalvarCaminho;
        private Label label1;
        private TextBox TxtChave;
        private Label label2;
        private TextBox TxtQuantidade;
        private OpenFileDialog OpenFile;
        private TextBox TxtCaminho;
        private Label label3;
        private Button BtnNovoProduto;
        private Panel panel1;
        private Label LbData;
        private Label label5;
        private TextBox TxtNotaFiscal;
        private Label label6;
        private Label label7;
        private DateTimePicker DpEmissao;
    }
}
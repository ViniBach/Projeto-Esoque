using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueFRM.Utilitarios
{
    public class MDataGrid
    {
        public static void MostraDg(DataGridView dgv, bool eMultiselect,string[] cabecalho, string[] alinhamento, string[] tamanho, string[] formato, bool[] visivel)
        {

            try
            {
                dgv.MultiSelect = false;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //Configura header da tabela
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

                //Altera a cor da linhas alternadas no grid0
                dgv.RowsDefaultCellStyle.BackColor = Color.White;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan; // Color.LightBlue

                int colunas = cabecalho.Length;
                for(int i = 0; i < colunas; i++)
                {
                    dgv.Columns[i].HeaderText = cabecalho[i];
                    dgv.Columns[i].Visible = visivel[i];

                    switch (alinhamento[i].ToLower())
                    {
                        case "left":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            break;
                        case "center":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case "right":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            break;
                            default:
                            break;
                    }
                    if (tamanho[i].ToLower() == "fill")
                    {
                        dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        int width = int.Parse(tamanho[i]);
                        dgv.Columns[i].Width = width;
                    }
                    dgv.Columns[i].DefaultCellStyle.Format = formato[i];
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
















        }
	}
}


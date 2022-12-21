using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes_Vini.CriaFerramentas
{
    public class NovaFerramenta
    {
        public static Button CriaButton(Button btn,string name, int LocationX, int LocationY, int SizeX, int SizeY,int TabIndex, string text )
        {
            btn.Location = new System.Drawing.Point(LocationX, LocationY);
            btn.Name = name;
            btn.Size = new System.Drawing.Size(SizeX, SizeY);
            btn.TabIndex = TabIndex;
            btn.Text = text;
            btn.UseVisualStyleBackColor = true;

            return btn;
        }

        public static TextBox CriaTextBox(TextBox txt, string name, int LocationX, int LocationY, int SizeX, int SizeY, int TabIndex)
        {
            txt.Location = new System.Drawing.Point(LocationX, LocationY);
            txt.Name = name;
            txt.Size = new System.Drawing.Size(SizeX, SizeY);
            txt.TabIndex = TabIndex;          
           
            return txt;
        }
        public static DataGridView CriaDataGrid(DataGridView dgv, string name, int LocationX, int LocationY, int SizeX, int SizeY, int TabIndex)
        {
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new System.Drawing.Point(LocationX, LocationY);
            dgv.Name = name;
            //dgv.RowTemplate.Height = 25;
            dgv.Size = new System.Drawing.Size(SizeX, SizeY);
            dgv.TabIndex = TabIndex;

            return dgv;
        }


    }
}

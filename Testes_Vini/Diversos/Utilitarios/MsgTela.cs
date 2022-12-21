using EstoqueDLL.ENnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueFRM.Utilitarios
{
    public abstract class MsgTela
    {
        public static void Mensagem(Label lbmensagem, string mensagem, StatusMensagemEnum status)
        {
            lbmensagem.Text = mensagem;
            switch (status)
            {
                case StatusMensagemEnum.MensagemErro:
                    lbmensagem.BackColor = Color.DarkRed;
                    lbmensagem.ForeColor = Color.White;
                    break;
                case StatusMensagemEnum.MensagemAviso:
                    lbmensagem.BackColor = Color.DarkBlue;
                    lbmensagem.ForeColor = Color.White;
                    break;
                case StatusMensagemEnum.MensagemWarning:
                    lbmensagem.BackColor = Color.DarkOrange;
                    lbmensagem.ForeColor = Color.White;
                    break;
                case StatusMensagemEnum.MensagemSucess:
                    lbmensagem.BackColor = Color.DarkGreen;
                    lbmensagem.ForeColor = Color.White;
                    break;
                default:

                    lbmensagem.BackColor = Color.DarkCyan;
                    lbmensagem.ForeColor = Color.White;
                    break;
            }
            lbmensagem.Visible = true;
        }
        public static DialogResult MsgSimNao(string mensagem, string titulo)
        {
            DialogResult result = MessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }
        public static void MsgOkCancel(string mensagem, string titulo, MessageBoxIcon icon)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OKCancel, icon);
        }
        public static void MsgOk(string mensagem, string titulo, MessageBoxIcon icon)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, icon);
        }

    }
}

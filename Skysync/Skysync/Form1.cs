using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skysync
{
    public partial class Form1 : Form
    {
        DataTable dt;
        ClasseConexao con;
        bool acesso;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            con = new ClasseConexao();
            dt = con.executarSQL("select * from contatos");
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            con = new ClasseConexao();
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            validarCampos(usuario, senha);
            if (acesso == true)
            {
                Form2 frm2 = new Form2();
                frm2.Show();
            }
        }
        private void validarCampos(string usuario, string senha)
        {
            dt = new DataTable();
            dt = con.executarSQL("select nome, fone from contatos where nome ='" + usuario + "'");
            try
            {
                if (usuario == dt.Rows[0]["nome"].ToString())
                {
                    if (senha == dt.Rows[0]["fone"].ToString())
                    {
                        acesso = true;
                    }
                }
                else
                {
                    acesso = false;
                }
            }catch
            {
                MessageBox.Show("Usuário ou senha incorretos");
            }     
        }
    }
}

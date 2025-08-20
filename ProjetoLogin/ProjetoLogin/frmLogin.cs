using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ProjetoLogin
{
    public partial class frmLogin : Form 

    {
        Conexao con = new Conexao(); //instanciando a string de conexão
        public frmLogin() 
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" && txtSenha.Text == "")
            {
                MessageBox.Show("Usuário e senha invalidos");
            }
            try
            {
                string sql ="select * from tbLogin where usuario=@user and senha = @senha"; //String de conexão
                MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD()); //Mandando ir conectar no Banco
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = txtUsuario.Text;// Adicionando Parametros no Banco
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value= txtSenha.Text;// Adicionando Parametros no Banco
                MySqlDataReader dados; //Vai ler os dados do Banco e guardar na variavel
                dados = cmd.ExecuteReader(); // Vai ler todos os dados da variavel

                if (dados.HasRows)
                {
                    MessageBox.Show("Seja bem-vindo ao sistema");
                    frmMenu menu = new frmMenu(); //Abrindo outro frm
                    this.Hide();//Escondendo esse frm
                    menu.Show();//Mostrar o proximo frm
                }
                else
                {
                    txtUsuario.Clear();
                    txtSenha.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                con.DesConnectarBD();
            }
        }
    }
}

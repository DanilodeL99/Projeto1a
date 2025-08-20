using System.Data.SqlClient;
using System;
using MySql.Data.MySqlClient;

namespace ProjetoLogin
{
    class Conexao
    {
        MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=BDProjeto;user=root;pwd=12345678"); //instanciando = o ato de apelidar algo
        public static string msg; // variável estatica permite reutilizar a variavel
        public MySqlConnection ConnectarBD()
        {
            try // try e catch são tratamento de erros. Evita que o sistema crache
            {
                con.Open(); // Retornando a conexão

            }
            catch (Exception erro) // Exepction é uma excessão, caso haja uma excessão durante o processo ele cai num erro
            {

                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return con; // Concluiu sua missão se foi positivo ou não é outros quinhentos
        }

        public MySqlConnection DesConnectarBD()
        {
            try
            {
                con.Close();

            }
            catch (Exception erro)
            {

                msg = "Ocorreu um erro ao se desconectar" + erro.Message;
            }
            return con;
        }

        internal void DesconnectarBd()
        {
            throw new NotImplementedException();
        }
    }
}

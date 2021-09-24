using MySql.Data.MySqlClient;
using System;

namespace api_pam3.Repositorio
{
    public class Conexao
    {
        MySqlConnection cn;
        public static string msg;

        public Conexao()
        {
            String connectionUrl = Environment.GetEnvironmentVariable("DB_HOST");
            if (connectionUrl == null) {
                connectionUrl = "Server=localhost;Database=api_nba;user=root; pwd=root";
            }

            this.cn = new MySqlConnection(connectionUrl);
        }

        public MySqlConnection ConectarBD()
        {
            try
            {
                cn.Open();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao conectar" + erro.Message;
            }
            return cn;
        }

        public void DesconectarBD()
        {
            try
            {
                cn.Close();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao conectar" + erro.Message;
            }
        }

    }
}
using MySql.Data.MySqlClient;
using System;

namespace api_pam3.Repositorio
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("Server= localhost;Database=api_nba;user=root; pwd=root");
        public static string msg;

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
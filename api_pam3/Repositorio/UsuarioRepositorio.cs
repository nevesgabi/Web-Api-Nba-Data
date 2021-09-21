using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_pam3.Models;
using System.Data;

namespace api_pam3.Repositorio
{
    //metodos CadastrarUsuario, ConsultarUsuario, ApagarUsuario, EditarUsuario e ListarUsuario
    public class UsuarioRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarUsuario(Usuario usu)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into Usuario(email_usuario,user_usuario,senha_usuario) Values ( @emailUsuario, @userUsuario, @senhaUsuario)", cn.ConectarBD());
            cmd.Parameters.Add("@emailUsuario", MySqlDbType.VarChar).Value = usu.EmailUsuario ;
            cmd.Parameters.Add("@userUsuario", MySqlDbType.VarChar).Value = usu.UserUsuario;
            cmd.Parameters.Add("@senhaUsuario", MySqlDbType.VarChar).Value = usu.SenhaUsuario;

            cmd.Parameters.Add("@idUsuario", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public Usuario ConsultarUsuario(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario where id_usuario = @id_usuario", cn.ConectarBD());
            cmd.Parameters.Add("@id_usuario", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Usuario usu = new Usuario();

            while (reader.Read())
            {
                usu.IdUsuario = reader.GetInt16(reader.GetOrdinal("id_usuario"));
                usu.EmailUsuario = reader.GetString(reader.GetOrdinal("email_usuario"));
                usu.UserUsuario = reader.GetString(reader.GetOrdinal("user_usuario"));
                usu.SenhaUsuario = reader.GetString(reader.GetOrdinal("senha_usuario"));
            }

            reader.Close();

            cn.DesconectarBD();

            return usu;
        }

        public bool ApagarUsuario(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM usuario WHERE id_usuario = @id_usuario", cn.ConectarBD());
            cmd.Parameters.Add("@id_usuario", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public long EditarUsuario(Usuario usu, int idUsuario)
        {
            MySqlCommand cmd = new MySqlCommand("update usuario set email_usuario = @emailUsuario, user_usuario = @userUsuario, senha_usuario = @senhaUsuario "
            + "where id_usuario = " + idUsuario + " ", cn.ConectarBD());

            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@emailUsuario", usu.EmailUsuario);
            cmd.Parameters.AddWithValue("@userUsuario", usu.UserUsuario);
            cmd.Parameters.AddWithValue("@senhaUsuario", usu.SenhaUsuario);

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public List<Usuario> ListarUsuario()
        {
            List<Usuario> usuario = new List<Usuario>();

            MySqlCommand cmd = new MySqlCommand("Select * from usuario", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Usuario usu = new Usuario();

                usu.IdUsuario = reader.GetInt16(reader.GetOrdinal("id_usuario"));
                usu.EmailUsuario = reader.GetString(reader.GetOrdinal("email_usuario"));
                usu.UserUsuario = reader.GetString(reader.GetOrdinal("user_usuario"));
                usu.SenhaUsuario = reader.GetString(reader.GetOrdinal("senha_usuario"));
                usuario.Add(usu);
            }

            return usuario;
        }

    }
}

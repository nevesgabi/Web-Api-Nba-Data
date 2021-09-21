using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_pam3.Models;
using System.Data;


namespace api_pam3.Repositorio
{
    public class FavoritaArenaRepositorio
    {
        //metodos cadastrararenafavorita, apagararenafavorita, consultararenafavorita, listararenafavorita
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public void CadastrarArenaFavorita(FavoritaArena fav)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into favorita_arena(id_usuario, id_arena) Values ( @idUsuario, @idArena)", cn.ConectarBD());
            cmd.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = fav.IdUsuario;
            cmd.Parameters.Add("@idArena", MySqlDbType.Int16).Value = fav.IdArena;
            
            cmd.ExecuteNonQuery();

            cn.DesconectarBD();

        }

        public FavoritaArena ConsultarArenaFavorita(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM favorita_arena where id_usuario = @id_usuario", cn.ConectarBD());
            cmd.Parameters.Add("@id_usuario", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            FavoritaArena fav = new FavoritaArena();

            while (reader.Read())
            {
                fav.IdUsuario = reader.GetInt16(reader.GetOrdinal("id_usuario"));
                fav.IdArena = reader.GetInt16(reader.GetOrdinal("id_arena"));
            }

            reader.Close();

            cn.DesconectarBD();

            return fav;
        }

        public bool ApagarArenaFavorita(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM favorita_arena WHERE id_arena = @id_arena", cn.ConectarBD());
            cmd.Parameters.Add("@id_arena", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public List<FavoritaArena> ListarArenaFavorita()
        {
            List<FavoritaArena> favorita = new List<FavoritaArena>();

            MySqlCommand cmd = new MySqlCommand("Select * from favorita_arena", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FavoritaArena fav = new FavoritaArena();

                fav.IdUsuario = reader.GetInt16(reader.GetOrdinal("id_usuario"));
                fav.IdArena = reader.GetInt16(reader.GetOrdinal("id_arena"));
                favorita.Add(fav);
            }

            return favorita;
        }
    }
}

using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_pam3.Models;
using System.Data;

namespace api_pam3.Repositorio
{
    public class FavoritaEquipeRepositorio
    {
        //metodos cadastartimefavorito, apagartimefavorito, consultartimefavorito, listartimefavorito
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public void CadastrarEquipeFavorita(FavoritaEquipe fav)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into favorita_equipe(id_usuario, id_equipe) Values ( @idUsuario, @idEquipe)", cn.ConectarBD());
            cmd.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = fav.IdUsuario;
            cmd.Parameters.Add("@idEquipe", MySqlDbType.Int16).Value = fav.IdEquipe;

            cmd.ExecuteNonQuery();

            cn.DesconectarBD();

        }

        public FavoritaEquipe ConsultarEquipeFavorita(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM favorita_equipe where id_usuario = @id_usuario", cn.ConectarBD());
            cmd.Parameters.Add("@id_usuario", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            FavoritaEquipe fav = new FavoritaEquipe();

            while (reader.Read())
            {
                fav.IdUsuario = reader.GetInt16(reader.GetOrdinal("id_usuario"));
                fav.IdEquipe = reader.GetInt16(reader.GetOrdinal("id_equipe"));
            }

            reader.Close();

            cn.DesconectarBD();

            return fav;
        }

        public bool ApagarEquipeFavorita(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM favorita_equipe WHERE id_equipe = @id_equipe", cn.ConectarBD());
            cmd.Parameters.Add("@id_equipe", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public List<FavoritaEquipe> ListarEquipeFavorita()
        {
            List<FavoritaEquipe> favorita = new List<FavoritaEquipe>();

            MySqlCommand cmd = new MySqlCommand("Select * from favorita_equipe", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FavoritaEquipe fav = new FavoritaEquipe();

                fav.IdUsuario = reader.GetInt16(reader.GetOrdinal("id_usuario"));
                fav.IdEquipe = reader.GetInt16(reader.GetOrdinal("id_equipe"));
                favorita.Add(fav);
            }

            return favorita;
        }
    }
}

using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_pam3.Models;
using System.Data;

namespace api_pam3.Repositorio
{
    public class FavoritaJogadorRepositorio
    {
        //metodos cadastarjogadorfavorito, apagarjogadorfavorito, consultarjogadorfavorito, listarjogadorfavorito
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public void CadastrarJogadorFavorito(FavoritaJogador fav)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into favorita_jogador(id_usuario, id_jogador) Values ( @idUsuario, @idJogador)", cn.ConectarBD());
            cmd.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = fav.IdUsuario;
            cmd.Parameters.Add("@idJogador", MySqlDbType.Int16).Value = fav.IdJogador;

            cmd.ExecuteNonQuery();

            cn.DesconectarBD();

        }

        public FavoritaJogador ConsultarJogadorFavorito(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM favorita_jogador where id_usuario = @id_usuario", cn.ConectarBD());
            cmd.Parameters.Add("@id_usuario", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            FavoritaJogador fav = new FavoritaJogador();

            while (reader.Read())
            {
                fav.IdUsuario = reader.GetInt16(reader.GetOrdinal("id_usuario"));
                fav.IdJogador = reader.GetInt16(reader.GetOrdinal("id_jogador"));
            }

            reader.Close();

            cn.DesconectarBD();

            return fav;
        }

        public bool ApagarJogadorFavorito(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM favorita_jogador WHERE id_jogador = @id_jogador", cn.ConectarBD());
            cmd.Parameters.Add("@id_jogador", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public List<FavoritaJogador> ListarJogadorFavorito()
        {
            List<FavoritaJogador> favorita = new List<FavoritaJogador>();

            MySqlCommand cmd = new MySqlCommand("Select * from favorita_jogador", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FavoritaJogador fav = new FavoritaJogador();

                fav.IdUsuario = reader.GetInt16(reader.GetOrdinal("id_usuario"));
                fav.IdJogador = reader.GetInt16(reader.GetOrdinal("id_equipe"));
                favorita.Add(fav);
            }

            return favorita;
        }
    }
}

using MySql.Data.MySqlClient;
using api_pam3.Models;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_pam3.Repositorio;

namespace api_pam3.Repositorio
{
    //metodos CadastrarArena, ConsultarArena e ListarArena
    public class ArenaRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarArena(Arena are)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into arena (nome_arena,cidade_arena,estado_arena, capacidade_arena, id_equipe) Values ( @nomeArena, @cidadeArena, @estadoArena, @capacidadeArena, @idEquipe)", cn.ConectarBD());
            cmd.Parameters.Add("@nomeArena", MySqlDbType.VarChar).Value = are.NomeArena;
            cmd.Parameters.Add("@cidadeArena", MySqlDbType.VarChar).Value = are.CidadeArena;
            cmd.Parameters.Add("@estadoArena", MySqlDbType.VarChar).Value = are.EstadoArena;
            cmd.Parameters.Add("@capacidadeArena", MySqlDbType.Int32).Value = are.CidadeArena;
            cmd.Parameters.Add("@id_equipe", MySqlDbType.Int16).Value = are.IdEquipe;

            cmd.Parameters.Add("@idArena", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public Arena ConsultarArena(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM arena where id_arena = @id_arena", cn.ConectarBD());
            cmd.Parameters.Add("@id_arena", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Arena are = new Arena();

            while (reader.Read())
            {
                are.IdArena = reader.GetInt16(reader.GetOrdinal("id_arena"));
                are.NomeArena = reader.GetString(reader.GetOrdinal("nome_arena"));
                are.CidadeArena = reader.GetString(reader.GetOrdinal("cidade_arena"));
                are.EstadoArena = reader.GetString(reader.GetOrdinal("estado_arena"));
                are.CapacidadeArena = reader.GetInt16(reader.GetOrdinal("capacidade_arena"));
                are.IdEquipe = reader.GetInt16(reader.GetOrdinal("id_equipe"));
            }

            reader.Close();

            cn.DesconectarBD();

            return are;
        }

        public List<Arena> ListarArena()
        {
            List<Arena> arena = new List<Arena>();

            MySqlCommand cmd = new MySqlCommand(" Select * from arena", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Arena ar = new Arena();

                ar.IdArena = reader.GetInt16(reader.GetOrdinal("id_arena"));
                ar.NomeArena = reader.GetString(reader.GetOrdinal("nome_arena"));
                ar.CidadeArena = reader.GetString(reader.GetOrdinal("cidade_arena"));
                ar.EstadoArena = reader.GetString(reader.GetOrdinal("estado_arena"));
                ar.CapacidadeArena = reader.GetInt32(reader.GetOrdinal("capacidade_arena"));
                ar.IdEquipe = reader.GetInt16(reader.GetOrdinal("id_equipe"));

                arena.Add(ar);
            }

            return arena;
        }
    }
}

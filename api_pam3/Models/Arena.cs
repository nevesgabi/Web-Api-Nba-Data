using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_pam3.Models
{
    public class Arena
    {
        public int IdArena { get; set; }

        public string NomeArena { get; set; }

        public string CidadeArena { get; set; }

        public string EstadoArena { get; set; }
        //esse abaixo é bigint no banco
        public int CapacidadeArena { get; set; }
        //confirmar se vai ser equipe mesmo e não time
        public int IdEquipe { get; set; }
    }
}

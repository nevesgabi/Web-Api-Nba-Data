using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_pam3.Models
{
    public class FavoritaEquipe
    {
        //conferir se vai ser idEquipe ou idTime
        public int IdEquipe { get; set; }

        public int IdUsuario { get; set; }
    }
}

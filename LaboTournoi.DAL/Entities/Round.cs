using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboTournoi.DAL.Entities
{
    public class Round
    {
        public int Id { get; set; }
        public int WinnerId { get; set; }
        public int MatchId { get; set; }
        public int Player1MoveId { get; set; }
        public int Player2MoveId { get; set; }
        public int NbRound { get; set; }
    }
}

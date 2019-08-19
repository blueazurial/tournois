using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboTournoi.DAL.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public DateTime LimitDate { get; set; }
        public int NbPlayer { get; set; }
        public int AdminId { get; set; }

    }
}

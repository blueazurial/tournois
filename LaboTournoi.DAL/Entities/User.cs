using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboTournoi.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Pseudo { get; set; }
        public String Password { get; set; }
    }
}

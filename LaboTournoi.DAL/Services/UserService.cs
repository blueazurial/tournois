using DB;
using LaboTournoi.DAL.Entities;
using LaboTournoi.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboTournoi.DAL.Services
{
    public class UserService :  BaseService<User>
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override User Get(int id)
        {
            throw new NotImplementedException();
        }

        
//metode qui sera appeler pour crée un User 
        public override int Insert(User item)
        {
            Command cmd = new Command("SP_Register", true);
          //methodes generique pour ajouter les argument a la fonction sql
            cmd.SetParameters(item);

            return _Connection.ExecuteNonQuery(cmd);

        }

        public override bool Update(User item)
        {
            throw new NotImplementedException();
        }

//pouvoir se connecter il renvois un user si y en a un dans la db
        public User Login(string user, string password)
        {
            Command cmd = new Command("SP_Login", true);
            cmd.AddParameter("@email", user);
            cmd.AddParameter("@password", password);
            //
            return (User)_Connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<User>).FirstOrDefault();
        }

        public override IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tournament> GetTournament(int id)
        {
            //je vais cherche dans tournament si id est dans les tourn  mentId dans la table User_Tournament avec comme contrinte que id 
            //rentre soit idem a UserId  
            string query = "SELECT * FROM Tournament WHERE Id IN (SELECT TournamentId FROM User_Tournament WHERE UserId = @id)";
            Command cmd = new Command(query);
            cmd.AddParameter("@id", id);
            return _Connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<Tournament>);

        }
    }
}

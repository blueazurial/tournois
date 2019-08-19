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
    public class TournamentService : BaseService<Tournament>
    {
        public override bool Delete(int id)
        {
            //on crée une commande pour aller chercher dans la db l id pour pouvoir le suprimer 
            string query = "DELETE FROM Tournament WHERE Id = @id";
            //on crée la commande avec query en argument 
            Command cmd = new Command(query);
            //ajoute le paramettre @id qui vas prendre la valeur de id(id qui est passer en argument)
            cmd.Parameters.Add("@id", id);
            //ExecuteNonQuery =fonction de connection object crée avec sam ces juste un ordre pas une requete (y a pas de resulta ces la diff)
            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override Tournament Get(int id)
        {
            //on crée une commande pour aller chercher dans la db l id pour pouvoir l optenir .
            string query = "SELECT * FROM Tournament WHERE Id = @id";
            //on crée la commande avec query en argument
            Command cmd = new Command(query);
            //ajoute le paramettre @id qui vas prendre la valeur de id(id qui est passer en argument)
            cmd.AddParameter("@id", id);
            //executer la requete qui retourne un reader (object dinamique avec comme index tous les champs de la db)
            //retourne lingne par ligne et le FirstOrDefault vas faire qu on retourne le 1 ere
            return _Connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<Tournament>).FirstOrDefault();
        }

        public override IEnumerable<Tournament> GetAll()
        {
            string query = "SELECT * FROM Tournament ";
            Command cmd = new Command(query);
            //ExecuteReader =executer la requete qui retourne un reader (object dinamique avec comme index tous les champs de la db)(renvois un object parcourable) 
            //retourne lingne par ligne en une liste 
            return _Connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<Tournament>);
        }

        public override int Insert(Tournament item)
        {
            string query = "INSERT INTO Tournament( LimitDate, NbPlayer, AdminId) OUTPUT inserted.id VALUES ( @, @limitDate, @nbPlayer, @adminId)";
            Command cmd = new Command(query);
         
            cmd.SetParameters(item);
            //ExecuteScalar= quand tu veux recuperer une valeur unique (renvois une seul valeur)
            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(Tournament item)
        {
            throw new NotImplementedException();
        }
        //IEnumerable type generique (que tu dois le typer ici de User) je peux faire un foreach sur la lsite qui vas sortir
        public IEnumerable<User> GetParticipants(int id)
        {
            //je vais cherche dans user si id est dans les userId dans la table User_Tournament avec comme contrinte que id 
            //rentre soit idem a tournamentId 
            string query = "SELECT * FROM [User] WHERE Id IN (SELECT UserId FROM User_Tournament WHERE TournamentId = @id)";
            Command cmd = new Command(query);
            cmd.AddParameter("@id",id);
            return _Connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<User>);

        }

        public int AddParticipants(int idu, int idt)
        {
            string query = "INSERT INTO User_Tournament (UserId , TournamentId) VALUES (@userId , @tournamentId)";
            Command cmd = new Command(query);
            cmd.AddParameter("@userId", idu);
            cmd.AddParameter("@tournamentId", idt);
            return (int)_Connection.ExecuteNonQuery(cmd);

        }
    }
}

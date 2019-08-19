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
    public class MatchService : BaseService<Match>
    {
        public override bool Delete(int id)
        {
            //on crée une commande pour aller chercher dans la db l id pour pouvoir le suprimer 
            string query = "DELETE FROM Macth WHERE Id = @id";
            //on crée la commande avec query en argument 
            Command cmd = new Command(query);
            //ajoute le paramettre @id qui vas prendre la valeur de id(id qui est passer en argument)
            cmd.Parameters.Add("@id", id);
            //ExecuteNonQuery =fonction de connection object crée avec sam ces juste un ordre pas une requete (y a pas de resulta ces la diff)
            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override Match Get(int id)
        {
            //on crée une commande pour aller chercher dans la db l id pour pouvoir l optenir .
            string query = "SELECT * FROM Match WHERE Id = @id";
            //on crée la commande avec query en argument
            Command cmd = new Command(query);
            //ajoute le paramettre @id qui vas prendre la valeur de id(id qui est passer en argument)
            cmd.AddParameter("@id", id);
            //executer la requete qui retourne un reader (object dinamique avec comme index tous les champs de la db)
            //retourne lingne par ligne et le FirstOrDefault vas faire qu on retourne le 1 ere
            return _Connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<Match>).FirstOrDefault();
        }

        public override IEnumerable<Match> GetAll()
        {
            string query = "SELECT * FROM Match WHERE Deleted = 0";
            Command cmd = new Command(query);
            //ExecuteReader =executer la requete qui retourne un reader (object dinamique avec comme index tous les champs de la db)(renvois un object parcourable) 
            //retourne lingne par ligne en une liste 
            return _Connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<Match>);
        }

        public override int Insert(Match item)
        {
            string query = "INSERT INTO Match(Id, TournamentId, Player1Id, Player2Id) OUTPUT inserted.id VALUES ( @id, @tournamentId, @player1Id, @player2Id)";
            Command cmd = new Command(query);
            
            cmd.SetParameters(item);
            //ExecuteScalar= quand tu veux recuperer une valeur unique (renvois une seul valeur)
            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(Match item)
        {
            string query = "UPDATE Match SET TournamentId = @tournamentId, Player1Id = @player1Id, Player2Id = @player2Id WHERE Id = @id";
            Command cmd = new Command(query);
            //on vas chercher l boject demaneder avec item 
            cmd.Parameters.Add("@tournamentId", item.TournamentId);
            cmd.Parameters.Add("@player1Id", item.Player1Id);
            cmd.Parameters.Add("@player2Id", item.Player2Id);
           //retoune le premere correspondans a l item entre si il est vrai
            return (_Connection.ExecuteNonQuery(cmd) == 1);
        }
    }
}

using LaboTournoi.DAL.Entities;
using LaboTournoi.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region test UserService insert 
            //UserService userService = new UserService();
            //User Player1 = new User();
            //Player1.Email = "ribouille@hotmail.be";
            //Player1.Password = "pretty";
            //Player1.Pseudo = "Yogso";
            //userService.Insert(Player1);
            //Console.WriteLine(Player1.Pseudo);
            //Console.ReadLine();
            #endregion

            #region test Userservice login
            //UserService userService = new UserService();
            //User Player1 = userService.Login("md@hotmail.be", "yoko");
            //Console.WriteLine(Player1.Password);
            //Console.ReadLine();
            #endregion

            #region test userService getTournament
            //UserService userService = new UserService();
            //IEnumerable<Tournament> listTournament = userService.GetTournament(1);
            //foreach (Tournament t in listTournament)
            //{
            //    Console.WriteLine(t.Id);
            //}
            //Console.ReadLine();
            #endregion

            #region test TournamentService Insert
            //TournamentService tournamentService = new TournamentService();
            //Tournament tournament1 = new Tournament();
            //DateTime date = new DateTime(2019, 5, 1, 8, 30, 52);
            //tournament1.LimitDate = date;
            //tournament1.NbPlayer = 2;
            //tournament1.AdminId = 2;
            //tournamentService.Insert(tournament1);
            //Console.WriteLine(tournament1.Id);
            //Console.WriteLine(tournament1.LimitDate);
            //Console.WriteLine(tournament1.NbPlayer);
            //Console.WriteLine(tournament1.AdminId);
            //Console.ReadLine();
            #endregion

            #region test TournamentService get (= obtenir 1)
            //TournamentService tournamentService = new TournamentService();
            //Tournament getTournament = tournamentService.Get(2) ;
            //Console.WriteLine(getTournament.AdminId);
            //Console.ReadLine();
            #endregion

            #region test TournamentService getAll (tous obtenir)
            //TournamentService tournamentService = new TournamentService();
            //IEnumerable<Tournament> getAllTournament = tournamentService.GetAll();
            ////pour recuperer le tous un par un il faux faire un foreach
            //foreach (Tournament t in getAllTournament)
            //{
            //    Console.WriteLine(t.AdminId);
            //}
            //Console.ReadLine();
            #endregion

            #region test TournamentService Deleted
            //TournamentService tournamentService = new TournamentService();
            //TournamentService tournamentService2 = new TournamentService();
            //IEnumerable<Tournament> getAllTournament = tournamentService2.GetAll();
            //bool deletedTournament = tournamentService.Delete(2);

            //foreach (Tournament t in getAllTournament)
            //{
            //    Console.WriteLine(t.Id);
            //}
            //Console.ReadLine();

            #endregion
            #region test TournamentService addparticipants
            //TournamentService tournamentService = new TournamentService();
            //int AddParticipants = tournamentService.AddParticipants(2, 1);
            //Console.WriteLine(AddParticipants);

            //Console.ReadLine();
            #endregion

        }
    }
}

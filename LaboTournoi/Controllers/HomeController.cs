using LaboTournoi.DAL.Entities;
using LaboTournoi.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboTournoi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TournamentService tournamentService = new TournamentService();
            IEnumerable<Tournament> getAllTournament = tournamentService.GetAll();
                       
            return View(getAllTournament);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
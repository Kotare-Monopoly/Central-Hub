using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using KotareMonopoly.Models;
using KotareMonopoly.Plumbing;
using WebGrease.Css.Extensions;

namespace KotareMonopoly.Controllers.v1
{
    public class NewGameController : ApiController
    {
        private KotareMonopolyDBContext db = new KotareMonopolyDBContext();

        // GET: api/NewGame
        public IQueryable<Player> GetPlayers()
        {
            db.Players.ForEach(p => p.Hours = 1500);
            db.Players.ForEach(p => p.CurrentPositionId = 0);
            db.SaveChanges();

            return db.Players;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
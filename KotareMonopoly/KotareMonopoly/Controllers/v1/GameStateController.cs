using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Http.Description;
using KotareMonopoly.Models;
using KotareMonopoly.Plumbing;

namespace KotareMonopoly.Controllers.v1
{
    public class GameStateController : ApiController
    {

        private Player player1 = new Player();
        private Player player2 = new Player();
        
        //Post: api/GameState/DiceRoll
        public void postDiceRoll(int playerID, int diceValue)
        {
     
            movePlayer(playerID, diceValue);
         
        }

        private void movePlayer(int playerId, int diceValue)
        {
            var newLocationId = 0;

            if (playerId == 1)
            {
                newLocationId = player1.CurrentPositionId + diceValue;

                if (newLocationId >= 40)
                {
                    newLocationId -= 40;
                }
                player1.CurrentPositionId = newLocationId;
            }

            if (playerId == 2)
            {
                newLocationId = player1.CurrentPositionId + diceValue;
                player2.CurrentPositionId = newLocationId;

                if (newLocationId >= 40)
                {
                    newLocationId -= 40;
                }
                player1.CurrentPositionId = newLocationId;
            }
            db.SaveChanges();
            evaluateSquare(playerId, newLocationId);
        }

        private void evaluateSquare(int playerId, int newLocationId)
        {
            SquareDTO squareDTO = new SquareDTO();
            SquareInformation squareInformation = squareDTO.GetsquareInfo(newLocationId);

            if (playerId == 1)
            {
                player1.Money += squareInformation.moneyChange;
            }

            if (playerId == 2)
            {
                player2.Money += squareInformation.moneyChange;
            }
            

        }


        private KotareMonopolyDBContext db = new KotareMonopolyDBContext();

        // GET: api/GameState
        public IQueryable<Player> GetPlayers()
        {
            return db.Players;
        }

        // GET: api/GameState/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult GetPlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/GameState/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayer(int id, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.Id)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GameState
        [ResponseType(typeof(Player))]
        public IHttpActionResult PostPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.Id }, player);
        }

        // DELETE: api/GameState/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok(player);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.Id == id) > 0;
        }
    }
}
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
using KotareMonopoly.Workers;
using Newtonsoft.Json.Linq;

namespace KotareMonopoly.Controllers.v1
{
    public class GameStateController : ApiController
    {

        private Player player1 = new Player();
        private Player player2 = new Player();

        private KotareMonopolyDBContext db = new KotareMonopolyDBContext();

        //Post: api/GameState/DiceRoll
        public IHttpActionResult postDiceRoll(DieRoll roll)
        {
            movePlayer(roll.dieResult, roll.currentPlayer);
            return Ok(roll);
        }

        private void movePlayer(int diceValue, int playerId)
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
            var worker = new ApiDAL();

            //SquareDTO squareDTO = new SquareDTO();
            //SquareInformation squareInformation = GetsquareInfo(newLocationId);
            SquareInformation realEstateResult = worker.GetSquareInformations(newLocationId);
            if (playerId == 1)
            {
                player1.Hours -= realEstateResult.Hours;
            }

            if (playerId == 2)
            {
                player2.Hours -= realEstateResult.Hours;
            }

            db.SaveChanges();

        }

        //Get api/GameState/GameInfo
        public IHttpActionResult GetGameInfo()
        {
            //string data = "['player1' : {'playerId' : 1,'hours' : 1500,'newLocation' : 5,'locationDetails' : 'Pay player2 rent of $50'},'player2' : {'playerId' : 2,'hours' : 1550,'newLocation' : 9,'locationDetails' : 'No one owns this property.'}]";
            //List<Player> playersInDatabase = db.Players.Select(x => x.Id);
            List<Player> playersInDatabase = db.Players.ToList();
            //Player player1 = new Player()
            //{
            //    Id = 1,
            //    Hours = 1000,
            //    CurrentPositionId = 22

            //};

            // Player player2 = new Player()
            //{
            //    Id = 1,
            //    Hours = 1000,
            //    CurrentPositionId = 22

            //};

            //List<Player> listOfPlayers = new List<Player>();
            //listOfPlayers.Add(player1);
            //listOfPlayers.Add(player2);

            return Ok(playersInDatabase);
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
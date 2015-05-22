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
        private Player _currentPlayer = new Player();
        private KotareMonopolyDBContext db = new KotareMonopolyDBContext();

        //Post: api/GameState/DiceRoll
        public IHttpActionResult postDiceRoll(DieRoll roll)
        {
            _currentPlayer = db.Players.Find(roll.currentPlayer);
            movePlayer(roll.dieResult, roll.currentPlayer);
            db.SaveChanges();
            return Ok(roll);
        }

        private void movePlayer(int diceValue, int playerId)
        {
            _currentPlayer.CurrentPositionId += diceValue;
            if (_currentPlayer.CurrentPositionId > 39)
            {
                _currentPlayer.CurrentPositionId -= 39;
            }

            evaluateSquare();
        }

        private void evaluateSquare()
        {
            var worker = new ApiDAL();

            SquareInformation realEstateResult = worker.GetSquareInformations(_currentPlayer.CurrentPositionId);
            if (realEstateResult != null)
            {
                _currentPlayer.Hours -= realEstateResult.Hours;
            }
        }

        //Get api/GameState/GameInfo
        public IHttpActionResult GetGameInfo()
        {
            return Ok(db.Players);
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
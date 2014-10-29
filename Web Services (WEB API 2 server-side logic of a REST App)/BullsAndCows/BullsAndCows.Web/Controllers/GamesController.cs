namespace BullsAndCows.Web.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Web.DataModels;

    public class GamesController : BaseApiController
    {
        public GamesController(IBullsAndCowsData data)
            : base(data)
        {
        }

        // POST /api/games
        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(GameDataModel model)
        {
            var currentUserID = this.User.Identity.GetUserId();
            var bluePlayer = "No blue player yet";

            var game = new Game
            {
                RedPlayerNumber = model.Number,
                RedPlayerId = currentUserID,
                GameState = GameState.WaitingForOpponent,
                DateCreated = DateTime.Now,
                Name = model.Name
            };

            this.data.Games.Add(game);
            this.data.SaveChanges();

            model.Id = game.Id;
            model.Red = this.data.Users.All().FirstOrDefault(user => user.Id == game.RedPlayerId).UserName;
            model.Blue = game.BluePlayer != null ? game.BluePlayer.UserName : bluePlayer;
            model.Number = game.Number;
            model.Name = game.Name;
            model.GameState = game.GameState.ToString();
            model.DateCreated = game.DateCreated;

            return Ok(model);
        }

        // GET /api/games/{ID}

        [HttpGet]
        [Authorize]
        public IHttpActionResult Details(int id)
        {
            var game = this.data.Games.Find(id);
            if (game == null || game.GameState == 0)
            {
                return NotFound();
            }

            var gameModel = new GameDetailsDataModel(game);
            gameModel.YourColor = this.User.Identity.GetUserName() == gameModel.Red ? "Red" : "Blue";
            return Ok(gameModel);
        }

        // GET /api/games?page=P
        [HttpGet]
        public IHttpActionResult All(int page)
        {

            if (this.User.Identity.IsAuthenticated)
            {
                return this.All(page, true);
            }

            return this.All(page, false);
        }


        // GET /api/games?page=P
        [HttpGet]
        public IHttpActionResult All(int page, bool authenticated)
        {
            var games = this.GetAllOrdered()
                    .Where(game => game.BluePlayer.UserName == null)
                    .Skip(10 * page)
                    .Take(10)
                    .Select(GameDataModel.FromGame).ToList();

            if (authenticated)
            {
                var currentId = this.User.Identity.GetUserId();
                var currentUserName = this.data.Users.All().FirstOrDefault(user => user.Id == currentId).UserName;

                games = this.GetAllOrdered()
                    .Where(game => game.BluePlayer.UserName == null
                                    || game.BluePlayer.UserName == currentUserName
                                    || game.RedPlayer.UserName == currentUserName)
                    .Skip(10 * page)
                    .Take(10)
                    .Select(GameDataModel.FromGame).ToList();
            }

            return Ok(games);
        }


        // api/games/{ID} 
        [HttpPut]
        public IHttpActionResult JoinGame([FromBody] int number, int id)
        {
            var game = this.data.Games.Find(id);
            var currentPlayerId = this.User.Identity.GetUserId();

            if (game.RedPlayerId == currentPlayerId || game.BluePlayerId == currentPlayerId)
            {
                game.BluePlayerId = currentPlayerId;
                game.BluePlayerNumber = number;

                // Notifying the hosting user, that someone has joined he game.
                game.RedPlayer.Notifications.Add(new Notification()
                {
                    GameId = game.Id,
                    Message = "It is your turn in game \\" + game.Name,
                    DateCreated = DateTime.Now,
                    State = NotificationState.Unread,
                });

                this.data.SaveChanges();

                return Ok();
            }

            return NotFound();
        }


        // GET /api/games
        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(0);
        }

        private IQueryable<Game> GetAllOrdered()
        {
            return this.data.Games.All()
                .OrderBy(game => game.GameState)
                .ThenBy(game => game.Name)
                .ThenBy(game => game.DateCreated)
                .ThenBy(game => game.RedPlayer.UserName);
        }
    }
}

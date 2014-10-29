namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using BullsAndCows.Models;

    public class GameDataModel
    {
        public GameDataModel()
        {
        }

        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return game => new GameDataModel
                {
                    Id = game.Id,
                    Name = game.Name,
                    Blue = game.BluePlayer.UserName,
                    Red = game.RedPlayer.UserName,
                    GameState = game.GameState.ToString(),
                    DateCreated = game.DateCreated
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public int Number { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
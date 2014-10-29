namespace BullsAndCows.Web.DataModels
{

    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class GameDetailsDataModel
    {
         public GameDetailsDataModel(Game game)
        {
            
            this.Id = game.Id;
            this.Name = game.Name;
            this.DateCreated = game.DateCreated;
            this.Red = game.RedPlayer.UserName;
            this.Blue = game.BluePlayer.UserName;
            this.YourNumber = game.Number;
            this.YourGuesses = game.YourGuesses.AsQueryable()
                .Select(GuessDataModel.FromGuess).ToArray();
            this.OpponentsGuesses = game.OpponentGuesses.AsQueryable()
                .Select(GuessDataModel.FromGuess).ToArray();
            this.GameState = game.GameState.ToString();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Red { get; set; }

        public string Blue { get; set; }

        public int YourNumber { get; set; }

        public ICollection<GuessDataModel> YourGuesses { get; set; }

        public ICollection<GuessDataModel> OpponentsGuesses { get; set; }

        public string YourColor { get; set; }

        public string GameState { get; set; }
    }
}
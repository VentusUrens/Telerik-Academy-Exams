using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.Web.DataModels
{
    public class GuessDataModel
    {

        public static Expression<Func<Guess, GuessDataModel>> FromGuess
        {
            get
            {
                return guess => new GuessDataModel
                {
                    Id = guess.Id,
                    UserId = guess.UserId,
                    UserName = guess.UserName,
                    GameId = guess.GameId,
                    Number = guess.Number,
                    DateMade = guess.DateMade,
                    CowsCount = guess.CowsCount,
                    BullsCount = guess.BullsCount
                };
            }
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int GameId { get; set; }

        public int Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}
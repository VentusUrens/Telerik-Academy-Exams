using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    public class Game
    {
        private ICollection<Guess> yourGuesses;

        private ICollection<Guess> opponentGuesses;

        public Game()
        {
            this.yourGuesses = new HashSet<Guess>();
            this.opponentGuesses = new HashSet<Guess>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string RedPlayerId { get; set; }

        public int RedPlayerNumber { get; set; }

        public virtual ApplicationUser RedPlayer { get; set; }

        public string BluePlayerId { get; set; }

        public int BluePlayerNumber { get; set; }

        public virtual ApplicationUser BluePlayer { get; set; }

        public GameState GameState { get; set; }

        public int Number { get; set; }

        public virtual ICollection<Guess> YourGuesses
        {
            get { return this.yourGuesses; }
            set { this.yourGuesses = value; }
        }

        public virtual ICollection<Guess> OpponentGuesses
        {
            get { return this.opponentGuesses; }
            set { this.opponentGuesses = value; }
        }

        public DateTime DateCreated { get; set; }
    }
}

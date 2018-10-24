using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    struct Card
    {
        public Suit suit { get; private set; }
        public Rank rank { get; private set; }

        public Card(Suit s, Rank r) : this()
        {
            suit = s;
            rank = r;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} ", (char) suit, rank);
        }

    }

    public enum Suit { Spades = 9824, Clubs = 9827, Hearts = 9829, Diamonds = 9830 }
    public enum Rank { Duece, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, King, Queen, Ace }

}

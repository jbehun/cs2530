// Project:     Cards
// File:        Card.cs
// Name:        Justin Behunin
// Date:        2/6/2015
// Desription:  The struct that stores the cards rank and stuit.
//              Includes the enums used to intialize each cards.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    struct Card : IComparable<Card>
    {
        public Suit suit { get; private set; }
        public Rank rank { get; private set; }

        public Card(Rank r, Suit s)
            : this()
        {
            suit = s;
            rank = r;
        }

        public override String ToString()
        {
            return String.Format("{0} {1} ", (char)suit, rank);
        }


        public int CompareTo(Card other)
        {
            
            int rankCompare = this.rank.CompareTo(other.rank);

            //return the difference in rank unless rank is equal then return differnce in suit
            if (rankCompare != 0)
                return rankCompare;
            else
                return this.suit.CompareTo(other.suit);
        }
    }

    public enum Suit { Spades = 9824, Clubs = 9827, Hearts = 9829, Diamonds = 9830 }
    public enum Rank { Ace, Deuce, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
}

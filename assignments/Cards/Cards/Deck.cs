// Project:     Cards
// File:        Deck.cs
// Name:        Justin Behunin
// Date:        2/6/2015
// Desription:  Creates a deck of cards. Provides methods to shuffle, deal, create new deck.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = NewDeck();
        }

        public Deck(List<Card> cardDeck)
        {
            Cards = cardDeck;
        }

        public void Shuffle()
        {
            Random randomNumber = new Random();
            int j;

            for(int i = Cards.Count - 1; i >= 0; i--)
            {
                j = randomNumber.Next(0, i);
                Card temp = Cards[j];
                Cards[j] = Cards[i];
                Cards[i] = temp;
            }
        }

        public List<Card> Deal(int i)
        {
            if (Cards.Count < i)
                throw new Exception("ArgumentOutOfRangeException");

            List<Card> tempHand = new List<Card>();
            for (int j = 1; j <= i; j++)
            {
                tempHand.Add(Cards[0]);
                Cards.RemoveAt(0);
            }

            return tempHand;
        }

        public override String ToString()
        {
            return BuildString();
        }


        public static List<Card> NewDeck()
        {
            List<Card> newDeck = new List<Card>();

            foreach (Cards.Rank r in Enum.GetValues(typeof(Rank)))
                foreach (Cards.Suit s in Enum.GetValues(typeof(Suit)))
                    newDeck.Add(new Card(r, s));

            return newDeck;
        }

        private String BuildString()
        {
            StringBuilder deckString = new StringBuilder();

            for (int i = 0; i < Cards.Count; i++)
            {
                deckString.Append(string.Format("{0,-9}", Cards[i]));
                if ((i + 1) % 4 == 0)
                    deckString.Append("\n");
            }

            return deckString.ToString();
        }

    }
}

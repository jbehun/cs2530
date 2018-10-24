// Project:     Cards
// File:        Hands.cs
// Name:        Justin Behunin
// Date:        2/6/2015
// Desription:  Stores a hand of cards. Checks if the hand is a flush or straight.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Hand
    {
        public List<Card> Cards { get; private set; }

        public Hand(List<Card> newHand)
        {
            newHand.Sort();
            Cards = newHand;
        }

        public bool IsFlush()
        {
            for (int i = 0; i < Cards.Count - 1; i++)
                if (Cards[i].suit != Cards[i + 1].suit)
                    return false;
            return true;
        }

        public bool IsStraight()
        {
            for (int i = Cards.Count - 1; i > 0; i--)
                if (Cards[i].rank - Cards[i-1].rank != 1)
                    return false;
            return true;
        }

        public override string ToString()
        {
            return BuildString();
        }

        private String BuildString()
        {
            StringBuilder handString = new StringBuilder();

            for (int i = 0; i < Cards.Count; i++)
            {
                handString.Append(string.Format("{0,-9}", Cards[i]));
            }

            if (IsStraight())
                handString.Append(string.Format("{0, -9}", "Straight"));

            if (IsFlush())
                handString.Append(string.Format("{0, -9}", "Flush"));

            return handString.ToString();
        }
    }
}

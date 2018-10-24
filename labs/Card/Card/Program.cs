using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class Program
    {
        static void Main(string[] args)
        {
            Card c1 = new Card(Suit.Clubs, Rank.Five);
            Card c2 = new Card(Suit.Diamonds, Rank.Ace);

            Console.WriteLine("{0}, {1}", c1, c2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4._5
{
    internal class Card
    {

        public CardSymbol Suit { get; set; }
       public  Number Number { get; set; }


        public Card(CardSymbol suit, Number number)
        {
            Suit = suit;
            Number = number;
        }   


        public delegate bool FilterCardDelegate(Card card);

        public override string ToString()
        {
            return $"{Suit} {Number}";
        }
    }


    public enum Number
    {
        Ace,

        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    enum CardSymbol {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}

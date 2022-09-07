using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_4._5;

namespace Exercise_4._5
{
    internal class Program
    {

        public static bool filterByClub(Card card)
        {
            return card.Suit == CardSymbol.Clubs;
        }

        public static bool filterBySpades (Card card)
        {
            return card.Suit == CardSymbol.Spades;
        }

        public static bool filterByPictureCard (Card card)

        {
            return card.Number == Number.Jack || card.Number == Number.Queen || card.Number == Number.King;
        }

        public static bool filterByNumbersCard(Card card)

        {
            return card.Number != Number.Jack && card.Number != Number.Queen && card.Number != Number.King;
        }





        static void Main(string[] args)
        {

            Card card2 = new Card(CardSymbol.Hearts, Number.Two);
            Card card3 = new Card(CardSymbol.Hearts, Number.Three);
            Card card4 = new Card(CardSymbol.Clubs, Number.Four);
            Card card5 = new Card(CardSymbol.Clubs, Number.Five);
            Card card6 = new Card(CardSymbol.Diamonds, Number.Six);
            Card card7 = new Card(CardSymbol.Diamonds, Number.Seven);
            Card card8 = new Card(CardSymbol.Spades, Number.Eight);
            Card card9 = new Card(CardSymbol.Spades, Number.Nine);
            Card queenClubs = new Card(CardSymbol.Clubs, Number.Queen);
            Card queenSpades = new Card(CardSymbol.Spades, Number.Queen);
            Card queenDiamonds = new Card(CardSymbol.Diamonds, Number.Queen);
            Card queenHearts = new Card(CardSymbol.Hearts, Number.Queen);


            CardCollection cardCollection = new CardCollection();

            cardCollection.AddCard(card2);
            cardCollection.AddCard(card3);
            cardCollection.AddCard(card4);
            cardCollection.AddCard(card5);
            cardCollection.AddCard(card6);
            cardCollection.AddCard(card7);
            cardCollection.AddCard(card8);
            cardCollection.AddCard(card9);
            cardCollection.AddCard(queenClubs);
            cardCollection.AddCard(queenSpades);
            cardCollection.AddCard(queenDiamonds);
            cardCollection.AddCard(queenHearts);

            CardCollection filteredCards = cardCollection.filterCards(filterByClub);

            Console.WriteLine(string.Join(",", filteredCards));

            Console.WriteLine();
            /*
            Console.WriteLine(cardCollection.filterCards(filterByClub);
            Console.WriteLine(cardCollection.filterCards(filterBySpades));
            Console.WriteLine(cardCollection.filterCards(filterByPictureCard));
            Console.WriteLine(cardCollection.filterCards(filterByNumbersCard));
             */
            

            // filter by clubs lambda syntax:
            Console.WriteLine(cardCollection.filterCards((Card card) => card.Suit == CardSymbol.Clubs));

            // filter by spades lamda syntax: 

            Console.WriteLine(cardCollection.filterCards((Card card) => card.Suit == CardSymbol.Spades));

            // filter by picture cards lambda syntax: 

            Console.WriteLine(cardCollection.filterCards((Card card) => card.Number == Number.Jack || card.Number == Number.Queen || card.Number == Number.King));


            // filter by numbers card: 

            Console.WriteLine(cardCollection.filterCards((Card card) => card.Number != Number.Jack && card.Number != Number.Queen && card.Number != Number.King));

            Console.ReadLine();



        }
    }
}

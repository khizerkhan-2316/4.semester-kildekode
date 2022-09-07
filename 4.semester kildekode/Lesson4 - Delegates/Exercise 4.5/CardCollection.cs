using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise_4._5.Card;

namespace Exercise_4._5
{
    internal class CardCollection
    {

        private List<Card> _cards;


        public CardCollection()
        {
            _cards = new List<Card>();
        }


        public void AddCard(Card card)
        {
            this._cards.Add(card);
        }

        public CardCollection filterCards (FilterCardDelegate filter)
        {
            CardCollection cards = new CardCollection();

            this._cards.ForEach((Card card) =>
            {
                if (filter.Invoke(card))
                {
                    cards.AddCard(card);
                }
            });

            return cards;

        }

        public override string ToString()
        {

            return string.Join(",",(IEnumerable<Card>) _cards.ToArray());
        }
    }
}

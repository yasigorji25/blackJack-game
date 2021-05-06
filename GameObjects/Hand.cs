using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    /// <summary>
    /// The card in Hand
    /// <author>Yanmei Zeng 10307389</author>
    /// <author>Yasaman Gorjinejad 10295647</author>
    /// </summary>
    public class Hand : IEnumerable
    {
        /// <summary>
        /// creat a list of card for private hand 
        /// </summary>
        private List<Card> _hand;

        /// <summary>
        /// The number of card in the Hand
        /// </summary>
        public int Count { get { return _hand.Count; } }

        /// <summary>
        /// Create an empty list for _hand
        /// </summary>
        public Hand()
        {
            _hand = new List<Card>();
        }

        /// <summary>
        /// Give value Cards to _hand
        /// </summary>
        /// <param name="Cards">cards in the hand</param>
        public Hand(List<Card> Cards)
        {
            _hand = Cards; 
        }

        /// <summary>
        /// Get the card in specific position 
        /// </summary>
        /// <param name="position">the position of the card</param>
        /// <returns>card position</returns>
        public Card GetCard(int position)
        {
            return _hand[position];
        }

        /// <summary>
        /// Add new card to _hand list
        /// </summary>
        /// <param name="newCard">a new card</param>
        public void AddCard(Card newCard) {
            _hand.Add(newCard);
        }

        /// <summary>
        /// Detect if the _hand have card or not
        /// </summary>
        /// <param name="card">card</param>
        /// <returns>return ture if the given card is in the hand
        /// otherwise false
        /// </returns>
        public bool ContainsCard(Card card) {
            return _hand.Contains(card);
             }

        /// <summary>
        /// Remove the given card from hand
        /// </summary>
        /// <param name="card"> card</param>
        /// <returns>if succesful return ture
        /// otherwise false
        /// </returns>
        public bool RemoveCard(Card card)
        {
            if (_hand.Contains(card)) {
                _hand.Remove(card);
                if (_hand.Contains(card)) {
                    return false;
                } else return true;
            } else return false; 
        }

        /// <summary>
        /// Remove the card at the indext given by the int parameter
        /// </summary>
        /// <param name="position">position of the card</param>
        /// <returns>return ture if successful</returns>
        public bool RemoveCardAt(int  position)
        {
            if (_hand.Contains(_hand[position])) {
                _hand.Remove(_hand[position]);
                return true;
            } 
            else return false; 
        }

        /// <summary>
        /// Sort the Hand by suit and then facevalue
        /// </summary>
        public void SortHand()
        {
            _hand.Sort();
        }
        public IEnumerator GetEnumerator() {
            return _hand.GetEnumerator();
        }
    }
}

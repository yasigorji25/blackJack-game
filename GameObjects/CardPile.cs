using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    /// <summary>
    /// card pile class has cards. 
    /// <author>Yanmei Zeng 10307389</author>
    /// <author>Yasaman Gorjinejad 10295647</author>
    /// </summary>
    public class CardPile
    {
        /// <summary>
        /// Properties
        /// </summary>
        private List<Card> _pile = new List<Card>();
        Random numberGenerator = new Random();
        public int Count { get { return _pile.Count; } }
        
        /// <summary>
        /// Get the top card
        /// </summary>
        public Card TopCard { get { return _pile[_pile.Count - 1];  } }

        /// <summary>
        /// Create 52 card set
        /// </summary>
        public CardPile(bool valid = false)
        {
            if (valid) {
                foreach(Suit suit in Enum.GetValues(typeof(Suit))) {
                    foreach (FaceValue facevalue in Enum.GetValues(typeof(FaceValue))) {
                        _pile.Add(new Card(suit, facevalue)); 
                    }
                }
            }
        }

        /// <summary>
        /// Add card to Pile
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            _pile.Add(card);
        }

        /// <summary>
        /// Shuffle card pile
        /// </summary>
        public void ShufflePile()
        {
            List<Card> shuffledCard = new List<Card>();
            while (_pile.Count> 0)
            {
                int randomCardPos = numberGenerator.Next(0, _pile.Count);
                Card cardToRemove = _pile[randomCardPos];
                shuffledCard.Add(cardToRemove);
                _pile.Remove(cardToRemove); 
            }
            _pile = shuffledCard; 
        }

        /// <summary>
        /// get next card form card pile
        /// and remove it from card pile
        /// </summary>
        /// <returns>return the next card form card pile
        /// and remove it from card pile
        /// </returns>
        public Card DealOneCard()
        {
            Card card = _pile[0];
            _pile.RemoveAt(0);
            return card; 
        }

        /// <summary>
        /// Deal the number of card specified by the parameter
        /// removing them and put them in list of card
        /// </summary>
        /// <param name="number_card">the number of deal's card</param>
        /// <returns>return the list of the card</returns>
        public List<Card> DealCards(int number_card)
        {
            List<Card> list_cards = new List<Card>();
            for (int i= 0; i< number_card; i++) {
                Card card = _pile[0];
                _pile.Remove(card);
                list_cards.Add(card); 
            }
            return list_cards;
        }

    }
    }












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    /// <summary>
    /// Enum for facevalue and suit
    /// <author>Yanmei Zeng 10307389</author>
    /// <author>Yasaman Gorjinejad 10295647</author>
    /// </summary>
    public enum Suit { Clubs, Diamonds, Hearts, Spades }
    public enum FaceValue
    {
        Ace = 1, Two, Three, Four, Five,
        Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
    
    /// <summary>
    /// creat the cards 
    /// </summary>
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        /// <summary>
        /// Creat private array for suit and facevalue 
        /// </summary>
        private string[] _suitArray = new string[]
        { "C", "D", "H", "S" };
        private string[] _faceValueArray = new string[]
                {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                    "J", "Q", "K" };


        /// <summary>
        /// Get the item in suit and facevalue
        /// </summary>
        public FaceValue FaceValue { get; }
        public Suit Suit { get; }

        /// <summary>
        /// Contractor - build card by facevalue and suit
        /// </summary>
        /// <param name="suit">name for distingguish Suit</param>
        /// <param name="faceValue">name for distingguish Facevalue</param>
        public Card(Suit suit, FaceValue faceValue)
        {
            Suit = suit;
            FaceValue = faceValue;
        }

        /// <summary>
        /// It will sort the cards . cards first should be sorted by their 
        /// suit alphabetically, and when suit are the same it should be sorted
        /// by afcevalue for instance ace of clubs come before 6 of clubs. 
        /// </summary>
        /// <param name="other">the card been given</param>
        /// <returns>
        /// The card should be sorted before given card
        /// return a number smaller than 0;
        /// If Card occurs in the same position as given card
        /// return 0;
        /// If Card should be sorted after the given card
        /// return a number greter than 0
        /// </returns>
        public int CompareTo(Card other)
        {
            // the suit should be go before other suit 
            if (other.Suit > Suit) {
                return -1;
            // if the suit are same then check the facevalue 
            } else if (other.Suit == Suit) {
                if (other.FaceValue > FaceValue) {
                    return -1;
                } else if (other.FaceValue == FaceValue) {
                    return 0;
                } else {
                    return 1;
                }
            } else {
                return 1;
            }
        }

        /// <summary>
        /// Check if the card is the same suit and facevalue
        /// </summary>
        /// <param name="other">other card</param>
        /// <returns>
        /// return true if this card(from which equals was called) is quivalant to
        /// given card(the prameter; otherwise false)
        /// </returns>
        public bool Equals(Card other)
        {
            return (other.FaceValue == FaceValue && other.Suit == Suit); 
        }
        public override string ToString()  {
            return _faceValueArray[(int)FaceValue-1] + _suitArray[(int)Suit]; 
        }
    }
}
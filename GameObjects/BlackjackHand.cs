using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    /// <summary>
    /// BlackjackHand is a subclass of Hand
    /// <author>Yanmei Zeng 10307389</author>
    /// <author>Yasaman Gorjinejad 10295647</author>
    /// </summary>
    public class BlackjackHand : Hand
    {
        /// <summary>
        /// Property used to keep track of whether the Hand is standing 
        /// </summary>
        public bool IsStanding { get; set; }
        
        /// <summary>
        /// Property used to keep track of whether the Hand was surrendered
        /// </summary>
        public bool HasSurrendered { get; set; }
        
        /// <summary>
        /// Property used to keep track of the bet placed on a Hand 
        /// </summary>
        public int Bet { get; set; }
        
        /// <summary>
        /// Property used to calculate the value or score of a Hand 
        /// according to the Blackjack rules (including values of 
        /// Aces which can be 11 or 1). This property should have a 
        /// Get method only (no set), and should always calculate the 
        /// correct Blackjack score. 
        /// </summary>
        public int Score {
            get {
                return GetScore();
            }
        }

        /// <summary>
        /// Constructor used to set up the initial bet for a Hand.
        ///  the Dealer does not have funds and 
        ///  so does not place a bet on their hand (bet can be 0 by default). 
        /// </summary>
        /// <param name="initialBet"> the initial bet on the hand</param>
        public BlackjackHand(int initialBet = 0)
        {
            Bet = initialBet;

        }
        /// <summary>
        /// GetScore method calculate the score of the cards. 
        /// </summary>
        /// <returns>it will return the value or score of the cards.</returns>
        private int GetScore()
        {

            // counts the number of aces
            int value = 0;
            const int blackjack = 21;
            int aceNums = 0;
            for (int i = 0; i < Count; i++)
            {
                if (GetCard(i).FaceValue == FaceValue.Ace)
                {
                    aceNums++;
                }
            }

            // calculate the score but don't count aces at all
            for (int i = 0; i < Count; i++)
            {
                if ((int)GetCard(i).FaceValue > 10)
                {
                    value += 10;
                }
                else
                {
                    value += (int)GetCard(i).FaceValue;
                }
            }

            // determine the score from aces


            for(int i = 0; i<aceNums; i++)
            {
                if(value + 10 <= blackjack)
                {
                    value += 10; 
                }
            }
            return value; 
        }
    }
}












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameObjects;

namespace Games {
    /// <summary>
    /// It has the logic of the game 
    /// <author>Yanmei Zeng 10307389</author>
    /// <author>Yasaman Gorjinejad 10295647</author>
    /// </summary>
    public static class Blackjack {
        /// <summary>
        /// This enum represents the results for a Hand depending on the outcome of a Blackjack game.
        /// It is important for the DealerPlay method when the dealer determines the result of a game. 
        /// </summary>
        public enum Result { Push, Won, Lost, Bust, Surrendered }
        /// <summary>
        /// The shuffled CardPile from which all cards are retrieved.
        /// Should be reset every round. 
        /// </summary>
        private static CardPile _deck = new CardPile(false);
        /// <summary>
        /// The BlackjackHand used to represent the dealer’s hand 
        /// </summary>
        public static BlackjackHand DealerHand { get; private set; }
        /// <summary>
        /// A List of BlackjackHands used to represent the player’s hands (at most two in this version) 
        /// </summary>
        public static List<BlackjackHand> PlayerHands { get; private set; }
        /// <summary>
        /// A property used to represent how much funds the player has. 
        /// When the player makes a bet, doubles or splits on a hand, 
        /// this should be reduced appropriately. 
        /// At the end of each round, PlayerFunds may increase appropriately
        /// if the player has won or surrendered.
        /// </summary>
        public static int PlayerFunds { get; private set; }
        /// <summary>
        /// Resets the player’s funds to its initial value (1000). 
        /// Initialises the PlayerHands and DealerHand objects.
        /// </summary>
        public static void Reset() {
            PlayerFunds = 1000;
            PlayerHands = new List<BlackjackHand>();
            DealerHand = new BlackjackHand();
        }
        /// <summary>
        /// Initiates a new round using a bet from the player (parameter). 
        /// The player’s funds are reduced by the amount they bet.
        /// The deck of 52 cards is created and shuffled.
        /// Cards are dealt to the player and the dealer as needed.
        /// </summary>
        /// <param name="initialBet">the initial bet on the hand.</param>
        public static void NewRound(int initialBet) {
            DealerHand = new BlackjackHand();
            PlayerHands = new List<BlackjackHand>();
            PlayerHands.Add(new BlackjackHand(initialBet));
            _deck = new CardPile(true);
            _deck.ShufflePile();
            PlayerFunds -= PlayerHands[0].Bet;
            DealerHand.Bet = 0;
            // deal new 2 new cards gor the player 
            PlayerHands[0].AddCard(_deck.DealOneCard());
            PlayerHands[0].AddCard(_deck.DealOneCard());
            // deal new 2 new cards for the dealer
            DealerHand.AddCard(_deck.DealOneCard());
            DealerHand.AddCard(_deck.DealOneCard());
        }
        /// <summary>
        /// The dealer plays out their turn according to the rules of the game. 
        /// The correct amount of funds are given back to the player according to the
        /// rules of the game and the outcome of the dealer’s turn.  
        /// The result of each of the player’s hands forms the output of this method.
        /// Each list item should correspond to a Hand in PlayerHands
        /// </summary>
        /// <returns>the result of the game (push, lost, win , bust, surrender)</returns>
        public static List<Result> DealerPlay() {
            List<Result> results = new List<Result>();
            // bust: (if it is only one hand )
            if (PlayerHands.Count == 1 && PlayerHands[0].Score > 21) {
                results.Add(Result.Bust);
                return results;
            }
            // surrendered: If the hand was surrendered, the player regains half of their bet. 
            else if (PlayerHands[0].HasSurrendered) {
                PlayerFunds += PlayerHands[0].Bet / 2;
                results.Add(Result.Surrendered);
                return results;
            }
            // bust (if 2 playerhands)
            if (PlayerHands.Count == 2 & PlayerHands[0].Score > 21 && PlayerHands[1].Score > 21) {
                results.Add(Result.Bust);
                results.Add(Result.Bust);
                return results;
            }
            // deal a card until the dealer score reach up to 17. 
            while (DealerHand.Score < 17) {
                // _deck = new CardPile(true);
                // _deck.ShufflePile();
                DealerHand.AddCard(_deck.DealOneCard());
            }
            // check both playerhands 
            foreach (BlackjackHand Hand in PlayerHands) {
                //If the hand’s score is more than 21, the player does not get anything
                if (Hand.Score > 21) {
                    results.Add(Result.Bust);
                }
                // If the hand’s score is less than the dealer’s, the player does not get anything; otherwise; 
                // player is win. 
                else if (Hand.Score < DealerHand.Score) {
                    if (DealerHand.Score <= 21) {
                        results.Add(Result.Lost);
                    } else {
                        results.Add(Result.Won);
                        PlayerFunds += Hand.Bet * 2;
                    }
                }
                // If the hand’s score is the same as the dealer’s (and did not go bust)
                //then the player regains their bet, but nothing more. 
                else if (Hand.Score == DealerHand.Score) {
                    PlayerFunds += Hand.Bet;
                    results.Add(Result.Push);
                }
                // If the hand’s score is higher than the dealer’s score, 
                // but not greater than 21, or if the dealer goes bust, 
                // then the player regains their own hand’s bet multiplied by two.  
                else if (Hand.Score > DealerHand.Score) {
                    PlayerFunds += Hand.Bet * 2;
                    results.Add(Result.Won);
                }
            }
            return results;
        }
        /// <summary>
        /// The dealer deals an additional card to the player 
        /// For example, Hit(0) would cause the player to be dealt a new card into their first Hand. 
        /// </summary>
        /// <param name="handNum">number of player's hand</param>
        public static void Hit(int handNum) {
            if (CanHit(handNum) == true) {
                PlayerHands[handNum].AddCard(_deck.DealOneCard());
                if (PlayerHands[handNum].Score >= 21) {
                    PlayerHands[handNum].IsStanding = true;
                }
            }
        }
        /// <summary>
        /// If the player can afford it, they double their hand’s bet before being dealt a new card.
        /// The player automatically stands afterwards and may not perform any more moves for this hand. 
        /// </summary>
        /// <param name="handNum">the hand number of player's hand</param>
        public static void Double(int handNum) {
            if (CanDouble(handNum) == true) {
                PlayerFunds -= (PlayerHands[handNum].Bet);
                PlayerHands[handNum].Bet += PlayerHands[handNum].Bet;
                PlayerHands[handNum].IsStanding = true;
                PlayerHands[handNum].AddCard(_deck.DealOneCard());
            }
        }
        /// <summary>
        /// The player stops playing the hand.  
        /// </summary>
        /// <param name="handNum">the number of playerhands</param>
        public static void Stand(int handNum) {
            PlayerHands[handNum].IsStanding = true;
        }

        /// <summary>
        ///The hand is ‘surrendered’
        /// </summary>
        public static void Surrender() {
            PlayerHands[0].HasSurrendered = true;
            PlayerHands[0].IsStanding = true;
        }
        /// <summary>
        ///  Splits one of the cards off into a new hand. 
        ///  Both hands are dealt a new card, and the player must place
        ///  the same bet on the second hand as the original.
        ///  The player continues play with both hands separately. The player may only split once. 
        /// </summary>
        public static void Split() {
            PlayerHands.Add(new BlackjackHand());
            //the same bet on the second hand as the original.
            PlayerHands[1].Bet = PlayerHands[0].Bet;
            // reduce the amount of bet from player funds
            PlayerFunds -= PlayerHands[1].Bet;
            // split a hand 0 card into hand 1
            PlayerHands[1].AddCard(PlayerHands[0].GetCard(1));
            PlayerHands[0].RemoveCardAt(1);
            PlayerHands[1].AddCard(_deck.DealOneCard());
            PlayerHands[0].AddCard(_deck.DealOneCard());
        }
        /// <summary>
        ///  to check weather if player can hit or not. 
        /// </summary>
        /// <param name="handNum">the number of playerhands</param>
        /// <returns>Returns true if it is currently possible for the player to Hit for the chose Hand; 
        /// otherwise false</returns>
        public static bool CanHit(int handNum) {
            if (handNum == 1 && PlayerHands.Count < 2) {
                return false;
            }

            if (PlayerHands[handNum].Score < 21 && !PlayerHands[handNum].IsStanding) {
                return true;
            }
            return false;
        }
        /// <summary>
        ///  to check weather if player can double or not. 
        /// </summary>
        /// <param name="handNum">the number of playerhands</param>
        /// <returns>Returns true if it is currently possible for the player to Double for the chose Hand; 
        /// otherwise false</returns>
        public static bool CanDouble(int handNum) {
            if (handNum == 1 && PlayerHands.Count < 2) {
                return false;
            }
            // if (playerfunds - bet) > 0 and  
            //the player has < 21 points and they haven't surrendered, and they haven't 'stand' yet
            if (PlayerFunds - (PlayerHands[handNum].Bet) > 0 && !PlayerHands[handNum].IsStanding &&
                !PlayerHands[handNum].HasSurrendered && PlayerHands[handNum].Score < 21) {
                return true;
            }
            return false;
        }
        /// <summary>
        ///  to check weather if player can stand or not. 
        ///  Standing occurs automatically if the player reaches 21 points or more for a hand,
        ///  or if the hand is ‘doubled’ or ‘surrendered’. 
        /// </summary>
        /// <param name="handNum">the number of playerhands</param>
        /// <returns>Returns true if it is currently possible for the player to Stand for the chose Hand; 
        /// otherwise false</returns>
        public static bool CanStand(int handNum) {
            // if the player has < 21 points and they haven't surrendered, and they haven't 'stand' yet, return true
            if (handNum == 1 && PlayerHands.Count < 2) {
                return false;
            }
            // if the player score is less than 21 and has not already chosen 'stand'or 'surrender.
            if (PlayerHands[handNum].Score < 21 && !PlayerHands[handNum].IsStanding && !PlayerHands[0].HasSurrendered) {
                return true;
            }
            return false;
        }
        /// <summary>
        /// to check weather if player can surrender or not. 
        /// </summary>
        /// <returns>>Returns true if it is currently possible for the player to Stand for the chose Hand; 
        /// otherwise false</returns>
        public static bool CanSurrender() {
            // if the player has one hand with two cards and has not already chosen 'stand'or 'surrender
            if (PlayerHands.Count == 1 && PlayerHands[0].Count == 2 &&
                !PlayerHands[0].IsStanding &&
                !PlayerHands[0].HasSurrendered && PlayerHands[0].Score < 21) {
                return true;
            }
            return false;
        }
        /// <summary>
        /// to check weather if player can split or not. 
        /// This can only be done if the player has two cards in their hand,
        /// each with the same point value (or two aces), and the player can afford to split.
        /// </summary>
        /// <returns>>Returns true if it is currently possible for the player to Split for the chose Hand; 
        /// otherwise false</returns>
        public static bool CanSplit() {
            // if the player has one hand with two cards and they are not standing or surrendered and < 21
            if (PlayerHands.Count == 1 && PlayerHands[0].Count == 2 &&
               !PlayerHands[0].IsStanding &&
               !PlayerHands[0].HasSurrendered && PlayerHands[0].Score < 21) {
                //int firstCardValue;
                if (PlayerHands[0].GetCard(0).FaceValue == PlayerHands[0].GetCard(1).FaceValue) {
                    // both cards are the same (e.g. 10 and 10, Ace and Ace, Jack and Jack)
                    return true;

                } else if ((int)PlayerHands[0].GetCard(0).FaceValue >= 10
                        && (int)PlayerHands[0].GetCard(1).FaceValue >= 10) {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// if the olayer can hit so the player can paly
        /// </summary>
        /// <returns>returns true if the player can play; otherwise false.</returns>
        public static bool CanPlayerPlay() {
            if (CanHit(0) || CanHit(1)) {
                return true;
            }
            return false;
        }
    }
}

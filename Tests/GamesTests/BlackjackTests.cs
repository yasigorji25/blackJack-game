using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Games;
using GameObjects;
using System.ComponentModel;
using System.Reflection;

/*
 * The unit tests described in this file will test your Blackjack code from the
 * Games project.
 * 
 * Running the tests will help you determine whether you have implemented the
 * Blackjack logic correctly. The tests may be used to guide the marking
 * of your submission.
 * 
 * NOTE: The tests will not run until you have completed the method headers
 *       in the Blackjack class as described by the UML diagram.
 * 
 * If there are any errors present in this file, it may be because:
 *     - You have not written all the necessary method headers in Blackjack
 *       as specified by the UML diagram
 *     - You have written the method headers, but they are incorrect in some way
 *       (e.g. misspelled a method name, missing parameters, incorrect access 
 *       modifier etc.)
 *     - You are missing return statements in value-returning methods
 * 
 * At the bottom of this file is the class Scenarios, which can start Blackjack
 * scenarios which otherwise occur rarely during normal play.
 * 
 */

namespace BlackjackTests {
    [TestClass()]
    public class A_Blackjack_Test_UML_Properties {
        [TestMethod()]
        public void Test_DealerHand_HasPublicGet() {
            Assert.IsTrue(typeof(Blackjack).GetProperty("DealerHand").GetGetMethod() != null);
        }

        [TestMethod()]
        public void Test_DealerHand_HasPrivateSet() {
            Assert.IsTrue(typeof(Blackjack).GetProperty("DealerHand").GetSetMethod() == null);
        }

        [TestMethod()]
        public void Test_PlayerHands_HasPublicGet() {
            Assert.IsTrue(typeof(Blackjack).GetProperty("PlayerHands").GetGetMethod() != null);
        }

        [TestMethod()]
        public void Test_PlayerHands_HasPrivateSet() {
            Assert.IsTrue(typeof(Blackjack).GetProperty("PlayerHands").GetSetMethod() == null);
        }

        [TestMethod()]
        public void Test_PlayerFunds_HasPrivateSet() {
            Assert.IsTrue(typeof(Blackjack).GetProperty("PlayerFunds").GetSetMethod() == null);
        }

        [TestMethod()]
        public void Test_PlayerFunds_HasPublicGet() {
            Assert.IsTrue(typeof(Blackjack).GetProperty("PlayerFunds").GetGetMethod() != null);
        }

        [TestMethod()]
        public void Test_Reset_RunsWithoutErrors() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_Reset_CreatesDealerHand() {
            Blackjack.Reset();
            Assert.IsTrue(Blackjack.DealerHand != null && Blackjack.DealerHand.Count == 0);
        }

        [TestMethod()]
        public void Test_Reset_SetsfundsTo1000() {
            Blackjack.Reset();
            Assert.IsTrue(Blackjack.PlayerFunds == 1000);
        }

        [TestMethod()]
        public void Test_Reset_CreatesPlayerListOfHand() {
            Blackjack.Reset();
            Assert.IsTrue(Blackjack.PlayerHands != null);
            Assert.IsTrue(Blackjack.PlayerHands.Count == 0 || Blackjack.PlayerHands[0].Count == 0);
        }
    }

    [TestClass()]
    public class B_Blackjack_Test_NewRound {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_NewRound_RunsWithoutErrors() {
            Blackjack.NewRound(10);
        }

        [TestMethod()]
        public void Test_NewRound_CreatesOnePlayerHandWithTwoCards() {
            Blackjack.NewRound(10);
            Assert.IsTrue(Blackjack.PlayerHands.Count == 1);
            Assert.IsTrue(Blackjack.PlayerHands[0].Count == 2);
        }

        [TestMethod()]
        public void Test_NewRound_CreatesDealerHandWithTwoCards() {
            Blackjack.NewRound(10);
            Assert.IsTrue(Blackjack.DealerHand.Count == 2);
        }

        [TestMethod()]
        public void Test_NewRound_PlayerBetStoredCorrectly() {
            Blackjack.NewRound(10);
            Assert.IsTrue(Blackjack.PlayerHands[0].Bet == 10);

            Blackjack.NewRound(100);
            Assert.IsTrue(Blackjack.PlayerHands[0].Bet == 100);
        }

        [TestMethod()]
        public void Test_NewRound_DealerDoesNotBet() {
            Blackjack.NewRound(10);
            Assert.IsTrue(Blackjack.DealerHand.Bet == 0);

            Blackjack.NewRound(100);
            Assert.IsTrue(Blackjack.DealerHand.Bet == 0);
        }

        [TestMethod(), Timeout(1000)]
        public void Test_NewRound_PlayerfundsReducedByBetAmount() {
            // It's possible that the player's funds will increase if they are 
            // dealt a Blackjack. Therefore, we have to repeat until a 
            // non-Blackjack is dealt. This test times out after 1 second,
            // which is a very reasonable amount time to be sure that 
            // non-Blackjack hands are possible. 

            do {
                Blackjack.Reset();
                Blackjack.NewRound(10);
            } while (Blackjack.PlayerHands[0].Score == 21);
            Assert.IsTrue(Blackjack.PlayerFunds == 990);

            do {
                Blackjack.Reset();
                Blackjack.NewRound(100);
            } while (Blackjack.PlayerHands[0].Score == 21);
            Assert.IsTrue(Blackjack.PlayerFunds == 900);
        }

        [TestMethod()]
        public void Test_NewRound_DeckExists() {
            Blackjack.NewRound(10);

            CardPile deck = Utility.GetDeck();
            Assert.IsTrue(deck != null);
        }

        [TestMethod()]
        public void Test_NewRound_DeckHasCorrectNumCards() {
            Blackjack.NewRound(10);
            CardPile deck = Utility.GetDeck();
            Assert.IsTrue(deck.Count == 48); // 52 -2 for user -2 for dealer;
        }
    }

    [TestClass()]
    public class C_Blackjack_Test_CanHit {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_CanHit_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanHit(0));
        }

        [TestMethod()]
        public void Test_CanHit_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Three));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanHit(0));
        }

        [TestMethod()]
        public void Test_CanHit_IsFalse_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanHit(0));
        }

        [TestMethod()]
        public void Test_CanHit_IsFalse_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanHit(0));
        }

        [TestMethod()]
        public void Test_CanHit_SecondHand_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Four));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsTrue(Blackjack.CanHit(1));
        }

        [TestMethod()]
        public void Test_CanHit_SecondHand_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Ace));
            hand2.AddCard(new Card(Suit.Clubs, FaceValue.Five));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsTrue(Blackjack.CanHit(1));
        }

        [TestMethod()]
        public void Test_CanHit_SecondHand_IsFalse_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Five));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Six));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanHit(1));
        }

        [TestMethod()]
        public void Test_CanHit_SecondHand_IsFalse_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Ace));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanHit(1));
        }

        [TestMethod()]
        public void Test_CanHit_IsFalse__AlreadyStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            hand1.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanHit(0));
        }

        [TestMethod()]
        public void Test_CanHit_SecondHand_IsFalse__AlreadyStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Four));
            hand2.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanHit(1));
        }
    }

    [TestClass()]
    public class D_Blackjack_Test_CanDouble {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_CanDouble_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanDouble(0));
        }

        [TestMethod()]
        public void Test_CanDouble_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Three));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanDouble(0));
        }

        [TestMethod()]
        public void Test_CanDouble_IsFalse_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanDouble(0));
        }

        [TestMethod()]
        public void Test_CanDouble_IsFalse_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanDouble(0));
        }

        [TestMethod()]
        public void Test_CanDouble_SecondHand_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Four));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsTrue(Blackjack.CanDouble(1));
        }

        [TestMethod()]
        public void Test_CanDouble_SecondHand_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Ace));
            hand2.AddCard(new Card(Suit.Clubs, FaceValue.Five));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsTrue(Blackjack.CanDouble(1));
        }

        [TestMethod()]
        public void Test_CanDouble_SecondHand_IsFalse_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Five));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Six));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanDouble(1));
        }

        [TestMethod()]
        public void Test_CanDouble_SecondHand_IsFalse_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Ace));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanDouble(1));
        }

        [TestMethod()]
        public void Test_CanDouble_IsFalse__AlreadyStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            hand1.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanDouble(0));
        }

        [TestMethod()]
        public void Test_CanDouble_SecondHand_IsFalse__AlreadyStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Four));
            hand2.HasSurrendered = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanDouble(1));
        }
    }

    [TestClass()]
    public class E_Blackjack_Test_CanSplit {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_CanSplit_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanSplit());
        }

        [TestMethod()]
        public void Test_CanSplit_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ten));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanSplit());
        }

        [TestMethod()]
        public void Test_CanSplit_IsTrue_Example3() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Six));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Six));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanSplit());
        }

        [TestMethod()]
        public void Test_CanSplit_IsTrue_Example4() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanSplit());
        }

        [TestMethod()]
        public void Test_CanSplit_IsFalse_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Two));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanSplit());
        }

        [TestMethod()]
        public void Test_CanSplit_IsFalse_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Two));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Two));
            hand1.AddCard(new Card(Suit.Spades, FaceValue.Two));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanSplit());
        }

        [TestMethod()]
        public void Test_CanSplit_IsFalse_Example3() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Two));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanSplit());
        }

        [TestMethod()]
        public void Test_CanSplit_IsFalse_Example4() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanSplit());
        }

        [TestMethod()]
        public void Test_CanSplit_IsFalse_Example5() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Hearts, FaceValue.King));
            hand1.AddCard(new Card(Suit.Spades, FaceValue.Ace));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanSplit());
        }

        [TestMethod()]
        public void Test_CanSplit_IsFalse__AlreadyStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            hand1.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanSplit());
        }
    }

    [TestClass()]
    public class F_Blackjack_Test_CanStand {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_CanStand_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanStand(0));
        }

        [TestMethod()]
        public void Test_CanStand_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Three));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanStand(0));
        }

        [TestMethod()]
        public void Test_CanStand_IsFalse_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanStand(0));
        }

        [TestMethod()]
        public void Test_CanStand_IsFalse_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanStand(0));
        }

        [TestMethod()]
        public void Test_CanStand_SecondHand_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Four));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsTrue(Blackjack.CanStand(1));
        }

        [TestMethod()]
        public void Test_CanStand_SecondHand_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Ace));
            hand2.AddCard(new Card(Suit.Clubs, FaceValue.Five));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsTrue(Blackjack.CanStand(1));
        }

        [TestMethod()]
        public void Test_CanStand_SecondHand_IsFalse_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Five));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Six));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanStand(1));
        }

        [TestMethod()]
        public void Test_CanStand_SecondHand_IsFalse_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Ace));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanStand(1));
        }

        [TestMethod()]
        public void Test_CanStand_IsFalse__AlreadyStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            hand1.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanStand(0));
        }

        [TestMethod()]
        public void Test_CanStand_SecondHand_IsFalse__AlreadyStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Seven));
            hand2.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Assert.IsFalse(Blackjack.CanStand(1));
        }
    }

    [TestClass()]
    public class G_Blackjack_Test_CanSurrender {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_CanSurrender_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanSurrender());
        }

        [TestMethod()]
        public void Test_CanSurrender_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsTrue(Blackjack.CanSurrender());
        }

        [TestMethod()]
        public void Test_CanSurrender_IsFalse_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanSurrender());
        }

        [TestMethod()]
        public void Test_CanSurrender_IsFalse_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanSurrender());
        }

        [TestMethod()]
        public void Test_CanSurrender_IsFalse__AlreadyStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Three));
            hand1.IsStanding = true;
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Assert.IsFalse(Blackjack.CanSurrender());
        }
    }

    [TestClass()]
    public class H_Blackjack_Test_Hit {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_Hit_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Two));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Eight));

            // hit
            Blackjack.Hit(0);
            Assert.IsTrue(deck.Count == 0);
            Assert.IsTrue(hand1.Count == 3);
            Assert.IsTrue(hand1.GetCard(2).Equals(new Card(Suit.Clubs, FaceValue.Eight)));
        }

        [TestMethod()]
        public void Test_Hit_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Spades, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Hearts, FaceValue.Ace));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            List<Card> cards = new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Ace),
                new Card(Suit.Diamonds, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Clubs, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Hearts, FaceValue.Three),
                new Card(Suit.Clubs, FaceValue.Three)
            };

            // hit player with all the cards above, reaching the maximum possible hand (11 cards)
            foreach (Card card in cards) {
                deck.AddCard(card);
                Blackjack.Hit(0);
            }

            Assert.AreEqual(0, deck.Count); // deck should be empty
            Assert.IsTrue(hand1.Count == 11); // player should have 11 cards
            foreach (Card card in cards) {
                Assert.IsTrue(hand1.ContainsCard(card)); // cards should be the same cards dealt
            }
        }

        [TestMethod()]
        public void Test_Hit__21CausesAutomaticStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Six));

            // hit
            Blackjack.Hit(0);
            Assert.IsTrue(hand1.IsStanding);
        }

        [TestMethod()]
        public void Test_Hit__Over21CausesAutomaticStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Eight));

            // hit
            Blackjack.Hit(0);
            Assert.IsTrue(hand1.IsStanding);
        }

        [TestMethod()]
        public void Test_Hit__LowerNumDoesNotCauseAutomaticStanding() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Five));

            // hit
            Blackjack.Hit(0);
            Assert.IsFalse(hand1.IsStanding);
        }
    }

    [TestClass()]
    public class I_Blackjack_Test_Double {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_Double_Example_1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Three));

            Blackjack.Double(0);
            Assert.IsTrue(hand1.IsStanding);             // automatic standing
            Assert.AreEqual(3, hand1.Count);             // added card
            Assert.AreEqual(20, hand1.Bet);              // doubled bet
            Assert.AreEqual(980, Blackjack.PlayerFunds); // subtracted bet
        }

        [TestMethod()]
        public void Test_Double_Example_2() {
            // start round
            Blackjack.NewRound(20);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Two));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Two));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Three));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Three));

            Blackjack.Double(0);
            Assert.IsTrue(hand1.IsStanding);             // automatic standing
            Assert.AreEqual(4, hand1.Count);             // added card
            Assert.AreEqual(40, hand1.Bet);              // doubled bet
            Assert.AreEqual(960, Blackjack.PlayerFunds); // subtracted bet
        }

        [TestMethod()]
        public void Test_Double_SecondHand_Example_1() {
            // start round
            Blackjack.NewRound(40);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Two));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Two));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Three));
            BlackjackHand hand2 = new BlackjackHand(20);
            hand2.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Three));

            Blackjack.Double(1);
            Assert.IsTrue(hand2.IsStanding);             // automatic standing
            Assert.AreEqual(3, hand2.Count);             // added card
            Assert.AreEqual(40, hand2.Bet);              // doubled bet
            Assert.AreEqual(20, hand1.Bet);              // other hand's bet remains the same
            Assert.AreEqual(940, Blackjack.PlayerFunds); // subtracted bet
        }

        [TestMethod()]
        public void Test_Double_SecondHand_Example_2() {
            // start round
            Blackjack.NewRound(50);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            BlackjackHand hand2 = new BlackjackHand(30);
            hand2.AddCard(new Card(Suit.Clubs, FaceValue.Two));
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.Two));
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.Three));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Three));

            Blackjack.Double(1);
            Assert.IsTrue(hand2.IsStanding);             // automatic standing
            Assert.AreEqual(4, hand2.Count);             // added card
            Assert.AreEqual(60, hand2.Bet);              // doubled bet
            Assert.AreEqual(20, hand1.Bet);              // other hand's bet remains the same
            Assert.AreEqual(920, Blackjack.PlayerFunds); // subtracted bet
        }
    }

    [TestClass()]
    public class J_Blackjack_Test_Split {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_Split_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ten));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Three));
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Four));

            Blackjack.Split();

            Assert.AreEqual(2, Blackjack.PlayerHands.Count);     // two hands
            Assert.AreEqual(2, Blackjack.PlayerHands[0].Count);  // two cards in first hand
            Assert.AreEqual(2, Blackjack.PlayerHands[1].Count);  // two cards in second hand
            Assert.AreEqual(10, Blackjack.PlayerHands[0].Bet);   // bet unchanged
            Assert.AreEqual(10, Blackjack.PlayerHands[1].Bet);   // split hand matches bet
            Assert.AreEqual(980, Blackjack.PlayerFunds);         // funds reduced by bet
            Assert.AreEqual(0, deck.Count);                      // drew two cards so deck is now empty
            Assert.IsFalse(Blackjack.PlayerHands[0].IsStanding); // hand should not be standing
            Assert.IsFalse(Blackjack.PlayerHands[1].IsStanding); // hand should not be standing
        }

        [TestMethod()]
        public void Test_Split_Example2() {
            // start round
            Blackjack.NewRound(20);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Spades, FaceValue.Four));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Four));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Three));
            deck.AddCard(new Card(Suit.Clubs, FaceValue.Four));

            Blackjack.Split();

            Assert.AreEqual(2, Blackjack.PlayerHands.Count);     // two hands
            Assert.AreEqual(2, Blackjack.PlayerHands[0].Count);  // two cards in first hand
            Assert.AreEqual(2, Blackjack.PlayerHands[1].Count);  // two cards in second hand
            Assert.AreEqual(20, Blackjack.PlayerHands[0].Bet);   // bet unchanged
            Assert.AreEqual(20, Blackjack.PlayerHands[1].Bet);   // split hand matches bet
            Assert.AreEqual(960, Blackjack.PlayerFunds);         // funds reduced by bet
            Assert.AreEqual(0, deck.Count);                      // drew two cards so deck is now empty
            Assert.IsFalse(Blackjack.PlayerHands[0].IsStanding); // hand should not be standing
            Assert.IsFalse(Blackjack.PlayerHands[1].IsStanding); // hand should not be standing
        }
    }

    [TestClass()]
    public class K_Blackjack_Test_Stand {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_CanStand_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Blackjack.Stand(0);
            Assert.IsTrue(hand1.IsStanding);
        }

        [TestMethod()]
        public void Test_CanStand_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Three));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Blackjack.Stand(0);
            Assert.IsTrue(hand1.IsStanding);
        }

        [TestMethod()]
        public void Test_CanStand_SecondHand_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Four));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Blackjack.Stand(1);
            Assert.IsFalse(hand1.IsStanding);
            Assert.IsTrue(hand2.IsStanding);
        }

        [TestMethod()]
        public void Test_CanStand_SecondHand_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Ace));
            hand2.AddCard(new Card(Suit.Clubs, FaceValue.Five));

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            Blackjack.Stand(1);
            Assert.IsFalse(hand1.IsStanding);
            Assert.IsTrue(hand2.IsStanding);
        }
    }

    [TestClass()]
    public class L_Blackjack_Test_Surrender {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_CanSurrender_IsTrue_Example1() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.King));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Blackjack.Surrender();
            Assert.IsTrue(Blackjack.PlayerHands[0].IsStanding);
            Assert.IsTrue(Blackjack.PlayerHands[0].HasSurrendered);
        }

        [TestMethod()]
        public void Test_CanSurrender_IsTrue_Example2() {
            // start round
            Blackjack.NewRound(10);

            // replace player hand
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            Blackjack.Surrender();
            Assert.IsTrue(Blackjack.PlayerHands[0].IsStanding);
            Assert.IsTrue(Blackjack.PlayerHands[0].HasSurrendered);
        }
    }

    [TestClass()]
    public class M_Blackjack_Test_DealerPlay {
        [TestInitialize]
        public void BeforeTests() {
            Blackjack.Reset();
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Loses() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Two));

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Spades, FaceValue.Six));
            deck.AddCard(new Card(Suit.Spades, FaceValue.Four));

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(3, Blackjack.DealerHand.Count); // dealer should draw the Six to reach 18
            Assert.IsTrue(Blackjack.DealerHand.GetCard(2).Equals(new Card(Suit.Spades, FaceValue.Six)));
            Assert.AreEqual(990, Blackjack.PlayerFunds); // funds taken from player
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(Blackjack.Result.Lost, results[0]);
        }

        [TestMethod()]
        public void Test_DealerPlay_Push() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Two));

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Spades, FaceValue.Five));
            deck.AddCard(new Card(Suit.Spades, FaceValue.Four));

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(3, Blackjack.DealerHand.Count); // dealer should draw the Five to reach 17
            Assert.IsTrue(Blackjack.DealerHand.GetCard(2).Equals(new Card(Suit.Spades, FaceValue.Five)));
            Assert.AreEqual(1000, Blackjack.PlayerFunds); // funds returned to player
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(Blackjack.Result.Push, results[0]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Wins() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Eight));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Two));

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Spades, FaceValue.Five));
            deck.AddCard(new Card(Suit.Spades, FaceValue.Four));

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(3, Blackjack.DealerHand.Count); // dealer should draw the Five to reach 17
            Assert.IsTrue(Blackjack.DealerHand.GetCard(2).Equals(new Card(Suit.Spades, FaceValue.Five)));
            Assert.AreEqual(1010, Blackjack.PlayerFunds); // player wins bet
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(Blackjack.Result.Won, results[0]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Wins_DealerBust() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Eight));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Two));

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Spades, FaceValue.Ten));
            deck.AddCard(new Card(Suit.Spades, FaceValue.Four));

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(3, Blackjack.DealerHand.Count); // dealer should draw the Ten to reach 22 (bust)
            Assert.IsTrue(Blackjack.DealerHand.GetCard(2).Equals(new Card(Suit.Spades, FaceValue.Ten)));
            Assert.AreEqual(1010, Blackjack.PlayerFunds); // player wins bet
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(Blackjack.Result.Won, results[0]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Loses_Bust() {
            // start round
            Blackjack.NewRound(10);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(10);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Eight));
            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Two));

            // replace deck
            CardPile deck = Utility.GetDeck();
            deck.DealCards(deck.Count);
            deck.AddCard(new Card(Suit.Spades, FaceValue.Ten));

            Blackjack.Hit(0); // player should go bust
            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(2, Blackjack.DealerHand.Count); // dealer should not draw anything
            Assert.AreEqual(990, Blackjack.PlayerFunds);    // player loses bet
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(Blackjack.Result.Bust, results[0]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Wins_SecondHand_Loses() {
            // start round
            Blackjack.NewRound(40);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Eight));
            hand1.IsStanding = true;

            BlackjackHand hand2 = new BlackjackHand(20);
            hand2.AddCard(new Card(Suit.Spades, FaceValue.King));
            hand2.AddCard(new Card(Suit.Spades, FaceValue.Six));
            hand2.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Seven)); // 17

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(1000, Blackjack.PlayerFunds);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(Blackjack.Result.Won, results[0]);
            Assert.AreEqual(Blackjack.Result.Lost, results[1]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Loses_SecondHand_Loses() {
            // start round
            Blackjack.NewRound(40);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Six));
            hand1.IsStanding = true;

            BlackjackHand hand2 = new BlackjackHand(20);
            hand2.AddCard(new Card(Suit.Spades, FaceValue.King));
            hand2.AddCard(new Card(Suit.Spades, FaceValue.Six));
            hand2.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Seven)); // 17

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(960, Blackjack.PlayerFunds);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(Blackjack.Result.Lost, results[0]);
            Assert.AreEqual(Blackjack.Result.Lost, results[1]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Loses_SecondHand_Wins() {
            // start round
            Blackjack.NewRound(50);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(30);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Six));
            hand1.IsStanding = true;

            BlackjackHand hand2 = new BlackjackHand(20);
            hand2.AddCard(new Card(Suit.Spades, FaceValue.King));
            hand2.AddCard(new Card(Suit.Spades, FaceValue.Nine));
            hand2.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Seven)); // 17

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(990, Blackjack.PlayerFunds);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(Blackjack.Result.Lost, results[0]);
            Assert.AreEqual(Blackjack.Result.Won, results[1]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Wins_SecondHand_Wins() {
            // start round
            Blackjack.NewRound(30);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Eight));
            hand1.IsStanding = true;

            BlackjackHand hand2 = new BlackjackHand(10);
            hand2.AddCard(new Card(Suit.Spades, FaceValue.King));
            hand2.AddCard(new Card(Suit.Spades, FaceValue.Eight));
            hand2.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Seven)); // 17

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(1030, Blackjack.PlayerFunds);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(Blackjack.Result.Won, results[0]);
            Assert.AreEqual(Blackjack.Result.Won, results[1]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Wins_SecondHand_Push() {
            // start round
            Blackjack.NewRound(40);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Eight));
            hand1.IsStanding = true;

            BlackjackHand hand2 = new BlackjackHand(20);
            hand2.AddCard(new Card(Suit.Spades, FaceValue.King));
            hand2.AddCard(new Card(Suit.Spades, FaceValue.Seven));
            hand2.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Seven)); // 17

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(1020, Blackjack.PlayerFunds);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(Blackjack.Result.Won, results[0]);
            Assert.AreEqual(Blackjack.Result.Push, results[1]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Loses_SecondHand_Push() {
            // start round
            Blackjack.NewRound(40);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Four));
            hand1.IsStanding = true;

            BlackjackHand hand2 = new BlackjackHand(20);
            hand2.AddCard(new Card(Suit.Spades, FaceValue.King));
            hand2.AddCard(new Card(Suit.Spades, FaceValue.Seven));
            hand2.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Seven)); // 17

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(980, Blackjack.PlayerFunds);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(Blackjack.Result.Lost, results[0]);
            Assert.AreEqual(Blackjack.Result.Push, results[1]);
        }

        [TestMethod()]
        public void Test_DealerPlay_FirstHand_Push_SecondHand_Push() {
            // start round
            Blackjack.NewRound(40);

            // replace player hands
            BlackjackHand hand1 = new BlackjackHand(20);
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.King));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Seven));
            hand1.IsStanding = true;

            BlackjackHand hand2 = new BlackjackHand(20);
            hand2.AddCard(new Card(Suit.Spades, FaceValue.King));
            hand2.AddCard(new Card(Suit.Spades, FaceValue.Seven));
            hand2.IsStanding = true;

            Blackjack.PlayerHands.Clear();
            Blackjack.PlayerHands.Add(hand1);
            Blackjack.PlayerHands.Add(hand2);

            // replace dealer hand
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.RemoveCardAt(0);
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Jack));
            Blackjack.DealerHand.AddCard(new Card(Suit.Hearts, FaceValue.Seven)); // 17

            List<Blackjack.Result> results = Blackjack.DealerPlay();

            Assert.AreEqual(1000, Blackjack.PlayerFunds);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(Blackjack.Result.Push, results[0]);
            Assert.AreEqual(Blackjack.Result.Push, results[1]);
        }
    }

    static class Utility {
        public static void SetDeck(CardPile newDeck) {
            CardPile originalDeck = GetDeck();
            originalDeck = newDeck;
        }

        public static CardPile GetDeck() {
            return (CardPile)(typeof(Blackjack).GetField("_deck", BindingFlags.NonPublic | BindingFlags.Static).GetValue(new object()));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GameObjects;

namespace BlackjackHandTests {
    [TestClass()]
    public class A_BlackjackHand_Tests {
        [TestMethod()]
        public void Test_BlackjackHand_Constructor_RunsWithoutErrors() {
            BlackjackHand hand1 = new BlackjackHand();
            BlackjackHand hand2 = new BlackjackHand(10);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Constructor_SetsUpBet() {
            BlackjackHand hand1 = new BlackjackHand(20);
            BlackjackHand hand2 = new BlackjackHand(40);
            Assert.AreEqual(20, hand1.Bet);
            Assert.AreEqual(40, hand2.Bet);
        }

        [TestMethod()]
        public void Test_BlackjackHand_InitiallyNotStandingOrSurrendered() {
            BlackjackHand hand1 = new BlackjackHand();
            Assert.IsFalse(hand1.IsStanding);
            Assert.IsFalse(hand1.HasSurrendered);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example1() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Two));
            Assert.AreEqual(2, hand1.Score);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example2() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ten));
            Assert.AreEqual(10, hand1.Score);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example3() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Jack));

            BlackjackHand hand2 = new BlackjackHand();
            hand2.AddCard(new Card(Suit.Hearts, FaceValue.Queen));

            BlackjackHand hand3 = new BlackjackHand();
            hand3.AddCard(new Card(Suit.Spades, FaceValue.King));

            Assert.AreEqual(10, hand1.Score);
            Assert.AreEqual(10, hand2.Score);
            Assert.AreEqual(10, hand3.Score);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example4() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Two));
            Assert.AreEqual(13, hand1.Score);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example5() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Jack));
            Assert.AreEqual(21, hand1.Score);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example6() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Four));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Seven));
            Assert.AreEqual(12, hand1.Score);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example7() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Hearts, FaceValue.Ace));
            Assert.AreEqual(12, hand1.Score);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example8() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Five));
            hand1.AddCard(new Card(Suit.Hearts, FaceValue.Ace));
            Assert.AreEqual(17, hand1.Score);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example9() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Spades, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Hearts, FaceValue.Ace));
            Assert.AreEqual(13, hand1.Score);
        }

        [TestMethod()]
        public void Test_BlackjackHand_Score_Example10() {
            BlackjackHand hand1 = new BlackjackHand();
            hand1.AddCard(new Card(Suit.Diamonds, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Spades, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Hearts, FaceValue.Ace));
            hand1.AddCard(new Card(Suit.Clubs, FaceValue.Ace));
            Assert.AreEqual(14, hand1.Score);
        }
    }
}

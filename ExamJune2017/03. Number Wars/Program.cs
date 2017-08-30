using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Number_Wars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var firstPlayerInput = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var secondPlayerInput = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Queue<Card> firstPlayerCards = AddPlayerCards(firstPlayerInput);
            Queue<Card> secondPlayerCards = AddPlayerCards(secondPlayerInput);
            bool gameOver = false;
            bool IsDraw = false;
            int turns = 0;
            string playerWinner = string.Empty;
            var deck = new HashSet<Card>();

            while (gameOver == false)
            {
                Card firstPlayerCard = firstPlayerCards.Dequeue();
                Card secondPlayerCard = secondPlayerCards.Dequeue();

                deck.Add(firstPlayerCard);
                deck.Add(secondPlayerCard);

                if (firstPlayerCard.Number > secondPlayerCard.Number)
                {
                    TransferCardsFromDeckToPerson(firstPlayerCards, deck);
                }
                else if (firstPlayerCard.Number < secondPlayerCard.Number)
                {
                    TransferCardsFromDeckToPerson(secondPlayerCards, deck);
                }
                else
                {
                    bool thereIsWinner = false;

                    while (thereIsWinner == false)
                    {
                        Card[] fpCards = new Card[3].ToArray();

                        if (firstPlayerCards.Count < 3)
                        {
                            for (int i = 0; i < firstPlayerCards.Count; i++)
                            {
                                fpCards[i] = firstPlayerCards.Dequeue();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                fpCards[i] = firstPlayerCards.Dequeue();
                            }
                        }


                        Card[] spCards = new Card[3].ToArray();

                        if (secondPlayerCards.Count < 3)
                        {
                            for (int i = 0; i < secondPlayerCards.Count; i++)
                            {
                                spCards[i] = secondPlayerCards.Dequeue();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                spCards[i] = secondPlayerCards.Dequeue();
                            }
                        }


                        for (int i = 0; i < fpCards.Length; i++)
                        {
                            deck.Add(fpCards[i]);
                        }
                        for (int i = 0; i < spCards.Length; i++)
                        {
                            deck.Add(spCards[i]);
                        }


                        int firstPlayerSum = fpCards.Sum(c => c.LetterValue);
                        int secondPlayerSum = spCards.Sum(c => c.LetterValue);

                        if (firstPlayerSum > secondPlayerSum)
                        {
                            TransferCardsFromDeckToPerson(firstPlayerCards, deck);
                            thereIsWinner = true;
                        }
                        else if (firstPlayerSum < secondPlayerSum)
                        {
                            TransferCardsFromDeckToPerson(secondPlayerCards, deck);
                            thereIsWinner = true;
                        }
                        if (firstPlayerCards.Count == 0 && secondPlayerCards.Count == 0)
                        {
                            thereIsWinner = true;
                            gameOver = true;
                            IsDraw = true;
                        }
                    }
                }

                if (firstPlayerCards.Count == 0)
                {
                    gameOver = true;
                    playerWinner = "Second";
                }
                else if (secondPlayerCards.Count == 0)
                {
                    gameOver = true;
                    playerWinner = "First";
                }



                turns++;

                if (turns == 1000000)
                {
                    if (secondPlayerCards.Count > firstPlayerCards.Count)
                    {
                        gameOver = true;
                        playerWinner = "Second";
                    }
                    else
                    {
                        gameOver = true;
                        playerWinner = "First";
                    }
                }
            }
            if (IsDraw)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (playerWinner == "First")
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
        }

        private static void TransferCardsFromDeckToPerson(Queue<Card> firstPlayerCards,
            HashSet<Card> deck)
        {
            foreach (var card in deck.OrderByDescending(c => c.Number).ThenByDescending(c => c.LetterValue))
            {
                firstPlayerCards.Enqueue(card);
            }
            deck.Clear();
        }


        private static Queue<Card> AddPlayerCards(string[] playerInput)
        {
            Queue<Card> cards = new Queue<Card>();

            foreach (var cardInput in playerInput)
            {
                int number = int.Parse(cardInput.Substring(0, cardInput.Length - 1));
                char letter = char.Parse(cardInput[cardInput.Length - 1].ToString());

                cards.Enqueue(new Card(number, letter));
            }

            return cards;
        }
    }

    public class Card
    {
        public Card(int number, char letter)
        {
            Number = number;
            LetterValue = char.ToUpper(letter) - 64;
        }

        public int Number { get; set; }
        public int LetterValue { get; set; }
    }
}

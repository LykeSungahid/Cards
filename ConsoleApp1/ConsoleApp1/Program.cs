using System;
using System.Collections.Generic;

namespace ConsoleCardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            int menuOption = 0;
            do
            {
                Console.WriteLine("Please select an option from the menu:");
                Console.WriteLine("1. Create Deck");
                Console.WriteLine("2. Shuffle Deck");
                Console.WriteLine("3. Deal Cards");
                Console.WriteLine("4. Display Deck");
                Console.WriteLine("5. Exit");
                menuOption = Convert.ToInt32(Console.ReadLine());

                switch (menuOption)
                {
                    case 1:
                        deck.Create();
                        Console.WriteLine("Deck created successfully!");
                        break;
                    case 2:
                        deck.Shuffle();
                        Console.WriteLine("Deck shuffled successfully!");
                        break;
                    case 3:
                        Console.WriteLine("How many cards do you want to deal?");
                        int numberOfCards = Convert.ToInt32(Console.ReadLine());
                        deck.Deal(numberOfCards);
                        break;
                    case 4:
                        deck.Display();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        break;
                }
            } while (menuOption != 5);
        }
    }

    class Deck
    {
        private List<string> deck;
        private List<string> suits = new List<string>
        {
            "Cloves",
            "Diamonds",
            "Hearts",
            "Spades"
        };
        private List<string> ranks = new List<string>
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Ace", "Jack", "Queen", "King"
        };

        public Deck()
        {
            deck = new List<string>();
        }

        public void Create()
        {
            deck.Clear();
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(rank + " of " + suit);
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        public void Deal(int numberOfCards)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                if (deck.Count > 0)
                {
                    Console.WriteLine(deck[deck.Count - 1]);
                    deck.RemoveAt(deck.Count - 1);
                }
                else
                {
                    Console.WriteLine("No more cards left in the deck!");
                    break;
                }
            }
        }

        public void Display()
        {
            Console.WriteLine("Cards in deck: ");
            foreach (var card in deck)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine("Number of cards remaining: " + deck.Count);
        }
    }
}
using System;
using System.Collections.Generic;

namespace CardGames{
    public class solitaire
    {

        public List<Card> deck = new List<Card>();

        //holds all the 7 fields for cards to be placed going left-to-right on indexes 0-6
        public List<List<Card>> fields = new List<List<Card>>();

        public void SetUp(){
            
            CreateDeck();

            //Giving it a good shuffle
            for(int i = 0; i < 6; i++)
                ShuffleDeck();
           
            InitializeFieldLists();

            SetFields();

            //PrintCardsInFileds();
            //PrintCardsInDeck();
        }

        private void CreateDeck()
        {
            for(int i = 1; i < 14; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    switch(j){
                        case 0:     //Hearts
                        deck.Add(new Card(i, Card.Suit.Hearts, Card.Color.Red));
                        break;
                        case 1:     //Diamonds
                        deck.Add(new Card(i, Card.Suit.Diamonds, Card.Color.Red));
                        break;
                        case 2:     //Spades
                        deck.Add(new Card(i, Card.Suit.Spades, Card.Color.Black));
                        break;
                        case 3:     //Club
                        deck.Add(new Card(i, Card.Suit.Clubs, Card.Color.Black));
                        break;
                    }
                }
            }
        }

        private void ShuffleDeck()
        {
            Random random = new Random();
            for(int i = 0; i < deck.Count; i++){
                int randIndex = i + random.Next(deck.Count - i);
                //making sure index doesn't go out of list bounds
                if(randIndex == deck.Count)
                    continue;
                Card temp = deck[randIndex];
                deck[randIndex] = deck[i];
                deck[i] = temp;
            }
        }
    
        //places cards into each field
        private void SetFields(){
            for(int i = 0; i < fields.Count; i++){
                switch(i){
                    case 0:
                    for(int j = 0; j < fields.Count; j++)
                        SetCard(fields[j]);
                    break;
                    case 1:
                    for(int j = 1; j < fields.Count; j++)
                        SetCard(fields[j]);
                    break;
                    case 2:
                    for(int j = 2; j < fields.Count; j++)
                        SetCard(fields[j]);
                    break;
                    case 3:
                    for(int j = 3; j < fields.Count; j++)
                        SetCard(fields[j]);
                    break;
                    case 4:
                    for(int j = 4; j < fields.Count; j++)
                        SetCard(fields[j]);
                    break;
                    case 5:
                    for(int j = 5; j < fields.Count; j++)
                        SetCard(fields[j]);
                    break;
                    case 6:
                    for(int j = 6; j < fields.Count; j++)
                        SetCard(fields[j]);
                    break;
                }
            }
        }

        //makes 7 fileds for cards to be played from
        private void InitializeFieldLists(){
            for(int i = 0; i < 7 ; i++)
                fields.Add(new List<Card>());
        }

        //places the top card of the deck onto given field
        private void SetCard(List<Card> field){
            if(deck[0] != null){
                field.Add(deck[0]);
                deck.RemoveAt(0);
            }
        }
    
        //prints each card in each field, for debugging purposes if needed
        private void PrintCardsInFileds(){
            for(int i = 0; i < fields.Count; i++){
                Console.WriteLine("There are " + fields[i].Count + " cards in field " + i);
                for(int j = 0; j < fields[i].Count; j++)
                    Console.WriteLine("In field " + i + " there is a " + fields[i][j].color + " " + fields[i][j].value + " of " + fields[i][j].suit + ".");
                Console.WriteLine();
            }        
        }

        //prints each card in the deck, for debugging purposes if needed
        private void PrintCardsInDeck(){
            Console.WriteLine("There are " + deck.Count + " cards in the deck");
            for(int i = 0; i < deck.Count; i++)
                Console.WriteLine("There is a " + deck[i].color + " " + deck[i].value + " of " + deck[i].suit + ".");       
            Console.WriteLine(); 
        }    
    }
}

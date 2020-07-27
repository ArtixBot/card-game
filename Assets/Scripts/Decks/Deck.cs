using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// At start of combat, create a copy of the player's deck and shuffle the copy.
public class Deck
{    
    // For reference, let index 0 be the topmost card.
    public List<AbstractCard> deck;

    // Shuffles the deck.
    public void Shuffle(){
        System.Random rng = new System.Random();
        int n = this.deck.Count;
        while (n > 1){
            n--;
            int k = rng.Next(n + 1);
            AbstractCard card = this.deck[k];

            this.deck[k] = this.deck[n];
            this.deck[n] = card;
        }
    }

    // Returns deck size.
    public int GetSize(){
        return this.deck.Count;
    }

    // Returns the top card of the deck. If NULL, then the deck's empty.
    public AbstractCard GetTopCard(){
        return this.deck[0];
    }

    // Returns the top card of the deck and removes it from the list. If NULL is returned, the deck is empty.
    public AbstractCard PopTopCard(){
        if (this.deck.Count != 0){
            AbstractCard card = this.deck[0];
            this.deck.RemoveAt(0);
            return card;
        }
        return null;
    }

    // Returns the entire deck.
    public List<AbstractCard> GetDeckList(){
        return this.deck;
    }

    // Returns the top <X> cards of the deck. If <X> exceeds decksize, only <decksize> cards are returned.
    public List<AbstractCard> GetTopXCards(int count){
        return this.deck.Take(count).ToList();  // If we try to get top 20 cards or whatever, but current deck size is 4, then just 4 elements will be returned.
    }

    // Returns the number of cards which match the argument's ID.
    public int CountOfCard(AbstractCard card){
        int count = 0;
        for (int i = 0; i < this.deck.Count; i++){
            if (card.ID == this.deck[i].ID){
                count++;
            }
        }
        return count;
    }
}

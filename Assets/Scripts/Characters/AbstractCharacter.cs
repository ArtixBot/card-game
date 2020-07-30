using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacter : MonoBehaviour
{
    public string NAME;     // Character name

    public int maxHP;
    public int curHP;
    
    public int drawModifier = 0;        // Default: At end of turn, draw 5 + <drawModifier>.

    public int maxAP;   // action points
    public int curAP;

    public Deck battleDeck = new Deck();        // The "permanent deck" of a character. At the start of combat, deep-copy the contents of this deck to drawPile, shuffle drawPile, then draw <X> cards from it.

    public List<AbstractCard> hand = new List<AbstractCard>();
    private Deck drawPile = new Deck();
    private Deck discardPile = new Deck();

    public void Draw(int numOfCards){
        int i = numOfCards;
        while (i > 0){
            if (drawPile.GetSize() == 0 && discardPile.GetSize() == 0){
                // Special case where the draw pile and discard pile are both empty and therefore remaining draws cannot occur.
                return;
            } else if (drawPile.GetSize() == 0){
                // Draw pile is empty; deep-copy contents of discard pile to draw pile and shuffle the draw pile, then clear out the discard pile.
                drawPile.deck.AddRange(discardPile.deck);
                drawPile.Shuffle();
                discardPile.deck.Clear();
            }
            hand.Add(drawPile.PopTopCard());
            i--;
        }
        return;
    }

    public void DiscardHand(){
        // Backwards iteration lets us safely remove things from hand without messing up indices.
        for (int i = this.hand.Count - 1; i >= 0; i++){
            // TODO: Handle retain properties
            this.discardPile.AddCard(this.hand[i]);  // Add the card to the discard pile first.
            this.hand.RemoveAt(i);              // Then actually remove it from the hand.
        }
        return;
    }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}

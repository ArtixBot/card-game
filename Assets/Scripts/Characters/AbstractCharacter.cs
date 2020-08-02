using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacter
{
    public string NAME;     // Character name

    public int maxHP;
    public int curHP;
    
    public int drawModifier = 0;        // Default: At end of turn, draw 5 + <drawModifier>.
    
    // Damage formula: ((CardAttackDamage + self.damageMod) * self.damageMul) + target.damageTakenMod) * target.damageTakenMul
    public float damageDealtMul = 1.0f;     // Multiplicative modifier for damage dealt.
    public int damageDealtMod = 0;          // Additive modifier for damage dealt.
    public float damageTakenMul = 1.0f;     // Multiplicative modifier for damage taken.
    public int damageTakenMod = 0;          // Additive modifier for damage taken.

    public int maxAP;   // action points
    public int curAP;

    public Deck battleDeck = new Deck();        // The "permanent deck" of a character. At the start of combat, deep-copy the contents of this deck to drawPile, shuffle drawPile, then draw <X> cards from it.

    public List<AbstractCard> hand = new List<AbstractCard>();
    protected Deck drawPile = new Deck();
    protected Deck discardPile = new Deck();

    public void Draw(int numOfCards){
        int i = numOfCards;
        while (i > 0){
            if (drawPile.GetSize() == 0 && discardPile.GetSize() == 0){
                // Special case where the draw pile and discard pile are both empty and therefore remaining draws cannot occur.
                return;
            } else if (drawPile.GetSize() == 0){
                // Draw pile is empty; copy all card references from discard pile to draw pile and shuffle the draw pile, then clear out the discard pile.
                drawPile.deck.AddRange(discardPile.deck);
                drawPile.Shuffle();
                discardPile.deck.Clear();
            }
            hand.Add(drawPile.PopTopCard());
            i--;
        }
        return;
    }

    public List<AbstractCard> GetHand(){
        return this.hand;
    }
    
    public void DiscardHand(){
        // Backwards iteration lets us safely remove things from hand without messing up indices.
        for (int i = this.hand.Count - 1; i >= 0; i--){
            // TODO: Handle retain properties
            this.discardPile.AddCard(this.hand[i]);  // Add the card to the discard pile first.
            this.hand.RemoveAt(i);              // Then actually remove it from the hand.
        }
        return;
    }


    public void DebugListHand(){
        foreach(AbstractCard card in hand){
            Debug.Log(card.NAME + " " + card.TYPE[0] + " " + card.TEXT);
        }
    }

    public abstract void AddStarterDeck();
}

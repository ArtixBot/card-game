using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacter : MonoBehaviour
{
    public string NAME;     // Character name

    public int maxHP;
    public int curHP;
    public int drawModifier = 0;        // Default: At end of turn, draw 5 + <drawModifier>.

    public Deck battleDeck;        // The "permanent deck" of a character. At the start of combat, deep-copy the contents of this deck to drawPile, shuffle drawPile, then draw <X> cards from it.
    private Deck drawPile;
    private Deck discardPile;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}

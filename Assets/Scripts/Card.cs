using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Card {
    string cardName {get; set;}
    string cardId{get; set;}
    int cost{get; set;}
}
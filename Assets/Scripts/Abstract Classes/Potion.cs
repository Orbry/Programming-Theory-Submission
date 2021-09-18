using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : Item, IConsumable
{
    public float Magintude { get; private set; }
    public Player.Stats Stat { get; private set; }
    
    public abstract void Consume(Player player);
}

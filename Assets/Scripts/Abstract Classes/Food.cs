using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : Item, IConsumable
{
    public float Saturation { get; private set; }
    public float Restoration { get; private set; }

    public abstract void Consume(Player player);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gear : Item, IWearable
{
    public Player.Slots Slot { get; private set; }
}

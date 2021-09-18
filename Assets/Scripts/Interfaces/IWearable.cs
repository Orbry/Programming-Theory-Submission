using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWearable
{
    Player.Slots Slot { get; }
    Sprite Icon { get; }
}

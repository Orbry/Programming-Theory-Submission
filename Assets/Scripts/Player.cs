using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Slots { Weapon, Body, Head }
    public enum Stats { Health, Mana }

    private void Start()
    {
        // create item and supply it
    }
    
    public void UseItem(IConsumable item)
    {
        Debug.Log("Consuming item");
    }
    
    public void UseItem(IWearable item)
    {
        Debug.Log("Equipping item");
    }
}

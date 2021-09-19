using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    public enum Slots { Weapon, Body, Head }
    public enum Stats { Health, Mana }

    private void Awake()
    {
        Instance = this;
    }
    
    public void UseItem(IConsumable item)
    {
        // TODO: delete log
        Debug.Log($"Using consumable item - {((Item)item).ItemName}");
        item.Consume(this);
    }
    
    public void UseItem(IWearable item)
    {
        // TODO: delete log
        Debug.Log("Equipping item");
        EquipItem(item);
    }
    
    public void ChangeStat(Stats stat, float delta)
    {
        // TODO: implement
        Debug.Log($"Changing {stat} by {delta}");
    }
    
    public void EquipItem(IWearable item)
    {
        // TODO: implement
        Debug.Log($"Equipping item");
    }
}

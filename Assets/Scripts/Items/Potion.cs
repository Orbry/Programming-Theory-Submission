using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Potion : Item, IConsumable
{
    [SerializeField] protected float Magnitude;
    [SerializeField] protected Player.Stats Stat;
    
    public void Consume(Player player)
    {
        // TODO: delete log
        Debug.Log($"Drinking the {name}");
        player.ChangeStat(Stat, Magnitude);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        // TODO: delete log
        Debug.Log($"Item {name} clicked");
        if (Player.Instance != null)
        {
            Player.Instance.UseItem(this);
        }
    }
}

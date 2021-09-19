using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Gear : Item, IWearable
{
    public Player.Slots Slot { get; private set; }
    public Sprite Icon => m_ItemIcon;
    
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

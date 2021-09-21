using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// INHERITANCE
public class Gear : Item, IWearable
{
    [Header("Gear settings")]
    [SerializeField] private Player.Slots m_Slot;
    
    public Sprite Icon => m_ItemIcon;
    public Player.Slots Slot => m_Slot;
    
    // POLYMORPHISM
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        
        if (Player.Instance != null)
        {
            Player.Instance.UseItem(this);
        }
    }
}

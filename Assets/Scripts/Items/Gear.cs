using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gear : Item, IWearable
{
    [Header("Gear settings")]
    [SerializeField] private Player.Slots m_Slot;
    
    public Sprite Icon => m_ItemIcon;
    public Player.Slots Slot => m_Slot;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        
        if (Player.Instance != null)
        {
            Player.Instance.UseItem(this);
        }
    }
}

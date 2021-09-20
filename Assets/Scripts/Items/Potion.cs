using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Potion : Item, IConsumable
{
    [Header("Potion settings")]
    [SerializeField] private float m_Magnitude;
    [SerializeField] private Player.Stats m_Stat;
    
    public void Consume(Player player)
    {
        player.ChangeStat(m_Stat, m_Magnitude);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (Player.Instance != null)
        {
            Player.Instance.UseItem(this);
        }
    }
}

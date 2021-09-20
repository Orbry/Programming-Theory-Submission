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
        // TODO: delete log
        Debug.Log($"Drinking the {name}");
        player.ChangeStat(m_Stat, m_Magnitude);
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

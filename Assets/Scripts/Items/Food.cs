using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food : Item, IConsumable
{
    [Header("Food settings")]
    [SerializeField] private float m_Saturation;
    [SerializeField] private float m_Restoration;

    public void Consume(Player player)
    {
        player.ChangeNeed(Player.Needs.Hunger, m_Saturation);
        player.ChangeNeed(Player.Needs.Stamina, m_Restoration);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (Player.Instance != null)
        {
            Player.Instance.UseItem(this);
        }
    }
}

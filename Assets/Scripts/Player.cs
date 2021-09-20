using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Slots { Weapon, Body, Head }
    public enum Stats { Health, Mana }
    public enum Needs { Hunger, Stamina }
    
    public static Player Instance { get; private set; }

    private Dictionary<Stats, float> m_Stats = new Dictionary<Stats, float>();
    private Dictionary<Needs, float> m_Needs = new Dictionary<Needs, float>();
    
    // TODO: hook stats and needs with bars in UI
    // TODO: hook gear with slots in UI
    
    private void Awake()
    {
        Instance = this;
        
        m_Stats.Add(Stats.Health, 0.2f);
        m_Stats.Add(Stats.Mana, 0.3f);

        m_Needs.Add(Needs.Hunger, 0.15f);
        m_Needs.Add(Needs.Stamina, 0.4f);
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
    
    public void ChangeStat(Stats stat, float amount)
    {
        float delta = amount / 100;
        m_Stats[stat] = Mathf.Clamp(m_Stats[stat] + delta, 0.0f, 1.0f);
        // TODO: delete logs
        Debug.Log($"Changing {stat} by {amount}");
        Debug.Log($"New value is {m_Stats[stat]}");
    }
    
    public void ChangeNeed(Needs need, float amount)
    {
        float delta = amount / 100;
        m_Needs[need] = Mathf.Clamp(m_Needs[need] + delta, 0.0f, 1.0f);
        // TODO: delete logs
        Debug.Log($"Changing {need} by {amount}");
        Debug.Log($"New value is {m_Needs[need]}");
    }
    
    public void EquipItem(IWearable item)
    {
        // TODO: implement
        Debug.Log($"Equipping item {item.ItemName}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the current value of player stats and equipped gear
public class Player : MonoBehaviour
{
    public enum Slots { Weapon, Body, Head }
    public enum Stats { Health, Mana }
    public enum Needs { Hunger, Stamina }
    public static Player Instance { get; private set; }

    [SerializeField] private StatBar m_HealthBar;
    [SerializeField] private StatBar m_ManaBar;
    [SerializeField] private StatBar m_HungerBar;
    [SerializeField] private StatBar m_StaminaBar;

    private Dictionary<Stats, float> m_Stats = new Dictionary<Stats, float>();
    private Dictionary<Needs, float> m_Needs = new Dictionary<Needs, float>();
    
    // TODO: hook gear with slots in UI
    
    private void Awake()
    {
        Instance = this;
        
        m_Stats.Add(Stats.Health, 0.2f);
        m_Stats.Add(Stats.Mana, 0.3f);

        m_Needs.Add(Needs.Hunger, 0.15f);
        m_Needs.Add(Needs.Stamina, 0.4f);
    }

    private void Start()
    {
        m_HealthBar.Value = m_Stats[Stats.Health];
        m_ManaBar.Value = m_Stats[Stats.Mana];
        
        m_HungerBar.Value = m_Needs[Needs.Hunger];
        m_StaminaBar.Value = m_Needs[Needs.Stamina];
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

        StatBar bar = stat == Stats.Health ? m_HealthBar : m_ManaBar;
        bar.Value = m_Stats[stat];
    }
    
    public void ChangeNeed(Needs need, float amount)
    {
        float delta = amount / 100;
        m_Needs[need] = Mathf.Clamp(m_Needs[need] + delta, 0.0f, 1.0f);

        StatBar bar = need == Needs.Hunger ? m_HungerBar : m_StaminaBar;
        bar.Value = m_Needs[need];
    }
    
    public void EquipItem(IWearable item)
    {
        // TODO: implement
        Debug.Log($"Equipping item {item.ItemName}");
    }
}

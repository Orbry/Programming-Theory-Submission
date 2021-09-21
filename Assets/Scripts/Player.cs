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

    [Header("UI Bars")]
    [SerializeField] private StatBar m_HealthBar;
    [SerializeField] private StatBar m_ManaBar;
    [SerializeField] private StatBar m_HungerBar;
    [SerializeField] private StatBar m_StaminaBar;

    [Header("UI Inventory")]
    [SerializeField] private InventorySlot m_WeaponSlot;
    [SerializeField] private InventorySlot m_ArmorSlot;
    [SerializeField] private InventorySlot m_HelmetSlot;

    private Dictionary<Stats, float> m_Stats = new Dictionary<Stats, float>();
    private Dictionary<Needs, float> m_Needs = new Dictionary<Needs, float>();
    
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

    // POLYMORPHISM
    public void UseItem(IConsumable item)
    {
        item.Consume(this);
    }
    
    public void UseItem(IWearable item)
    {
        // ABSTRACTION
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
        InventorySlot slot = null;
        switch (item.Slot)
        {
            case Slots.Weapon:
                slot = m_WeaponSlot;
                break;
            case Slots.Body:
                slot = m_ArmorSlot;
                break;
            case Slots.Head:
                slot = m_HelmetSlot;
                break;
        }
        
        if (slot != null)
        {
            slot.SetIcon(item.Icon);
        }
    }
}

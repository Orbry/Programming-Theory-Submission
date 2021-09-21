using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Simulates UI bars with non-interactable horizontal scrollbars
public class StatBar : MonoBehaviour
{
    [SerializeField] private Scrollbar m_Scrollbar;
    [SerializeField] private Image m_HandleImage;
    [SerializeField] private Color m_BarColor;

    // ENCAPSULATION
    private float m_Value = 0.2f;
    public float Value
    {
        set {
            m_Value = Mathf.Clamp(value, 0.0f, 1.0f);
            m_Scrollbar.size = m_Value;
        }
    }

    void Start()
    {
        m_Scrollbar.interactable = false;
        m_Scrollbar.size = m_Value;

        if (m_BarColor != null)
        {
            m_HandleImage.color = m_BarColor;
        }
    }
}

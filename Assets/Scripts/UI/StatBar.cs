using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* A class that simulates UI bars with non-interactable horizontal scrollbars
 */
public class StatBar : MonoBehaviour
{
    [SerializeField] private Scrollbar m_Scrollbar;
    [SerializeField] private Image m_HandleImage;
    [SerializeField] private Color m_BarColor;

    void Start()
    {
        m_Scrollbar.interactable = false;
        m_Scrollbar.size = Random.Range(0f, 1f);

        if (m_BarColor != null)
        {
            m_HandleImage.color = m_BarColor;
        }
    }
}

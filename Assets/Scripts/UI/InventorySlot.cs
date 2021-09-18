using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Sprite m_DefaultSprite;
    [SerializeField] private string m_DefaultName;

    [SerializeField] private TMP_Text m_TextNode;
    [SerializeField] private Image m_ImageNode;

    private void Start()
    {
        // making image transparent first in case there is no icon set
        m_ImageNode.color = Color.clear;
        
        if (m_DefaultSprite != null)
        {
            m_ImageNode.sprite = m_DefaultSprite;
            m_ImageNode.color = Color.white;
        }

        m_TextNode.text = m_DefaultName;
    }
}

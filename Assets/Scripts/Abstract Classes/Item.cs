using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class Item : MonoBehaviour, IPointerClickHandler
{
    [Header("Item settings")]
    [SerializeField] protected string m_ItemName;
    [SerializeField] protected Sprite m_ItemIcon;
    [SerializeField] protected SpriteRenderer m_SpriteRenderer;

    public string ItemName => m_ItemName;

    protected virtual void Awake()
    {
        if (m_SpriteRenderer != null && m_ItemIcon != null)
        {
            m_SpriteRenderer.sprite = m_ItemIcon;
        }
    }

    # if UNITY_EDITOR
    // Updating sprite in Scene View while not in Play Mode
    // Using delegate as changing sprite in OnValidate throws a warning
    private void OnValidate() { UnityEditor.EditorApplication.delayCall += _OnValidate; }
    private void _OnValidate()
    {
        if (m_SpriteRenderer != null && m_ItemIcon != null)
        {
            m_SpriteRenderer.sprite = m_ItemIcon;
        }
    }
    #endif

    public abstract void OnPointerClick(PointerEventData eventData);
}

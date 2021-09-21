using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class Item : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected static AudioSource m_AudioSource;
    
    [Header("Item settings")]
    [SerializeField] protected string m_ItemName;
    [SerializeField] protected Sprite m_ItemIcon;
    [SerializeField] protected AudioClip m_ItemsSFX;
    [SerializeField] protected SpriteRenderer m_SpriteRenderer;
    [SerializeField] private Material m_OnHoverMaterial;
    [SerializeField] private Material m_DefaultMaterial;

    public string ItemName => m_ItemName;

    protected virtual void Awake()
    {
        if (m_SpriteRenderer != null && m_ItemIcon != null)
        {
            m_SpriteRenderer.sprite = m_ItemIcon;
        }

        m_AudioSource = Camera.main.GetComponent<AudioSource>();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        m_AudioSource.PlayOneShot(m_ItemsSFX);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_SpriteRenderer.material = m_OnHoverMaterial;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        m_SpriteRenderer.material = m_DefaultMaterial;
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
}

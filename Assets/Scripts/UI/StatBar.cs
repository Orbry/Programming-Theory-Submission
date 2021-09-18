using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* A class that simulates UI bars with non-interactable horizontal scrollbars
 */
public class StatBar : MonoBehaviour
{
    private Scrollbar m_Scrollbar;
    private GameObject m_Handle;

    public Color color;

    private void Awake()
    {
        m_Scrollbar = GetComponent<Scrollbar>();
        m_Handle = gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Scrollbar.interactable = false;
        m_Scrollbar.size = Random.Range(0f, 1f);

        m_Handle.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

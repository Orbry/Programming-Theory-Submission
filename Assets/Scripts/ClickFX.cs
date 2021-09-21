using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_Particle;
    [SerializeField] private AudioClip m_ClickSound;

    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = Camera.main.GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;
            
            ParticleSystem fx = GameObject.Instantiate(m_Particle);
            fx.gameObject.transform.position = clickPosition;

            m_AudioSource.PlayOneShot(m_ClickSound, 0.1f);
        }
    }
}

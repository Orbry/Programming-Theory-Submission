using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;
            
            ParticleSystem fx = GameObject.Instantiate(particle);
            fx.gameObject.transform.position = clickPosition;
        }
    }
}

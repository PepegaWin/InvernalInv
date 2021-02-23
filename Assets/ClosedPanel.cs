using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedPanel : MonoBehaviour
{
    [SerializeField] GameObject panelStart;
    private AudioSource audioSource;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (panelStart.activeSelf)
        {
            audioSource.playOnAwake = true;
        }
    }
}

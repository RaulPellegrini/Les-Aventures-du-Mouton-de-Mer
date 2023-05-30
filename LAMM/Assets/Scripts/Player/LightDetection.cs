using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightDetection : MonoBehaviour
{
    PlayerController playerController;
    public bool isDark = false;
    private Light lightIsOn;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        lightIsOn = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        if (isDark)
        {
            
        }
    }

}

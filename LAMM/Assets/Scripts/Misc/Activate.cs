using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Activate : MonoBehaviour
{
    private Animator animator;
    [SerializeField] bool lightOn = true;
    [SerializeField] int lightIntensity = 4;
    readonly int ACTIVATE_HASH = Animator.StringToHash("Activate");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger(ACTIVATE_HASH);

        if (lightOn)
        {
            transform.GetChild(0).GetComponentInChildren<Light2D>().intensity = lightIntensity;
        }
    }



}

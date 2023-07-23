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
    
    public bool pulled = false;

    //lever system
    /*
    [SerializeField] bool leverN0;
    [SerializeField] bool leverN1;
    [SerializeField] bool leverN2;
    [SerializeField] bool leverN3;

    private bool lever0 = false;
    private bool lever1 = false;
    private bool lever2 = false;
    private bool lever3 = false;
    */

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //IsActive();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<PlayerController>()|| other.gameObject.GetComponent<Projectile>())
        {
            animator.SetTrigger(ACTIVATE_HASH);
            pulled = true;

            if (lightOn)
            {
                transform.GetChild(0).GetComponentInChildren<Light2D>().intensity = lightIntensity;
            }
            /*
            if (leverN0) { lever0 = true; }
            if (leverN1) { lever1 = true; }
            if (leverN2) { lever2 = true; }
            if (leverN3) { lever3 = true; }
            */

        }

    }

}

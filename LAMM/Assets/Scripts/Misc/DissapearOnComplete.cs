using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearOnComplete : MonoBehaviour
{
    private static bool leversDone = false;
    [SerializeField] GameObject lever1;
    [SerializeField] GameObject lever2;
    [SerializeField] GameObject lever3;
    [SerializeField] GameObject lever4;

    private Activate leverPulled1;
    private Activate leverPulled2;
    private Activate leverPulled3;
    private Activate leverPulled4;


    private void Awake()
    {
        leverPulled1 = lever1.GetComponent<Activate>();
        leverPulled2 = lever2.GetComponent<Activate>();
        leverPulled3 = lever3.GetComponent<Activate>();
        leverPulled4 = lever4.GetComponent<Activate>();
    }

    private void Update()
    {
        if (leverPulled1.pulled && leverPulled2.pulled && leverPulled3.pulled && leverPulled4.pulled)
        {
            leversDone = true;

        }
        
        if (leversDone)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        
    }


}

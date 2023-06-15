using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearOnComplete : MonoBehaviour
{
    Activate activate;

    private void Awake()
    {
        activate = GetComponentInChildren<Activate>();
    }

    private void Update()
    {
        if (activate.active)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{

    [SerializeField] GameObject signMessage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<PlayerController>())
        {
            signMessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.transform.GetComponent<PlayerController>())
        {
            signMessage.SetActive(false);
        }

    }

}

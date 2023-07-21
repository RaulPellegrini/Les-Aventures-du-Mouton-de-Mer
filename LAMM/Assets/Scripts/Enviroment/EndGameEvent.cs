using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameEvent : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.GetComponent<PlayerController>())
        {

        }
    }
}

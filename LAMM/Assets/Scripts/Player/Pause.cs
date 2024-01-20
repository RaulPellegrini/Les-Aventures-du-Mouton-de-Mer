using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{

    [SerializeField] GameObject signMessage;



    private void OnMouseDown()
    {
        signMessage.SetActive(true);

    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<PlayerController>())
        {
            signMessage.SetActive(true);

        }
    }
    */
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.transform.GetComponent<PlayerController>())
        {
            signMessage.SetActive(false);
        }

    }

    //How to press a button in Unity?
    //Instantiate Canvas

    //Pause the Game

    //Change Message from Start to Continue

    //Game Start/Continue

    //I'm Stuck! Help!

}

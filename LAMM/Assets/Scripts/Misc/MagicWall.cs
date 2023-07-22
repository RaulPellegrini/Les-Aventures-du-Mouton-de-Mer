using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicWall : MonoBehaviour
{
    [SerializeField] GameObject walls;

    private bool wallDone = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !wallDone)
        {
            walls.SetActive(true);
            wallDone = true;
        }
    }

    public void WallsOff()
    {

        walls.SetActive(false);
    }
}
